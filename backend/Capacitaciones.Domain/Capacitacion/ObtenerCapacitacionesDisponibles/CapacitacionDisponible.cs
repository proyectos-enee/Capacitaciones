namespace Capacitaciones.Domain.Capacitacion.ObtenerCapacitacionesDisponibles;

public class CapacitacionDisponible
{
    public Guid Id { get; set; }
    public string NombreLargo { get; set; }
    public string Modalidad { get; set; }
    public DateTime FechaInicioRegistro { get; set; }
    public DateTime FechaFinRegistro { get; set; }
    public string Estado { get; set; }
}
