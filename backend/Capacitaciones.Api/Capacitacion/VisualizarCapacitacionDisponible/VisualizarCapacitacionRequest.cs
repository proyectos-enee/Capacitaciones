namespace Capacitaciones.Api.Capacitacion.VisualizarCapacitacionDisponible;

public class VisualizarCapacitacionRequest
{
    public string? Nombre { get; set; }
    public string? Modalidad { get; set; }
    public DateTime? FechaInicio { get; set; }
    public DateTime? FechaFin { get; set; }
}
