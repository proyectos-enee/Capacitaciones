namespace Capacitaciones.Api.Controllers;

public class CapacitacionRequest
{
    public required string CodigoCapacitacion { get; set; }
    public required string NombreCorto { get; set; }
    public required string NombreLargo { get; set; }
    public string? Descripcion { get; set; }
    public required string EnteCapacitador { get; set; }
    public required string Modalidad { get; set; }
    public string? Lugar { get; set; }
    public string? Horario { get; set; }
    public required DateTime FechaInicioRegistro { get; set; }
    public required DateTime FechaFinRegistro { get; set; }
    public required string Estado { get; set; }
}
