using Enee.Core.CQRS.Command;

namespace Capacitaciones.Domain.Capacitacion.EliminarCapacitacion
{
    // Cambiamos el parámetro de 'id' a 'codigoCapacitacion'
    public record EliminarCapacitacionCommand(string CodigoCapacitacion) : ICommand;
}
