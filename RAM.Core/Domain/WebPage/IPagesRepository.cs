using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace ModestoPower.Core.Domain.Pages
{
    public interface IPagesRepository
    {
        IList<IPages> GetAll();
        Pages GetById(ObjectId id);
        Pages Save(Pages p);
        IPages Delete(IPages p);
        Pages GetByTitle(string title);
    }
}
