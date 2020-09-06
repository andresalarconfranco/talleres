using Javeriana.Pica.ApplicationCore.Entities;
using System.Collections.Generic;

namespace Javeriana.Pica.ApplicationCore.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        T GetById(int id);
        IList<T> ListAll();
        T Add(T entity);
        T Update(T entity);
        T Delete(T entity);
    }
}
