using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using System.Runtime.Serialization;

namespace ModestoPower.Core.Domain.Schedule
{
    [Serializable]
    public class Schedule : ISchedule
    {
        [DataMember]
        public ObjectId Id { get; set; }

        [DataMember]
        public string instructor { get; set; }

        [DataMember]
        public string name { get; set; }

        [DataMember]
        public string description { get; set; }

        [DataMember]
        public string day { get; set; }

        [DataMember]
        public string times { get; set; }
        
        [DataMember]
        public string sid { get; set; }
    }
}
