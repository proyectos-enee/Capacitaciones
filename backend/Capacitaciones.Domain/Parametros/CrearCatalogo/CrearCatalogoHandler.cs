using Enee.Core.CQRS.Command;
using Enee.Core.Domain.Repository;

namespace Capacitaciones.Domain.Parametros.CrearCatalogo;

public class CrearCatalogoHandler:ICommandHandler<CrearCatalogoCommand>
{
    public IWritableRepository<Catalogo> Catalogo { get; }

    public CrearCatalogoHandler(IWritableRepository<Catalogo> catalogo)
    {
        Catalogo = catalogo;
    }

    //ATENCION: Este ejemplo es solo para ilustrar el funcionamiento de EF
    //Debe crearse la migracion para la tabla para que eset ejemplo funcione correctamente
    public async Task Handle(CrearCatalogoCommand command)
    {
        var entity = new Catalogo(command.Id, command.Nombre);
        await Catalogo.Create(entity);
    }
}
