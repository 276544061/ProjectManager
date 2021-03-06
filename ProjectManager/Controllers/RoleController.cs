﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PetaPoco;
using ProjectManager.Common;
using ProjectManager.Models;

namespace ProjectManager.Controllers
{
    /// <summary>
    /// 角色管理
    /// </summary>
    public class RoleController : BaseController
    {
        /// <summary>
        /// 角色列表
        /// </summary>
        /// <returns></returns>
        public ActionResult Index(Page<RoleModel> pageModel)
        {
            if (0 == pageModel.CurrentPage)
            {
                pageModel.CurrentPage = 1;
            }
            Page<RoleModel> roleList = RoleModel.Page(pageModel.CurrentPage, 20, "");
            return View(roleList);
        }

        /// <summary>
        /// 添加角色
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        /// <summary>
        /// 添加角色 保存数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Add(RoleModel model)
        {
            ResultModel<RoleModel> result = new ResultModel<RoleModel>();
            if (!ModelState.IsValid)
            {
                result.Res = false;
                result.Msg = ValidateMessage(ModelState);
            }

            try
            {
                model.Insert();
            }
            catch (Exception ex)
            {
                result.Res = false;
                result.Msg = ex.Message;
            }
            return Json(result);
        }

        /// <summary>
        /// 删除角色:同时删除角色权限对应表数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(int id)
        {
            ResultModel<RoleModel> result = new ResultModel<RoleModel>();
            if (0 == id)
            {
                result.Msg = "参数错误";
                result.Res = false;
            }
            using (var tran = RoleModel.repo.GetTransaction())
            {
                try
                {
                    AccessModel.Delete("where Role_ID=@0", id);
                    RoleModel.Delete(id);
                    tran.Complete();
                }
                catch (Exception ex)
                {
                    result.Msg = ex.Message;
                    result.Res = false;
                }
            }

            return Json(result);
        }

        /// <summary>
        /// 设置角色权限
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Access(int id)
        {
            RoleModel roleModel = RoleModel.SingleOrDefault(id);
            return View(roleModel);
        }
        /// <summary>
        /// 读取角色权限节点
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult GetAccess(int id)
        {
            List<AccessModel> accessList = AccessModel.Fetch("where Role_ID=@0", id);
            return Json(accessList,JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 保存角色权限
        /// </summary>
        /// <param name="role_id"></param>
        /// <param name="node"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult SaveAccess(int role_id, string node)
        {
            ResultModel<AccessModel> result=new ResultModel<AccessModel>();
            using (var tran = AccessModel.repo.GetTransaction())
            {
                try
                {
                    AccessModel.Delete("where role_id=@0", role_id);
                    string[] node_id = node.Split(',');
                    foreach (string item in node_id)
                    {
                        int n = item.ToInt();
                        if (0 == n)
                            continue;
                        AccessModel model = new AccessModel();
                        model.RoleID = role_id;
                        model.NodeID = n;
                        model.Insert();
                    }
                    tran.Complete();
                }
                catch (Exception ex)
                {
                    result.Res = false;
                    result.Msg = ex.Message;
                }
            }
            return Json(result);
        }

    }
}
