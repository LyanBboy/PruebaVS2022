namespace ItemsDeTrabajo.Data.Interfaces
{
    using ItemsDeTrabajo.Entidad.Dto;
    using ItemsDeTrabajo.Entidad.Models;

    public interface IItemTrabajoRepositorio
    {
        Task<IEnumerable<ItemTrabajo>> ObtenerItemsAsync(string estado = "");
        Task CrearItemAsync(DtoItemTrabajoRegistro item);
        Task ActualizarItemAsync(ItemTrabajo itemDeTrabajo);
    }
}
