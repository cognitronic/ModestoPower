using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using ModestoPower.Core.Domain.Settings;
using RAM.Core;

namespace RAM.Repository.Mongo.Repositories
{
    public class SettingsRepository : ISettingsRepository
    {
        private String _connectionString;
        private MongoClient _client;
        private MongoServer _server;
        private MongoDatabase _database;
        private MongoCollection _collection;
        public SettingsRepository()
        {
            _connectionString = ConfigurationManager.AppSettings["mongoConnectionString"];
            _client = new MongoClient(_connectionString);
            _server = _client.GetServer();
            _database = _server.GetDatabase(ConfigurationManager.AppSettings["mongoDatabase"]);
            _collection = _database.GetCollection<ISettings>(ResourceStrings.Mongo_Settings_Collection);
        }
        public IList<Settings> GetAll()
        {
            return _collection.FindAllAs<Settings>().ToList<Settings>();
        }

        public Settings GetById(ObjectId id)
        {
            var query = Query<Settings>.EQ(e => e.Id, id);
            return _collection.FindOneAs<Settings>(query);
        }

        public Settings Save(Settings p)
        {
            _collection.Save(p);
            return p;
        }

        public Settings Delete(Settings p)
        {
            var query = Query<Settings>.EQ(e => e.Id, p.Id);
            _collection.Remove(query);
            return  p;
        }
    }
}

