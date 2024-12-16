using Capacitaciones.Api.Utils;
using Enee.Core.CQRS.Command;
using Capacitaciones.Domain.Capacitacion.EliminarCapacitacion;

namespace Capacitaciones.Api.Capacitacion.EliminarCapacitacion
{
    public static class Endpoint
    {
        public static void EliminarCapacitacion(this IEndpointRouteBuilder app)
        {

            app.MapDelete("/{codigoCapacitacion}", async (string codigoCapacitacion, IDispatcher dispatcher) =>
                {
                    // Ejecutamos el comando para eliminar la capacitación por código
                    var result = await dispatcher.Dispatch(new EliminarCapacitacionCommand(codigoCapacitacion));

                    // Procesamos el resultado de Either
                    return result.Match(
                        success => Results.NoContent(),  // Si es OK, retornamos NoContent
                        errors => Results.BadRequest(errors)  // Si hay errores, retornamos BadRequest con los detalles
                    );
                })
                .Produces(StatusCodes.Status204NoContent) // Eliminación exitosa
                .Produces(StatusCodes.Status400BadRequest) // Validaciones fallidas
                .Produces(StatusCodes.Status404NotFound) // Si no se encuentra la capacitación
                .WithSummary("Eliminar capacitación")
                .WithDescription("Permite eliminar una capacitación por su código de capacitación")
                .WithOpenApi();
        }
    }
}
