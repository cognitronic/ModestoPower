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
        IList<Pages> GetAll();
        Pages GetById(ObjectId id);
        Pages Save(Pages p);
        Pages Delete(Pages p);
        Pages GetByTitle(string title);
    }
}
