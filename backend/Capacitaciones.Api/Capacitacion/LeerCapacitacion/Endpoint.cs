using Enee.Core.CQRS.Query;
using Enee.Core.Domain;
using Capacitaciones.Domain.Capacitacion.ConsultarCapacitacion;
using Capacitaciones.Domain.Capacitacion.Projections.Capacitacion;

namespace Capacitaciones.Api.Capacitacion.LeerCapacitacion;

public static class Endpoint
{
    public static void LeerCapacitacion(this IEndpointRouteBuilder app)
    {
        app.MapGet(
            "/",
            async (
                [AsParameters] ConsultaCapacitacionPaginado query,
                IQueryDispatcher dispatcher
            ) =>
            {
                var result = await dispatcher.Execute(query);
                return result;
            }).Produces<IPaginated<CapacitacionDocumento>>()
            .WithSummary("Obtiene listado de capacitaciones")
            .WithDescription("Listar varias capacitaciones.")
            .WithOpenApi();
    }
}
