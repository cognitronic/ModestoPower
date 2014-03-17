using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RAM.Core.Domain.Blog;
using RAM.Infrastructure.Querying;
using RAM.Services.Interfaces;
using RAM.Services.Messaging.Blog;
using RAM.Services.Mapping;
using RAM.Services.Cache;
using RAM.Infrastructure.UnitOfWork;

namespace RAM.Services.Implementations
{
    public class BlogService : IBlogService
    {
        private readonly IBlogRepository _repository;
        private readonly IBlogTagRepository _blogtagRepository;
        private readonly ICacheStorage _cache;
        private readonly IUnitOfWork _uow;

        public BlogService(IBlogRepository repository, IBlogTagRepository blogtagRepository, ICacheStorage cache, IUnitOfWork uow)
        {
            _repository = repository;
            _blogtagRepository = blogtagRepository;
            _cache = cache;
            _uow = uow;
        }

        #region IBlogService Members

        public GetBlogByTitleResponse GetByTitle(GetBlogByTitleRequest request)
        {
            var response = new GetBlogByTitleResponse();

            var post = _repository.GetByTitle(request.Title);
            if (post != null)
            {
                response.Success = true;
                response.Message = "Blogs Retrieved Successfully!";
                response.BlogPost = post;
            }
            else
            {
                response.Success = false;
                response.Message = "Blogs Retrieved Failed!";
            }

            return response;
        }

        public GetBlogsResponse GetByCategory(GetBlogsByCategoryRequest request)
        {
            var response = new GetBlogsResponse();

            var list = _repository.GetByCategory(request.CategoryName);
            if (list != null)
            {
                response.Success = true;
                response.Message = "Blogs Retrieved Successfully!";
                response.BlogList = list.ToList<IBlog>();
            }
            else
            {
                response.Success = false;
                response.Message = "Blogs Retrieved Failed!";
            }

            return response;
        }

        public GetBlogsResponse GetAll()
        {
            var response = new GetBlogsResponse();
            var list = new List<IBlog>();
            if (_cache.Get<IList<IBlog>>(RAM.Core.ResourceStrings.Cache_BlogPosts) == null)
            {
                list = _repository.GetAll()
                    .Where(o => o.isactive = true)
                    .OrderByDescending(o => o.dateposted).ToList<IBlog>();
                _cache.Store(RAM.Core.ResourceStrings.Cache_BlogPosts, list);
            }
            else
            { 
                list = _cache.Get<List<IBlog>>(RAM.Core.ResourceStrings.Cache_BlogPosts);
            }

            if (list != null)
            {
                response.Success = true;
                response.Message = "Blogs Retrieved Successfully!";
                response.BlogList = list.ToList<IBlog>();
            }
            else
            {
                response.Success = false;
                response.Message = "Blogs Retrieved Failed!";
            }

            return response;
        }

        public IList<IBlog> GetLatestPosts(int count)
        {
            var list = _cache.Get<IList<IBlog>>(RAM.Core.ResourceStrings.Cache_BlogPosts);
            if (list == null)
            {
                list = _repository.GetAll()
                    .Where(o => o.isactive = true)
                    .OrderByDescending(o => o.dateposted).Take(count).ToList<IBlog>();
                _cache.Store(RAM.Core.ResourceStrings.Cache_BlogPosts, list);
            }
            return list;
        }

        public GetBlogsResponse GetAllForAdmin()
        {
            var response = new GetBlogsResponse();
            var list = new List<IBlog>();
            if (_cache.Get<IList<IBlog>>(RAM.Core.ResourceStrings.Cache_BlogPosts) == null)
            {
                list = _repository.GetAll()
                    .OrderByDescending(o => o.dateposted).ToList<IBlog>();
                _cache.Store(RAM.Core.ResourceStrings.Cache_BlogPosts, list);
            }
            else
            {
                list = _cache.Get<List<IBlog>>(RAM.Core.ResourceStrings.Cache_BlogPosts);
            }

            if (list != null)
            {
                response.Success = true;
                response.Message = "Blogs Retrieved Successfully!";
                response.BlogList = list.ToList<IBlog>();
            }
            else
            {
                response.Success = false;
                response.Message = "Blogs Retrieved Failed!";
            }

            return response;
        }

        public Blog GetByID(string postID)
        {
            var blog = _repository.GetById(new MongoDB.Bson.ObjectId(postID));
            return blog;
        }

        public void SavePost(Blog post)
        {
            _repository.Save(post);
            _cache.Remove(RAM.Core.ResourceStrings.Cache_BlogPosts);
        }

        public void DeletePost(Blog post)
        {
            _repository.Delete(post);
            _cache.Remove(RAM.Core.ResourceStrings.Cache_BlogPosts);
        }
        #endregion
    

        public void SaveBlogTag(BlogTag blogtag)
        {
            _blogtagRepository.Save(blogtag);
            _uow.Commit();
        }

        public void DeleteBlogTag(BlogTag blogtag)
        {
            _blogtagRepository.Remove(blogtag);
            _uow.Commit();
        }
    }
}
