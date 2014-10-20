using System.Web.Mvc;
using PetaPoco;
using ProjectManager.Common;
using ProjectManager.Models;

namespace ProjectManager.Controllers
{
    public class ProjectController : Controller
    {
        public ActionResult Index(int page = 1)
        {
            ProjectIndexViewModel model = new ProjectIndexViewModel();
            model.ProjectList = ProjectModel.Page(page, 30, "");
            model.ProjectList.Item = new ProjectModel();
            return View(model);
        }

        public ActionResult Page(int page = 1)
        {
            ProjectIndexViewModel model = new ProjectIndexViewModel();
            model.ProjectList = ProjectModel.Page(page, 30, "");
            model.ProjectList.Item = new ProjectModel();
            return Json(model.ProjectList.Items);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(ProjectModel model)
        {
            ResultModel<ProjectModel> result = new ResultModel<ProjectModel>();
            result.Res = true;
            result.Msg = "保存成功";
            if (ModelState.IsValid)
            {
                model.Insert();
            }
            return Json(result);
        }

        [HttpGet]
        public ActionResult Edit(int id=0)
        {
            ProjectModel model = ProjectModel.SingleOrDefault(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(ProjectModel model)
        {
            ResultModel<ProjectModel> result = new ResultModel<ProjectModel>();
            result.Res = true;
            result.Msg = "保存成功";
            if (ModelState.IsValid)
            {
                model.Update();
            }
            return Json(result);
        }

        public ActionResult Delete(int id = 0)
        {
            ResultModel<ProjectModel> result = new ResultModel<ProjectModel>();
            if (id == 0)
            {
                result.Res = false;
                result.Msg = "错误的参数";
                return Json(result);
            }
            result.Res = ProjectModel.Delete(id) == 1;
            result.Msg = string.Format("删除成功");
            return RedirectToAction("index");
        }

        public ActionResult Change(int id = 0)
        {
            ResultModel<ProjectModel> result = new ResultModel<ProjectModel>();
            if (0 == id)
            {
                result.Res = false;
                result.Msg = "无效参数";
            }
            ProjectModel model = ProjectModel.SingleOrDefault(id);
            MyStatus.CurrentProject = model;
            return Json(result);
        }
    }
}
