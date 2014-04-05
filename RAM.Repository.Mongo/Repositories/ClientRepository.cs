using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModestoPower.Core.Domain.Client;
using MongoDB.Bson;
using RAM.Core;
using RAM.Services.Cache;

namespace RAM.Repository.Mongo.Repositories
{
    public class ClientRepository : BaseRepository, IClientRepository
    {
        private readonly ICacheStorage _cache;
        public ClientRepository(ICacheStorage cache)
            : base(ResourceStrings.Mongo_Client_Collection)
        {
            _cache = cache;
        }

        public IList<Client> GetAll()
        {
            throw new NotImplementedException();
        }

        public Client GetById(string id)
        {
            throw new NotImplementedException();
        }

        public Client Save(Client client)
        {
            _collection.Save(client);
            return client;
        }
    }
}
