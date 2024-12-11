using Enee.Core.Common;
using Enee.Core.CQRS.Query;
using Enee.Core.Domain;

namespace Capacitaciones.Domain.Capacitacion.Projections.Capacitacion;

[DocumentName("capacitacion_documento")]
public class CapacitacionDocumento : Document<Guid>
{
    public  Guid Id { get; set; }
    public string CodigoCapacitacion { get; set; }
    public string NombreCorto { get; set; }
    public string NombreLargo { get; set; }
    public string? Descripcion { get; set; }
    public string EnteCapacitador { get; set; }
    public string Modalidad { get; set; }
    public string? Lugar { get; set; }
    public string? Horario { get; set; }
    public DateTime FechaInicioRegistro { get; set; }
    public DateTime FechaFinRegistro { get; set; }
    public string Estado { get; set; }
}
