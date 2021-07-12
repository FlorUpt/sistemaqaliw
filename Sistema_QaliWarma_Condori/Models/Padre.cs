namespace Sistema_QaliWarma_Condori.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Padre")]
    public partial class Padre
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Padre()
        {
            ProductoSalidas = new HashSet<ProductoSalidas>();
        }

        [Key]
        public int padre_id { get; set; }

        public int padre_dni { get; set; }

        public int estudiante_id { get; set; }

        [Required]
        [StringLength(100)]
        public string apellido { get; set; }

        [Required]
        [StringLength(100)]
        public string parentesco { get; set; }

        [Required]
        [StringLength(50)]
        public string nombre { get; set; }

        public virtual Estudiante Estudiante { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductoSalidas> ProductoSalidas { get; set; }
    }
}
