using Enee.Core.Common;

namespace Capacitaciones.Domain.Parametros.CrearCatalogo;

public class CatalogoCreado:DomainEvent<Guid>
{
    public string Nombre { get; set;}

    public CatalogoCreado(Guid aggregateId,string nombre) : base(aggregateId)
    {
        Nombre = nombre;
    }
}