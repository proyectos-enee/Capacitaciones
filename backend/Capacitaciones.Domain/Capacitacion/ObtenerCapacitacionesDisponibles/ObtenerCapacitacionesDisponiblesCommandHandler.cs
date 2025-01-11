using Enee.Core.CQRS.Command;
using Microsoft.EntityFrameworkCore;

namespace Capacitaciones.Domain.Capacitacion.ObtenerCapacitacionesDisponibles;

public class ObtenerCapacitacionesDisponiblesCommandHandler : ICommandHandler<ObtenerCapacitacionesDisponiblesCommand, IEnumerable<CapacitacionDisponible>>
{
    private readonly DbContext _dbContext;

    public ObtenerCapacitacionesDisponiblesCommandHandler(DbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<CapacitacionDisponible>> Handle(ObtenerCapacitacionesDisponiblesCommand command)
    {
        var capacitaciones = _dbContext.Set<Capacitacion>().AsQueryable();

        if (!string.IsNullOrEmpty(command.Modalidad))
        {
            capacitaciones = capacitaciones.Where(x => x.Modalidad == command.Modalidad);
        }

        if (!string.IsNullOrEmpty(command.Nombre))
        {
            capacitaciones = capacitaciones.Where(x => x.NombreLargo.Contains(command.Nombre));
        }

        if (command.FechaInicio.HasValue && command.FechaFin.HasValue)
        {
            capacitaciones = capacitaciones.Where(x =>
                x.FechaInicioRegistro >= command.FechaInicio.Value &&
                x.FechaFinRegistro <= command.FechaFin.Value);
        }

        capacitaciones = capacitaciones.Where(x => x.Estado == "disponible" && x.FechaFinRegistro >= DateTime.UtcNow);

        return await capacitaciones
            .Select(x => new CapacitacionDisponible
            {
                Id = x.Id,
                NombreLargo = x.NombreLargo,
                Modalidad = x.Modalidad,
                FechaInicioRegistro = x.FechaInicioRegistro,
                FechaFinRegistro = x.FechaFinRegistro,
                Estado = x.Estado
            })
            .ToListAsync();
    }
}
