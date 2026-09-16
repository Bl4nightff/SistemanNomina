namespace SistemaNomina.Models;

public class EmpleadoAsalariado : Empleado
{
    public decimal SalarioSemanal { get; set; }

    public override decimal CalcularPago()
    {
        return SalarioSemanal;
    }
}