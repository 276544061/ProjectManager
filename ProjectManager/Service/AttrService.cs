using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectManager.Models;

namespace ProjectManager.Service
{
    public class AttrService
    {
        public static List<AttrModel> GetAttrByType(string type)
        {
            List<AttrModel> list = AttrModel.Fetch("where type=@0", type);
            return list;
        } 

        public static SelectList GetAttrSelectList(string type)
        {
            List<AttrModel> list = GetAttrByType(type);
            SelectList selectList=new SelectList(list,"id","name");
            return selectList;
        }
    }
}