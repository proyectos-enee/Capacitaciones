using Enee.Core.CQRS.Command;
using Enee.Core.Domain.Repository;

namespace Capacitaciones.Domain.Capacitacion.EliminarCapacitacion;

public class EliminarCapacitacionCommandHandler:ICommandHandler<EliminarCapacitacionCommand>
{
    public IWritableEventStoreRepository<Capacitacion> Repository { get; }

    public EliminarCapacitacionCommandHandler(IWritableEventStoreRepository<Capacitacion> repository)
    {
        Repository = repository;
    }
    public async Task Handle(EliminarCapacitacionCommand command)
    {
        var capacitacion = await Repository.Find(command.Id).ConfigureAwait(false);
        capacitacion.Eliminar();
        await Repository.Update(capacitacion).ConfigureAwait(false);
    }
}
