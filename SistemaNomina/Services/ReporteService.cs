using SistemaNomina.Models;

namespace SistemaNomina.Services;

public class ReporteService
{
    public void GenerarReporte(List<Empleado> empleados)
    {
        Console.WriteLine("\n===== REPORTE SEMANAL DE PAGOS =====\n");

        decimal total = 0;

        foreach (var empleado in empleados)
        {
            decimal pago = empleado.CalcularPago();
            total += pago;

            Console.WriteLine($"{empleado}");
            Console.WriteLine($"Tipo: {empleado.GetType().Name}");
            Console.WriteLine($"Pago semanal: ${pago:N2}");
            Console.WriteLine("----------------------------------");
        }

        Console.WriteLine($"TOTAL A PAGAR: ${total:N2}\n");
    }
}