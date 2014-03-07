using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Web.Providers;

namespace RAM.Services.Cache
{
    public class MongoDBCacheAdapter : ICacheStorage
    {
        private readonly static MongoDBOutputCacheProvider _instance;

        static MongoDBCacheAdapter()
        {
            _instance = new MongoDBOutputCacheProvider();
        }

        public static MongoDBOutputCacheProvider Instance { get { return _instance; } }
        public void Remove(string key)
        {
            Instance.Remove(key);
        }

        public void Store(string key, object data)
        {
            Instance.Add(key, data, DateTime.Now.AddDays(7));
        }

        public T Get<T>(string key)
        {
            T itemStored = (T)Instance.Get(key);
            if (itemStored == null)
                itemStored = default(T);
            return itemStored;
        }
    }
}
