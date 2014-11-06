using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectManager.Common;
using ProjectManager.Models;

namespace ProjectManager.Controllers
{
    public class AreaController : Controller
    {
        public ActionResult Load()
        {
            ResultModel<List<AreaModel>> result = new ResultModel<List<AreaModel>>();
            result.Data = AreaModel.Fetch("where project_id=@0", MyStatus.CurrentProject.ID);
            return Json(result);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();  
        }

        [HttpPost]
        public ActionResult Add(AreaModel model)
        {
            if (ModelState.IsValid)
            {
                model.ProjectID = MyStatus.CurrentProject.ID;
                model.Insert();
            }
            return Json(new ResultModel<ModuleModel>());
        }
    }
}
