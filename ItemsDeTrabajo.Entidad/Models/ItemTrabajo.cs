namespace ItemsDeTrabajo.Entidad.Models
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;

    public class ItemTrabajo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ItemId { get; set; }

        [StringLength(100)]
        public string Descripcion { get; set; } = "";

        public DateTime FechaCreacion { get; set; } = DateTime.Now;
        
        public DateTime FechaEntrega { get; set; }

        /// <summary>alta; baja// </summary>
        public string Relevancia { get; set; } = "baja";

        /// <summary>PENDIENTE, COMPLETADO// </summary>
        public string Estado { get; set; } = "PENDIENTE";
        
        public string? UserName { get; set; }
    }
}
