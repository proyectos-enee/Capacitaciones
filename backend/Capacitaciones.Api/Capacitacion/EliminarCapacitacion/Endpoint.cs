using Capacitaciones.Api.Utils;
using Enee.Core.CQRS.Command;
using Enee.Core.CQRS.Validation;
using Capacitaciones.Domain.Capacitacion.EliminarCapacitacion;

namespace Capacitaciones.Api.Capacitacion.EliminarCapacitacion;

public static class Endpoint
{
    public static void EliminarCapacitacion(this IEndpointRouteBuilder app)
    {
        app.MapDelete("/{id}", async (Guid id, IDispatcher dispatcher) =>
            {
                var result = await dispatcher.Dispatch(new EliminarCapacitacionCommand(id));

                // Procesar el resultado de Either
                return result.Match(
                    success => Results.NoContent(), // Si es OK, retorna NoContent
                    errors => Results.BadRequest(errors) // Si hay errores, retorna BadRequest con los detalles
                );
            })
            .Produces(StatusCodes.Status204NoContent) // Eliminación exitosa
            .Produces(StatusCodes.Status400BadRequest) // Validaciones fallidas
            .Produces(StatusCodes.Status404NotFound) // Si no se encuentra la capacitación
            .WithSummary("Eliminar capacitación")
            .WithDescription("Permite eliminar una capacitación por su identificador")
            .WithOpenApi();
    }
}
