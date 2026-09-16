namespace SistemaNomina.Models;

public class EmpleadoPorHoras : Empleado
{
    public decimal SueldoPorHora { get; set; }
    public decimal HorasTrabajadas { get; set; }

    public override decimal CalcularPago()
    {
        if (HorasTrabajadas <= 40)
            return SueldoPorHora * HorasTrabajadas;

        return (SueldoPorHora * 40) + (SueldoPorHora * 1.5m * (HorasTrabajadas - 40));
    }
}