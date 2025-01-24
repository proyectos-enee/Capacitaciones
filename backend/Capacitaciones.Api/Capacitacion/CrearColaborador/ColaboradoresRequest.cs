namespace Capacitaciones.Api.Capacitacion.CrearColaborador;

public class ColaboradoresRequest
{
    public string ClaveEmpleado { get; set; }
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public string? Email { get; set; }
    public string Password { get; set; }
    public DateTime FechaRegistro { get; set; }
    public string Estado { get; set; }
}
