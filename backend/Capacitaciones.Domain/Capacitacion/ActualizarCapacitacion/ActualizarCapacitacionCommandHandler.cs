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
        // Buscar la capacitación existente
        var entity = await Repository.Find(command.Id);
        if (entity == null)
        {
            throw new InvalidOperationException("No se encontró la capacitación para actualizar.");
        }

        // Actualizar los valores de la entidad con los datos del comando

        entity.NombreCorto = command.NombreCorto;
        entity.NombreLargo = command.NombreLargo;
        entity.Descripcion = command.Descripcion;
        entity.EnteCapacitador = command.EnteCapacitador;
        entity.Modalidad = command.Modalidad;
        entity.Lugar = command.Lugar;
        entity.Horario = command.Horario;
        entity.FechaInicioRegistro = command.FechaInicioRegistro;
        entity.FechaFinRegistro = command.FechaFinRegistro;
        entity.Estado = command.Estado;

        // Guardar los cambios en el repositorio
        await Repository.Update(entity);
    }
}
