using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RAM.Infrastructure.Domain;
using RAM.Core.Domain.User;
using MongoDB.Bson;

namespace RAM.Core.Domain.Blog
{
    public interface IBlog
    {
        ObjectId Id { get; set; }
        string sid { get; set; }
        string title { get; set; }
        string category { get; set; }
        string post { get; set; }
        string postpreview { get; set; }
        string enteredby { get; set; }
        string seokeywords { get; set; }
        string seodescription { get; set; }
        DateTime dateposted { get; set; }
        bool isactive { get; set; }
        string imagepath { get; set; }
        IList<string> tags { get; set; }
    }
}
