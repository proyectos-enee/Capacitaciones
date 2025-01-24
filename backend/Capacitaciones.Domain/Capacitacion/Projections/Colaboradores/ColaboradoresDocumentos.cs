using Enee.Core.Common;
using Enee.Core.CQRS.Query;
using Enee.Core.Domain;

namespace Capacitaciones.Domain.Capacitacion.Projections.Colaboradores;

[DocumentName("colaboradores_documento")]
public class ColaboradoresDocumento : Document<Guid>
{
    public  Guid Id { get; set; }
    public string ClaveEmpleado { get; set; }
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public string? Email { get; set; }
    public string Password { get; set; }
    public string Modalidad { get; set; }
    public DateTime FechaRegistro { get; set; }
    public string Estado { get; set; }
}
