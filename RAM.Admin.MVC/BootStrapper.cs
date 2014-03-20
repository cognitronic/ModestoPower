using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RAM.Infrastructure.Authentication;
using RAM.Core.Domain.User;
using RAM.Services.Implementations;
using RAM.Services.Interfaces;
using StructureMap;
using RAM.Core.Domain.Blog;
using RAM.Core.Domain.Project;
using RAM.Core.Domain.Banner;
using StructureMap.Configuration.DSL;
using RAM.Infrastructure.Configuration;
using RAM.Infrastructure.Logging;
using RAM.Infrastructure.Email;
using RAM.Admin.Controllers.ActionArguments;
using RAM.Infrastructure.UnitOfWork;
//using RAM.Repository.NHibernate;
using RAM.Services.Cache;
using System.Web.Security;
using ModestoPower.Core.Domain.Programs;
using ModestoPower.Core.Domain.Pages;
using RAM.Web.Security;
using RAM.Repository.Mongo.Repositories;
using ModestoPower.Core.Domain.Schedule;
//using RAM.Repository.NHibernate.Repositories;

namespace RAM.Admin.MVC
{
    public class BootStrapper
    {
        public static void ConfigureStructureMap()
        {
            ObjectFactory.Initialize(x => { x.AddRegistry<ApplicationSettingsRegistry>(); });
            ApplicationSettingsFactory.
                InitializeApplicationSettingsFactory
                                  (ObjectFactory.GetInstance<IApplicationSettings>());

            ObjectFactory.Initialize(x => { x.AddRegistry<ModelRegistry>(); });
        }

        public class ModelRegistry : Registry
        {
            public ModelRegistry()
            {
                if (ApplicationSettingsFactory.
                    GetApplicationSettings().
                    PersistenceStrategy.Equals(RAM.Infrastructure.Domain.PersistenceStrategy.NHibernate.ToString()))
                {
                    //Repositories
                    //For<IUserRepository>().Use<UserRepository>();
                }
                else
                {
                    For<IUserRepository>().Use<RAM.Repository.Mongo.Repositories.UserRepository>();
                    For<IScheduleRepository>().Use<RAM.Repository.Mongo.Repositories.ScheduleRepository>();
                }

                For<IBlogRepository>().Use<BlogRepository>();
                For<ITagRepository>().Use<TagRepository>();
               // For<IBlogTagRepository>().Use<BlogTagRepository>();
               //// For<ISubscriberRepository>().Use<SubscriberRepository>();
               // For<IProjectRepository>().Use<ProjectRepository>();
               For<IProgramRepository>().Use<ProgramRepository>();
               For<IPagesRepository>().Use<WebPageRepository>();
               // For<IProjectImageRepository>().Use<ProjectImageRepository>();
               // For<IBannerRepository>().Use<BannerRepository>();
               // For<IBlogCategoryRepository>().Use<BlogCategoryRepository>();

               For<IUnitOfWork>().Use<RAM.Repository.Mongo.MongoUnitOfWork>();

                For<ICacheStorage>().Use<MongoDBCacheAdapter>();

                //Models
                For<IUser>().Use<User>();
                For<IBlog>().Use<Blog>();
                For<ITag>().Use<Tag>();
                For<ISchedule>().Use<Schedule>();
                For<IPages>().Use<Pages>();
               // For<ISubscriber>().Use<Subscriber>();
                For<IProject>().Use<Project>();
                For<IProjectImage>().Use<ProjectImage>();
                For<IBanner>().Use<Banner>();
                For<IBlogCategory>().Use<BlogCategory>();
                For<IProgram>().Use<Program>();

                //Services
                For<IUserService>().Use<UserService>();
                For<IProgramService>().Use<ProgramService>();
                //For<IBannerService>().Use<BannerService>();
                //For<ISubscriberService>().Use<SubscriberService>();
                //For<IBlogService>().Use<BlogService>();
                //For<IProjectService>().Use<ProjectService>();
                //For<IBlogCategoryService>().Use<BlogCategoryService>();

                // Logger
                For<ILogger>().Use
                          <Log4NetAdapter>();
                // Email Service                 
                For<IEmailService>().Use
                        <SMTPService>();
                //Authentication
                For<IExternalAuthenticationService>().Use<JanrainAuthenticationService>();
                For<IFormsAuthentication>().Use<AspFormsAuthentication>();
                For<ILocalAuthenticationService>().Use<HRRMarketingAuthenticationService>();
                //Controller Helpers
                For<IActionArguments>().Use<HttpRequestActionArguments>();
            }
        }

        public class ApplicationSettingsRegistry : Registry
        {
            public ApplicationSettingsRegistry()
            {
                // Application Settings                 
                For<IApplicationSettings>().Use
                         <WebConfigApplicationSettings>();
            }
        }

        public static IContainer ConfigureStructureMapWebAPI()
        {
            ObjectFactory.Initialize(x => { x.AddRegistry<ApplicationSettingsRegistry>(); });
            ApplicationSettingsFactory.
                InitializeApplicationSettingsFactory
                                  (ObjectFactory.GetInstance<IApplicationSettings>());
            if (ApplicationSettingsFactory.
                    GetApplicationSettings().
                    PersistenceStrategy.Equals(RAM.Infrastructure.Domain.PersistenceStrategy.NHibernate.ToString()))
            {
                var container = new Container(x =>
                {
                    x.For<IUserService>().Use<UserService>();
                    //x.For<IBannerService>().Use<BannerService>();
                    //x.For<IBlogService>().Use<BlogService>();
                    //x.For<IProjectService>().Use<ProjectService>();
                    //x.For<ISubscriberService>().Use<SubscriberService>();
                    //x.For<IBlogCategoryService>().Use<BlogCategoryService>();

                   // x.For<IUserRepository>().Use<RAM.Repository.NHibernate.Repositories.UserRepository>();
                    //x.For<IBannerRepository>().Use<BannerRepository>();
                    //x.For<IBlogTagRepository>().Use<BlogTagRepository>();
                    x.For<IBlogRepository>().Use<BlogRepository>();
                    x.For<ITagRepository>().Use<TagRepository>();
                    x.For<IScheduleRepository>().Use<ScheduleRepository>();
                    ////x.For<ISubscriberRepository>().Use<SubscriberRepository>();
                    //x.For<IProjectRepository>().Use<ProjectRepository>();
                    //x.For<IProjectImageRepository>().Use<ProjectImageRepository>();
                    //x.For<IBlogCategoryRepository>().Use<BlogCategoryRepository>();

                    x.For<IUnitOfWork>().Use<RAM.Repository.Mongo.MongoUnitOfWork>();

                    x.For<ICacheStorage>().Use<MongoDBCacheAdapter>();

                    x.For<IUser>().Use<User>();
                    x.For<IBanner>().Use<Banner>();
                    x.For<ISchedule>().Use<Schedule>();
                    x.For<IBlog>().Use<Blog>();
                    x.For<ITag>().Use<Tag>();
                   // x.For<ISubscriber>().Use<Subscriber>();
                    x.For<IProject>().Use<Project>();
                    x.For<IProjectImage>().Use<ProjectImage>();
                    x.For<IBlogCategory>().Use<BlogCategory>();

                    x.For<ILogger>().Use<Log4NetAdapter>();

                    x.For<IEmailService>().Use<SMTPService>();

                    x.For<IExternalAuthenticationService>().Use<JanrainAuthenticationService>();
                    x.For<IFormsAuthentication>().Use<AspFormsAuthentication>();
                    x.For<ILocalAuthenticationService>().Use<HRRMarketingAuthenticationService>();

                    x.For<IActionArguments>().Use<HttpRequestActionArguments>();
                });
                return container;
            }
            else
            {
                var container = new Container(x =>
                {
                    x.For<IUserService>().Use<UserService>();
                    x.For<IBannerService>().Use<BannerService>();
                    //x.For<IBlogService>().Use<BlogService>();
                    //x.For<IProjectService>().Use<ProjectService>();
                    //x.For<ISubscriberService>().Use<SubscriberService>();
                    //x.For<IBlogCategoryService>().Use<BlogCategoryService>();
                    x.For<IProgramService>().Use<ProgramService>();

                    x.For<IUserRepository>().Use<RAM.Repository.Mongo.Repositories.UserRepository>();
                    x.For<IProgramRepository>().Use<RAM.Repository.Mongo.Repositories.ProgramRepository>();
                    x.For<IScheduleRepository>().Use<RAM.Repository.Mongo.Repositories.ScheduleRepository>();
                    //x.For<IBannerRepository>().Use<BannerRepository>();
                    //x.For<IBlogTagRepository>().Use<BlogTagRepository>();
                    x.For<IBlogRepository>().Use<BlogRepository>();
                    x.For<ITagRepository>().Use<TagRepository>();
                   // x.For<ISubscriberRepository>().Use<SubscriberRepository>();
                    //x.For<IProjectRepository>().Use<ProjectRepository>();
                    //x.For<IProjectImageRepository>().Use<ProjectImageRepository>();
                    //x.For<IBlogCategoryRepository>().Use<BlogCategoryRepository>();

                    x.For<IUnitOfWork>().Use<RAM.Repository.Mongo.MongoUnitOfWork>();

                    x.For<ICacheStorage>().Use<MongoDBCacheAdapter>();

                    x.For<IUser>().Use<User>();
                    x.For<IBanner>().Use<Banner>();
                    x.For<IBlog>().Use<Blog>();
                    x.For<ISchedule>().Use<Schedule>();
                    x.For<ITag>().Use<Tag>();
                   // x.For<ISubscriber>().Use<Subscriber>();
                    x.For<IProject>().Use<Project>();
                    x.For<IProjectImage>().Use<ProjectImage>();
                    x.For<IBlogCategory>().Use<BlogCategory>();
                    x.For<IProgram>().Use<Program>();

                    x.For<ILogger>().Use<Log4NetAdapter>();

                    x.For<IEmailService>().Use<SMTPService>();

                    x.For<IExternalAuthenticationService>().Use<JanrainAuthenticationService>();
                    x.For<IFormsAuthentication>().Use<AspFormsAuthentication>();
                    x.For<ILocalAuthenticationService>().Use<HRRMarketingAuthenticationService>();

                    x.For<IActionArguments>().Use<HttpRequestActionArguments>();
                });
                return container;
            }
            return null;
        }
    }
}