using Capacitaciones.Api.Capacitacion.EliminarCapacitacion;
using Capacitaciones.Api.Utils;
using Enee.Core.CQRS.Command;
using Capacitaciones.Domain.Capacitacion.EliminarCapacitacion;

namespace Capacitaciones.Api.Capacitacion.EliminarCapacitacion
{
    public static class Endpoint
    {
        public static void EliminarCapacitacion(this IEndpointRouteBuilder app)
        {
            app.MapDelete("/{id}", async (Guid id, IDispatcher dispatcher) =>
                {
                    // aca se elimina la capacitacion
                    var result = await dispatcher.Dispatch(new EliminarCapacitacionCommand(id));

                    // Comprobamos si la eliminación fue exitosa
                    return result.Match(
                        success => Results.NoContent(),  // eliminacion exitosa
                        failure => Results.NotFound()    // 404 Not Found si no se encontró la capacitación para eliminar
                    );
                })
                .Produces(204) // eliminado corr3ectamente
                .Produces(404) // No encontrado
                .WithSummary("Eliminar capacitación")
                .WithDescription("Permite eliminar una capacitación dada su ID")
                .WithOpenApi();
        }
    }
}

