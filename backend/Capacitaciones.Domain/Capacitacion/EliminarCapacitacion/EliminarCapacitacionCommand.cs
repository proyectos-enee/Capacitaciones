using Enee.Core.CQRS.Command;

namespace Capacitaciones.Domain.Capacitacion.EliminarCapacitacion;

public record EliminarCapacitacionCommand(Guid Id) : ICommand;
