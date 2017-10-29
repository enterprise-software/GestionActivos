using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionActivos.Domain;
using GestionActivos.DAL;
namespace GestionActivos.Repository
{
    public class CiudadRepository : Repository<Ciudad>
    {
        private GestionActivosContext dbContext;
        public CiudadRepository()
        {
            dbContext = new GestionActivosContext();
        }

        public IEnumerable<Ciudad> List => dbContext.Ciudad.Include("Area");

        public void Add(Ciudad entity)
        {
            dbContext.Ciudad.Add(entity);
            dbContext.SaveChanges();
        }

        public void Delete(Ciudad entity)
        {
            throw new NotImplementedException();
        }

        public Ciudad FindById(int Id)
        {
            throw new NotImplementedException();
        }

        public void Update(int Id, Ciudad entity)
        {
            throw new NotImplementedException();
        }
    }
}
