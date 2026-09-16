using SistemaNomina.Models;

namespace SistemaNomina.Data;

public class EmpleadoRepository
{
    private readonly List<Empleado> _empleados = new();

    public void Agregar(Empleado empleado) => _empleados.Add(empleado);

    public List<Empleado> ObtenerTodos() => _empleados;

    public Empleado? BuscarPorNSS(string nss)
    {
        return _empleados.Find(e => e.NumeroSeguroSocial == nss);
    }
}