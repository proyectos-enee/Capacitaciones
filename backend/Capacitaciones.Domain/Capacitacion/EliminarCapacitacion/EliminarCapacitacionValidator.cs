using Enee.Core.CQRS.Validation;
using FluentValidation;

namespace Capacitaciones.Domain.Capacitacion.EliminarCapacitacion;

public class EliminarCapacitacionValidator : CommandValidatorBase<EliminarCapacitacionCommand>
{
    public EliminarCapacitacionValidator()
    {
        RuleFor(x => x.Id).NotEmpty().NotNull().WithMessage("El ID de la capacitación es requerido");
    }
}
