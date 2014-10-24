﻿
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
    [MetadataType(typeof(AreaModelMeta))]
    public partial class AreaModel
    {
        public partial class AreaModelMeta
        {
            [Display(Name = "编号")]
            public int ID { get; set; }

            [Display(Name = "名称")]
            [Required]
            [StringLength(20)]
            [UIHint("Text")]
            public string Name { get; set; }
        }
	}
}

