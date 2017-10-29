using GestionActivos.DAL;
using GestionActivos.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionActivos.Repository
{
    public class PersonasRepository : Repository<Persona>
    {
        private GestionActivosContext dbContext;
        public PersonasRepository()
        {
            dbContext = new GestionActivosContext();
        }
        public IEnumerable<Persona> List => dbContext.Persona;

        public void Add(Persona entity)
        {
            dbContext.Persona.Add(entity);
            dbContext.SaveChanges();
        }

        public void Delete(Persona entity)
        {
            throw new NotImplementedException();
        }

        public Persona FindById(int Id)
        {
            throw new NotImplementedException();
        }

        public void Update(int Id, Persona entity)
        {
            throw new NotImplementedException();
        }
    }
}
