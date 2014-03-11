using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace ModestoPower.Core.Domain.Programs
{
    public interface IProgram
    {
        ObjectId Id { get; set; }
        string name { get; set; }
        string description { get; set; }
        IList<string> imagepaths { get; set; }


    }
}
