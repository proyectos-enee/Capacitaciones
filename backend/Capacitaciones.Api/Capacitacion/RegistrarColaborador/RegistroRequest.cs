namespace Capacitaciones.Api.Capacitacion.RegistrarColaborador;

public class RegistroRequest
{
    public string ClaveEmpleado { get; set; }
    public Guid Id { get; set; } // ID de la capacitación a la que se quiere registrar
}
