using Enee.Core.CQRS.Command;
using Enee.Core.Domain.Repository;

namespace Capacitaciones.Domain.Capacitacion.CrearColaborador;

public class CrearColaboradorCommandHandler:ICommandHandler<CrearColaboradorCommand>
{
    public IWritableEventStoreRepository<Colaboradores> Repository { get; }

    public CrearColaboradorCommandHandler(IWritableEventStoreRepository<Colaboradores> repository)
    {
        Repository = repository;
    }

    public async Task Handle(CrearColaboradorCommand command)
    {

        var entity = new Colaboradores(command.Id, command.ClaveEmpleado, command.Nombre, command.Cargo,
            command.Correo, command.Dependencia,  command.FechaRegistro, command.Estado);
        await Repository.Create(entity);
    }
}
