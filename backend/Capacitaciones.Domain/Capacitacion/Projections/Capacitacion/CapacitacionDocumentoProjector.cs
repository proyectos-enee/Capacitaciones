using Enee.Core.CQRS.Query;
using Capacitaciones.Domain.Capacitacion.CrearCapacitacion;
using Capacitaciones.Domain.Capacitacion.EliminarCapacitacion;
using Capacitaciones.Domain.Capacitacion.ActualizarCapacitacion;

namespace Capacitaciones.Domain.Capacitacion.Projections.Capacitacion;

public class CapacitacionDocumentoProjector : DocumentProjector<CapacitacionDocumento>
{
    public CapacitacionDocumentoProjector()
    {
        // Manejador para el evento CapacitacionCreada
        Create<CapacitacionCreada>((@event, documento) =>
        {
            documento.Id = @event.AggregateId;
            documento.CodigoCapacitacion = @event.CodigoCapacitacion;
            documento.NombreCorto = @event.NombreCorto;
            documento.NombreLargo = @event.NombreLargo;
            documento.Descripcion = @event.Descripcion;
            documento.EnteCapacitador = @event.EnteCapacitador;
            documento.Modalidad = @event.Modalidad;
            documento.Lugar = @event.Lugar;
            documento.Horario = @event.Horario;
            documento.FechaInicioRegistro = @event.FechaInicioRegistro;
            documento.FechaFinRegistro = @event.FechaFinRegistro;
            documento.Estado = @event.Estado;
            //documento.Otro = "Otro";
        });

        // Manejador para el evento CapacitacionActualizada (actualiza el documento existente)
        Project<CapacitacionActualizada>((@event, documento) =>
        {
            // Aquí solo actualizamos las propiedades que han cambiado
            documento.NombreCorto = @event.NombreCorto;
            documento.NombreLargo = @event.NombreLargo;
            documento.Descripcion = @event.Descripcion;
            documento.EnteCapacitador = @event.EnteCapacitador;
            documento.Modalidad = @event.Modalidad;
            documento.Lugar = @event.Lugar;
            documento.Horario = @event.Horario;
            documento.FechaInicioRegistro = @event.FechaInicioRegistro;
            documento.FechaFinRegistro = @event.FechaFinRegistro;
            documento.Estado = @event.Estado;
        });

        // Manejador para el evento CapacitacionEliminada
        Deleted<CapacitacionEliminada>();
    }
}

