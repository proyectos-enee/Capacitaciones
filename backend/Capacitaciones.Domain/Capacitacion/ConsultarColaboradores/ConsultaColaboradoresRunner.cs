using Ardalis.Specification;
using Enee.Core.CQRS.Query;
using Enee.Core.Domain.Specs;
using Enee.Core.Domain.Repository;
using Capacitaciones.Domain.Capacitacion.Projections.Colaboradores;

namespace Capacitaciones.Domain.Capacitacion.ConsultarColaboradores;

public class ConsultaColaboradoresRunner : IQueryRunner<ConsultaColaboradores, IEnumerable<ColaboradoresDocumento>>
{
    public IReadOnlyDocumentRepository<ColaboradoresDocumento> Repository { get; }

    public ConsultaColaboradoresRunner(IReadOnlyDocumentRepository<ColaboradoresDocumento> repository)
    {
        Repository = repository;
    }

    public async Task<IEnumerable<ColaboradoresDocumento>> Run(ConsultaColaboradores query)
    {
        var spec = new SpecificationGeneric<ColaboradoresDocumento>();
        spec.Query
            .Where(x => x.ClaveEmpleado.Contains(query.ClaveEmpleado)) // Only filter by ClaveEmpleado
            .OrderBy(x => x.ClaveEmpleado);

        var result = await Repository.List(spec);
        return result;
    }
}
