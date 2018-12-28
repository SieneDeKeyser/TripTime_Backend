using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TripTime.Infrastructure.GlobalInterfaces
{
    public interface IRepository<T>
    {
        Task<List<T>> GetAll();
        Task<T> GetById(Guid id);
        Task<T> Save(T entity);
        Task<T> update(T entityToUpdate);
    }
}
