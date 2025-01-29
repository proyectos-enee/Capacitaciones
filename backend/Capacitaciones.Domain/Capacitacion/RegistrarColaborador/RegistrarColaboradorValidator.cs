using Enee.Core.CQRS.Validation;
using FluentValidation;

namespace Capacitaciones.Domain.Capacitacion.RegistrarColaborador;

public class RegistrarColaboradorValidator : CommandValidatorBase<RegistrarColaboradorCommand>
{
    public RegistrarColaboradorValidator()
    {
        RuleFor(x => x.ClaveEmpleado).NotEmpty().NotNull();
        RuleFor(x => x.CodigoCapacitacion).NotEmpty().NotNull();
    }
}
