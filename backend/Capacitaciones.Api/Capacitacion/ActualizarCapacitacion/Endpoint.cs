using Capacitaciones.Api.Utils;
using Enee.Core.CQRS.Command;
using Capacitaciones.Domain.Capacitacion.ActualizarCapacitacion;

namespace Capacitaciones.Api.Capacitacion.ActualizarCapacitacion;

public static class Endpoint
{
    public static void ActualizarCapacitacion(this IEndpointRouteBuilder app)
    {
        app.MapPut("/{id}", async (Guid id, ActualizarCapacitacionRequest request, IDispatcher dispatcher) =>
        {
            try
            {
                // Despachamos el comando de actualización con todos los valores proporcionados
                var result = await dispatcher.Dispatch(new ActualizarCapacitacionCommand(
                    id,
                    CodigoCapacitacion: request.CodigoCapacitacion,
                    NombreCorto: request.NombreCorto,
                    NombreLargo: request.NombreLargo,
                    Descripcion: request.Descripcion,
                    EnteCapacitador: request.EnteCapacitador,
                    Modalidad: request.Modalidad,
                    Lugar: request.Lugar,
                    Horario: request.Horario,
                    FechaInicioRegistro: request.FechaInicioRegistro,
                    FechaFinRegistro: request.FechaFinRegistro,
                    Estado: request.Estado
                ));

                // Devolver la respuesta con los detalles actualizados
                return Results.Ok(new ActualizarCapacitacionResponse
                {
                    Id = id,
                    CodigoCapacitacion = request.CodigoCapacitacion,
                    NombreCorto = request.NombreCorto,
                    NombreLargo = request.NombreLargo,
                    Descripcion = request.Descripcion,
                    EnteCapacitador = request.EnteCapacitador,
                    Modalidad = request.Modalidad,
                    Lugar = request.Lugar,
                    Horario = request.Horario,
                    FechaInicioRegistro = request.FechaInicioRegistro,
                    FechaFinRegistro = request.FechaFinRegistro,
                    Estado = request.Estado
                });
            }
            catch (Exception ex)
            {
                // Manejo de errores si ocurre algo
                return Results.Problem(ex.Message, statusCode: 500);
            }
        })
        .Produces<ActualizarCapacitacionResponse>()
        .WithSummary("Actualizar capacitación")
        .WithDescription("Permite actualizar los detalles de una capacitación dada su ID")
        .WithOpenApi();
    }
}
