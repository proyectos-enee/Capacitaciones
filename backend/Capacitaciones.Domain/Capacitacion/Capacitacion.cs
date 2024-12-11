using Enee.Core.Domain;
using Capacitaciones.Domain.Capacitacion.CrearCapacitacion;
using Capacitaciones.Domain.Capacitacion.EliminarCapacitacion;

namespace Capacitaciones.Domain.Capacitacion;

public class Capacitacion:AggregateRoot<Guid>
{
    public Capacitacion()
    {

    }
    public Capacitacion(Guid id, string codigoCapacitacion, string nombreCorto, string nombreLargo, string descripcion, string enteCapacitador, string modalidad, string? lugar, string? horario, DateTime fechaInicioRegistro, DateTime fechaFinRegistro,  string estado)
    {
        Apply(NewChange(new CapacitacionCreada(id, codigoCapacitacion, nombreCorto, nombreLargo, descripcion, enteCapacitador, modalidad, lugar, horario, fechaInicioRegistro, fechaFinRegistro, estado)));
    }


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

    public void Eliminar()
    {
        Apply(NewChange(new CapacitacionEliminada(this.Id)));
    }

    private void Apply(CapacitacionCreada @event)
    {
        this.Id = @event.AggregateId;
        this.CodigoCapacitacion = @event.CodigoCapacitacion;
        this.NombreCorto  = @event.NombreCorto ;
        this.NombreLargo  = @event.NombreLargo ;
        this.Descripcion  = @event.Descripcion ;
        this.EnteCapacitador  = @event.EnteCapacitador ;
        this.Modalidad  = @event.Modalidad ;
        this.Lugar  = @event.Lugar ;
        this.NombreCorto  = @event.NombreCorto ;
        this.Horario  = @event.Horario ;
        this.FechaInicioRegistro  = @event.FechaInicioRegistro ;
        this.FechaFinRegistro  = @event.FechaFinRegistro ;
        this.Estado  = @event.Estado;
        Version++; // de validar en las pull request
    }

    private void Apply(CapacitacionEliminada @event)
    {
        Version++;
    }

}
