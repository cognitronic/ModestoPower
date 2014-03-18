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
    public class TagRepository : BaseRepository, ITagRepository
    {
        private readonly ICacheStorage _cache;
        public TagRepository(ICacheStorage cache)
            : base(ResourceStrings.Mongo_Tags_Collection)
        {
            _cache = cache;
        }

        public IList<Tag> GetAll()
        {
            return _collection.FindAllAs<Tag>().OrderBy(o => o.name).ToList<Tag>();
        }

        public IList<Tag> GetForAutoComplete(string input)
        {
            var query = Query.Matches("name", ".*" + input + ".*");
            return _collection.FindAllAs<Tag>().OrderBy(o => o.name).ToList<Tag>();
        }

        public Tag GetById(ObjectId id)
        {
            var query = Query<Tag>.EQ(e => e.Id, id);
            return _collection.FindOneAs<Tag>(query);
        }

        public Tag GetByTitle(string title)
        {
            var query = Query<Tag>.EQ(e => e.name, title);
            return _collection.FindOneAs<Tag>(query);
        }

        public Tag Save(Tag p)
        {
            _collection.Save(p);
            return p;
        }

        public Tag Delete(Tag p)
        {
            if (p != null)
            {
                var query = Query<Tag>.EQ(e => e.Id, p.Id);
                _collection.Remove(query);
            }
            return null;
        }
    }
}
