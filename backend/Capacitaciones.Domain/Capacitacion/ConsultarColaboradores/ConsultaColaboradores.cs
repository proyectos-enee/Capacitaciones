using Enee.Core.CQRS.Query;
using Capacitaciones.Domain.Capacitacion.Projections.Colaboradores;

namespace Capacitaciones.Domain.Capacitacion.ConsultarColaboradores;

public class ConsultaColaboradores : IQuery<IEnumerable<ColaboradoresDocumento>>
{
    public string Description { get; } = "Consulta de colaboradores sin paginación";

    public string? ClaveEmpleado { get; set; }

}
