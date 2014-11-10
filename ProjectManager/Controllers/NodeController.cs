using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectManager.Models;

namespace ProjectManager.Controllers
{
    /// <summary>
    /// 节点管理
    /// </summary>
    public class NodeController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 添加页面加载
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Add()
        {
            ViewBag.GroupID = new SelectList(GroupModel.Fetch(""), "ID", "Name");
            NodeModel model=new NodeModel();
            model.Pid = 0;
            model.SortNo = 100;
            return View(model);
        }

        /// <summary>
        /// 添加节点保存数据
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
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

        /// <summary>
        /// 添加页面加载
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Edit()
        {
            ViewBag.GroupID = new SelectList(GroupModel.Fetch(""), "ID", "Name");
            NodeModel model = new NodeModel();
            model.Pid = 0;
            model.SortNo = 100;
            return View(model);
        }

        /// <summary>
        /// 添加节点保存数据
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Edit(NodeModel node)
        {
            ResultModel<NodeModel> result = new ResultModel<NodeModel>();
            if (ModelState.IsValid)
            {
                node.Update();
            }
            else
            {
                result.Res = false;
                result.Msg = ValidateMessage(ModelState);
            }
            return Json(result);
        }

        /// <summary>
        /// 删除节点
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(int id)
        {
            ResultModel<NodeModel> result = new ResultModel<NodeModel>();
            if (0!=id)
            {
                NodeModel.Delete(id);
            }
            else
            {
                result.Res = false;
                result.Msg = "请选择节点";
            }
            return Json(result);
        }

        /// <summary>
        /// 加载所有节点数据
        /// </summary>
        /// <returns></returns>
        public ActionResult GetNode()
        {
            List<NodeModel> nodelList = NodeModel.Fetch("");
            return Json(nodelList,JsonRequestBehavior.AllowGet);
        }
    }
}
