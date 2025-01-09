using Enee.Core.CQRS.Command;
using Enee.Core.Domain.Repository;

namespace Capacitaciones.Domain.Capacitacion.VisualizarCapacitaciones;

public class VisualizarCapacitacionesCommandHandler : ICommandHandler<VisualizarCapacitacionesCommand>
{
    private readonly IWritableEventStoreRepository<Capacitacion> _repository;

    public VisualizarCapacitacionesCommandHandler(IWritableEventStoreRepository<Capacitacion> repository)
    {
        _repository = repository;
    }

    public async Task Handle(VisualizarCapacitacionesCommand command)
    {
        // Recupera todas las capacitaciones disponibles
        var capacitaciones = await ObtenerCapacitaciones();

        // Filtrar capacitaciones disponibles
        capacitaciones = capacitaciones
            .Where(c => c.Estado == "disponible" &&
                        c.FechaFinRegistro >= DateTime.UtcNow)
            .ToList();

        if (!string.IsNullOrEmpty(command.Nombre))
        {
            capacitaciones = capacitaciones
                .Where(c => c.NombreCorto.Contains(command.Nombre, StringComparison.OrdinalIgnoreCase) ||
                            c.NombreLargo.Contains(command.Nombre, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        if (!string.IsNullOrEmpty(command.Modalidad))
        {
            capacitaciones = capacitaciones
                .Where(c => c.Modalidad.Equals(command.Modalidad, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        if (command.FechaInicio.HasValue && command.FechaFin.HasValue)
        {
            capacitaciones = capacitaciones
                .Where(c => c.FechaInicioRegistro >= command.FechaInicio &&
                            c.FechaFinRegistro <= command.FechaFin)
                .ToList();
        }

        // Aquí manejas el resultado según tu flujo de negocio
        // Por ejemplo: enviar eventos, notificar al usuario, etc.
    }

    private async Task<List<Capacitacion>> ObtenerCapacitaciones()
    {
        // Implementa esta función para obtener todas las capacitaciones disponibles desde el repositorio
        throw new NotImplementedException("Implementar la lógica para obtener capacitaciones.");
    }
}
