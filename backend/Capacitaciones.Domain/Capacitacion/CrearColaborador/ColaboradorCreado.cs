using Enee.Core.Common;

namespace Capacitaciones.Domain.Capacitacion.CrearColaborador;

public class ColaboradorCreado:DomainEvent<Guid>
{
    public ColaboradorCreado(Guid aggregateId,
        string claveEmpleado, string nombre,
        string apellido, string email, string password,
         DateTime fechaRegistro,
         string estado) : base(aggregateId)
    {
        ClaveEmpleado = claveEmpleado;
        Nombre = nombre;
        Apellido = apellido;
        Email = email ;
        Password = password;
        FechaRegistro = fechaRegistro;
        Estado = estado;
    }

    public string ClaveEmpleado { get; set; }
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public string? Email { get; set; }
    public string Password { get; set; }
    public DateTime FechaRegistro { get; set; }
    public string Estado { get; set; }
}
