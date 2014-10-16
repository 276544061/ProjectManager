using System.Web.Mvc;
using PetaPoco;
using ProjectManager.Models;

namespace ProjectManager.Controllers
{
    public class ProjectController : Controller
    {
        public ActionResult Index(int page=1)
        {
            ProjectIndexViewModel model=new ProjectIndexViewModel();
            model.ProjectList = ProjectModel.Page(page, 30, "");
            return View(model);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(ProjectModel model)
        {
            if (ModelState.IsValid)
            {
                model.Insert();
            }
            return View();
        }

    }
}
