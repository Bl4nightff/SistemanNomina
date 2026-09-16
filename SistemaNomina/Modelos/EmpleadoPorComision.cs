namespace SistemaNomina.Models;

public class EmpleadoPorComision : Empleado
{
    public decimal VentasBrutas { get; set; }
    public decimal TarifaComision { get; set; }

    public override decimal CalcularPago()
    {
        return VentasBrutas * TarifaComision;
    }
}