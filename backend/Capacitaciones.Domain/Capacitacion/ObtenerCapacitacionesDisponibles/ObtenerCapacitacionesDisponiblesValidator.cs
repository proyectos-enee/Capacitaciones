using Enee.Core.CQRS.Validation;
using FluentValidation;

namespace Capacitaciones.Domain.Capacitacion.ObtenerCapacitacionesDisponibles;

public class ObtenerCapacitacionesDisponiblesValidator : CommandValidatorBase<ObtenerCapacitacionesDisponiblesCommand>
{
    public ObtenerCapacitacionesDisponiblesValidator()
    {
        RuleFor(x => x.FechaInicio)
            .LessThanOrEqualTo(x => x.FechaFin)
            .When(x => x.FechaInicio.HasValue && x.FechaFin.HasValue)
            .WithMessage("La fecha de inicio debe ser menor o igual a la fecha de fin.");
    }
}
