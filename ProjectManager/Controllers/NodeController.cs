using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectManager.Models;

namespace ProjectManager.Controllers
{
    public class NodeController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Add()
        {
            ViewBag.GroupID = new SelectList(GroupModel.Fetch(""), "ID", "Name");
            NodeModel model=new NodeModel();
            model.Pid = 0;
            model.SortNo = 100;
            return View(model);
        }

        [HttpPost]
        public ActionResult Add(NodeModel node)
        {
            ResultModel<NodeModel> result = new ResultModel<NodeModel>();
            if (ModelState.IsValid)
            {
                node.Insert();
            }
            else
            {
                result.Res = false;
                result.Msg = ValidateMessage(ModelState);
            }
            return Json(result);
        }

        public ActionResult GetNode()
        {
            List<NodeModel> nodelList = NodeModel.Fetch("");
            return Json(nodelList,JsonRequestBehavior.AllowGet);
        }
    }
}
