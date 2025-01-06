using Capacitaciones.Api.Utils;
using System.Linq;
using Enee.Core.CQRS.Command;
using Capacitaciones.Domain.Capacitacion.VisualizarCapacitacionDisponible;

//amespace Capacitaciones.Api.Capacitacion.VisualizarCapacitacionDisponible;

//public static class Endpoint
//{
  //  public static void VisualizarCapacitacionDisponible(this IEndpointRouteBuilder app)
   // {
     //   app.MapPost("/", async (VisualizarCapacitacionRequest request, IDispatcher dispatcher) =>
           // {
                //var result = await dispatcher.Dispatch(new VisualizarCapacitacionesCommand(
       //             Nombre: request.Nombre,
         //           Modalidad: request.Modalidad,
           //         FechaInicio: request.FechaInicio,
             //       FechaFin: request.FechaFin
             //   ));

                //if (result.Any())
               // {
                    //return Results.Ok(result);
                //}
                //else
              //  {
                   // return Results.NotFound(new { Message = "No hay capacitaciones disponibles con los filtros aplicados." });
             //   }
          //  })
          //  .Produces<List<CapacitacionDisponibleResponse>>()
        //    .Produces(404)
        //    .WithSummary("Ver capacitaciones disponibles")
         //   .WithDescription("Permite consultar las capacitaciones disponibles con filtros opcionales.")
         //   .WithOpenApi();
 //  }
//}
