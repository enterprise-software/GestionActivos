using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionActivos.Repository
{
    public interface Repository<T> where T: class
    {
        IEnumerable<T> List { get; }
        void Add(T entity);
        void Delete(T entity);
        void Update(int Id, T entity);
        T FindById(int Id);
    }
}
