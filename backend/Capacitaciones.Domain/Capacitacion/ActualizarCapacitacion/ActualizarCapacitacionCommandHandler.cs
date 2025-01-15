﻿using Enee.Core.CQRS.Command;
using Enee.Core.Domain.Repository;
using Capacitaciones.Domain.Exceptions;
namespace Capacitaciones.Domain.Capacitacion.ActualizarCapacitacion;

public class ActualizarCapacitacionCommandHandler : ICommandHandler<ActualizarCapacitacionCommand>
{
    public IWritableEventStoreRepository<Capacitacion> Repository { get; }

    public ActualizarCapacitacionCommandHandler(IWritableEventStoreRepository<Capacitacion> repository)
    {
        Repository = repository;
    }

    public async Task Handle(ActualizarCapacitacionCommand command)
    {
        // Verificar si la capacitación existe
        var capacitacion = await Repository.Find(command.Id);
        if (capacitacion == null)
        {
            throw new NotFoundException($"La capacitación con Id {command.Id} no existe.");
        }

        // Validar datos (ejemplo de validación adicional)
        if (string.IsNullOrWhiteSpace(command.NombreCorto))
        {
            throw new ValidationException("El nombre corto es obligatorio.");
        }

        // Verificar si hay cambios antes de actualizar
        if (capacitacion.EsIgual(
            command.NombreCorto,
            command.NombreLargo,
            command.Descripcion,
            command.EnteCapacitador,
            command.Modalidad,
            command.Lugar,
            command.Horario,
            command.FechaInicioRegistro,
            command.FechaFinRegistro,
            command.Estado))
        {
            return; // No realizar actualización si no hay cambios
        }

        // Actualizar la entidad
        capacitacion.Actualizar(
            command.NombreCorto,
            command.NombreLargo,
            command.Descripcion,
            command.EnteCapacitador,
            command.Modalidad,
            command.Lugar,
            command.Horario,
            command.FechaInicioRegistro,
            command.FechaFinRegistro,
            command.Estado);

        try
        {
            await Repository.Update(capacitacion);
        }
        catch (Exception ex)
        {
            // Manejo de errores durante la actualización
            throw new RepositoryException("Error al actualizar la capacitación.", ex);
        }
    }
}
