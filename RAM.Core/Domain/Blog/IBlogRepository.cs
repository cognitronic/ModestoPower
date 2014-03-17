using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using RAM.Infrastructure.Domain;

namespace RAM.Core.Domain.Blog
{
    public interface IBlogRepository
    {
        IList<Blog> GetAll();
        Blog GetById(ObjectId id);
        Blog Save(Blog b);
        Blog Delete(Blog b);
        Blog GetByTitle(string title);
        IList<Blog> GetByTag(string tag);
        IList<Blog> GetByCategory(string category);
    }
}
