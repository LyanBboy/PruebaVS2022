namespace ItemsDeTrabajo.Data.Contexto
{
    using Microsoft.EntityFrameworkCore;
    using Entidad.Models;

    public class ItemTrabajoDbContext : DbContext
    {
        public ItemTrabajoDbContext(DbContextOptions<ItemTrabajoDbContext> options) : base(options)
        {

        }

        public DbSet<ItemTrabajo> ItemTrabajos { get; set; }
    }
}
