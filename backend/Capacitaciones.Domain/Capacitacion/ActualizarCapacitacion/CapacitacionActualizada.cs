﻿using Enee.Core.Common;

namespace Capacitaciones.Domain.Capacitacion.ActualizarCapacitacion;

public class CapacitacionActualizada : DomainEvent<Guid>
{
    public CapacitacionActualizada(Guid aggregateId,
        string nombreCorto,
        string nombreLargo,
        string descripcion,
        string enteCapacitador,
        string modalidad,
        string? lugar,
        string? horario,
        DateTime fechaInicioRegistro,
        DateTime fechaFinRegistro,
        string estado) : base(aggregateId)
    {
        NombreCorto = nombreCorto;
        NombreLargo = nombreLargo;
        Descripcion = descripcion;
        EnteCapacitador = enteCapacitador;
        Modalidad = modalidad;
        Lugar = lugar;
        Horario = horario;
        FechaInicioRegistro = fechaInicioRegistro;
        FechaFinRegistro = fechaFinRegistro;
        Estado = estado;
    }

    public string NombreCorto { get; set; }
    public string NombreLargo { get; set; }
    public string? Descripcion { get; set; }
    public string EnteCapacitador { get; set; }
    public string Modalidad { get; set; }
    public string? Lugar { get; set; }
    public string? Horario { get; set; }
    public DateTime FechaInicioRegistro { get; set; }
    public DateTime FechaFinRegistro { get; set; }
    public string Estado { get; set; }
}
