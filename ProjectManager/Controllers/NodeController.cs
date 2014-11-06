﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectManager.Models;

namespace ProjectManager.Controllers
{
    public class NodeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(NodeModel node)
        {
            return View();
        }

        public ActionResult GetNode()
        {
            List<NodeModel> nodelList = NodeModel.Fetch("");
            return Json(nodelList);
        }
    }
}
