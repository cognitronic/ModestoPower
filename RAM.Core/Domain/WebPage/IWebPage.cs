using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace ModestoPower.Core.Domain.WebPage
{
    public interface IWebPage
    {
        ObjectId Id { get; set; }
        string title { get; set; }
        bool isonline { get; set; }
        DateTime lastupdated { get; set; }
        string moviepath { get; set; }
        int sortorder { get; set; }
        string bannertext { get; set; }
        IList<string> bannerimage { get; set; }
    }
}
