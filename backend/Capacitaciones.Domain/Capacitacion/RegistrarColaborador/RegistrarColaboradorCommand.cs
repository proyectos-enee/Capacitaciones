using Enee.Core.CQRS.Command;

namespace Capacitaciones.Domain.Capacitacion.RegistrarColaborador;

public record RegistrarColaboradorCommand(Guid Id, string ClaveEmpleado, string Nombre, string Cargo, string Dependencia, string CorreoElectronico) : ICommand;
