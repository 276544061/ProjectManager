﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectManager.Common;
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

        [HttpGet]
        public ActionResult SimpleAdd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(ModuleModel model)
        {
            if (ModelState.IsValid)
            {
                model.ProjectID = MyStatus.CurrentProject.ID;
                model.Insert();
            }
            return Json(new ResultModel<ModuleModel>());
        }

        public ActionResult Load()
        {
            ResultModel<List<ModuleModel>> result=new ResultModel<List<ModuleModel>>();
            result.Data = ModuleModel.Fetch("where project_id=@0", MyStatus.CurrentProject.ID);
            return Json(result);
        }
    }
}
