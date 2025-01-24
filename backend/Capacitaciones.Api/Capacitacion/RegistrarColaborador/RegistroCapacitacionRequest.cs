namespace Capacitaciones.Api.Capacitacion.RegistrarColaborador;

public class RegistroCapacitacionRequest
{
    public string ClaveEmpleado { get; set; }
    public Guid IdCapacitacion { get; set; }
    public string? Nombre { get; set; }
    public string? Cargo { get; set; }
    public string? Dependencia { get; set; }
    public string? CorreoElectronico { get; set; }
}
