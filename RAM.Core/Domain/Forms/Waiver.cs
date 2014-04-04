using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using MongoDB.Bson;

namespace ModestoPower.Core.Domain.Forms
{
    [Serializable]
    public class Waiver
    {
        [DataMember]
        public ObjectId Id { get; set; }
        [DataMember]
        public string first { get; set; }
        [DataMember]
        public string last { get; set; }
        [DataMember]
        public DateTime datecreated { get; set; }
        [DataMember]
        public string phone { get; set; }
        [DataMember]
        public string email { get; set; }
        [DataMember]
        public string birthday { get; set; }
        [DataMember]
        public string address { get; set; }
        [DataMember]
        public string city { get; set; }
        [DataMember]
        public string state { get; set; }
        [DataMember]
        public string zip { get; set; }
        [DataMember]
        public string classattending { get; set; }
        [DataMember]
        public string emergencynumber { get; set; }
        [DataMember]
        public string emergencyname { get; set; }
        [DataMember]
        public string guardianname { get; set; }
        [DataMember]
        public bool agreedtoterms { get; set; }
    }
}
