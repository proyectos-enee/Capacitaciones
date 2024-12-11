using Enee.Core.Events;

namespace Capacitaciones.Domain.Capacitacion.Events.CapacitacionCreada;

public class CrearCuentaAnaliticaEnOdoo:IEventHandler<CrearCapacitacion.CapacitacionCreada>
{
    public Task Handle(CrearCapacitacion.CapacitacionCreada @event)
    {
        Console.WriteLine("Cuenta de capacitacion creada en odoo");
        return Task.CompletedTask;
    }
}
