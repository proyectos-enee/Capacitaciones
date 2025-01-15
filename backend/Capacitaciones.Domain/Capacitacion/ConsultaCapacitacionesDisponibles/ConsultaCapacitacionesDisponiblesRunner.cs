using Ardalis.Specification;
using Enee.Core.CQRS.Query;
using Enee.Core.Domain;
using Enee.Core.Domain.Repository;
using Enee.Core.Domain.Specs;
using Capacitaciones.Domain.Capacitacion.Projections.Capacitacion;

namespace Capacitaciones.Domain.Capacitacion.ConsultaCapacitacionesDisponibles;

public class ConsultaCapacitacionesDisponiblesRunner : IQueryRunner<ConsultaCapacitacionesDisponibles, IPaginated<CapacitacionDocumento>>
{
    public IReadOnlyDocumentRepository<CapacitacionDocumento> Repository { get; }

    public ConsultaCapacitacionesDisponiblesRunner(IReadOnlyDocumentRepository<CapacitacionDocumento> repository)
    {
        Repository = repository;
    }

    public async Task<IPaginated<CapacitacionDocumento>> Run(ConsultaCapacitacionesDisponibles query)
    {
        var spec = new SpecificationGeneric<CapacitacionDocumento>();

        // Aplicar filtros condicionalmente
        if (!string.IsNullOrWhiteSpace(query.Modalidad))
        {
            spec.Query.Where(x => x.Modalidad.Contains(query.Modalidad));
        }

        if (!string.IsNullOrWhiteSpace(query.NombreCorto))
        {
            spec.Query.Where(x => x.NombreCorto.Contains(query.NombreCorto));
        }

        if (query.FechaInicioRegistro.HasValue)
        {
            spec.Query.Where(x => x.FechaInicioRegistro >= query.FechaInicioRegistro.Value);
        }

        if (query.FechaFinRegistro.HasValue)
        {
            spec.Query.Where(x => x.FechaFinRegistro <= query.FechaFinRegistro.Value);
        }

        // Ordenar resultados
        spec.Query.OrderBy(x => x.FechaInicioRegistro);

        // Paginar resultados
        var paginated = await Repository.Paginate(query.Page, query.PageSize, spec);
        return paginated;
    }
}

