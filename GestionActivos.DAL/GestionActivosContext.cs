using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using GestionActivos.Domain;
namespace GestionActivos.DAL
{
    public class GestionActivosContext: DbContext
    {
        public GestionActivosContext() : base ("GestionActivosContextConnStr")
        {
            //var ensureDLLIsCopied =  System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }

        public virtual DbSet<Activo> Activo { get; set; }
        public virtual DbSet<Area> Area { get; set; }
        public virtual DbSet<Ciudad> Ciudad { get; set; }
        public virtual DbSet<Persona> Persona { get; set; }
        public virtual DbSet<TipoActivo> TipoActivo { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Area>()
                .HasMany(e => e.Activo)
                .WithOptional(e => e.Area)
                .HasForeignKey(e => e.AreaId);

            modelBuilder.Entity<Ciudad>()
                .HasMany(e => e.Area)
                .WithOptional(e => e.Ciudad)
                .HasForeignKey(e => e.CiudadId);

            modelBuilder.Entity<Persona>()
                .HasMany(e => e.Activo)
                .WithOptional(e => e.Persona)
                .HasForeignKey(e => e.PersonaId);

            modelBuilder.Entity<TipoActivo>()
                .HasMany(e => e.Activo)
                .WithOptional(e => e.TipoActivo)
                .HasForeignKey(e => e.TipoActivoId);
        }
    }
}
