using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using ModestoPower.Core.Domain.Programs;
using RAM.Core;

namespace RAM.Repository.Mongo.Repositories
{
    public class ProgramRepository : IProgramRepository
    {
        private String _connectionString;
        private MongoClient _client;
        private MongoServer _server;
        private MongoDatabase _database;
        private MongoCollection _collection;
        public ProgramRepository()
        {
            _connectionString = ConfigurationManager.AppSettings["mongoConnectionString"];
            _client = new MongoClient(_connectionString);
            _server = _client.GetServer();
            _database = _server.GetDatabase(ConfigurationManager.AppSettings["mongoDatabase"]);
            _collection = _database.GetCollection<IProgram>(ResourceStrings.Mongo_Programs_Collection);
        }
        public IList<IProgram> GetAll()
        {
            return _collection.FindAllAs<IProgram>().ToList<IProgram>();
        }

        public IProgram GetById(ObjectId id)
        {
            var query = Query<IProgram>.EQ(e => e.Id, id);
            return _collection.FindOneAs<IProgram>(query);
        }

        public IProgram Save(IProgram p)
        {
            return _collection.Save(p) as IProgram;
        }

        public IProgram Delete(IProgram p)
        {
            var query = Query<IProgram>.EQ(e => e.Id, p.Id);

            return _collection.Remove(query) as IProgram;
        }
    }
}
