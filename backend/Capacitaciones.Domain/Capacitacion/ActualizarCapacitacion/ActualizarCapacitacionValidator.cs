using Enee.Core.CQRS.Validation;
using FluentValidation;

namespace Capacitaciones.Domain.Capacitacion.ActualizarCapacitacion;

public class ActualizarCapacitacionValidator : CommandValidatorBase<ActualizarCapacitacionCommand>
{
    public ActualizarCapacitacionValidator()
    {
        RuleFor(x => x.Id).NotEmpty().NotNull();
        RuleFor(x => x.CodigoCapacitacion).NotEmpty().NotNull();
        RuleFor(x => x.NombreCorto).NotEmpty().NotNull();
        RuleFor(x => x.NombreLargo).NotEmpty().NotNull();
        RuleFor(x => x.Descripcion).NotEmpty().NotNull();
        RuleFor(x => x.EnteCapacitador).NotEmpty().NotNull();
        RuleFor(x => x.Modalidad).NotEmpty().NotNull();
        RuleFor(x => x.Lugar).NotEmpty().NotNull();
        RuleFor(x => x.Horario).NotEmpty().NotNull();
        RuleFor(x => x.FechaInicioRegistro).NotEmpty().NotNull();
        RuleFor(x => x.FechaFinRegistro).NotEmpty().NotNull();
        RuleFor(x => x.Estado).NotEmpty().NotNull();
    }
}
