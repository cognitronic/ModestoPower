using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using ModestoPower.Core.Domain.Forms;
using RAM.Core;
using RAM.Services.Cache;

namespace RAM.Repository.Mongo.Repositories
{
    public class WaiverRepository : BaseRepository, IWaiverRepository
    {
        private readonly ICacheStorage _cache;
        public WaiverRepository(ICacheStorage cache)
            : base(ResourceStrings.Mongo_Waiver_Collection)
        {
            _cache = cache;
        }
        public Waiver Save(Waiver entity)
        {
            _collection.Save(entity);
            return entity;
        }

        public Waiver GetById(string id)
        {
            var query = Query<Waiver>.EQ(e => e.Id, new ObjectId(id));
            return _collection.FindOneAs<Waiver>(query);
        }

        public IList<Waiver> GetAll()
        {
            return _collection.FindAllAs<Waiver>().OrderByDescending(o => o.datecreated).ToList<Waiver>();
        }

        public Waiver GetByEmail(string email)
        {
            return null;
        }

        public Waiver Delete(Waiver waiver)
        {

            return waiver;
        }
    }
}
