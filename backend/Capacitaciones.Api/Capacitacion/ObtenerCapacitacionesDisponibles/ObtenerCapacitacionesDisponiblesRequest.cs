namespace Capacitaciones.Api.Capacitacion.ObtenerCapacitacionesDisponibles;

public class ObtenerCapacitacionesDisponiblesRequest
{
    public string? Modalidad { get; set; }
    public string? Nombre { get; set; }
    public DateTime? FechaInicio { get; set; }
    public DateTime? FechaFin { get; set; }
}
