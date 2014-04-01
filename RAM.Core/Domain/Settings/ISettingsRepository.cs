using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace ModestoPower.Core.Domain.Settings
{
    public interface ISettingsRepository
    {
        IList<Settings> GetAll();
        Settings GetById(ObjectId id);
        Settings Save(Settings p);
        Settings Delete(Settings p);
    }
}
