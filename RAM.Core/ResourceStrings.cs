using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAM.Core
{
    public class ResourceStrings
    {
        #region Session
        public static string Session_IsAuthenticated = "Is_Authenticated";
        public static string Session_CurrentUser = "Current_User";
        public static string Session_CurrentBaseURL = "Current_BaseURL";
        public static string Session_CurrentAccessLevel = "Current_AccessLevel";
        #endregion

        #region Cache
        public static string Cache_BlogPosts = "Cache_BlogPosts";
        public static string Cache_Projects = "Cache_Projects";
        public static string Cache_Banners = "Cache_Banners";
        public static string Cache_Programs = "Cache_Programs";
        #endregion

        #region Mongo
        public static string Mongo_Programs_Collection = "programs";
        public static string Mongo_WebPages_Collection = "pages";
        public static string Mongo_Blog_Collection = "blogs";
        public static string Mongo_Tags_Collection = "tags";
        public static string Mongo_Schedule_Collection = "schedule";
        public static string Mongo_Settings_Collection = "settings";
        public static string Mongo_Waiver_Collection = "waiver";
        public static string Mongo_Client_Collection = "client";
        #endregion
    }
}
