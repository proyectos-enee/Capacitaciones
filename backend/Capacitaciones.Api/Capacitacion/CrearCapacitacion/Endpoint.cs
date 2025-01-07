﻿using Capacitaciones.Api.Utils;
using Enee.Core.CQRS.Command;
using Capacitaciones.Domain.Capacitacion.CrearCapacitacion;

namespace Capacitaciones.Api.Capacitacion.CrearCapacitacion;

public static class Endpoint
{
    public static void CrearCapacitacion(this IEndpointRouteBuilder app)
    {
        app.MapPost("/", async (CapacitacionRequest request, IDispatcher dispatcher) =>
            {
                var id = Guid.NewGuid();
                var codigoCapacitacion = GenerarCodigoCapacitacion();

                var result = await dispatcher.Dispatch(new CrearCapacitacionCommand(
                    id,
                    CodigoCapacitacion: codigoCapacitacion,
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

                return result.ToResponse(new CapacitacionResponse() { Id = id, CodigoCapacitacion = codigoCapacitacion });
            })
            .Produces<CapacitacionResponse>()
            // .RequireAuthorization()
            .WithSummary("Crear capacitacion")
            .WithDescription("Permite crear una capacitacion y devuelve el identificador de la capacitacion creada")
            .WithOpenApi();
    }

    private static string GenerarCodigoCapacitacion()
    {
        // código único
        return $"CAP-{DateTime.UtcNow:yyyyMMddHHmmss}-{Guid.NewGuid().ToString("N").Substring(0, 6).ToUpper()}";
    }
}
