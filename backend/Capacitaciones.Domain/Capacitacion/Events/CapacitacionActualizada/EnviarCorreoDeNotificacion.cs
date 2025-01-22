using Enee.Core.Events;

namespace Capacitaciones.Domain.Capacitacion.Events.CapacitacionActualizada;

public class EnviarCorreoDeNotificacion : IEventHandler<ActualizarCapacitacion.CapacitacionActualizada>
{

    public Task Handle(ActualizarCapacitacion.CapacitacionActualizada @event)
    {
        Console.WriteLine("Envio de correo de notificacion");
        return Task.CompletedTask;
    }
}
