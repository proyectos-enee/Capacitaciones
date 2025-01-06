using Enee.Core.CQRS.Command;
using Enee.Core.Domain.Repository;

namespace Capacitaciones.Domain.Capacitacion.ActualizarCapacitacion;

public class ActualizarCapacitacionCommandHandler:ICommandHandler<ActualizarCapacitacionCommand>
{
    public IWritableEventStoreRepository<Capacitacion> Repository { get; }

    public ActualizarCapacitacionCommandHandler(IWritableEventStoreRepository<Capacitacion> repository)
    {
        Repository = repository;
    }

    public async Task Handle(ActualizarCapacitacionCommand command)
    {

        var entity = new Capacitacion(command.Id, command.CodigoCapacitacion, command.NombreCorto, command.NombreLargo,
            command.Descripcion, command.EnteCapacitador, command.Modalidad, command.Lugar, command.Horario, command.FechaInicioRegistro, command.FechaFinRegistro, command.Estado);
        await Repository.Create(entity);
    }
}
