using GestionActivos.DAL;
using GestionActivos.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionActivos.Repository
{
    public class ActivoRepository : Repository<Activo>
    {
        private GestionActivosContext dbContext;
        public ActivoRepository()
        {
            dbContext = new GestionActivosContext();
        }

        public IEnumerable<Activo> List => dbContext.Activo.Include("Area").Include("Persona").Include("TipoActivo");

        public void Add(Activo entity)
        {
            dbContext.Activo.Add(entity);
            dbContext.SaveChanges();
        }

        public void Delete(Activo entity)
        {
            throw new NotImplementedException();
        }

        public Activo FindById(int Id)
        {
            Activo activo = dbContext.Activo.Find(Id);
            return activo;
        }

        public void Update(int Id, Activo activo)
        {
            var activoInfo = dbContext.Activo.Find(Id);
            if(activoInfo != null)
            {
                activoInfo.FechaBaja = activo.FechaBaja;
                activoInfo.NumeroInternoInventario = activo.NumeroInternoInventario;
                dbContext.SaveChanges();

            }
        }
    }
}
