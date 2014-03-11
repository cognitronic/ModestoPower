using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModestoPower.Core.Domain.Programs;
using MongoDB.Bson;

namespace RAM.Services.Interfaces
{
    public interface IProgramService
    {
        IList<IProgram> GetAll();
        IProgram GetById(ObjectId id);
        IProgram Save(IProgram p);
        IProgram Delete(IProgram p);


    }
}
