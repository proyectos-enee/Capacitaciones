namespace Capacitaciones.Domain.Capacitacion.VisualizarCapacitacionDisponible;

public class CapacitacionDisponibleResponse
{
    public Guid Id { get; set; }
    public string CodigoCapacitacion { get; set; }
    public string NombreCorto { get; set; }
    public string Modalidad { get; set; }
    public DateTime FechaInicioRegistro { get; set; }
    public DateTime FechaFinRegistro { get; set; }
    public string Estado { get; set; }
}
