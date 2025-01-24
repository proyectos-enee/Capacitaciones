using Enee.Core.Common;

namespace Capacitaciones.Domain.Capacitacion.ActualizarColaborador;

public class ColaboradorActualizado : DomainEvent<Guid>
{
    public ColaboradorActualizado(Guid aggregateId,
        string nombre,
        string apellido,
        string email,
        string password,
        DateTime fechaRegistro,
        string estado) : base(aggregateId)
    {
        Nombre = nombre;
        Apellido = apellido;
        Email = email;
        Password = password;
        FechaRegistro = fechaRegistro;
        Estado = estado;
    }

    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public string? Email { get; set; }
    public string Password { get; set; }
    public DateTime FechaRegistro { get; set; }
    public string Estado { get; set; }
}
