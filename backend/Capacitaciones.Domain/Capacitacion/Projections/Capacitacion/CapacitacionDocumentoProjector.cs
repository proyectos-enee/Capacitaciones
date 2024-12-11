using Enee.Core.CQRS.Query;
using Capacitaciones.Domain.Capacitacion.CrearCapacitacion;
using Capacitaciones.Domain.Capacitacion.EliminarCapacitacion;

namespace Capacitaciones.Domain.Capacitacion.Projections.Capacitacion;

public class CapacitacionDocumentoProjector:DocumentProjector<CapacitacionDocumento>
{

    public CapacitacionDocumentoProjector()
    {
        Create<CapacitacionCreada>((@event, documento) =>
        {
            documento.Id = @event.AggregateId;
            documento.CodigoCapacitacion = @event.CodigoCapacitacion;
            documento.NombreCorto  = @event.NombreCorto ;
            documento.NombreLargo  = @event.NombreLargo ;
            documento.Descripcion  = @event.Descripcion ;
            documento.EnteCapacitador  = @event.EnteCapacitador; ;
            documento.Modalidad  = @event.Modalidad ;
            documento.Lugar  = @event.Lugar ;
            documento.Horario  = @event.Horario ;
            documento.FechaInicioRegistro  = @event.FechaInicioRegistro ;
            documento.FechaFinRegistro  = @event.FechaFinRegistro ;
            documento.Estado  = @event.Estado;
            //documento.Otro = "Otro";

        });


        Deleted<CapacitacionEliminada>();
    }
}
