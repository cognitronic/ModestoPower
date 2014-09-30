using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace ModestoPower.Core.Domain.Schedule
{
    public interface ISchedule
    {
        ObjectId Id { get; set; }
        string instructor { get; set; }
        string name { get; set; }
        string description { get; set; }
        string day { get; set; }
        string times { get; set; }
        string sid { get; set; }
        DateTime starttime { get; set; }
        DateTime endtime { get; set; }
    }
}
