using System;
using System.ComponentModel.DataAnnotations;

namespace ProjectManager.Models
{
    [Serializable]
    [MetadataType(typeof(RoleModelMeta))]
    public partial class RoleModel
    {
        public partial class RoleModelMeta
        {
            [Display(Name = "编号")]
            public int ID { get; set; }

            [Display(Name = "角色名")]
            [Required]
            [StringLength(20)]
            public string Name { get; set; }

            [Display(Name = "备注")]
            [StringLength(100)]
            public string Remark { get; set; }
        }
    }
}

