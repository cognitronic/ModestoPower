﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using RAM.Core.Domain.User;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
namespace RAM.Repository.Mongo.Repositories
{
    public class UserRepository : IUserRepository
    {
        private MongoCollection userCollection;

        public UserRepository()
        {
             userCollection = new MongoClient(ConfigurationManager.AppSettings["mongoConnectionString"]).GetServer().GetDatabase(ConfigurationManager.AppSettings["mongoDatabase"]).GetCollection("user");
        }
        public User FindByID(int ID)
        {
            var query = Query.EQ("firstname", "DannyTickleBalls");
            return userCollection.FindAs<User>(query).FirstOrDefault();
        }

        public int Save(User entity)
        {
            throw new NotImplementedException();
        }

        public int Add(User entity)
        {
            throw new NotImplementedException();
        }

        public int Remove(User entity)
        {
            throw new NotImplementedException();
        }

        public User FindBy(User entity)
        {
            throw new NotImplementedException();
        }

        public IList<User> FindAll()
        {
            throw new NotImplementedException();
        }

        public IList<User> FindAll(int index, int count)
        {
            throw new NotImplementedException();
        }

        public IList<User> FindBy(Infrastructure.Querying.Query query)
        {
            throw new NotImplementedException();
        }

        public IList<User> FindBy(Infrastructure.Querying.Query query, int index, int count)
        {
            throw new NotImplementedException();
        }
    }
}
