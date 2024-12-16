using Enee.Core.CQRS.Validation;
using Enee.Core.Domain.Repository;
using Capacitaciones.Domain.Capacitacion.Projections.Capacitacion;
using FluentValidation;

namespace Capacitaciones.Domain.Capacitacion.EliminarCapacitacion
{
    public class EliminarCapacitacionValidator : CommandValidatorBase<EliminarCapacitacionCommand>
    {
        public IReadOnlyDocumentRepository<CapacitacionDocumento> Repository { get; }

        public EliminarCapacitacionValidator(IReadOnlyDocumentRepository<CapacitacionDocumento> repository)
        {
            Repository = repository;

            // Asegúrate de que el codigoCapacitacion no esté vacío ni nulo
            RuleFor(x => x.CodigoCapacitacion).NotEmpty().NotNull().Custom(VerificarExistaEnTablaDocumento);
        }

        // Método de validación que ahora busca por codigoCapacitacion
        private void VerificarExistaEnTablaDocumento(string codigoCapacitacion, ValidationContext<EliminarCapacitacionCommand> context)
        {
            // Buscamos por codigoCapacitacion
            var existe = Repository.AsQueryable().Any(x => x.CodigoCapacitacion == codigoCapacitacion);

            if (!existe)
            {
                context.AddFailure("No existe un elemento con el código de capacitación proporcionado.");
            }
        }
    }
}
