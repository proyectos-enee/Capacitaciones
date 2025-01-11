using Enee.Core.CQRS.Command;

namespace Capacitaciones.Domain.Capacitacion.ObtenerCapacitacionesDisponibles;

public record ObtenerCapacitacionesDisponiblesCommand(
    string? Modalidad,
    string? Nombre,
    DateTime? FechaInicio,
    DateTime? FechaFin
) : ICommand<IEnumerable<CapacitacionDisponible>>;
