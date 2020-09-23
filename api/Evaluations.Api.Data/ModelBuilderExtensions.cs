using Microsoft.EntityFrameworkCore;

namespace Evaluations.Api.Data
{
    public static class ModelBuilderExtensions
    {
        public static void ConfigureEntity<TEntity>(this ModelBuilder modelBuilder)where TEntity : class, IEntity {
            modelBuilder
                .Entity<TEntity>()
                .HasKey(x => x.Id);
            
            modelBuilder
                .Entity<TEntity>()
                .HasIndex(x => x.Organization);
        }
    }
}