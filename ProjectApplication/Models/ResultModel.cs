using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectManager.Models
{
    public class ResultModel<T>
    {
        public bool Res { get; set; }
        public string Msg { get; set; }
        public T Data { get; set; }
    }
}