
//*****************************************************************
//
// File Name:   AccessMeta.cs
//
// Description:  Sys_Access:权限表
//
// Coder:       CodeSmith Generate
//
// Date:        2013-06-27 
//
//*****************************************************************

using System;
using System.ComponentModel.DataAnnotations;

namespace ProjectManager.Models
{
    [Serializable]
    [MetadataType(typeof(RequirementModelMeta))]
    public partial class RequirementModel
    {
        public partial class RequirementModelMeta
        {
            [Display(Name = "编号")]
            public int ID { get; set; }

            [Display(Name = "名称")]
            [Required]
            [StringLength(20)]
            [UIHint("Text")]
            public string Name { get; set; }


            [Display(Name = "模块")]
            [Required]
            [StringLength(20)]
            [UIHint("Text")]
            public string ModuleName { get; set; }


            [Display(Name = "区域")]
            [Required]
            [StringLength(20)]
            [UIHint("Text")]
            public string AreaName { get; set; }


            [Display(Name = "角色")]
            [Required]
            [StringLength(20)]
            [UIHint("Text")]
            public string Roles { get; set; }


            [Display(Name = "数据来源")]
            [Required]
            [StringLength(100)]
            [UIHint("Text")]
            public string DataSource { get; set; }

            [Display(Name = "需求描述")]
            [Required]
            [StringLength(4000)]
            public string Description { get; set; }

            [Display(Name = "版本号")]
            public int Version { get; set; }

            [Display(Name = "约束")]
            [Required]
            [StringLength(500)]
            public string Premise { get; set; }
        }
    }
}

