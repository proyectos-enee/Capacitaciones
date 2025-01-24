using Enee.Core.CQRS.Command;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Capacitaciones.Domain.Capacitacion.CrearColaborador;

public record CrearColaboradorCommand(Guid Id, string ClaveEmpleado, string Nombre, string Apellido, string Email,string Password ,DateTime FechaRegistro, string Estado) : ICommand;
