using Enee.Core.CQRS.Validation;
using FluentValidation;

namespace Capacitaciones.Domain.Capacitacion.RegistrarColaborador;

public class RegistrarColaboradorValidator : CommandValidatorBase<RegistrarColaboradorCommand>
{
    public RegistrarColaboradorValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.ClaveEmpleado).NotEmpty().Length(6, 20);
        RuleFor(x => x.Nombre).NotEmpty();
        RuleFor(x => x.Cargo).NotEmpty();
        RuleFor(x => x.Dependencia).NotEmpty();
        RuleFor(x => x.CorreoElectronico).NotEmpty().EmailAddress();
    }
}
