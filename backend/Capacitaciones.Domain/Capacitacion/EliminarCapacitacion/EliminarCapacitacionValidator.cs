using Enee.Core.CQRS.Validation;
using Enee.Core.Domain.Repository;
using Capacitaciones.Domain.Capacitacion.Projections.Capacitacion;
using FluentValidation;

namespace Capacitaciones.Domain.Capacitacion.EliminarCapacitacion;

public class EliminarCapacitacionValidator:CommandValidatorBase<EliminarCapacitacionCommand>
{
    public IReadOnlyDocumentRepository<CapacitacionDocumento> Repository { get; }

    public EliminarCapacitacionValidator(IReadOnlyDocumentRepository<CapacitacionDocumento> repository)
    {
        Repository = repository;
        RuleFor(x => x.Id).NotEmpty().NotNull().Custom(VerificarExistaEnTablaDocumento);
    }

    private void VerificarExistaEnTablaDocumento(Guid id, ValidationContext<EliminarCapacitacionCommand> arg2)
    {
        var existe = this.Repository.AsQueryable().Any(x => x.Id == id);

        if (!existe)
        {
            arg2.AddFailure("No existe elemento que desea eliminar");
        }
    }
}
