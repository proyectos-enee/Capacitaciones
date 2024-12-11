using Enee.Core.Events;

namespace Capacitaciones.Domain.Parametros.Events.CatalogoCreado;

public class EnviarCorreoElectronico:IEventHandler<CrearCatalogo.CatalogoCreado>
{
    public Task Handle(CrearCatalogo.CatalogoCreado @event)
    {
        Console.WriteLine("Ejemplo de envio de correo");

        return Task.CompletedTask;
    }
}
