using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectManager.Models;

namespace ProjectManager.Common
{
    public class MyStatus
    {
        #region const

        private const string Session_Key_CurrentProject = "current_project";

        private const string Session_Key_CurrentUser = "current_user";
        #endregion
        public static ProjectModel CurrentProject
        {
            get { return HttpContext.Current.Session[Session_Key_CurrentProject] as ProjectModel; }
            set { HttpContext.Current.Session[Session_Key_CurrentProject] = value; }
        }

        public static UserModel CurrentUser
        {
            get { return HttpContext.Current.Session[Session_Key_CurrentUser] as UserModel; }
            set { HttpContext.Current.Session[Session_Key_CurrentUser] = value; }
        }
    }
}