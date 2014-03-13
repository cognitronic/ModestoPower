using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModestoPower.Core.Domain.WebPage
{
    public class WebPage : IWebPage
    {
        public MongoDB.Bson.ObjectId Id { get; set; }

        public string title { get; set; }

        public bool isonline { get; set; }

        public DateTime lastupdated { get; set; }

        public string moviepath { get; set; }

        public int sortorder { get; set; }

        public string bannertext { get; set; }

        public IList<string> bannerimage { get; set; }
    }
}
