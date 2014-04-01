using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using System.Runtime.Serialization;

namespace ModestoPower.Core.Domain.Settings
{
    [Serializable]
    public class Settings : ISettings
    {
        [DataMember]
        public ObjectId Id { get; set; }

        [DataMember]
        public string name { get; set; }

        [DataMember]
        public string description { get; set; }

        [DataMember]
        public string value { get; set; }
    }
}
