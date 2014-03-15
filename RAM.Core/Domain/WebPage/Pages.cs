using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace ModestoPower.Core.Domain.Pages
{
    [Serializable]
    public class Pages : IPages
    {

        public Pages()
        {
            bannerimage = new List<string>();
        }
        [DataMember]
        public MongoDB.Bson.ObjectId Id { get; set; }

        [DataMember]
        public string title { get; set; }

        [DataMember]
        public bool isonline { get; set; }

        [DataMember]
        public DateTime lastupdated { get; set; }

        [DataMember]
        public string moviepath { get; set; }

        [DataMember]
        public int sortorder { get; set; }

        [DataMember]
        public string bannertext { get; set; }

        [DataMember]
        public string seokeywords { get; set; }

        [DataMember]
        public string seodescription { get; set; }

        [DataMember]
        public string maincontent { get; set; }

        [DataMember]
        public string parent { get; set; }

        [DataMember]
        public IList<string> bannerimage { get; set; }

        [DataMember]
        public string headertext { get; set; }
    }
}
