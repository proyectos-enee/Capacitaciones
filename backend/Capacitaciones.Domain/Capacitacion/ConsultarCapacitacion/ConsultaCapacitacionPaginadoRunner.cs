using Ardalis.Specification;
using Enee.Core.CQRS.Query;
using Enee.Core.Domain;
using Enee.Core.Domain.Repository;
using Enee.Core.Domain.Specs;
using Capacitaciones.Domain.Capacitacion.Projections.Capacitacion;

namespace Capacitaciones.Domain.Capacitacion.ConsultarCapacitacion;

public class ConsultaCapacitacionPaginadoRunner:IQueryRunner<ConsultaCapacitacionPaginado,IPaginated<CapacitacionDocumento>>
{
    public IReadOnlyDocumentRepository<CapacitacionDocumento> Repository { get; }

    public ConsultaCapacitacionPaginadoRunner(IReadOnlyDocumentRepository<CapacitacionDocumento> repository)
    {
        Repository = repository;
    }
    public async Task<IPaginated<CapacitacionDocumento>> Run(ConsultaCapacitacionPaginado query)
    {
        var spec = new SpecificationGeneric<CapacitacionDocumento>();
        spec.Query.Where(x => x.CodigoCapacitacion.Contains(query.CodigoCapacitacion),
            !string.IsNullOrWhiteSpace(query.NombreCapacitacion));
        spec.Query.OrderBy(x => x.CodigoCapacitacion);
        var paginated = await Repository.Paginate(query.Page, query.PageSize, spec);
        return paginated;

    }
}
