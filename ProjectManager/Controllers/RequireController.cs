using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PetaPoco;
using ProjectManager.Common;
using ProjectManager.Models;

namespace ProjectManager.Controllers
{
    public class RequireController : BaseController
    {
        [HttpGet]
        public ActionResult Add(int id = 0)
        {
            if (0 == id)
            {
                if (null == MyStatus.CurrentProject)
                {
                    return RedirectToAction("index", "Project");
                }
            }
            else
            {
                MyStatus.CurrentProject = ProjectModel.SingleOrDefault(id);
            }

            RequirementModel model = new RequirementModel();
            ViewBag.Roles = new List<string>(MyStatus.CurrentProject.Roles.Split(';'));
            ViewBag.ModuleName = new SelectList(ModuleModel.Fetch("where project_id=@0", MyStatus.CurrentProject.ID), "ID", "Name");
            ViewBag.AreaName = new SelectList(AreaModel.Fetch("where project_id=@0", MyStatus.CurrentProject.ID), "ID", "Name");
            return View(model);
        }

        [HttpPost]
        public ActionResult Add(RequirementModel model)
        {
            ResultModel<RequirementModel> result = new ResultModel<RequirementModel>();
            result.Res = ModelState.IsValid;
            if (result.Res)
            {
                model.Insert();
            }
            else
            {
                result.Msg = ValidateMessage(ModelState);
            }
            return Json(result);
        }


        public ActionResult Index(int id = 0, int page = 1)
        {
            Page<RequirementModel> list = RequirementModel.Page(page, 20, "where project_id=@0", id);
            return View(list);
        }

    }
}
