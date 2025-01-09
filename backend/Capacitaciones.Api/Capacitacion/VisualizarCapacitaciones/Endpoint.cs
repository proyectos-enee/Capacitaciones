using Capacitaciones.Api.Utils;
using Enee.Core.CQRS.Command;
using Capacitaciones.Domain.Capacitacion.VisualizarCapacitaciones;
using Capacitaciones.Api.Capacitacion.CrearCapacitacion;

namespace Capacitaciones.Api.Capacitacion.VisualizarCapacitaciones;
    public static class Endpoint
    {
        public static void VisualizarCapacitaciones(this IEndpointRouteBuilder app)
        {
            app.MapPost("/disponibles", async (VisualizarCapacitacionesCommand command, IDispatcher dispatcher) =>
                {
                    var result = await dispatcher.Dispatch(command);

                    return result.Match(
                        left => Results.Ok(left), // Caso exitoso con la lista de capacitaciones
                        right => Results.BadRequest(new { Errors = right }) // Caso de error con validaciones
                    );
                })
                .Produces<List<CapacitacionResponse>>()
                .WithSummary("Listar capacitaciones disponibles")
                .WithDescription("Obtiene una lista de capacitaciones disponibles filtradas por criterios opcionales como nombre, modalidad y rango de fechas.")
                .WithOpenApi();
        }
    }



