using Enee.Core.Common;

namespace Capacitaciones.Domain.Capacitacion.Events;

public class ColaboradorRegistrado : DomainEvent<Guid>
{
    public ColaboradorRegistrado(Guid aggregateId, string claveEmpleado, string nombre, string cargo, string dependencia, string correoElectronico)
        : base(aggregateId)
    {
        ClaveEmpleado = claveEmpleado;
        Nombre = nombre;
        Cargo = cargo;
        Dependencia = dependencia;
        CorreoElectronico = correoElectronico;
    }

    public string ClaveEmpleado { get; set; }
    public string Nombre { get; set; }
    public string Cargo { get; set; }
    public string Dependencia { get; set; }
    public string CorreoElectronico { get; set; }
}
