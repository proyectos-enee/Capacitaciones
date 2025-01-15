using Carter;
using Capacitaciones.Api.Capacitacion.CrearCapacitacion;
using Capacitaciones.Api.Capacitacion.RecuperarCapacitacion;
using Capacitaciones.Api.Capacitacion.ActualizarCapacitacion;
using Capacitaciones.Api.Capacitacion.EliminarCapacitacion;
using Capacitaciones.Api.Capacitacion.RecuperarCapacitacionesDisponibles;



namespace Capacitaciones.Api.Capacitacion;

public class Endpoints:CarterModule
{
    public Endpoints():base("/api/v1/capacitacion")
    {
        this.WithTags("Capacitacion");

    }
    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.CrearCapacitacion();
        app.RecuperarCapacitacion();
        app.ActualizarCapacitacion();
        app.EliminarCapacitacion();
        app.RecuperarCapacitacionesDisponibles();






    }
}
