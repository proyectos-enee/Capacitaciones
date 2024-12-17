using Enee.Core.Common;

namespace Capacitaciones.Domain.Capacitacion.EliminarCapacitacion;

public class CapacitacionEliminada : DomainEvent<Guid>
{
    public CapacitacionEliminada(Guid aggregateId) : base(aggregateId)
    {
        // Constructor simple ya que eliminar solo requiere el ID
    }

    // Puedes agregar propiedades adicionales si necesitas más información sobre la eliminación
    public DateTime FechaEliminacion { get; } = DateTime.UtcNow;
}
