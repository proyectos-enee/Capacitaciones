using Enee.Core.CQRS.Query;
using Capacitaciones.Domain.Capacitacion.ConsultarColaboradores;
using Capacitaciones.Domain.Capacitacion.Projections.Colaboradores;

namespace Capacitaciones.Api.Capacitacion.RecuperarColaboradores;

public static class Endpoint
{
    public static void RecuperarColaboradores(this IEndpointRouteBuilder app)
    {
        app.MapGet(
                "/ClaveEmpleado",
                async (
                    [AsParameters] ConsultaColaboradores query,
                    IQueryDispatcher dispatcher
                ) =>
                {
                    var result = await dispatcher.Execute(query);
                    return result;
                }).Produces<IEnumerable<ColaboradoresDocumento>>()
            .WithSummary("Obtiene listado de colaboradores")
            .WithDescription("Listar varios colaboradores sin paginación.")
            .WithOpenApi();
    }
}
