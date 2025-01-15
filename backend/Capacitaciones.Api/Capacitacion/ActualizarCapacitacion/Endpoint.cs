﻿using Capacitaciones.Api.Utils;
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
                // Despachar el comando para actualizar la capacitación
                var result = await dispatcher.Dispatch(new ActualizarCapacitacionCommand(
                    id,

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

                if (result == null) // Validación adicional
                {
                    return Results.NotFound(new { Error = "No se encontró la capacitación para actualizar." });
                }

                return Results.Ok(new { Message = "Capacitación actualizada correctamente.", Id = id });
            }
            catch (InvalidOperationException ex)
            {
                return Results.NotFound(new { Error = ex.Message });
            }
            catch (Exception ex)
            {
                return Results.Problem(detail: ex.Message, statusCode: 500, title: "Error inesperado.");
            }
        })
        .Produces(200)
        .Produces(404)
        .Produces(500)
        .WithSummary("Actualizar capacitación")
        .WithDescription("Permite actualizar los datos de una capacitación existente y devuelve el estado de la operación.")
        .WithOpenApi();
    }
}
