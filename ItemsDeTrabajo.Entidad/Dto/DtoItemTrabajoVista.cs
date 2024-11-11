namespace ItemsDeTrabajo.Entidad.Dto
{
    public class DtoItemTrabajoVista
    {
        public string Descripcion { get; set; } = "";

        public DateTime FechaCreacion { get; set; }
        
        public DateTime FechaEntrega { get; set; }

        /// <summary>Alta = 1, Media = 2, Baja = 3// </summary>
        public string Relevancia { get; set; }

        /// <summary>PENDIENTE, COMPLETADO// </summary>
        public string Estado { get; set; } = "PENDIENTE";

        /// <summary>Usuario responsable// </summary>
        public string? UserName { get; set; }
    }
}
