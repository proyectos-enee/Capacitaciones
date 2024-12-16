using Enee.Core.CQRS.Command;

namespace Capacitaciones.Domain.Capacitacion.LeerCapacitacion
{
    public record LeerCapacitacionCommand(Guid Id) : ICommand;
}
