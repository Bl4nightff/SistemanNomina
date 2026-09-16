using SistemaNomina.Data;
using SistemaNomina.Models;
using SistemaNomina.Services;

var repositorio = new EmpleadoRepository();
var calculadora = new CalculadoraPago();
var reporteService = new ReporteService();

while (true)
{
    Console.WriteLine("===== SISTEMA DE NOMINA =====");
    Console.WriteLine("1. Agregar empleado");
    Console.WriteLine("2. Mostrar reporte semanal");
    Console.WriteLine("3. Actualizar empleado");
    Console.WriteLine("4. Salir");
    Console.Write("Opcion: ");

    string opcion = Console.ReadLine() ?? "";

    switch (opcion)
    {
        case "1":
            AgregarEmpleado(repositorio);
            break;
        case "2":
            reporteService.GenerarReporte(repositorio.ObtenerTodos());
            break;
        case "3":
            ActualizarEmpleado(repositorio, calculadora);
            break;
        case "4":
            return;
        default:
            Console.WriteLine("Opcion invalida.\n");
            break;
    }
}

static void AgregarEmpleado(EmpleadoRepository repositorio)
{
    Console.WriteLine("\n--- Tipo de empleado ---");
    Console.WriteLine("1. Asalariado");
    Console.WriteLine("2. Por horas");
    Console.WriteLine("3. Por comision");
    Console.WriteLine("4. Asalariado por comision");
    Console.Write("Opcion: ");
    string tipo = Console.ReadLine() ?? "";

    Empleado empleado = tipo switch
    {
        "1" => CrearAsalariado(),
        "2" => CrearPorHoras(),
        "3" => CrearPorComision(),
        "4" => CrearAsalariadoPorComision(),
        _ => throw new Exception("Tipo invalido")
    };

    repositorio.Agregar(empleado);
    Console.WriteLine("Empleado agregado.\n");
}

static Empleado CrearAsalariado()
{
    var e = new EmpleadoAsalariado();
    CompletarDatosBase(e);
    Console.Write("Salario semanal: ");
    e.SalarioSemanal = decimal.Parse(Console.ReadLine() ?? "0");
    return e;
}

static Empleado CrearPorHoras()
{
    var e = new EmpleadoPorHoras();
    CompletarDatosBase(e);
    Console.Write("Sueldo por hora: ");
    e.SueldoPorHora = decimal.Parse(Console.ReadLine() ?? "0");
    Console.Write("Horas trabajadas: ");
    e.HorasTrabajadas = decimal.Parse(Console.ReadLine() ?? "0");
    return e;
}

static Empleado CrearPorComision()
{
    var e = new EmpleadoPorComision();
    CompletarDatosBase(e);
    Console.Write("Ventas brutas: ");
    e.VentasBrutas = decimal.Parse(Console.ReadLine() ?? "0");
    Console.Write("Tarifa de comision (ej. 0.10): ");
    e.TarifaComision = decimal.Parse(Console.ReadLine() ?? "0");
    return e;
}

static Empleado CrearAsalariadoPorComision()
{
    var e = new EmpleadoAsalariadoPorComision();
    CompletarDatosBase(e);
    Console.Write("Ventas brutas: ");
    e.VentasBrutas = decimal.Parse(Console.ReadLine() ?? "0");
    Console.Write("Tarifa de comision (ej. 0.10): ");
    e.TarifaComision = decimal.Parse(Console.ReadLine() ?? "0");
    Console.Write("Salario base: ");
    e.SalarioBase = decimal.Parse(Console.ReadLine() ?? "0");
    return e;
}

static void CompletarDatosBase(Empleado e)
{
    Console.Write("Primer nombre: ");
    e.PrimerNombre = Console.ReadLine() ?? "";
    Console.Write("Apellido paterno: ");
    e.ApellidoPaterno = Console.ReadLine() ?? "";
    Console.Write("Numero de seguro social: ");
    e.NumeroSeguroSocial = Console.ReadLine() ?? "";
}

static void ActualizarEmpleado(EmpleadoRepository repositorio, CalculadoraPago calculadora)
{
    Console.Write("NSS del empleado a buscar: ");
    string nss = Console.ReadLine() ?? "";

    var empleado = repositorio.BuscarPorNSS(nss);
    if (empleado == null)
    {
        Console.WriteLine("Empleado no encontrado.\n");
        return;
    }

    Console.WriteLine($"Encontrado: {empleado}");

    switch (empleado)
    {
        case EmpleadoAsalariado e:
            Console.Write("Nuevo salario semanal: ");
            e.SalarioSemanal = decimal.Parse(Console.ReadLine() ?? "0");
            break;
        case EmpleadoPorHoras e:
            Console.Write("Nuevo sueldo por hora: ");
            e.SueldoPorHora = decimal.Parse(Console.ReadLine() ?? "0");
            Console.Write("Nuevas horas trabajadas: ");
            e.HorasTrabajadas = decimal.Parse(Console.ReadLine() ?? "0");
            break;
        case EmpleadoPorComision e:
            Console.Write("Nuevas ventas brutas: ");
            e.VentasBrutas = decimal.Parse(Console.ReadLine() ?? "0");
            break;
        case EmpleadoAsalariadoPorComision e:
            Console.Write("Nuevas ventas brutas: ");
            e.VentasBrutas = decimal.Parse(Console.ReadLine() ?? "0");
            Console.Write("Nuevo salario base: ");
            e.SalarioBase = decimal.Parse(Console.ReadLine() ?? "0");
            break;
    }

    Console.WriteLine($"Pago recalculado: ${calculadora.Calcular(empleado):N2}\n");
}