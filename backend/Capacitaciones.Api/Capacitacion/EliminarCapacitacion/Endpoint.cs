using Capacitaciones.Api.Utils;
using Enee.Core.CQRS.Command;
using Capacitaciones.Domain.Capacitacion.EliminarCapacitacion;

namespace Capacitaciones.Api.Capacitacion.EliminarCapacitacion;

public static class Endpoint
{
    public static void EliminarCapacitacion(this IEndpointRouteBuilder app)
    {
        app.MapDelete("/{id}", async (Guid id, IDispatcher dispatcher) =>
            {
                var result = await dispatcher.Dispatch(new EliminarCapacitacionCommand(id));
                return result.ToResponse();
            })
            .Produces(204)
            // .RequireAuthorization()
            .WithSummary("Eliminar capacitacion")
            .WithDescription("Permite eliminar una capacitacion por su identificador")
            .WithOpenApi();
    }
}
