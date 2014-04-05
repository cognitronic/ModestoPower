using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using System.Runtime.Serialization;

namespace ModestoPower.Core.Domain.Client
{
    [Serializable]
    public class Client
    {
        [DataMember]
        public ObjectId Id { get; set; }
        [DataMember]
        public string first { get; set; }
        [DataMember]
        public string last { get; set; }
        [DataMember]
        public string email { get; set; }
        [DataMember]
        public string phone { get; set; }
        [DataMember]
        public string sid { get; set; }
    }
}
