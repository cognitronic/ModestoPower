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
    public class Sessions
    {

        [DataMember]
        public string day { get; set; }
        [DataMember]
        public string time { get; set; }
    }
}
