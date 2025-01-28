using Enee.Core.Common;
using Enee.Core.CQRS.Query;
using Enee.Core.Domain;

namespace Capacitaciones.Domain.Capacitacion.Projections.Colaboradores;

[DocumentName("colaboradores_documento")]
public class ColaboradoresDocumento : Document<Guid>
{

    public string ClaveEmpleado { get; set; }
    public string Nombre { get; set; }
    public string Cargo { get; set; }
    public string Dependencia { get; set; }

    public string Correo { get; set; }



    public DateTime FechaRegistro { get; set; }
    public string Estado { get; set; }
}
