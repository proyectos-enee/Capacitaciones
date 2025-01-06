using Capacitaciones.Api.Utils;
using Enee.Core.CQRS.Query;
using Capacitaciones.Domain.Capacitacion.VisualizarCapacitacionDisponible;

namespace Capacitaciones.Api.Capacitacion.VisualizarCapacitacionDisponible;

public static class Endpoint
{
    public static void VisualizarCapacitacion(this IEndpointRouteBuilder app)
    {
        app.MapGet("/", async (VisualizarCapacitacionRequest request, IDispatcher dispatcher) =>
            {
                var result = await dispatcher.Dispatch(new VisualizarCapacitacionQuery(
                    request.Nombre,
                    request.Modalidad,
                    request.FechaInicio,
                    request.FechaFin
                ));
                return result.ToResponse();
            })
            .Produces<IEnumerable<VisualizarCapacitacionResponse>>()
            .WithSummary("Visualizar capacitaciones disponibles")
            .WithDescription("Permite listar capacitaciones disponibles según filtros aplicados")
            .WithOpenApi();
    }
}
