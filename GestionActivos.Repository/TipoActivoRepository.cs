using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionActivos.Domain;
using GestionActivos.DAL;
namespace GestionActivos.Repository
{
    public class TipoActivoRepository : Repository<TipoActivo>
    {
        private GestionActivosContext dbContext;
        public TipoActivoRepository()
        {
            dbContext = new GestionActivosContext();
        }
        public IEnumerable<TipoActivo> List => dbContext.TipoActivo;

        public void Add(TipoActivo tipoActivo)
        {
            dbContext.TipoActivo.Add(tipoActivo);
            dbContext.SaveChanges();
        }

        public void Delete(TipoActivo entity)
        {
            throw new NotImplementedException();
        }

        public TipoActivo FindById(int Id)
        {
            throw new NotImplementedException();
        }

        public void Update(int Id, TipoActivo entity)
        {
            throw new NotImplementedException();
        }
    }
}
