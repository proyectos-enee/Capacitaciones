namespace Capacitaciones.Api.Capacitacion.VisualizarCapacitacionesDisponibles;

public class CapacitacionDisponibleResponse
{
    public Guid Id { get; set; }
    public string NombreLargo { get; set; }
    public string Modalidad { get; set; }
    public DateTime FechaInicioRegistro { get; set; }
    public DateTime FechaFinRegistro { get; set; }
    public string Estado { get; set; }
}
