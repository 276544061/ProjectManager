using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectManager.Models
{
    public class ResultModel<T>
    {
        public ResultModel()
        {
            this.Res = true;
            this.Msg = "操作成功";
        }
        public bool Res { get; set; }
        public string Msg { get; set; }
        public T Data { get; set; }
        public string Callback { get; set; }
    }
}