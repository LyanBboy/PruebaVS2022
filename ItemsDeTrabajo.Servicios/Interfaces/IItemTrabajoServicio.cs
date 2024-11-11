namespace ItemsDeTrabajo.Servicios.Interfaces
{
    using ItemsDeTrabajo.Entidad.Dto;

    public interface IItemTrabajoServicio
    {
        Task<int> CrearItemAsync(DtoItemTrabajoRegistro item);

        Task<int> CrearYDistribuirItemAsync(DtoItemTrabajoRegistro item);

        Task<int> DistribuirItemsAsync();

        Task<int> FinalizarItemAsync(DtoItemTrabajoTermina item);

        Task<List<DtoItemTrabajoVista>> ObtenerItemTareas();
    }
}
