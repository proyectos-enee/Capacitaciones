using Capacitaciones.Api.Utils;
using Enee.Core.CQRS.Command;
using Capacitaciones.Domain.Capacitacion.ObtenerCapacitacionesDisponibles;


namespace Capacitaciones.Api.Capacitacion.ObtenerCapacitacionesDisponibles;

public static class Endpoint
{
    public static void ObtenerCapacitacionesDisponibles(this IEndpointRouteBuilder app)
    {
        app.MapPost("/disponibles", async (ObtenerCapacitacionesDisponiblesRequest request, IDispatcher dispatcher) =>
            {
                var result = await dispatcher.Dispatch(new ObtenerCapacitacionesDisponiblesCommand(
                    Modalidad: request.Modalidad,
                    Nombre: request.Nombre,
                    FechaInicio: request.FechaInicio,
                    FechaFin: request.FechaFin
                ));

                return result.ToResponse<CapacitacionDisponibleResponse>();
            })
            .Produces<IEnumerable<CapacitacionDisponibleResponse>>()
            .WithSummary("Obtener capacitaciones disponibles")
            .WithDescription("Devuelve una lista de capacitaciones disponibles que cumplan con los filtros proporcionados")
            .WithOpenApi();
    }
}
