using System.ComponentModel.DataAnnotations;

namespace ItemsDeTrabajo.Entidad.Dto
{
    public class DtoItemTrabajoRegistro
    {
        public int? ItemId { get; set; }
        
        [Required]
        public string Descripcion { get; set; }

        public DateTime FechaCreacion { get; set; }
        
        [Required]
        public DateTime FechaEntrega { get; set; }

        /// <summary>alta; baja// </summary>
        public string Relevancia { get; set; }

        /// <summary>PENDIENTE, COMPLETADO// </summary>
        public string Estado { get; set; }
    }
}
