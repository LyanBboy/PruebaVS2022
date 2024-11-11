namespace ItemsDeTrabajo.Servicios.Servicio
{
    using ItemsDeTrabajo.Data.Interfaces;
    using ItemsDeTrabajo.Servicios.Interfaces;
    using ItemsDeTrabajo.Entidad.Dto;

    public class ItemTrabajoServicio : IItemTrabajoServicio
    {
        private readonly IItemTrabajoRepositorio _repositorio;

        private readonly IUsuarioServicio _repositorioUsuario;

        public ItemTrabajoServicio(IItemTrabajoRepositorio repositorio, IUsuarioServicio repositorioUsuario)
        {
            _repositorio = repositorio;
            _repositorioUsuario = repositorioUsuario;
        }

        protected int ValidarCrearItem(DtoItemTrabajoRegistro item)
        {
            if (!string.IsNullOrWhiteSpace(item.Relevancia) && item.Relevancia.ToLower() != "baja" && item.Relevancia.ToLower() != "alta")
            {
                return -1;
            }
            else if (item.FechaEntrega.Date <= DateTime.Now.Date)
            {
                return -2;
            }
            else
            {
                return 0;
            }
        }

        public async Task<int> CrearItemAsync(DtoItemTrabajoRegistro item)
        {
            var resultado = this.ValidarCrearItem(item);

            if (resultado == 0)
            {
                await _repositorio.CrearItemAsync(item);
            }

            return resultado;
        }


        public async Task<int> CrearYDistribuirItemAsync(DtoItemTrabajoRegistro item)
        {
            var resultado = await this.CrearItemAsync(item);

            if (resultado == 0)
            {
                await this.DistribuirItemsAsync();
            }

            return resultado;
        }


        public async Task<int> DistribuirItemsAsync()
        {
            var itemsPendientes = await _repositorio.ObtenerItemsAsync("PENDIENTE");

            var usuariosLista = _repositorioUsuario.ObtenerUsuarios();

            foreach (var item in itemsPendientes.Where(itm => itm.UserName == null || String.IsNullOrWhiteSpace(itm.UserName)).OrderBy(o => o.FechaEntrega).ThenBy(t => t.Relevancia))
            {
                var usuariosItems = await _repositorioUsuario.ObtenerItemsTrabajo();

                var usuarioMenosPendientes = usuariosItems.OrderBy(o => o.CantidadPendientes).FirstOrDefault(f => f.CantidadRelevanciaAlta < 3);

                var usuarioResponsable = usuarioMenosPendientes?.UserName;

                //  Toma siguiente usuario de la lista
                if (usuarioMenosPendientes == null || String.IsNullOrWhiteSpace(usuarioResponsable))
                {
                    usuarioResponsable = usuariosLista.FirstOrDefault(usu => !usuariosItems.Select(s => s.UserName).Contains(usu.UserName))?.UserName ?? string.Empty;
                }

                if (usuarioResponsable != null && !String.IsNullOrWhiteSpace(usuarioResponsable))
                {
                    if ((item.FechaEntrega.Date - DateTime.Now.Date).TotalDays < 3)
                    {
                        item.UserName = usuarioResponsable;

                        await _repositorio.ActualizarItemAsync(item);
                    }
                    else if (item.Relevancia.ToLower() == "alta")
                    {
                        item.UserName = usuarioResponsable;

                        await _repositorio.ActualizarItemAsync(item);
                    }
                }
                else
                {
                    break;
                }
            }

            return 0;
        }


        public async Task<int> FinalizarItemAsync(DtoItemTrabajoTermina item)
        {
            if (item.ItemId != 0)
            {
                var itemsTrabajo = await _repositorio.ObtenerItemsAsync();

                var itemInline = itemsTrabajo.First(i => i.ItemId.Equals(item.ItemId));
                
                if (itemInline.Estado != "COMPLETADO")
                {
                    itemInline.Estado = "COMPLETADO";

                    await _repositorio.ActualizarItemAsync(itemInline);

                    return 0;
                }
                else
                {
                    return -2;
                }
            }
            else
            {
                return -1;
            }
        }


        public async Task<List<DtoItemTrabajoVista>> ObtenerItemTareas()
        {
            List<DtoItemTrabajoVista> resultado = new List<DtoItemTrabajoVista>();

            var itemsTrabajo = await _repositorio.ObtenerItemsAsync();

            foreach (var item in itemsTrabajo)
            {
                DtoItemTrabajoVista itemTrabajoNew = new DtoItemTrabajoVista();
                itemTrabajoNew.Descripcion = item.Descripcion;
                itemTrabajoNew.FechaCreacion = item.FechaCreacion;
                itemTrabajoNew.FechaEntrega = item.FechaEntrega;
                itemTrabajoNew.Relevancia = item.Relevancia;
                itemTrabajoNew.Estado = item.Estado;
                itemTrabajoNew.UserName = item.UserName ?? "Ninguno";
                resultado.Add(itemTrabajoNew);            
            }

            return resultado;
        }
    }
}
