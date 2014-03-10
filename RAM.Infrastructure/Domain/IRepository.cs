using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAM.Infrastructure.Domain
{
    public interface IRepository<T> : IReadOnlyRepository<T> where T : IAggregateRoot
    {
        T Save(T entity);
        T Add(T entity);
        T Remove(T entity);
    }
}
