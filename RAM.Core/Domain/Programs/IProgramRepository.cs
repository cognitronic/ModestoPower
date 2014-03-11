using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using ModestoPower.Core.Domain.Programs;

namespace ModestoPower.Core.Domain.Programs
{
    public interface IProgramRepository
    {
        IList<IProgram> GetAll();
        IProgram GetById(ObjectId id);
        IProgram Save(IProgram p);
        IProgram Delete(IProgram p);
    }
}
