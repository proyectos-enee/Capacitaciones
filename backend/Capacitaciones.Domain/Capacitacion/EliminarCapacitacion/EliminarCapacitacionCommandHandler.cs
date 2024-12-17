using Enee.Core.CQRS.Command;
using Enee.Core.Domain.Repository;

namespace Capacitaciones.Domain.Capacitacion.EliminarCapacitacion;

public class EliminarCapacitacionCommandHandler : ICommandHandler<EliminarCapacitacionCommand>
{
    public IWritableEventStoreRepository<Capacitacion> Repository { get; }

    public EliminarCapacitacionCommandHandler(IWritableEventStoreRepository<Capacitacion> repository)
    {
        Repository = repository;
    }

    public async Task Handle(EliminarCapacitacionCommand command)
    {
        var entity = await Repository.GetById(command.Id);
        if (entity == null)
        {
            throw new NotFoundException($"Capacitación con ID {command.Id} no encontrada");
        }

        await Repository.Delete(entity);
    }
}
