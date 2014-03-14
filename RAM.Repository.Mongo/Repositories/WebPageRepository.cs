using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using ModestoPower.Core.Domain.Pages;
using RAM.Core;
using RAM.Services.Cache;

namespace RAM.Repository.Mongo.Repositories
{
    public class WebPageRepository : BaseRepository, IPagesRepository
    {
        private readonly ICacheStorage _cache;
        public WebPageRepository(ICacheStorage cache)
            : base(ResourceStrings.Mongo_WebPages_Collection)
        {
            _cache = cache;
        }
        public IList<IPages> GetAll()
        {
            return _collection.FindAllAs<IPages>().OrderBy(o => o.sortorder).ToList<IPages>();
        }

        public IPages GetById(ObjectId id)
        {
            var query = Query<IPages>.EQ(e => e.Id, id);
            return _collection.FindOneAs<IPages>(query);
        }

        public IPages Save(IPages p)
        {
            throw new NotImplementedException();
        }

        public IPages Delete(IPages p)
        {
            throw new NotImplementedException();
        }
    }
}
