using Enee.Core.CQRS.Command;
using Enee.Core.CQRS.Query;
using Enee.Core.Domain;
using Capacitaciones.Domain.Capacitacion.ConsultarCapacitacion;
using Capacitaciones.Domain.Capacitacion.CrearCapacitacion;
using Capacitaciones.Domain.Capacitacion.EliminarCapacitacion;
using Capacitaciones.Domain.Capacitacion.Projections.Capacitacion;
using Enee.IoC.Architecture.Others;
using Microsoft.AspNetCore.Mvc;

namespace Capacitaciones.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class CapacitacionController : ControllerBase
{
    public IDispatcher Dispatcher { get; }
    public IQueryDispatcher QueryDispatcher { get; }


    public CapacitacionController(IDispatcher dispatcher, IQueryDispatcher queryDispatcher)
    {
        Dispatcher = dispatcher;
        QueryDispatcher = queryDispatcher;
    }

   [HttpGet]
    public async Task<IPaginated<CapacitacionDocumento>> ConsultarPaginado([FromQuery] int? page,int? pageSize, string? nombre)
    {
        var result = await QueryDispatcher.Execute(new ConsultaCapacitacionPaginado()
        {
            Page = page,
            PageSize = pageSize,
            CodigoCapacitacion = nombre
        }).ConfigureAwait(false);
        return result;
    }
    //
    // [HttpPost]
    // public async Task<IActionResult> Guardar([FromBody] AlmanceRequest request)
    // {
    //     var id = Guid.NewGuid();
    //     var result = await Dispatcher.Dispatch(new CrearAlmacenCommand(
    //         id,
    //         request.NombreSucursal,
    //         request.NombreAdministrador,
    //         request.Telefono,
    //         request.Direccion,
    //         request.Fax,
    //         request.NumeroPedidos
    //
    //     )).ConfigureAwait(false);
    //
    //     return result.ToResponse(new { Id = id });
    // }
    //
    // [HttpDelete("{id}")]
    // public async Task<IActionResult> Eliminar([FromRoute] Guid id)
    // {
    //     var result= await Dispatcher.Dispatch(new EliminarAlmacenCommand(id)).ConfigureAwait(false);
    //     return result.ToResponse();
    // }

}
