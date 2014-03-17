using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using RAM.Infrastructure.Domain;
using MongoDB.Bson;

namespace RAM.Core.Domain.Blog
{
    [Serializable]
    public class Tag : ITag
    {
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public ObjectId Id { get; set; }
        [DataMember]
        public string sid { get; set; }
    }
}
