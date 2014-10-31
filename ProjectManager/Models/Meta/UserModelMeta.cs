using System;
using System.ComponentModel.DataAnnotations;

namespace ProjectManager.Models
{
    [Serializable]
    [MetadataType(typeof(UserModelMeta))]
    public partial class UserModel
    {
        public partial class UserModelMeta
        {
            [Display(Name = "编号")]
            public int ID { get; set; }

            [Display(Name = "姓名")]
            public string Name { get; set; }

            [Display(Name = "帐号")]
            public string Code { get; set; }

            [Display(Name = "密码")]
            public string Pwd { get; set; }

            [Display(Name = "邮箱")]
            public string Email { get; set; }

            [Display(Name = "手机")]
            public int Phone { get; set; }

            [Display(Name = "QQ")]
            public int QQ { get; set; }

            [Display(Name = "职务")]
            public string Job { get; set; }

            [Display(Name = "职位")]
            public string Position { get; set; }
        }
	}
}

