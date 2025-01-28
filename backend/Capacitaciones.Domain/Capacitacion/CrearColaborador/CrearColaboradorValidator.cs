using Enee.Core.CQRS.Validation;
using FluentValidation;

namespace Capacitaciones.Domain.Capacitacion.CrearColaborador;

public class CrearColaboradorValidator : CommandValidatorBase<CrearColaboradorCommand>
{
    public CrearColaboradorValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("El ID es obligatorio.")
            .NotNull().WithMessage("El ID no puede ser nulo.");

        RuleFor(x => x.ClaveEmpleado)
            .NotEmpty().WithMessage("El código de la capacitación es obligatorio.")
            .NotNull().WithMessage("El código de la capacitación no puede ser nulo.");

        RuleFor(x => x.Nombre)
            .NotEmpty().WithMessage("El nombre corto es obligatorio.")
            .NotNull().WithMessage("El nombre corto no puede ser nulo.")
            .MaximumLength(50).WithMessage("El nombre corto no debe superar los 50 caracteres.");

        RuleFor(x => x.Cargo)
            .NotEmpty().WithMessage("El nombre largo es obligatorio.")
            .NotNull().WithMessage("El nombre largo no puede ser nulo.")
            .MaximumLength(100).WithMessage("El nombre largo no debe superar los 100 caracteres.");

        RuleFor(x => x.Correo)
            .NotEmpty().WithMessage("La descripción es obligatoria.")
            .NotNull().WithMessage("La descripción no puede ser nula.");

        RuleFor(x => x.Dependencia)
            .NotEmpty().WithMessage("El ente capacitador es obligatorio.")
            .NotNull().WithMessage("El ente capacitador no puede ser nulo.");



        RuleFor(x => x.FechaRegistro)
            .NotEmpty().WithMessage("La fecha de inicio del registro es obligatoria.")
            .NotNull().WithMessage("La fecha de inicio del registro no puede ser nula.")
            .GreaterThanOrEqualTo(DateTime.Today)
            .WithMessage("La fecha de inicio debe ser igual o posterior a la fecha actual.");


        RuleFor(x => x.Estado)
            .NotEmpty().WithMessage("El estado es obligatorio.")
            .NotNull().WithMessage("El estado no puede ser nulo.")
            .Must(x => x == "disponible" || x == "no disponible")
            .WithMessage("El estado debe ser 'disponible' o 'no disponible'.");
    }
}
