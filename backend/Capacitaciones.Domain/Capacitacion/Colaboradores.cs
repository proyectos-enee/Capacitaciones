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


    public Colaboradores(
        Guid id,
        string claveEmpleado,
        string nombre,
        string correo,
        string dependencia,
        string cargo,
        DateTime fechaRegistro,
        string estado)
    {
        Apply(NewChange(new ColaboradorCreado(
            id,
            claveEmpleado,
            nombre,
            correo,
            dependencia,
            cargo,
            fechaRegistro,
            estado
        )));
    }

    // Propiedades del agregado
    public override Guid Id { get; set; }
    public string ClaveEmpleado { get; set; }
    public string Nombre { get; set; }
    public string Cargo { get; set; }
    public string? Correo { get; set; }
    public string Dependencia { get; set; }
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
        string cargo,
        string correo,
        string dependencia,
        DateTime fechaRegistro,
        string estado)
    {
        return this.ClaveEmpleado == claveEmpleado &&
               this.Nombre == nombre &&
               this.Cargo == cargo &&
               this.Correo == correo &&
               this.Dependencia == dependencia &&
               this.FechaRegistro == fechaRegistro &&
               this.Estado == estado;
    }

    // Métodos para aplicar eventos de dominio
    private void Apply(ColaboradorCreado @event)
    {
        Id = @event.AggregateId;
        ClaveEmpleado = @event.ClaveEmpleado;
        Nombre = @event.Nombre;
        Cargo = @event.Cargo;
        Correo = @event.Correo;
        Dependencia = @event.Dependencia;
        FechaRegistro = @event.FechaRegistro;
        Estado = @event.Estado;
        Version++;
    }

    public void Actualizar(
        string claveEmpleado,
        string nombre,
        string cargo,
        string correo,
        string dependencia,
        DateTime fechaRegistro,
        string estado)
    {
        var colaboradores = new ColaboradorActualizado
        (  Id,
        nombre,
        cargo,
        correo,
        dependencia,


        fechaRegistro,

        estado);

        Apply(NewChange(colaboradores));
    }

    public void Apply(ColaboradorActualizado  colaboradorActualizado)
    {

        Nombre = colaboradorActualizado.Nombre;
        Cargo = colaboradorActualizado.Cargo;
        Correo = colaboradorActualizado.Correo;
        Dependencia = colaboradorActualizado.Dependencia;
        FechaRegistro = colaboradorActualizado.FechaRegistro;
        Estado = colaboradorActualizado.Estado;
        Version++;
    }

    private void Apply(ColaboradorEliminado @event)
    {

        Version++;
    }
}
