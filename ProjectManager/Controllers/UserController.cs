using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectManager.Common;
using ProjectManager.Models;
using ProjectManager.Service;

namespace ProjectManager.Controllers
{
    public class UserController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Add()
        {
            ViewBag.Job = AttrService.GetAttrSelectList("职务");
            ViewBag.Position = AttrService.GetAttrSelectList("职位");
            return View();
        }

        [HttpPost]
        public ActionResult Add(UserModel userModel)
        {
            ResultModel<UserModel> result=new ResultModel<UserModel>();
            if (ModelState.IsValid)
            {
                userModel.Salt = new Random().Next();
                userModel.Pwd = (userModel.Pwd + userModel.Salt).MD5();
                userModel.Insert();
            }
            else
            {
                result.Res = false;
                result.Msg = ValidateMessage(ModelState);
            }
            return Json(result);
        }

    }
}
