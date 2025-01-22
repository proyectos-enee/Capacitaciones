using Enee.Core.Events;

namespace Capacitaciones.Domain.Capacitacion.Events.CapacitacionActualizada;

public class ActualizarCuentaAnaliticaEnOdoo:IEventHandler<ActualizarCapacitacion.CapacitacionActualizada>
{
    public Task Handle(ActualizarCapacitacion.CapacitacionActualizada @event)
    {
        Console.WriteLine("Cuenta de capacitacion actualizada en odoo");
        return Task.CompletedTask;
    }
}
