using System;
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

        public User FindByEmail(string email)
        {
            var query = Query.EQ("Email", email);
            
            return userCollection.FindAs<User>(query).FirstOrDefault();
        }

        public User AuthenticateUser(string email, string password)
        {
            var query = Query.And(
                Query.EQ("Email", email),
                Query.EQ("Password", password)
                );
            return userCollection.FindAs<User>(query).FirstOrDefault();
        }

        public User Save(User entity)
        {
            userCollection.Save(entity);
            return entity;
        }

        public User Add(User entity)
        {
            userCollection.Insert<User>(entity);
            return entity;

        }

        public User Remove(User entity)
        {
            var query = Query<User>.EQ(e => e.Id, entity.Id);
            userCollection.Remove(query);
            return entity;
        }

        public User FindBy(User entity)
        {
            throw new NotImplementedException();
        }

        public IList<User> FindAll()
        {
            return userCollection.FindAllAs<User>().ToList();
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
