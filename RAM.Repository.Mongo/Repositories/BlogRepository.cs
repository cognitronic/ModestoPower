using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using RAM.Core.Domain.Blog;
using RAM.Core;
using RAM.Services.Cache;

namespace RAM.Repository.Mongo.Repositories
{
    public class BlogRepository : BaseRepository, IBlogRepository
    {
        private readonly ICacheStorage _cache;
        public BlogRepository(ICacheStorage cache)
            : base(ResourceStrings.Mongo_Blog_Collection)
        {
            _cache = cache;
        }

        public IList<Blog> GetAll()
        {
            return _collection.FindAllAs<Blog>().OrderByDescending(o => o.dateposted).ToList<Blog>();
        }

        public Blog GetById(ObjectId id)
        {
            var query = Query<Blog>.EQ(e => e.Id, id);
            return _collection.FindOneAs<Blog>(query);
        }

        public Blog GetByTitle(string title)
        {
            var query = Query<Blog>.EQ(e => e.title, title);
            return _collection.FindOneAs<Blog>(query);
        }

        public Blog Save(Blog p)
        {
            _collection.Save(p);
            return p;
        }

        public Blog Delete(Blog p)
        {
            var query = Query<Blog>.EQ(e => e.Id, p.Id);
            _collection.Remove(query);
            return null;
        }

        public IList<Blog> GetByTag(string tag)
        {
            var query = Query<Blog>.EQ(e => e.tags, tag);
            return _collection.FindAs<Blog>(query).OrderByDescending(o => o.dateposted).ToList();
        }

        public IList<Blog> GetByCategory(string category)
        {
            var query = Query<Blog>.EQ(e => e.category, category);
            return _collection.FindAs<Blog>(query).OrderByDescending(o => o.dateposted).ToList();
        }
    }
}
