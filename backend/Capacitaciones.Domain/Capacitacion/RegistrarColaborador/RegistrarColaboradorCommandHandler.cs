using Enee.Core.CQRS.Command;
using Enee.Core.Domain.Repository;

namespace Capacitaciones.Domain.Capacitacion.RegistrarColaborador;

public class RegistrarColaboradorCommandHandler : ICommandHandler<RegistrarColaboradorCommand>
{
    public IWritableEventStoreRepository<Colaboradores> Repository { get; }

    public RegistrarColaboradorCommandHandler(IWritableEventStoreRepository<Colaboradores> repository)
    {
        Repository = repository;
    }

    public async Task Handle(RegistrarColaboradorCommand command)
    {
        // Aquí se implementaría la lógica para buscar al colaborador y registrarlo en la capacitación
        var colaboradores = await Repository.Find(command.ClaveEmpleado).ConfigureAwait(false);
        if (colaboradores == null)
        {
            throw new Exception("Colaborador no encontrado");
        }

        // Lógica para verificar si el colaborador ya está registrado en la capacitación
        // Si no está registrado, se procede a registrarlo
        await Repository.Update(colaboradores);
    }
}
