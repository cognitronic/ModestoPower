using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace ModestoPower.Core.Domain.WebPage
{
    public interface IWebPageRepository
    {
        IList<IWebPage> GetAll();
        IWebPage GetById(ObjectId id);
        IWebPage Save(IWebPage p);
        IWebPage Delete(IWebPage p);
    }
}
