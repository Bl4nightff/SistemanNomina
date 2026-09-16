namespace SistemaNomina.Models;

public class EmpleadoAsalariadoPorComision : Empleado
{
    public decimal VentasBrutas { get; set; }
    public decimal TarifaComision { get; set; }
    public decimal SalarioBase { get; set; }
    private const decimal PorcentajeBono = 0.10m; // 10% sobre el salario base

    public override decimal CalcularPago()
    {
        return (VentasBrutas * TarifaComision) + SalarioBase + (SalarioBase * PorcentajeBono);
    }
}