using Enee.Core.CQRS.Validation;
using Enee.Core.Domain.Repository;
using Capacitaciones.Domain.Capacitacion.Projections.Capacitacion;
using FluentValidation;

namespace Capacitaciones.Domain.Capacitacion.ActualizarCapacitacion
{
    public class ActualizarCapacitacionValidator : CommandValidatorBase<ActualizarCapacitacionCommand>
    {
        public IReadOnlyDocumentRepository<CapacitacionDocumento> Repository { get; }

        public ActualizarCapacitacionValidator(IReadOnlyDocumentRepository<CapacitacionDocumento> repository)
        {
            Repository = repository;

            // Validamos que el código de la capacitación no esté vacío ni nulo
            RuleFor(x => x.CodigoCapacitacion)
                .NotEmpty().WithMessage("El código de la capacitación es obligatorio.")
                .NotNull().WithMessage("El código de la capacitación no puede ser nulo.")
                .Custom(VerificarExistaEnTablaDocumento);

            // Validaciones adicionales para otros campos, como el nombre corto, descripción, etc.
            RuleFor(x => x.NombreCorto)
                .NotEmpty().WithMessage("El nombre corto es obligatorio.")
                .NotNull().WithMessage("El nombre corto no puede ser nulo.");

            RuleFor(x => x.NombreLargo)
                .NotEmpty().WithMessage("El nombre largo es obligatorio.")
                .NotNull().WithMessage("El nombre largo no puede ser nulo.");

            RuleFor(x => x.Descripcion)
                .NotEmpty().WithMessage("La descripción es obligatoria.")
                .NotNull().WithMessage("La descripción no puede ser nula.");
        }

        // Método de validación que verifica si el codigoCapacitacion existe en la tabla
        private void VerificarExistaEnTablaDocumento(string codigoCapacitacion, ValidationContext<ActualizarCapacitacionCommand> context)
        {
            // Comprobamos si el código de capacitación existe en la base de datos
            var existe = Repository.AsQueryable().Any(x => x.CodigoCapacitacion == codigoCapacitacion);

            if (!existe)
            {
                context.AddFailure("No existe una capacitación con el código proporcionado.");
            }
        }
    }
}
