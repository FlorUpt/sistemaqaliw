namespace Sistema_QaliWarma_Condori.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ModeloQaliWarma : DbContext
    {
        public ModeloQaliWarma()
            : base("name=ModeloQaliWarma")
        {
        }

        public virtual DbSet<Estudiante> Estudiante { get; set; }
        public virtual DbSet<Padre> Padre { get; set; }
        public virtual DbSet<Producto> Producto { get; set; }
        public virtual DbSet<ProductoSalidas> ProductoSalidas { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Estudiante>()
                .Property(e => e.apellido)
                .IsUnicode(false);

            modelBuilder.Entity<Estudiante>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Estudiante>()
                .Property(e => e.nivel)
                .IsUnicode(false);

            modelBuilder.Entity<Estudiante>()
                .Property(e => e.grado)
                .IsUnicode(false);

            modelBuilder.Entity<Estudiante>()
                .Property(e => e.seccion)
                .IsUnicode(false);

            modelBuilder.Entity<Estudiante>()
                .HasMany(e => e.Padre)
                .WithRequired(e => e.Estudiante)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Estudiante>()
                .HasMany(e => e.ProductoSalidas)
                .WithRequired(e => e.Estudiante)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Padre>()
                .Property(e => e.apellido)
                .IsUnicode(false);

            modelBuilder.Entity<Padre>()
                .Property(e => e.parentesco)
                .IsUnicode(false);

            modelBuilder.Entity<Padre>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Padre>()
                .HasMany(e => e.ProductoSalidas)
                .WithRequired(e => e.Padre)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Producto>()
                .Property(e => e.descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Producto>()
                .HasMany(e => e.ProductoSalidas)
                .WithRequired(e => e.Producto)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ProductoSalidas>()
                .Property(e => e.descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.apellidos)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.estado)
                .IsFixedLength()
                .IsUnicode(false);
        }
    }
}
