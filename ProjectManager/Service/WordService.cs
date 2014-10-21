using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectManager.Models;
using Aspose.Words;
using System.ComponentModel.DataAnnotations;

namespace ProjectManager.Service
{
    /// <summary>
    /// 生成Word相关业务方法
    /// </summary>
    public class WordService
    {
        public static ResultModel<string> ProjectWord(int id)
        {
            ResultModel<string> result=new ResultModel<string>();
            ProjectModel project = ProjectModel.SingleOrDefault(id);
            Document doc = new Document(project.Name+" "+project.Version);
            DocumentBuilder builder=new DocumentBuilder(doc);
            
            //标题
            builder.Font.Name = "黑体";
            builder.Font.Size = 3;
            builder.Write(project.Name);
            builder.InsertBreak(BreakType.PageBreak);
            //
            builder.Font.Name = "宋体";
            builder.Font.Size = 5;
            builder.Font.Bold = true;
            builder.Writeln("业务需求");
            //内容
            List<RequirementModel> requireList = RequirementModel.Fetch("where project_id=@0", project.ID);
            foreach (RequirementModel item in requireList)
            {
                builder.StartTable();
                builder.InsertCell();
                builder.Write(GetDisplayName(item,"AreaName"));
            }
            return result;
        }
 
        private static string GetDisplayName(object o,string property)
        {
            Type t = o.GetType();
            var p = t.GetProperty(property);

            var displayName = p.GetCustomAttributes(typeof (DisplayAttribute), false);
            return displayName.ToString();
        }
    }
}