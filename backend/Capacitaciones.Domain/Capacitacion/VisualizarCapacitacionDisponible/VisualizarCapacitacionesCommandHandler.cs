using Enee.Core.CQRS.Command;
using Enee.Core.Domain.Repository;


//namespace Capacitaciones.Domain.Capacitacion.VisualizarCapacitacionDisponible;

//public class VisualizarCapacitacionesCommandHandler : ICommandHandler<VisualizarCapacitacionesCommand, List<CapacitacionDisponibleResponse>>
//{
  //  private readonly IReadOnlyEventStoreRepository<Capacitacion> _repository;

    //public VisualizarCapacitacionesCommandHandler(IReadOnlyEventStoreRepository<Capacitacion> repository)
  //  {
      //  _repository = repository;
    //}

    //public async Task<List<CapacitacionDisponibleResponse>> Handle(VisualizarCapacitacionesCommand command)
    //{
      //  var capacitaciones = await _repository.GetAll();

        // Filtrar por estado disponible y fechas no vencidas
        //var disponibles = capacitaciones
          //  .Where(c => c.Estado == "disponible" && c.FechaFinRegistro >= DateTime.UtcNow);

        // Aplicar filtros adicionales
        //if (!string.IsNullOrEmpty(command.Nombre))
      //  {
          //  disponibles = disponibles.Where(c => c.NombreCorto.Contains(command.Nombre, StringComparison.OrdinalIgnoreCase));
        //}

        //if (!string.IsNullOrEmpty(command.Modalidad))
        //{
          //  disponibles = disponibles.Where(c => c.Modalidad.Equals(command.Modalidad, StringComparison.OrdinalIgnoreCase));
        //}

        //if (command.FechaInicio.HasValue)
        //{
          //  disponibles = disponibles.Where(c => c.FechaInicioRegistro >= command.FechaInicio.Value);
        //}

        //if (command.FechaFin.HasValue)
        //{
          //  disponibles = disponibles.Where(c => c.FechaFinRegistro <= command.FechaFin.Value);
       // }

        //return disponibles.Select(c => new CapacitacionDisponibleResponse
     //   {
          //  Id = c.Id,
            //CodigoCapacitacion = c.CodigoCapacitacion,
            //NombreCorto = c.NombreCorto,
            //Modalidad = c.Modalidad,
            //FechaInicioRegistro = c.FechaInicioRegistro,
            //FechaFinRegistro = c.FechaFinRegistro,
            //Estado = c.Estado
        //}).ToList();
  //  }
//}
