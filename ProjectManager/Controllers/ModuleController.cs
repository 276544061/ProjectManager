using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectManager.Models;

namespace ProjectManager.Controllers
{
    public class ModuleController : Controller
    {
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(ModuleModel model)
        {
            if (ModelState.IsValid)
            {
                model.Insert();
            }
            return Json(new ResultModel<ModuleModel>());
        }
    }
}
