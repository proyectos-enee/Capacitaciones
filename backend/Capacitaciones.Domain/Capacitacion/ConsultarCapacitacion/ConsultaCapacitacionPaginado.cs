using Enee.Core.CQRS.Query;
using Enee.Core.Domain;
using Capacitaciones.Domain.Capacitacion.Projections.Capacitacion;

namespace Capacitaciones.Domain.Capacitacion.ConsultarCapacitacion;

public class ConsultaCapacitacionPaginado:IQuery<IPaginated<CapacitacionDocumento>>, IPaginatedParams
{
    public string Description { get; } = "Consulta de capacitaciones en forma paginada";

    public string? CodigoCapacitacion { get; set; }
    public string? NombreCorto { get; set; }
    public int? PageSize { get; set; }
    public int? Page { get; set; }
}
