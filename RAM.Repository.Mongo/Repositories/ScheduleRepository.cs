using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using ModestoPower.Core.Domain.Schedule;
using RAM.Core;
using RAM.Services.Cache;

namespace RAM.Repository.Mongo.Repositories
{
    public class ScheduleRepository : BaseRepository, IScheduleRepository
    {
        private readonly ICacheStorage _cache;
        public ScheduleRepository(ICacheStorage cache)
            : base(ResourceStrings.Mongo_Schedule_Collection)
        {
            _cache = cache;
        }

        public IList<ISchedule> GetAll()
        {
            return _collection.FindAllAs<ISchedule>().OrderBy(o => o.sessions).ToList<ISchedule>();
        }

        public ISchedule GetById(ObjectId id)
        {
            var query = Query<ISchedule>.EQ(e => e.Id, id);
            return _collection.FindOneAs<ISchedule>(query);
        }

        public ISchedule GetByName(string name)
        {
            var query = Query<ISchedule>.EQ(e => e.name, name);
            return _collection.FindOneAs<ISchedule>(query);
        }

        public ISchedule Save(ISchedule p)
        {
            _collection.Save(p);
            return p;
        }

        public ISchedule Delete(ISchedule p)
        {
            var query = Query<ISchedule>.EQ(e => e.Id, p.Id);
            _collection.Remove(query);
            return null;
        }
    }
}
