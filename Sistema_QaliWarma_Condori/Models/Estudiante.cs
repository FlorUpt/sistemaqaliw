namespace Sistema_QaliWarma_Condori.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("Estudiante")]
    public partial class Estudiante
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Estudiante()
        {
            Padre = new HashSet<Padre>();
            ProductoSalidas = new HashSet<ProductoSalidas>();
        }

        [Key]
        public int estudiante_id { get; set; }

        public int estudiante_dni { get; set; }

        [Required]
        [StringLength(100)]
        public string apellido { get; set; }

        [Required]
        [StringLength(50)]
        public string nombre { get; set; }

        [StringLength(15)]
        public string nivel { get; set; }

        [StringLength(15)]
        public string grado { get; set; }

        [StringLength(2)]
        public string seccion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Padre> Padre { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductoSalidas> ProductoSalidas { get; set; }

        //Metodo CRUD
        public List<Estudiante> Listar() //Retorna varios objetos
        {
            var objEstudiante = new List<Estudiante>();

            try
            {
                //1.Origen de datos
                using (var db = new ModeloQaliWarma())
                {
                    //2. Sentencia de LinQ
                    objEstudiante = db.Estudiante.ToList();
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            //3. Devolvemos los objetos
            return objEstudiante;
        }
        //Metodo obtener
        public Estudiante Obtener(int id) //Retorna varios objetos
        {
            var objEstudiante = new Estudiante();

            try
            {
                //1.Origen de datos
                using (var db = new ModeloQaliWarma())
                {
                    //2. Sentencia de LinQ
                    objEstudiante = db.Estudiante
                        .Where(x => x.estudiante_id == id)
                        .SingleOrDefault();
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            //3. Devolvemos el objeto
            return objEstudiante;
        }
        //Metodo BUSCAR
        public List<Estudiante> Buscar(string criterio) //Retorna varios objetos
        {
            var objEstudiante = new List<Estudiante>();

            try
            {
                //1.Origen de datos
                using (var db = new ModeloQaliWarma())
                {
                    //2. Sentencia de LinQ
                    objEstudiante = db.Estudiante.Include("Estudiante")
                        .Where(x => x.nombre.Contains(criterio) || x.estudiante_codigo.Equals(criterio))
                        .ToList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            //3. Devolvemos los objetos
            return objEstudiante;
        }

        //Metodo guardar
        public void Guardar()
        {
            try
            {
                //1.Origen de datos
                using (var db = new ModeloQaliWarma())
                {
                    if (this.estudiante_id > 0) //Existe el id
                    {
                        db.Entry(this).State = EntityState.Modified;
                    }
                    else
                    {
                        db.Entry(this).State = EntityState.Added;
                    }
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw;
            }

        }
        //Metodo Eliminar

        public void Eliminar()
        {
            try
            {
                //1.Origen de datos
                using (var db = new ModeloQaliWarma())
                {
                    db.Entry(this).State = EntityState.Deleted;
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
