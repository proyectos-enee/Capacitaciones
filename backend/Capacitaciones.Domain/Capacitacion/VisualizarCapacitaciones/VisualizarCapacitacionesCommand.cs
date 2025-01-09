using Enee.Core.CQRS.Command;

public record VisualizarCapacitacionesCommand(
    string? Nombre,
    string? Modalidad,
    DateTime? FechaInicio,
    DateTime? FechaFin
) : ICommand;
