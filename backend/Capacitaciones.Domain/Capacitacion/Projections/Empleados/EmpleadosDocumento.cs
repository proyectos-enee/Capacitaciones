using Enee.Core.Common;
using Enee.Core.CQRS.Query;
using Enee.Core.Domain;

namespace Capacitaciones.Domain.Capacitacion.Projections.Empleados;

[DocumentName("empleados_documento")]
public class EmpleadosDocumento : Document<Guid>
{
    public string ClaveEmpleado { get; set; } // Identificador único del empleado
    public string Nombre { get; set; }       // Nombre completo del empleado
    public string Cargo { get; set; }        // Puesto del empleado
    public string Dependencia { get; set; }  // Departamento o área del empleado
    public string Correo { get; set; }       // Correo electrónico del empleado
    public string Telefono { get; set; }     // Opcional: Teléfono de contacto
    public string Estado { get; set; }       // Activo/Inactivo
}
