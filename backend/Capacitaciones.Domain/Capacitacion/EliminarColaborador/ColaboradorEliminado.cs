using Enee.Core.Common;

namespace Capacitaciones.Domain.Capacitacion.EliminarColaborador;

public class ColaboradorEliminado:DomainEvent<Guid>
{
    public ColaboradorEliminado(Guid aggregateId) : base(aggregateId)
    {
    }
}
