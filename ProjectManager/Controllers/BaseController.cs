using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace ProjectManager.Controllers
{
    public class BaseController : Controller
    {
        protected string ValidateMessage(ModelStateDictionary  modelState)
        {
            StringBuilder msg=new StringBuilder();
            foreach (var item in modelState)
            {
                foreach (var error in item.Value.Errors)
                {
                    msg.AppendFormat("<p>{0}</p>", error.ErrorMessage);
                }
            }
            return msg.ToString();
        }
    }
}
