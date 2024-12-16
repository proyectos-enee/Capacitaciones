using Enee.Core.Common;

namespace Capacitaciones.Domain.Capacitacion.ActualizarCapacitacion;

public class CapacitacionActualizada:DomainEvent<Guid>
{
    public CapacitacionActualizada(Guid aggregateId) : base(aggregateId)
    {
    }
}
