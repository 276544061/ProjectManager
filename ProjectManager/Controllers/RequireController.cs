using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectManager.Common;
using ProjectManager.Models;

namespace ProjectManager.Controllers
{
    public class RequireController : Controller
    {
        public ActionResult Add()
        {
            RequireAddViewModel model = new RequireAddViewModel();
            model.Roles = new List<string>(MyStatus.CurrentProject.Roles.Split(';'));
            model.Modules =
                RequirementModel.repo.Fetch<string>(
                    "select Module_Name from Pro_Requirements where project_id=@0 group by Module_Name",
                    MyStatus.CurrentProject.ID);
            model.Areas =
                RequirementModel.repo.Fetch<string>(
                    "select Area_Name from Pro_Requirements where project_id=@0 group by Area_Name",
                    MyStatus.CurrentProject.ID);
            return View(model);
        }

    }
}
