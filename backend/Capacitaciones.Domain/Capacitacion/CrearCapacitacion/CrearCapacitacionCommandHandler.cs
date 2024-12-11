using Enee.Core.CQRS.Command;
using Enee.Core.Domain.Repository;

namespace Capacitaciones.Domain.Capacitacion.CrearCapacitacion;

public class CrearCapacitacionCommandHandler:ICommandHandler<CrearCapacitacionCommand>
{
    public IWritableEventStoreRepository<Capacitacion> Repository { get; }

    public CrearCapacitacionCommandHandler(IWritableEventStoreRepository<Capacitacion> repository)
    {
        Repository = repository;
    }

    public async Task Handle(CrearCapacitacionCommand command)
    {

        var entity = new Capacitacion(command.Id, command.CodigoCapacitacion, command.NombreCorto, command.NombreLargo,
            command.Descripcion, command.EnteCapacitador, command.Modalidad, command.Lugar, command.Horario, command.FechaInicioRegistro, command.FechaFinRegistro, command.Estado);
        await Repository.Create(entity);
    }
}
