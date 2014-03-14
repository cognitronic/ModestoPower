using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RAM.Infrastructure.UnitOfWork;

namespace RAM.Repository.Mongo
{
    public class MongoUnitOfWork : IUnitOfWork
    {
        public void RegisterAmended(Infrastructure.Domain.IAggregateRoot entity, IUnitOfWorkRepository unitofWorkRepository)
        {
            throw new NotImplementedException();
        }

        public void RegisterNew(Infrastructure.Domain.IAggregateRoot entity, IUnitOfWorkRepository unitofWorkRepository)
        {
            throw new NotImplementedException();
        }

        public void RegisterRemoved(Infrastructure.Domain.IAggregateRoot entity, IUnitOfWorkRepository unitofWorkRepository)
        {
            throw new NotImplementedException();
        }

        public void Commit()
        {
            throw new NotImplementedException();
        }
    }
}
