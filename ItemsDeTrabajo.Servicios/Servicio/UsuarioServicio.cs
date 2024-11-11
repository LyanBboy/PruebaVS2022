namespace ItemsDeTrabajo.Servicios.Servicio
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using ItemsDeTrabajo.Entidad.Dto;
    using ItemsDeTrabajo.Data.Interfaces;
    using ItemsDeTrabajo.Servicios.Interfaces;

    public class UsuarioServicio : IUsuarioServicio
    {
        private readonly IUsuarioRepositorio _repositorioUsuario;

        private readonly IItemTrabajoRepositorio _repositorioItemTrabajo;

        public UsuarioServicio(IUsuarioRepositorio repositorioUsuario)
        {
            _repositorioUsuario = repositorioUsuario;
        }

        public UsuarioServicio(IUsuarioRepositorio repositorioUsuario, IItemTrabajoRepositorio repositorioItemTrabajo)
        {
            _repositorioUsuario = repositorioUsuario;
            _repositorioItemTrabajo = repositorioItemTrabajo;
        }

        public List<DtoUsuarioVista> ObtenerUsuarios()
        {
            return _repositorioUsuario.ObtenerUsuarios();
        }

        public async Task<List<DtoUsuarioItemTrabajo>> ObtenerItemsTrabajo()
        {
            List<DtoUsuarioItemTrabajo> resultado = new List<DtoUsuarioItemTrabajo>();

            var itemsTrabajo = await _repositorioItemTrabajo.ObtenerItemsAsync();

            var itemsTrabajoGrupo = itemsTrabajo.Where(it => it.UserName != null && !String.IsNullOrWhiteSpace(it.UserName)).GroupBy(g => g.UserName).ToList();

            if (itemsTrabajoGrupo.Any())
            {
                foreach (var item in itemsTrabajoGrupo)
                {
                    DtoUsuarioItemTrabajo usuarioItemTrabajoNew = new DtoUsuarioItemTrabajo();
                    usuarioItemTrabajoNew.UserName = item.Key;
                    usuarioItemTrabajoNew.CantidadPendientes = item.Count(c => c.Estado.ToUpper() == "PENDIENTE");
                    usuarioItemTrabajoNew.CantidadCompletados = item.Count(c => c.Estado.ToUpper() == "COMPLETADO");
                    usuarioItemTrabajoNew.CantidadRelevanciaAlta = item.Count(c => c.Estado.ToUpper() == "PENDIENTE" && c.Relevancia.ToLower() == "alta");
                    resultado.Add(usuarioItemTrabajoNew);
                }
            }

            return resultado;
        }
    }
}
