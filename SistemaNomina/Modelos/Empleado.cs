namespace SistemaNomina.Models;

public abstract class Empleado
{
    public string PrimerNombre { get; set; } = "";
    public string ApellidoPaterno { get; set; } = "";
    public string NumeroSeguroSocial { get; set; } = "";

    public abstract decimal CalcularPago();

    public override string ToString()
    {
        return $"{PrimerNombre} {ApellidoPaterno} (NSS: {NumeroSeguroSocial})";
    }
}