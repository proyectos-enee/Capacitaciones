using Capacitaciones.Api.Utils;
using Enee.Core.CQRS.Command;
using Capacitaciones.Domain.Capacitacion.RegistrarColaborador;
using Capacitaciones.Domain.Capacitacion.CrearCapacitacion;

namespace Capacitaciones.Api.Capacitacion.RegistroColaborador;

public static class Endpoint
{
    public static void RegistrarColaborador(this IEndpointRouteBuilder app)
    {
        app.MapPost("/registro", async (RegistroColaboradorRequest request, IDispatcher dispatcher) =>
            {
                var result = await dispatcher.Dispatch(new RegistrarColaboradorCommand(
                    request.ClaveEmpleado,
                    request.CodigoCapacitacion
                ));

                return result.ToResponse(new RegistroColaboradorResponse() { Success = result.IsOk });
            })
            .Produces<RegistroColaboradorResponse>()
            .WithSummary("Registrar colaborador en capacitación")
            .WithDescription("Permite registrar a un colaborador en una capacitación específica")
            .WithOpenApi();
    }
}
