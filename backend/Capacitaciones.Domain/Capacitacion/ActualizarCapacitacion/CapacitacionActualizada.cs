using Enee.Core.Common;

namespace Capacitaciones.Domain.Capacitacion.ActualizarCapacitacion;

public class CapacitacionActualizada : DomainEvent<Guid>
{

    public string NombreCorto { get; }
    public string NombreLargo { get; }
    public string? Descripcion { get; }
    public string EnteCapacitador { get; }
    public string Modalidad { get; }
    public string? Lugar { get; }
    public string? Horario { get; }
    public DateTime FechaInicioRegistro { get; }
    public DateTime FechaFinRegistro { get; }
    public string Estado { get; }

    // Constructor con todos los parámetros necesarios para la actualización
    public CapacitacionActualizada(
        Guid aggregateId,
        string nombreCorto,
        string nombreLargo,
        string? descripcion,
        string enteCapacitador,
        string modalidad,
        string? lugar,
        string? horario,
        DateTime fechaInicioRegistro,
        DateTime fechaFinRegistro,
        string estado
    ) : base(aggregateId)
    {

        NombreCorto = nombreCorto;
        NombreLargo = nombreLargo;
        Descripcion = descripcion;
        EnteCapacitador = enteCapacitador;
        Modalidad = modalidad;
        Lugar = lugar;
        Horario = horario;
        FechaInicioRegistro = fechaInicioRegistro;
        FechaFinRegistro = fechaFinRegistro;
        Estado = estado;
    }
}
