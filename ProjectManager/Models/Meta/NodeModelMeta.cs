
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
    [MetadataType(typeof(NodeModelMeta))]
    public partial class NodeModel
    {
        public partial class NodeModelMeta
        {
            [Display(Name = "名称")]
            [Required]
            [StringLength(20)]
            public string Name { get; set; }

            [Display(Name = "上级节点")]
            [Required]
            public int Pid { get; set; }

            [Display(Name = "链接")]
            [Required]
            [StringLength(100)]
            public string Link { get; set; }

            [Display(Name = "分组")]
            [Required]
            public int GroupID { get; set; }

            [Display(Name = "顺序")]
            [Required]
            public int SortNo { get; set; }
        }
	}
}

