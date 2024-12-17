using Capacitaciones.Api.Utils;
using Enee.Core.CQRS.Command;
using Capacitaciones.Domain.Capacitacion.ActualizarCapacitacion;

namespace Capacitaciones.Api.Capacitacion.ActualizarCapacitacion;

public static class Endpoint
{
    public static void ActualizarCapacitacion(this IEndpointRouteBuilder app)
    {
        app.MapPut("/{id}", async (Guid id, CapacitacionRequest request, IDispatcher dispatcher) =>
            {
                var result = await dispatcher.Dispatch(new ActualizarCapacitacionCommand(
                    id,
                    request.CodigoCapacitacion,
                    request.NombreCorto,
                    request.NombreLargo,
                    request.Descripcion,
                    request.EnteCapacitador,
                    request.Modalidad,
                    request.Lugar,
                    request.Horario,
                    request.FechaInicioRegistro,
                    request.FechaFinRegistro,
                    request.Estado
                ));

                return result.ToResponse(new CapacitacionResponse {
                    Id = id,
                    CodigoCapacitacion = request.CodigoCapacitacion,
                    NombreCorto = request.NombreCorto,
                    Estado = request.Estado
                });
            })
            .Produces<CapacitacionResponse>()
            // .RequireAuthorization()
            .WithSummary("Actualizar capacitacion")
            .WithDescription("Permite actualizar los datos de una capacitacion")
            .WithOpenApi();
    }
}
