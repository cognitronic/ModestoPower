using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RAM.Infrastructure.Domain;

namespace RAM.Core.Domain.Blog
{
    public interface ITag 
    {
        string name { get; set; }
        string sid { get; set; }
        MongoDB.Bson.ObjectId Id { get; set; }
    }
}
