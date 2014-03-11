using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using RAM.Services.Cache;
using ModestoPower.Core.Domain.Programs;
using RAM.Services.Interfaces;

namespace RAM.Services.Implementations
{
    public class ProgramService : IProgramService
    {
        private readonly IProgramRepository _repository;
        private readonly ICacheStorage _cache;
        public ProgramService(IProgramRepository repository, ICacheStorage cache)
        {
            _repository = repository;
            _cache = cache;
        }
        public IList<IProgram> GetAll()
        {
            var list = _cache.Get<IList<IProgram>>(RAM.Core.ResourceStrings.Cache_Programs);
            if (list == null)
            {
                list = _repository.GetAll();
                _cache.Store(RAM.Core.ResourceStrings.Cache_Programs, list);
                return list;
            }
            return list;
        }

        public IProgram GetById(ObjectId id)
        {
            return _repository.GetById(id);
        }

        public IProgram Save(IProgram program)
        {
            var p = _repository.Save(program);
            _cache.Remove(RAM.Core.ResourceStrings.Cache_Programs);
            return p;

        }

        public IProgram Delete(IProgram p)
        {

            return _repository.Delete(p);
        } 
    }
}
