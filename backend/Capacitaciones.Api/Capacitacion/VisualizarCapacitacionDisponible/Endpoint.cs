using System.Runtime.InteropServices;

namespace Capacitaciones.Api.Capacitacion.VisualizarCapacitacionDisponible;

public static class Endpoint
{
    public static void VisualizarCapacitacionDisponible(this IEndpointRouteBuilder app)
    {
        app.MapGet("/disponibles", async (string? nombre, string? modalidad, DateTime? fechaInicio, DateTime? fechaFin, IDispatcher dispatcher) =>
            {
                // Se crea un comando para consultar capacitaciones disponibles con filtros.
                var result = await dispatcher.Dispatch(new VisualizarCapacitacionCommand(
                    nombre,
                    modalidad,
                    fechaInicio,
                    fechaFin
                ));

                if (result.Any())
                {
                    return Results.Ok(result); // Devuelve las capacitaciones filtradas.
                }
                else
                {
                    return Results.NoContent(); // Devuelve 204 No Content si no hay capacitaciones.
                }
            })
            .Produces<List<CapacitacionResponse>>()
            .WithSummary("Ver capacitaciones disponibles")
            .WithDescription("Permite ver las capacitaciones disponibles según filtros de nombre, modalidad y fechas.")
            .WithOpenApi();
    }
}
