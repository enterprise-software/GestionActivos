using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionActivos.Domain;
using GestionActivos.DAL;
namespace GestionActivos.Repository
{
    public class AreasRepository : Repository<Area>
    {
        private GestionActivosContext dbContext;
        public AreasRepository()
        {
            dbContext = new GestionActivosContext();
        }

        public IEnumerable<Area> List => dbContext.Area.Include("Ciudad");

        public void Add(Area entity)
        {
            dbContext.Area.Add(entity);
            dbContext.SaveChanges();
        }

        public void Delete(Area entity)
        {
            throw new NotImplementedException();
        }

        public Area FindById(int Id)
        {
            throw new NotImplementedException();
        }

        public void Update(int Id, Area entity)
        {
            throw new NotImplementedException();
        }
    }
}
