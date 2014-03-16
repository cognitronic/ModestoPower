using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RAM.Core.Domain.Banner;
using RAM.Core.Domain.Project;
using RAM.Core.Domain.Blog;
using ModestoPower.Core.Domain.Pages;

namespace RAM.Controllers.ViewModels
{
    public class HomeView
    {
        public HomeView()
        {
            NavView = new NavigationView();
            UserView = new User.UserAccountView();
        }
        public NavigationView NavView { get; set; }

        public IList<IBanner> Banners { get; set; }

        public IList<IProject> Projects { get; set; }
        public IProject SelectedProject { get; set; }

        public IPages SelectedPage { get; set; }

        public IList<IBlog> Posts { get; set; }

        public IBlog SelectedPost { get; set; }

        public IList<IBlogCategory> Categories { get; set; }

        public User.UserAccountView UserView { get; set; }
    }
}
