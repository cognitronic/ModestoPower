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

        public Pages GetById(ObjectId id)
        {
            var query = Query<Pages>.EQ(e => e.Id, id);
            return _collection.FindOneAs<Pages>(query);
        }

        public Pages GetByTitle(string title)
        {
            var query = Query<Pages>.EQ(e => e.title, title);
            return _collection.FindOneAs<Pages>(query);
        }

        public Pages Save(Pages p)
        {
            _collection.Save(p);
            return null;
        }

        public IPages Delete(IPages p)
        {
            throw new NotImplementedException();
        }
    }
}
