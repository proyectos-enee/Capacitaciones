using Enee.Core.CQRS.Query;
using Capacitaciones.Domain.Capacitacion.Projections.Capacitacion;
using System.Collections.Generic;

namespace Capacitaciones.Domain.Capacitacion.ConsultaCapacitacionesDisponibles
{
    public class ConsultaCapacitacionesDisponibles : IQuery<IEnumerable<CapacitacionDocumento>>
    {
        public string Description { get; } = "Consulta de capacitaciones disponibles";

        public string? NombreCorto { get; set; }
        public string? Modalidad { get; set; }
        public DateTime? FechaInicioRegistro { get; set; }
        public DateTime? FechaFinRegistro { get; set; }
    }
}
