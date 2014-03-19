using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using System.Runtime.Serialization;

namespace ModestoPower.Core.Domain.Schedule
{
    public class Schedule : ISchedule
    {
        public Schedule()
        {
            this.sessions = new List<Sessions>();
        }
        public ObjectId Id { get; set; }

        public string instructor { get; set; }

        public string name { get; set; }

        public string description { get; set; }

        public IList<Sessions> sessions { get; set; }
    }
}
