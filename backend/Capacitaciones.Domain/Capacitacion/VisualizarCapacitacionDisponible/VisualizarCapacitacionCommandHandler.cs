namespace Capacitaciones.Domain.Capacitacion.LeerCapacitacion;

public class LeerCapacitacionesDisponiblesCommandHandler : IQueryHandler<LeerCapacitacionesDisponiblesCommand, List<CapacitacionResponse>>
{
    private readonly ICapacitacionRepository _repository;

    public LeerCapacitacionesDisponiblesCommandHandler(ICapacitacionRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<CapacitacionResponse>> Handle(LeerCapacitacionesDisponiblesCommand query)
    {
        var capacitaciones = await _repository.GetCapacitacionesDisponibles(query.Nombre, query.Modalidad, query.FechaInicio, query.FechaFin);

        return capacitaciones.Select(c => new CapacitacionResponse
        {
            Id = c.Id,
            CodigoCapacitacion = c.CodigoCapacitacion,
            NombreCorto = c.NombreCorto,
            Estado = c.Estado
        }).ToList();
    }
}
