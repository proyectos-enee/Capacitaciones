using Enee.Core.CQRS.Query;
using Ardalis.Specification;
using Capacitaciones.Domain.Capacitacion.CrearColaborador;
using Capacitaciones.Domain.Capacitacion.EliminarColaborador;
using Capacitaciones.Domain.Capacitacion.ActualizarColaborador;
using JasperFx.Core;

namespace Capacitaciones.Domain.Capacitacion.Projections.Colaboradores;


public class ColaboradoresDocumentoProjector : DocumentProjector<ColaboradoresDocumento>
{
    public ColaboradoresDocumentoProjector()
    {
        // Manejador para el evento CapacitacionCreada
        Create<ColaboradorCreado>((@event, documento) =>
        {

            documento.ClaveEmpleado = @event.ClaveEmpleado;
            documento.Nombre = @event.Nombre;
            documento.Cargo = @event.Cargo;
            documento.Correo = @event.Correo;
            documento.Dependencia = @event.Dependencia;
            documento.FechaRegistro = @event.FechaRegistro;
            documento.Estado = @event.Estado;
            //documento.Otro = "Otro";
        });

        // Manejador para el evento CapacitacionActualizada (actualiza el documento existente)
        Project<ColaboradorActualizado>((@event, documento) =>
        {
            // Aquí solo actualizamos las propiedades que han cambiado

            documento.Nombre = @event.Nombre;
            documento.Cargo = @event.Cargo;
            documento.Correo = @event.Correo;
            documento.Dependencia = @event.Dependencia;
            documento.FechaRegistro = @event.FechaRegistro;
            documento.Estado = @event.Estado;
        });

        // Manejador para el evento CapacitacionEliminada
        Deleted<ColaboradorEliminado>();
    }
}
