namespace ItemsDeTrabajo.Entidad.Dto
{
    public class DtoUsuarioItemTrabajo : DtoUsuarioVista
    {
        public int CantidadPendientes { get; set; }

        public int CantidadCompletados { get; set; }

        public int CantidadTotal
        {
            get
            {
                return this.CantidadPendientes + this.CantidadCompletados;
            }
            set { }
        }
        public int CantidadRelevanciaAlta { get; set; }
    }
}
