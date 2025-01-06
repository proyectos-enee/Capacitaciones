﻿using Enee.Core.Common;

namespace Capacitaciones.Domain.Capacitacion.EliminarCapacitacion;

public class CapacitacionEliminada:DomainEvent<Guid>
{
    public CapacitacionEliminada(Guid aggregateId) : base(aggregateId)
    {
    }
}
