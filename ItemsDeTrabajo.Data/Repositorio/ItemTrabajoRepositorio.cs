namespace ItemsDeTrabajo.Data.Repositorio
{
    using Microsoft.EntityFrameworkCore;
    using Contexto;
    using Entidad.Models;
    using ItemsDeTrabajo.Data.Interfaces;
    using ItemsDeTrabajo.Entidad.Dto;

    public class ItemTrabajoRepositorio : IItemTrabajoRepositorio
    {
        private readonly ItemTrabajoDbContext _context;

        public ItemTrabajoRepositorio(ItemTrabajoDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ItemTrabajo>> ObtenerItemsAsync(string estado = "")
        {
            if (string.IsNullOrEmpty(estado))
            {
                return await _context.ItemTrabajos.ToListAsync();
            }
            else
            {
                return await _context.ItemTrabajos.Where(i => i.Estado.ToUpper() == estado.ToUpper()).ToListAsync();
            }            
        }

        public async Task CrearItemAsync(DtoItemTrabajoRegistro item)
        {
            ItemTrabajo itemTrabajoNew = new ItemTrabajo();
            itemTrabajoNew.Descripcion = item.Descripcion;
            itemTrabajoNew.FechaCreacion = DateTime.Now;
            itemTrabajoNew.FechaEntrega = item.FechaEntrega;
            itemTrabajoNew.Relevancia = !string.IsNullOrWhiteSpace(item.Relevancia) ? item.Relevancia.ToLower() : "baja" ;
            itemTrabajoNew.Estado = "PENDIENTE";

            await _context.ItemTrabajos.AddAsync(itemTrabajoNew);
            await _context.SaveChangesAsync();
        }

        public async Task ActualizarItemAsync(ItemTrabajo itemDeTrabajo)
        {
            _context.ItemTrabajos.Update(itemDeTrabajo);

            await _context.SaveChangesAsync();
        }
    }
}
