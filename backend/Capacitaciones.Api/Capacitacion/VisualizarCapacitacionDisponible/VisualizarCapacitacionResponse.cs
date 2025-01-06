namespace Capacitaciones.Api.Capacitacion.VisualizarCapacitacionDisponible;

public class VisualizarCapacitacionResponse
{
    public Guid Id { get; set; }
    public string NombreCorto { get; set; }
    public string Modalidad { get; set; }
    public DateTime FechaInicioRegistro { get; set; }
    public DateTime FechaFinRegistro { get; set; }
    public string Estado { get; set; }
}
