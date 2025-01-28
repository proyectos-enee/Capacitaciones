using Enee.Core.CQRS.Command;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Capacitaciones.Domain.Capacitacion.CrearColaborador;

public record CrearColaboradorCommand(Guid Id, string ClaveEmpleado, string Nombre, string Cargo, string Correo,string Dependencia ,DateTime FechaRegistro, string Estado) : ICommand;
