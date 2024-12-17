﻿using Enee.Core.Domain;
using Capacitaciones.Domain.Capacitacion.CrearCapacitacion;
using Capacitaciones.Domain.Capacitacion.EliminarCapacitacion;
using Capacitaciones.Domain.Capacitacion.ActualizarCapacitacion;

namespace Capacitaciones.Domain.Capacitacion;

public class Capacitacion : AggregateRoot<Guid>
{
    // Constructor por defecto requerido para la reconstrucción de agregados
    public Capacitacion()
    {
    }

    // Constructor para crear una nueva capacitación
    public Capacitacion(
        Guid id,
        string codigoCapacitacion,
        string nombreCorto,
        string nombreLargo,
        string descripcion,
        string enteCapacitador,
        string modalidad,
        string? lugar,
        string? horario,
        DateTime fechaInicioRegistro,
        DateTime fechaFinRegistro,
        string estado)
    {
        Apply(NewChange(new CapacitacionCreada(
            id,
            codigoCapacitacion,
            nombreCorto,
            nombreLargo,
            descripcion,
            enteCapacitador,
            modalidad,
            lugar,
            horario,
            fechaInicioRegistro,
            fechaFinRegistro,
            estado
        )));
    }

    // Propiedades del agregado
    public override Guid Id { get; set; }
    public string CodigoCapacitacion { get; private set; }
    public string NombreCorto { get; private set; }
    public string NombreLargo { get; private set; }
    public string? Descripcion { get; private set; }
    public string EnteCapacitador { get; private set; }
    public string Modalidad { get; private set; }
    public string? Lugar { get; private set; }
    public string? Horario { get; private set; }
    public DateTime FechaInicioRegistro { get; private set; }
    public DateTime FechaFinRegistro { get; private set; }
    public string Estado { get; private set; }

    // Método para eliminar la capacitación
    public void Eliminar()
    {
        Apply(NewChange(new CapacitacionEliminada(Id)));
    }

    // Método para actualizar los datos de la capacitación
    public void Actualizar(
        string codigoCapacitacion,
        string nombreCorto,
        string nombreLargo,
        string descripcion,
        string enteCapacitador,
        string modalidad,
        string? lugar,
        string? horario,
        DateTime fechaInicioRegistro,
        DateTime fechaFinRegistro,
        string estado)
    {
        Apply(NewChange(new CapacitacionActualizada(
            Id,
            codigoCapacitacion,
            nombreCorto,
            nombreLargo,
            descripcion,
            enteCapacitador,
            modalidad,
            lugar,
            horario,
            fechaInicioRegistro,
            fechaFinRegistro,
            estado
        )));
    }

    // Métodos para aplicar eventos de dominio
    private void Apply(CapacitacionCreada @event)
    {
        Id = @event.AggregateId;
        CodigoCapacitacion = @event.CodigoCapacitacion;
        NombreCorto = @event.NombreCorto;
        NombreLargo = @event.NombreLargo;
        Descripcion = @event.Descripcion;
        EnteCapacitador = @event.EnteCapacitador;
        Modalidad = @event.Modalidad;
        Lugar = @event.Lugar;
        Horario = @event.Horario;
        FechaInicioRegistro = @event.FechaInicioRegistro;
        FechaFinRegistro = @event.FechaFinRegistro;
        Estado = @event.Estado;
        Version++;
    }

    private void Apply(CapacitacionActualizada @event)
    {
        CodigoCapacitacion = @event.CodigoCapacitacion;
        NombreCorto = @event.NombreCorto;
        NombreLargo = @event.NombreLargo;
        Descripcion = @event.Descripcion;
        EnteCapacitador = @event.EnteCapacitador;
        Modalidad = @event.Modalidad;
        Lugar = @event.Lugar;
        Horario = @event.Horario;
        FechaInicioRegistro = @event.FechaInicioRegistro;
        FechaFinRegistro = @event.FechaFinRegistro;
        Estado = @event.Estado;
        Version++;
    }

    private void Apply(CapacitacionEliminada @event)
    {
        Version++;
    }
}
