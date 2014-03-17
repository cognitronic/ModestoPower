using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RAM.Infrastructure.Domain;
using MongoDB.Bson;

namespace RAM.Core.Domain.Blog
{
    public interface ITagRepository 
    {
        IList<Tag> GetAll();
        Tag GetById(ObjectId id);
        Tag Save(Tag t);
        Tag Delete(Tag t);
        Tag GetByTitle(string title);
        IList<Tag> GetForAutoComplete(string input);
    }
}
