﻿using Enee.Core.CQRS.Query;
using Enee.Core.Domain;
using Capacitaciones.Domain.Capacitacion.ConsultaCapacitacionesDisponibles;
using Capacitaciones.Domain.Capacitacion.Projections.Capacitacion;

namespace Capacitaciones.Api.Capacitacion.RecuperarCapacitacionesDisponibles
{
    public static class Endpoint
    {
        public static void RecuperarCapacitacionesDisponibles(this IEndpointRouteBuilder app)
        {
            app.MapGet(
                    "/capacitaciones/disponibles",
                    async (
                        [AsParameters] ConsultaCapacitacionesPaginado query,
                        IQueryDispatcher dispatcher
                    ) =>
                    {
                        var result = await dispatcher.Execute(query);
                        return result;
                    })
                .Produces<IPaginated<CapacitacionDocumento>>()
                .WithSummary("Obtiene listado de capacitaciones disponibles")
                .WithDescription("Lista capacitaciones disponibles para los colaboradores con opción de filtros.")
                .WithOpenApi();
        }
    }
}
