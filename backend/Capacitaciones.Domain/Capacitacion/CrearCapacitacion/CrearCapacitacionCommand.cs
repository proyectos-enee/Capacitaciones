
using Enee.Core.CQRS.Command;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Capacitaciones.Domain.Capacitacion.CrearCapacitacion;

public record CrearCapacitacionCommand(Guid Id, string CodigoCapacitacion, string NombreCorto, string NombreLargo, string Descripcion,string EnteCapacitador,string Modalidad, string Lugar, string Horario ,DateTime FechaInicioRegistro, DateTime FechaFinRegistro, string Estado) : ICommand;
