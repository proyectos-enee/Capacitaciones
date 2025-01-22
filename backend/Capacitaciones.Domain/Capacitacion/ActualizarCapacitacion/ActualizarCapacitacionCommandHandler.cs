using Enee.Core.CQRS.Command;
using Enee.Core.Domain.Repository;
using Capacitaciones.Domain.Exceptions;

namespace Capacitaciones.Domain.Capacitacion.ActualizarCapacitacion;

public class ActualizarCapacitacionCommandHandler : ICommandHandler<ActualizarCapacitacionCommand>
{
    public IWritableEventStoreRepository<Capacitacion> Repository { get; }

    public ActualizarCapacitacionCommandHandler(IWritableEventStoreRepository<Capacitacion> repository)
    {
        Repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }

    public async Task Handle(ActualizarCapacitacionCommand command)
    {
        // Validar comando
        if (command == null)
        {
            throw new ArgumentNullException(nameof(command), "El comando no puede ser nulo.");
        }

        // Buscar la entidad en el repositorio
        var capacitacion = await Repository.Find(command.Id).ConfigureAwait(false);
        if (capacitacion == null)
        {
            throw new NotFoundException($"La capacitación con Id {command.Id} no existe.");
        }

        // Actualizar la entidad con los nuevos datos
        capacitacion.Actualizar(
            command.NombreCorto,
            command.NombreLargo,
            command.Descripcion,
            command.EnteCapacitador,
            command.Modalidad,
            command.Lugar,
            command.Horario,
            command.FechaInicioRegistro,
            command.FechaFinRegistro,
            command.Estado);

        // Guardar los cambios en el repositorio (eventos generados)
        await Repository.Update(capacitacion).ConfigureAwait(false);
    }
}

