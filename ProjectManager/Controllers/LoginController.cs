using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectManager.Common;
using ProjectManager.Models;

namespace ProjectManager.Controllers
{
    public class LoginController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Index(string code, string pwd)
        {
            UserModel user = UserModel.SingleOrDefault("where code=@0", code);
            if (null == user)
            {
                ViewBag.Error = "用户不存在";
                return View();
            }
            string tmp_pwd = (pwd + user.Salt).MD5();
            if (tmp_pwd != user.Pwd)
            {
                ViewBag.Error = "密码错误";
                return View();
            }
            MyStatus.CurrentUser = user;
            return View();
        }
    }
}
