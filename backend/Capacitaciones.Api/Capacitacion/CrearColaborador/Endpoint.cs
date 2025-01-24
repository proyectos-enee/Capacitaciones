using Capacitaciones.Api.Utils;
using Enee.Core.CQRS.Command;
using Capacitaciones.Domain.Capacitacion.CrearColaborador;

namespace Capacitaciones.Api.Capacitacion.CrearColaborador;

public static class Endpoint
{
    public static void CrearColaborador(this IEndpointRouteBuilder app)
    {
        app.MapPost("/", async (ColaboradoresRequest request, IDispatcher dispatcher) =>
            {
                var id = Guid.NewGuid();
                var claveEmpleado = GenerarClaveEmpleado();

                var result = await dispatcher.Dispatch(new CrearColaboradorCommand(
                    id,
                    ClaveEmpleado: claveEmpleado,
                    Nombre: request.Nombre,
                    Apellido: request.Apellido,
                    Email: request.Email,
                    Password: request.Password,
                    FechaRegistro: request.FechaRegistro,
                    Estado: request.Estado
                ));

                return result.ToResponse(new ColaboradoresResponse() { Id = id, ClaveEmpleado = claveEmpleado });
            })
            .Produces<ColaboradoresResponse>()
            // .RequireAuthorization()
            .WithSummary("Crear colaborador")
            .WithDescription("Permite crear una capacitacion y devuelve el identificador de la capacitacion creada")
            .WithOpenApi();
    }

    private static string GenerarClaveEmpleado()
    {
        // código único
        return $"CAP-{DateTime.UtcNow:yyyyMMddHHmmss}-{Guid.NewGuid().ToString("N").Substring(0, 6).ToUpper()}";
    }
}
