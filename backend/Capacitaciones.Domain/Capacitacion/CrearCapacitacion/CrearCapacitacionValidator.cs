using Enee.Core.CQRS.Validation;
using FluentValidation;

namespace Capacitaciones.Domain.Capacitacion.CrearCapacitacion;

public class CrearCapacitacionValidator : CommandValidatorBase<CrearCapacitacionCommand>
{
    public CrearCapacitacionValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("El ID es obligatorio.")
            .NotNull().WithMessage("El ID no puede ser nulo.");

        RuleFor(x => x.CodigoCapacitacion)
            .NotEmpty().WithMessage("El código de la capacitación es obligatorio.")
            .NotNull().WithMessage("El código de la capacitación no puede ser nulo.");

        RuleFor(x => x.NombreCorto)
            .NotEmpty().WithMessage("El nombre corto es obligatorio.")
            .NotNull().WithMessage("El nombre corto no puede ser nulo.")
            .MaximumLength(50).WithMessage("El nombre corto no debe superar los 50 caracteres.");

        RuleFor(x => x.NombreLargo)
            .NotEmpty().WithMessage("El nombre largo es obligatorio.")
            .NotNull().WithMessage("El nombre largo no puede ser nulo.")
            .MaximumLength(100).WithMessage("El nombre largo no debe superar los 100 caracteres.");

        RuleFor(x => x.Descripcion)
            .NotEmpty().WithMessage("La descripción es obligatoria.")
            .NotNull().WithMessage("La descripción no puede ser nula.");

        RuleFor(x => x.EnteCapacitador)
            .NotEmpty().WithMessage("El ente capacitador es obligatorio.")
            .NotNull().WithMessage("El ente capacitador no puede ser nulo.");

        RuleFor(x => x.Modalidad)
            .NotEmpty().WithMessage("La modalidad es obligatoria.")
            .NotNull().WithMessage("La modalidad no puede ser nula.");

        RuleFor(x => x.Lugar)
            .NotEmpty().WithMessage("El lugar es obligatorio.")
            .NotNull().WithMessage("El lugar no puede ser nulo.");

        RuleFor(x => x.Horario)
            .NotEmpty().WithMessage("El horario es obligatorio.")
            .NotNull().WithMessage("El horario no puede ser nulo.");

        RuleFor(x => x.FechaInicioRegistro)
            .NotEmpty().WithMessage("La fecha de inicio del registro es obligatoria.")
            .NotNull().WithMessage("La fecha de inicio del registro no puede ser nula.")
            .GreaterThanOrEqualTo(DateTime.Today)
            .WithMessage("La fecha de inicio debe ser igual o posterior a la fecha actual.");

        RuleFor(x => x.FechaFinRegistro)
            .NotEmpty().WithMessage("La fecha de fin del registro es obligatoria.")
            .NotNull().WithMessage("La fecha de fin del registro no puede ser nula.")
            .GreaterThan(x => x.FechaInicioRegistro)
            .WithMessage("La fecha de fin debe ser posterior a la fecha de inicio.");

        RuleFor(x => x.Estado)
            .NotEmpty().WithMessage("El estado es obligatorio.")
            .NotNull().WithMessage("El estado no puede ser nulo.")
            .Must(x => x == "disponible" || x == "no disponible")
            .WithMessage("El estado debe ser 'disponible' o 'no disponible'.");
    }
}
