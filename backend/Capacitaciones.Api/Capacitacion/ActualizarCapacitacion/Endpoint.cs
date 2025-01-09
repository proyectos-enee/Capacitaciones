using Capacitaciones.Api.Utils;
using Enee.Core.CQRS.Command;
using Capacitaciones.Domain.Capacitacion.ActualizarCapacitacion;
using Capacitaciones.Api.Capacitacion.CrearCapacitacion;

namespace Capacitaciones.Api.Capacitacion.ActualizarCapacitacion;

public static class Endpoint
{
    public static void ActualizarCapacitacion(this IEndpointRouteBuilder app)
    {
        app.MapPut("/{id}", async (Guid id, CapacitacionRequest request, IDispatcher dispatcher) =>
        {


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

            return result.ToResponse();
        })
        .Produces<CapacitacionResponse>()

            // .RequireAuthorization()
            .WithSummary("Actualizar capacitacion")
                .WithDescription("Permite actualizar los datos de un almacén existente usando su identificador")
                .WithOpenApi();
        }
    }
