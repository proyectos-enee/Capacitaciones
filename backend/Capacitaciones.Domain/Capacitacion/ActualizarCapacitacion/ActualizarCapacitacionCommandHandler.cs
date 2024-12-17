using Enee.Core.CQRS.Command;
using Enee.Core.Domain.Repository;

namespace Capacitaciones.Domain.Capacitacion.ActualizarCapacitacion;

public class ActualizarCapacitacionCommandHandler : ICommandHandler<ActualizarCapacitacionCommand>
{
    public IWritableEventStoreRepository<Capacitacion> Repository { get; }

    public ActualizarCapacitacionCommandHandler(IWritableEventStoreRepository<Capacitacion> repository)
    {
        Repository = repository;
    }

    public async Task Handle(ActualizarCapacitacionCommand command)
    {
        var entity = await Repository.GetById(command.Id);
        if (entity == null)
        {
            throw new NotFoundException($"Capacitación con ID {command.Id} no encontrada");
        }

        // Actualizar propiedades de la entidad
        entity.ActualizarDatos(
            command.CodigoCapacitacion,
            command.NombreCorto,
            command.NombreLargo,
            command.Descripcion,
            command.EnteCapacitador,
            command.Modalidad,
            command.Lugar,
            command.Horario,
            command.FechaInicioRegistro,
            command.FechaFinRegistro,
            command.Estado
        );

        await Repository.Update(entity);
    }
}
