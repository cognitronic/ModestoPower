using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace ModestoPower.Core.Domain.Schedule
{
    public interface IScheduleRepository
    {
        IList<Schedule> GetAll();
        IList<Schedule> GetByDayOfWeek(string dow);
        Schedule GetById(ObjectId id);
        Schedule GetByName(string name);
        Schedule Save(Schedule s);
        Schedule Delete(Schedule s);
    }
}
