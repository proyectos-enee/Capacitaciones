using Ardalis.EFCore.Extensions;
using Enee.Core.Common;
using Enee.Core.Data.EFCore;
using Microsoft.EntityFrameworkCore;

namespace Capacitaciones.Data
{
    

    public class DiscoverEfConfigurations : IModelBuildingStrategy
    {
        /// <summary>
        /// Busca configuraciones disponibles
        /// </summary>
        /// <param name="modelBuilder"></param>
        public void Invoke(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyAllConfigurationsFromCurrentAssembly();
      
            var entites = modelBuilder.Model
                .GetEntityTypes();
                
            foreach (var entityType in entites)
            {
                if (typeof(IAuditable).IsAssignableFrom(entityType.ClrType))
                {
                    entityType.AddSoftDeleteQueryFilter();
                }
            }
        }

      
    }
}
