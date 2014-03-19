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

        public IList<Schedule> GetAll()
        {
            return _collection.FindAllAs<Schedule>().OrderBy( o => o.day).ToList<Schedule>();
        }

        public Schedule GetById(ObjectId id)
        {
            var query = Query<Schedule>.EQ(e => e.Id, id);
            return _collection.FindOneAs<Schedule>(query);
        }

        public Schedule GetByName(string name)
        {
            var query = Query<Schedule>.EQ(e => e.name, name);
            return _collection.FindOneAs<Schedule>(query);
        }

        public IList<Schedule> GetByDayOfWeek(string dow)
        {
            var query = Query<ISchedule>.EQ(e => e.day, dow);
            return _collection.FindAllAs<Schedule>().ToList<Schedule>();
        }

        public Schedule Save(Schedule p)
        {
            _collection.Save(p);
            return p;
        }

        public Schedule Delete(Schedule p)
        {
            var query = Query<Schedule>.EQ(e => e.Id, p.Id);
            _collection.Remove(query);
            return null;
        }
    }
}
