using Enee.Core.Common;

namespace Capacitaciones.Domain.Capacitacion.CrearColaborador;

public class ColaboradorCreado:DomainEvent<Guid>
{
    public ColaboradorCreado(Guid aggregateId,
        string claveEmpleado, string nombre,
        string cargo, string correo, string dependencia,
         DateTime fechaRegistro,
         string estado) : base(aggregateId)
    {
        ClaveEmpleado = claveEmpleado;
        Nombre = nombre;
        Cargo = cargo;
        Correo = correo ;
        Dependencia = dependencia;
        FechaRegistro = fechaRegistro;
        Estado = estado;
    }

    public string ClaveEmpleado { get; set; }
    public string Nombre { get; set; }
    public string Cargo { get; set; }
    public string? Correo { get; set; }
    public string Dependencia { get; set; }
    public DateTime FechaRegistro { get; set; }
    public string Estado { get; set; }
}
