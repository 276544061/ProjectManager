using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectManager.Common
{
    public static class ObjectExtend
    {
        public static int ToInt(this object value)
        {
            int iTemp;
            if (null == value)
            {
                return 0;
            }
            bool iRes = int.TryParse(value.ToString(), out iTemp);
            if (!iRes)
            {
                iTemp = 0;
            }
            return iTemp;
        }
    }
}