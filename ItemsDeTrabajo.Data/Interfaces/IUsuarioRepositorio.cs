namespace ItemsDeTrabajo.Data.Interfaces
{
    using ItemsDeTrabajo.Entidad.Dto;

    public interface IUsuarioRepositorio
    {
        List<DtoUsuarioVista> ObtenerUsuarios();
    }
}
