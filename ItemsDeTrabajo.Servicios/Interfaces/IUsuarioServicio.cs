namespace ItemsDeTrabajo.Servicios.Interfaces
{
    using ItemsDeTrabajo.Entidad.Dto;

    public interface IUsuarioServicio
    {
        List<DtoUsuarioVista> ObtenerUsuarios();
        Task <List<DtoUsuarioItemTrabajo>> ObtenerItemsTrabajo();
    }
}
