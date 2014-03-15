﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RAM.Core.Domain.Banner;
using RAM.Core.Domain.Project;
using RAM.Core.Domain.Blog;
using ModestoPower.Core.Domain.Programs;
using RAM.Core.Domain.User;
using ModestoPower.Core.Domain.Pages;

namespace RAM.Admin.Controllers.ViewModels
{
    public class HomeView
    {
        public HomeView()
        {
            NavView = new NavigationView();
            BlogCategories = new List<IBlogCategory>();
            Tags = new List<Tag>();
            Users = new List<User>();
            Programs = new List<IProgram>();
            WebPages = new List<IPages>();
        }
        public NavigationView NavView { get; set; }
        public IList<IBanner> Banners { get; set; }
        public IList<IProject> Projects { get; set; }
        public IList<IProgram> Programs { get; set; }
        public IList<User> Users { get; set; }
        public IList<IBlog> Blogs { get; set; }
        public IList<IPages> WebPages { get; set; }
        public IList<IBlogCategory> BlogCategories { get; set; }
        public IList<Tag> Tags { get; set; }
        public Blog SelectedBlog { get; set; }
        public IPages SelectedPage { get; set; }
        public IList<BlogTag> SelectedBlogTags { get; set; }

        public User SelectedUser { get; set; }
    }
}
