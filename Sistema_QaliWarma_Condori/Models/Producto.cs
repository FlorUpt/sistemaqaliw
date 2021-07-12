namespace Sistema_QaliWarma_Condori.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Producto")]
    public partial class Producto
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Producto()
        {
            ProductoSalidas = new HashSet<ProductoSalidas>();
        }

        [Key]
        public int producto_id { get; set; }

        public int producto_codigo { get; set; }

        [Required]
        [StringLength(20)]
        public string descripcion { get; set; }

        public int cantidad { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductoSalidas> ProductoSalidas { get; set; }
    }
}
