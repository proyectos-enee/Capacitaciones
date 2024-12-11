using Enee.Core.Events;

namespace Capacitaciones.Domain.Capacitacion.Events.CapacitacionCreada;

public class EnviarCorreoDeNotificacion:IEventHandler<CrearCapacitacion.CapacitacionCreada>
{

    public Task Handle(CrearCapacitacion.CapacitacionCreada @event)
    {
        Console.WriteLine("Envio de correo de notificacion");
        return Task.CompletedTask;
    }
}
