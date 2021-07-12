namespace Sistema_QaliWarma_Condori.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("Usuario")]
    public partial class Usuario
    {
        [Key]
        public int usuario_id { get; set; }

        [Required]
        [StringLength(250)]
        public string nombre { get; set; }

        [Required]
        [StringLength(250)]
        public string apellidos { get; set; }

        [StringLength(100)]
        public string email { get; set; }

        public int? clave { get; set; }

        [StringLength(1)]
        public string estado { get; set; }

        //Metodo CRUD
        public List<Usuario> Listar() //Retorna varios objetos
        {
            var objUsuario = new List<Usuario>();

            try
            {
                //1.Origen de datos
                using (var db = new ModeloQaliWarma())
                {
                    //2. Sentencia de LinQ
                    objUsuario = db.Usuario.ToList();
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            //3. Devolvemos los objetos
            return objUsuario;
        }
        //Metodo obtener
        public Usuario Obtener(int id) //Retorna varios objetos
        {
            var objUsuario = new Usuario();

            try
            {
                //1.Origen de datos
                using (var db = new ModeloQaliWarma())
                {
                    //2. Sentencia de LinQ
                    objUsuario = db.Usuario
                        .Where(x => x.usuario_id == id)
                        .SingleOrDefault();
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            //3. Devolvemos el objeto
            return objUsuario;
        }
        //Metodo BUSCAR
        public List<Usuario> Buscar(string criterio) //Retorna varios objetos
        {
            var objUsuario = new List<Usuario>();

            try
            {
                //1.Origen de datos
                using (var db = new ModeloQaliWarma())
                {
                    //2. Sentencia de LinQ
                    objUsuario = db.Usuario.Include("Usuario")
                        .Where(x => x.nombre.Contains(criterio) || x.nombre.Equals(criterio) || x.email.Equals
                        (criterio))
                        .ToList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            //3. Devolvemos los objetos
            return objUsuario;
        }

        //Metodo guardar
        public void Guardar()
        {
            try
            {
                //1.Origen de datos
                using (var db = new ModeloQaliWarma())
                {
                    if (this.usuario_id > 0) //Existe el id
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
