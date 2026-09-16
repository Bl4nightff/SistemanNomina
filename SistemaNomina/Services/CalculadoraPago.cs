using SistemaNomina.Models;

namespace SistemaNomina.Services;

public class CalculadoraPago
{
    public decimal Calcular(Empleado empleado)
    {
        return empleado.CalcularPago();
    }
}