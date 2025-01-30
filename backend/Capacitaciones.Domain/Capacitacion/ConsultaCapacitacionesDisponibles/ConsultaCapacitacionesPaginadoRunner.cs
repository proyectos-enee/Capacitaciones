using Ardalis.Specification;
using Enee.Core.CQRS.Query;
using Enee.Core.Domain.Repository;
using Enee.Core.Domain;
using Capacitaciones.Domain.Capacitacion.Projections.Capacitacion;
using Enee.Core.Domain.Specs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Capacitaciones.Domain.Capacitacion.ConsultaCapacitacionesDisponibles
{
    public class ConsultaCapacitacionesPaginadoRunner : IQueryRunner<ConsultaCapacitacionesPaginado, IPaginated<CapacitacionDocumento>>
    {
        public IReadOnlyDocumentRepository<CapacitacionDocumento> Repository { get; }

        public ConsultaCapacitacionesPaginadoRunner(IReadOnlyDocumentRepository<CapacitacionDocumento> repository)
        {
            Repository = repository;
        }

        public async Task<IPaginated<CapacitacionDocumento>> Run(ConsultaCapacitacionesPaginado query)
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

            // Validación, estado disponible
            spec.Query.Where(x => x.Estado == "disponible");

            // Ordenar resultados
            spec.Query.OrderBy(x => x.FechaInicioRegistro);

            // Obtener todos los resultados que coincidan con los criterios
            var paginated = await Repository.Paginate(query.Page, query.PageSize,spec);
            return paginated;
        }
    }
}
