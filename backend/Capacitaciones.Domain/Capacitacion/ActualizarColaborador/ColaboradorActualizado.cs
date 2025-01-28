using Enee.Core.Common;

namespace Capacitaciones.Domain.Capacitacion.ActualizarColaborador;

public class ColaboradorActualizado : DomainEvent<Guid>
{
    public ColaboradorActualizado(Guid aggregateId,
        string nombre,
        string cargo,
        string correo,
        string dependencia,
        DateTime fechaRegistro,
        string estado) : base(aggregateId)
    {
        Nombre = nombre;
        Cargo = cargo;
        Correo = correo;
        Dependencia = dependencia;
        FechaRegistro = fechaRegistro;
        Estado = estado;
    }

    public string Nombre { get; set; }
    public string Cargo { get; set; }
    public string? Correo { get; set; }
    public string Dependencia { get; set; }
    public DateTime FechaRegistro { get; set; }
    public string Estado { get; set; }
}
