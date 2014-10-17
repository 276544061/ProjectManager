using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectManager.Models;

namespace ProjectManager.Common
{
    public class MyStatus
    {
        public static ProjectModel CurrentProject
        {
            get { return HttpContext.Current.Session["current_project"] as ProjectModel; }
            set { HttpContext.Current.Session["current_project"] = value; }
        }
    }
}