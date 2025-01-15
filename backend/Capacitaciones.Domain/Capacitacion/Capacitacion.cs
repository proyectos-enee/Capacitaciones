using Enee.Core.Domain;
using Capacitaciones.Domain.Capacitacion.CrearCapacitacion;
using Capacitaciones.Domain.Capacitacion.EliminarCapacitacion;
using Capacitaciones.Domain.Capacitacion.ActualizarCapacitacion;


namespace Capacitaciones.Domain.Capacitacion;

public class Capacitacion : AggregateRoot<Guid>
{
    // Constructor por defecto requerido para la reconstrucción de agregados
    public Capacitacion()
    {
    }

    // Constructor para crear una nueva capacitación
    public Capacitacion(
        Guid id,
        string codigoCapacitacion,
        string nombreCorto,
        string nombreLargo,
        string descripcion,
        string enteCapacitador,
        string modalidad,
        string? lugar,
        string? horario,
        DateTime fechaInicioRegistro,
        DateTime fechaFinRegistro,
        string estado)
    {
        Apply(NewChange(new CapacitacionCreada(
            id,
            codigoCapacitacion,
            nombreCorto,
            nombreLargo,
            descripcion,
            enteCapacitador,
            modalidad,
            lugar,
            horario,
            fechaInicioRegistro,
            fechaFinRegistro,
            estado
        )));
    }

    // Propiedades del agregado
    public override Guid Id { get; set; }
    public string CodigoCapacitacion { get; set; }
    public string NombreCorto { get; set; }
    public string NombreLargo { get; set; }
    public string? Descripcion { get; set; }
    public string EnteCapacitador { get; set; }
    public string Modalidad { get; set; }
    public string? Lugar { get; set; }
    public string? Horario { get; set; }
    public DateTime FechaInicioRegistro { get; set; }
    public DateTime FechaFinRegistro { get; set; }
    public string Estado { get; set; }
    public bool IsDeleted { get; private set; } // Nueva propiedad

    // Método para eliminar la capacitación
    public void Eliminar()
    {
        IsDeleted = true; // Marcar como eliminado
        Apply(NewChange(new CapacitacionEliminada(Id)));
    }

    // Método para comparar datos
    public bool EsIgual(
        string nombreCorto,
        string nombreLargo,
        string descripcion,
        string enteCapacitador,
        string modalidad,
        string? lugar,
        string? horario,
        DateTime fechaInicioRegistro,
        DateTime fechaFinRegistro,
        string estado)
    {
        return this.NombreCorto == nombreCorto &&
               this.NombreLargo == nombreLargo &&
               this.Descripcion == descripcion &&
               this.EnteCapacitador == enteCapacitador &&
               this.Modalidad == modalidad &&
               this.Lugar == lugar &&
               this.Horario == horario &&
               this.FechaInicioRegistro == fechaInicioRegistro &&
               this.FechaFinRegistro == fechaFinRegistro &&
               this.Estado == estado;
    }

    // Métodos para aplicar eventos de dominio
    private void Apply(CapacitacionCreada @event)
    {
        Id = @event.AggregateId;
        CodigoCapacitacion = @event.CodigoCapacitacion;
        NombreCorto = @event.NombreCorto;
        NombreLargo = @event.NombreLargo;
        Descripcion = @event.Descripcion;
        EnteCapacitador = @event.EnteCapacitador;
        Modalidad = @event.Modalidad;
        Lugar = @event.Lugar;
        Horario = @event.Horario;
        FechaInicioRegistro = @event.FechaInicioRegistro;
        FechaFinRegistro = @event.FechaFinRegistro;
        Estado = @event.Estado;
        Version++;
    }

    public void Actualizar(
        string nombreCorto,
        string nombreLargo,
        string descripcion,
        string enteCapacitador,
        string modalidad,
        string? lugar,
        string? horario,
        DateTime fechaInicioRegistro,
        DateTime fechaFinRegistro,
        string estado)
    {
        NombreCorto = nombreCorto;
        NombreLargo = nombreLargo;
        Descripcion = descripcion;
        EnteCapacitador = enteCapacitador;
        Modalidad = modalidad;
        Lugar = lugar;
        Horario = horario;
        FechaInicioRegistro = fechaInicioRegistro;
        FechaFinRegistro = fechaFinRegistro;
        Estado = estado;

        // Incrementar versión u otras operaciones si es necesario
        Version++;
    }

    private void Apply(CapacitacionEliminada @event)
    {
        // Aquí puedes manejar cualquier lógica adicional cuando se elimina una capacitación,
        // como marcarla como eliminada, o simplemente actualizar la versión.
        Version++;
    }
}
