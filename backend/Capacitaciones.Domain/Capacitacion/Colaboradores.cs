using Enee.Core.Domain;
using Capacitaciones.Domain.Capacitacion.CrearColaborador;
using Capacitaciones.Domain.Capacitacion.EliminarColaborador;
using Capacitaciones.Domain.Capacitacion.ActualizarColaborador;


namespace Capacitaciones.Domain.Capacitacion;

public class Colaboradores : AggregateRoot<Guid>
{
    // Constructor por defecto requerido para la reconstrucción de agregados
    public Colaboradores()
    {
    }

    // Constructor para crear una nueva capacitación
    public Colaboradores(
        Guid id,
        string claveEmpleado,
        string nombre,
        string apellido,
        string email,
        string password,
        DateTime fechaRegistro,
        string estado)
    {
        Apply(NewChange(new ColaboradorCreado(
            id,
            claveEmpleado,
            nombre,
            apellido,
            email,
            password,
            fechaRegistro,
            estado
        )));
    }

    // Propiedades del agregado
    public override Guid Id { get; set; }
    public string ClaveEmpleado { get; set; }
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public string? Email { get; set; }
    public string Password { get; set; }
    public DateTime FechaRegistro { get; set; }
    public string Estado { get; set; }
    public bool IsDeleted { get; private set; } // Nueva propiedad

    // Método para eliminar la capacitación
    public void Eliminar()
    {
        IsDeleted = true; // Marcar como eliminado
        Apply(NewChange(new ColaboradorEliminado(Id)));
    }

    // Método para comparar datos
    public bool EsIgual(
        string claveEmpleado,
        string nombre,
        string apellido,
        string email,
        string password,
        DateTime fechaRegistro,
        string estado)
    {
        return this.ClaveEmpleado == claveEmpleado &&
               this.Nombre == nombre &&
               this.Apellido == apellido &&
               this.Email == email &&
               this.Password == password &&
               this.FechaRegistro == fechaRegistro &&
               this.Estado == estado;
    }

    // Métodos para aplicar eventos de dominio
    private void Apply(ColaboradorCreado @event)
    {
        Id = @event.AggregateId;
        ClaveEmpleado = @event.ClaveEmpleado;
        Nombre = @event.Nombre;
        Apellido = @event.Apellido;
        Email = @event.Email;
        Password = @event.Password;
        FechaRegistro = @event.FechaRegistro;
        Estado = @event.Estado;
        Version++;
    }

    public void Actualizar(
        string claveEmpleado,
        string nombre,
        string apellido,
        string email,
        string password,
        DateTime fechaRegistro,
        string estado)
    {
        var colaboradores = new ColaboradorActualizado
        (  Id,
        nombre,
        apellido,
        email,
        password,


        fechaRegistro,

        estado);

        Apply(NewChange(colaboradores));
    }

    public void Apply(ColaboradorActualizado  colaboradorActualizado)
    {

        Nombre = colaboradorActualizado.Nombre;
        Apellido = colaboradorActualizado.Apellido;
        Email = colaboradorActualizado.Email;
        Password = colaboradorActualizado.Password;
        FechaRegistro = colaboradorActualizado.FechaRegistro;
        Estado = colaboradorActualizado.Estado;
        Version++;
    }

    private void Apply(ColaboradorEliminado @event)
    {

        Version++;
    }
}
