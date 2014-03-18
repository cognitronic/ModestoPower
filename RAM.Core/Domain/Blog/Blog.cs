using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using RAM.Infrastructure.Domain;
using RAM.Core.Domain.User;

namespace RAM.Core.Domain.Blog
{
    [Serializable]
    public class Blog :  IBlog
    {

        public Blog()
        {
            this.tags = new List<string>();
        }
        #region IBlog Members
        [DataMember]
        public string title { get; set; }
        [DataMember]
        public string category { get; set; }
        [DataMember]
        public string post { get; set; }
        [DataMember]
        public string postpreview { get; set; }
        [DataMember]
        public string enteredby { get; set; }
        [DataMember]
        public string seokeywords { get; set; }
        [DataMember]
        public bool isactive { get; set; }
        [DataMember]
        public string seodescription { get; set; }
        [DataMember]
        public DateTime dateposted { get; set; }
        [DataMember]
        public string imagepath { get; set; }
        public IList<string> tags { get; set; }

        #endregion

        #region ISystemObject Members
        [DataMember]
        public string sid { get; set; }
        [DataMember]
        public MongoDB.Bson.ObjectId Id { get; set; }

        #endregion
    }
}
