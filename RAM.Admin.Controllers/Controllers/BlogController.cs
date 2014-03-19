using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RAM.Admin.Controllers.ViewModels;
using RAM.Core.Domain.User;
using RAM.Admin.Controllers.ActionArguments;
using RAM.Infrastructure.Authentication;
using RAM.Services.Interfaces;
using System.Web.Mvc;
using System.Web;
using System.IO;
using RAM.Core.Domain.Blog;
using System.Configuration;
using RAM.Services.Messaging.Blog;
using RAM.Core;
using System.Text.RegularExpressions;

namespace RAM.Admin.Controllers.Controllers
{
    public class BlogController : BaseUserAccountController
    {
        private readonly ITagRepository _tagRepository;
        private readonly IBlogRepository _blogRepository;
        public BlogController(ILocalAuthenticationService authenticationService,
            IUserService userService,
            IBlogRepository blogRepository,
            ITagRepository tagRepository,
            IExternalAuthenticationService externalAuthenticationService,
            IFormsAuthentication formsAuthentication,
            IActionArguments actionArguments)
            : base(authenticationService, userService, externalAuthenticationService, formsAuthentication, actionArguments)
        {
            _blogRepository = blogRepository;
            _tagRepository = tagRepository;

        }

        public ActionResult Index()
        {
            HomeView view = new HomeView();
            view.NavView.SelectedMenuItem = "nav-blog";
            view.BlogCategories = ConfigurationSettings.AppSettings["BlogCategories"].Split(',').ToList<string>();
            view.Blogs = _blogRepository.GetAll();
            view.Tags = _tagRepository.GetAll();
            return View(view);

        }

        public ActionResult BlogList()
        {
            HomeView view = new HomeView();
            view.NavView.SelectedMenuItem = "nav-blog";
            view.Blogs = _blogRepository.GetAll();

            return PartialView("_BlogList", view);

        }

        public ActionResult Post(string id)
        {
            HomeView view = new HomeView();
            view.BlogCategories = ConfigurationSettings.AppSettings["BlogCategories"].Split(',').ToList<string>();
            if (!string.IsNullOrEmpty(id))
                view.SelectedBlog = _blogRepository.GetById(new MongoDB.Bson.ObjectId(id));
            else
                view.SelectedBlog = null;
            view.NavView.SelectedMenuItem = "nav-blog";
            return View(view); 
        }

        public ActionResult SavePost(Blog blog, string tags)
        {
            var b = new Blog();
            var isNew = false;
            if (string.IsNullOrEmpty(blog.sid))
            {
                var images = new List<string>();
                b.imagepath = "";
                b.dateposted = DateTime.Now;
                isNew = true;
            }
            else
            {
                b = _blogRepository.GetById(new MongoDB.Bson.ObjectId(blog.sid));
            }
            b.category = blog.category;
            b.isactive = blog.isactive;
            b.tags.Clear();
            foreach (var tag in tags.Split(','))
            {
                b.tags.Add(tag);
            }
            b.post = blog.post;
            if (blog.post.Length > 300)
            {
                b.postpreview = Regex.Replace(blog.post.Substring(0, 297), @"<[^>]*>", String.Empty) + "...";
            }
            else
            {
                b.postpreview = Regex.Replace(blog.post, @"<[^>]*>", String.Empty); 
            }
            b.seodescription = blog.seodescription;
            b.seokeywords = blog.seokeywords;
            b.title = blog.title;
            _blogRepository.Save(b);
            if (b.tags != null)
            {
                foreach (var bt in b.tags)
                {
                    _tagRepository.Delete(_tagRepository.GetByTitle(bt.ToLower()));
                }
            }
            foreach (var t in tags.Split(','))
            {
                var tag = _tagRepository.GetByTitle(t);
                var blogtag = new BlogTag();
                var newtag = new Tag();
                if (tag == null)
                {
                    newtag.name = t.ToLower();
                    _tagRepository.Save(newtag);
                }

            }
            return Json(new
            {
                Message = "Blog saved!",
                Status = "success",
                BlogID = b.Id.ToString(),
                IsNew = isNew,
                ReturnUrl = "/Blog"
            });
        }

        public ActionResult SavePostImage()
        {
            var post = new Blog();
            if (Request.Form.Count > 0)
            {
                if (!string.IsNullOrEmpty(Request.Form["blogID"]))
                {
                    post = _blogRepository.GetById(new MongoDB.Bson.ObjectId(Request.Form["blogID"]));
                }
            }
            foreach (string fileName in Request.Files)
            {
                try
                {
                    var file = Request.Files[fileName];
                    post.imagepath = ConfigurationSettings.AppSettings["BlogImageURL"] + file.FileName;
                    file.SaveAs(ConfigurationSettings.AppSettings["BlogImageDir"] + file.FileName);
                }
                catch (Exception fileException)
                {
                    return Json(new
                    {
                        Message = "File failed to save with following error: " + fileException.Message,
                        Status = "failed"
                    });
                }
            }
            try
            {
                _blogRepository.Save(post);
            }
            catch (Exception exc)
            {
                return Json(new
                {
                    Message = "Blog post failed to save with following error: " + exc.Message,
                    Status = "failed"
                });
            }

            return Json(new
            {
                Message = "Blog Image saved!",
                Status = "success",
                ReturnUrl = "/Blog/Post/" + post.Id.ToString()
            });
        }

        public ActionResult GetByID(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                return Json(new
                {
                    Message = "Blog retreived!",
                    Status = "success",
                    BlogRef = _blogRepository.GetById(new MongoDB.Bson.ObjectId(id)),
                    ReturnUrl = "/Blog"
                });
            }
            return Json(new
            {
                Message = "Blog could not be found!",
                Status = "failed",
                ReturnUrl = "/Blog"
            });
        }


        public ActionResult TagList()
        {
            HomeView view = new HomeView();
            view.NavView.SelectedMenuItem = "nav-blog";
            view.Tags = _tagRepository.GetAll();

            return PartialView("_BlogTags", view);

        }

        public ActionResult GetTagsForAutoSelect(string query) 
        {
            return Json(new
            {
                Tags = _tagRepository.GetForAutoComplete(query.ToLower())
            }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetTagByID(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                return Json(new
                {
                    Message = "Tag retreived!",
                    Status = "success",
                    TagRef = _tagRepository.GetById(new MongoDB.Bson.ObjectId(id)),
                    ReturnUrl = "/Blog"
                });
            }
            return Json(new
            {
                Message = "Tag could not be found!",
                Status = "failed",
                ReturnUrl = "/Blog"
            });
        }

        public ActionResult SaveTag(Tag tag)
        {
            var t = new Tag();
            if (tag != null)
            {
                if (tag.Id != null)
                {
                    t = _tagRepository.GetById(new MongoDB.Bson.ObjectId(tag.sid));
                }
                t.name = tag.name;
                _tagRepository.Save(t);
            }

            return Json(new
            {
                Message = "Tag saved!",
                Status = "success",
                ReturnUrl = "/Blog"
            });
        }

        public ActionResult DeleteTag(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                try
                {                    
                    _tagRepository.Delete(_tagRepository.GetById(new MongoDB.Bson.ObjectId(id)));
                    return Json(new
                    {
                        Message = "Tag deleted!",
                        Status = "success",
                        ReturnUrl = "/Blog"
                    });
                }
                catch (Exception exc)
                {
                    return Json(new
                    {
                        Message = "Tag failed to delete!  You must remove all blog posts with this tag before it can be deleted.",
                        Status = "failed",
                        ReturnUrl = "/Blog"
                    });
                }
            }
            return Json(new
            {
                Message = "Tag failed to delete!  Tag was null.",
                Status = "failed",
                ReturnUrl = "/Blog"
            });
        }


        //public ActionResult CategoryList()
        //{
        //    HomeView view = new HomeView();
        //    view.NavView.SelectedMenuItem = "nav-blog";
        //    view.BlogCategories = _categoryService.GetAll().Categories;

        //    return PartialView("_BlogCategories", view);

        //}

        //public ActionResult GetCategoryByID(int id)
        //{
        //    if (id > 0)
        //    {
        //        var cat = _categoryService.GetByID(id);
        //        return Json(new
        //        {
        //            Message = "Category retreived!",
        //            Status = "success",
        //            CategoryRef = cat,
        //            ReturnUrl = "/Blog"
        //        });
        //    }
        //    return Json(new
        //    {
        //        Message = "Category could not be found!",
        //        Status = "failed",
        //        ReturnUrl = "/Blog"
        //    });
        //}

        //public ActionResult SaveCategory(BlogCategory category)
        //{
        //    var c = new BlogCategory();
        //    if (category != null)
        //    {
        //        if (category.ID > 0)
        //        {
        //            c = (BlogCategory)_categoryService.GetByID(category.ID);
        //        }
        //        c.Name = category.Name;
        //        _categoryService.Save(c);
        //    }

        //    return Json(new
        //    {
        //        Message = "Category saved!",
        //        Status = "success",
        //        ReturnUrl = "/Blog"
        //    });
        //}

        //public ActionResult DeleteCategory(int id)
        //{
        //    if (id > 0)
        //    {
        //        try
        //        {
        //            _categoryService.Delete((BlogCategory)_categoryService.GetByID(id));
        //            return Json(new
        //            {
        //                Message = "Category deleted!",
        //                Status = "success",
        //                ReturnUrl = "/Blog"
        //            });
        //        }
        //        catch (Exception exc)
        //        {
        //            return Json(new
        //            {
        //                Message = "Category failed to delete!  You must remove all blog posts with this category before it can be deleted.",
        //                Status = "failed",
        //                ReturnUrl = "/Blog"
        //            });
        //        }
        //    }
        //    return Json(new
        //    {
        //        Message = "Category failed to delete!  Category was null.",
        //        Status = "failed",
        //        ReturnUrl = "/Blog"
        //    });
        //}

        
    }
}
