using Capacitaciones.Domain.Parametros.CrearCatalogo;
using Autofac.Features.AttributeFilters;
using Enee.Core.CQRS.Command;
using Enee.IoC.Architecture;
using Enee.IoC.Architecture.Others;
using Microsoft.AspNetCore.Mvc;

namespace Capacitaciones.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ParametrosController : ControllerBase
{
    public IDispatcher Dispatcher { get; }


    public ParametrosController(IDispatcher dispatcher)
    {
        Dispatcher = dispatcher;

    }

    // [HttpPost(Name = "guardar") ]
    // public async Task<IActionResult> Guardar([FromBody] (Guid id,string nombre) request)
    // {
    //
    //     var id = Guid.NewGuid();
    //    var result = await Dispatcher.Dispatch(new CrearCatalogoCommand(id,request.nombre));
    //
    //     return result.ToResponse(new {Id=id});
    // }
}
