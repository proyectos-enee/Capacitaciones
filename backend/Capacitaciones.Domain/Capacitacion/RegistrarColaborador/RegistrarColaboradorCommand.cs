using Enee.Core.CQRS.Command;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Capacitaciones.Domain.Capacitacion.RegistrarColaborador;

public record RegistrarColaboradorCommand(string ClaveEmpleado, string CodigoCapacitacion) : ICommand;
