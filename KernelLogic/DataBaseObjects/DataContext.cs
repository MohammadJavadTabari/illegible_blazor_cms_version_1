using KernelLogic.DataBaseObjects.Entities;
using KernelLogic.DataBaseObjects.ReflectionHelper;
using Microsoft.EntityFrameworkCore;

namespace KernelLogic.DataBaseObjects
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema("dbo");

            var assembly = typeof(IBaseEntity).Assembly;
            //dbset entities
            modelBuilder.RegisterAllEntities<IBaseEntity>(assembly);

            //config entities (config shiits like IEntityTypeConfiguration,.....)
            modelBuilder.RegisterEntityTypeConfiguration(assembly);

        }
    }
}
