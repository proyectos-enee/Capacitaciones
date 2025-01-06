using Enee.Core.CQRS.Command;
namespace Capacitaciones.Domain.Capacitacion.VisualizarCapacitacionDisponibe;

public record VisualizarCapacitacionCommand(
    string? Nombre,
    string? Modalidad,
    DateTime? FechaInicio,
    DateTime? FechaFin) : ICommand<List<CapacitacionResponse>>;
