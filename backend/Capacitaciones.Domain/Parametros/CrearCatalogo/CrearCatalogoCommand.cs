using Enee.Core.CQRS.Command;

namespace Capacitaciones.Domain.Parametros.CrearCatalogo;


public record CrearCatalogoCommand(Guid Id, string Nombre):ICommand;