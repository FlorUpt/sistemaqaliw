namespace Sistema_QaliWarma_Condori.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ProductoSalidas
    {
        [Key]
        public int productsalida_id { get; set; }

        public int padre_id { get; set; }

        public int estudiante_id { get; set; }

        public int producto_id { get; set; }

        [Required]
        [StringLength(20)]
        public string descripcion { get; set; }

        public DateTime? fecha { get; set; }

        public int cantidad_saliente { get; set; }

        public virtual Estudiante Estudiante { get; set; }

        public virtual Padre Padre { get; set; }

        public virtual Producto Producto { get; set; }
    }
}
