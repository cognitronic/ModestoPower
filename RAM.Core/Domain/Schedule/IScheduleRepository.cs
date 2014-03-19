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
        IList<ISchedule> GetAll();
        ISchedule GetById(ObjectId id);
        ISchedule GetByName(string name);
        ISchedule Save(ISchedule s);
        ISchedule Delete(ISchedule s);
    }
}
