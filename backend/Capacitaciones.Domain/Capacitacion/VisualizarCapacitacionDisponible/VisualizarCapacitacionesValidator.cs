using FluentValidation;
using Enee.Core.CQRS.Validation;

namespace Capacitaciones.Domain.Capacitacion.VisualizarCapacitacionDisponible;

//public class VisualizarCapacitacionesValidator : CommandValidatorBase<VisualizarCapacitacionesCommand>
//{
    //public VisualizarCapacitacionesValidator()
    //{
        //RuleFor(x => x.Nombre).MaximumLength(100).When(x => !string.IsNullOrEmpty(x.Nombre));
        //RuleFor(x => x.Modalidad).MaximumLength(50).When(x => !string.IsNullOrEmpty(x.Modalidad));
      ////  RuleFor(x => x.FechaInicio).LessThanOrEqualTo(x => x.FechaFin)
    //        .When(x => x.FechaInicio.HasValue && x.FechaFin.HasValue);
  //  }
//}
