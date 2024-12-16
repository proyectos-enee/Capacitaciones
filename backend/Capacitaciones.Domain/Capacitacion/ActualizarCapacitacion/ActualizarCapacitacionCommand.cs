using Enee.Core.CQRS.Command;

namespace Capacitaciones.Domain.Capacitacion.ActualizarCapacitacion
{
    public record ActualizarCapacitacionCommand(
        Guid Id, string CodigoCapacitacion, string NombreCorto, string NombreLargo,
        string Descripcion, string EnteCapacitador, string Modalidad, string Lugar,
        string Horario, DateTime FechaInicioRegistro, DateTime FechaFinRegistro, string Estado) : ICommand;
}
