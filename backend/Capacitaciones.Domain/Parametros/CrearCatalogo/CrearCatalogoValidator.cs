using Enee.Core.CQRS.Validation;
using FluentValidation;

namespace Capacitaciones.Domain.Parametros.CrearCatalogo;

public class CrearCatalogoValidator:CommandValidatorBase<CrearCatalogoCommand>
{
    public CrearCatalogoValidator()
    {
        RuleFor(x => x.Nombre).NotEmpty().NotNull();
    }
}