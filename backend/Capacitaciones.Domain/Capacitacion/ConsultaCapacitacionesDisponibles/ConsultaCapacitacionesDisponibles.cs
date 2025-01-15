using Enee.Core.CQRS.Query;
using Enee.Core.Domain;
using Capacitaciones.Domain.Capacitacion.Projections.Capacitacion;

namespace Capacitaciones.Domain.Capacitacion.ConsultaCapacitacionesDisponibles;

public class ConsultaCapacitacionesDisponibles:IQuery<IPaginated<CapacitacionDocumento>>, IPaginatedParams
{
    public string Description { get; } = "Consulta de capacitaciones en forma paginada";

    public string? NombreCorto { get; set; }
    public string? Modalidad { get; set; }
    public DateTime? FechaInicioRegistro { get; set; }
    public DateTime? FechaFinRegistro { get; set; }
    public int? PageSize { get; set; }
    public int? Page { get; set; }
}
