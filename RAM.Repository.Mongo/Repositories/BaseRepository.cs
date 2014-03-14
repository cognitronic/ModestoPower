using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver.Builders;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Configuration;
using RAM.Services.Cache;
using RAM.Infrastructure.UnitOfWork;

namespace RAM.Repository.Mongo.Repositories
{
    public class BaseRepository
    {
        protected String _connectionString;
        protected MongoClient _client;
        protected MongoServer _server;
        protected MongoDatabase _database;
        protected MongoCollection _collection;
        protected  ICacheStorage _cache;
        protected  IUnitOfWork _uow;

        public BaseRepository(string connectionString, MongoClient client, MongoServer server, MongoDatabase database, MongoCollection collection, ICacheStorage cache, IUnitOfWork uow) 
        {
            _connectionString = connectionString;
            _client = client;
            _server = server;
            _database = database;
            _collection = collection;
            _cache = cache;
            _uow = uow;
        }

        public BaseRepository(string collection) 
        {
            _connectionString = ConfigurationManager.AppSettings["mongoConnectionString"];
            _client = new MongoClient(_connectionString);
            _server = _client.GetServer();
            _database = _server.GetDatabase(ConfigurationManager.AppSettings["mongoDatabase"]);
            _collection = _database.GetCollection(collection);
        }
    }
}
