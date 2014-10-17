using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectManager.Models
{
    public class RequireAddViewModel
    {
        public List<string> Roles { get; set; }

        public RequirementModel Item { get; set; }

        public List<string> Areas { get; set; }

        public List<string> Modules { get; set; } 
    }
}