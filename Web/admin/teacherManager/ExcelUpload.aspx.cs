using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Adapte;
namespace cycms.Web.admin.teacherManager
{
    public partial class ExcelUpload : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!currentAdmin.IsSuper)
            {
                adminOpers.ShowNoPower();
                return;
            }
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            //备份原来的文件，保存新上传的文件并重命名
            if (!file1.HasFile)
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "alert('请选择导入的文件')", true);
                return;

            }
            else
                if (!file1.FileName.EndsWith(".xls"))
                {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "alert('请选择一个Excel文件')", true);
                    return;
                }

            string filePath = Server.MapPath("~/") + @"uploads\teacherInfo\";
            string fileName = "科研人事行政各类成果汇编";
            System.IO.FileInfo fi = new System.IO.FileInfo(filePath + fileName + ".xls");
            if (fi.Exists)
            {
                fi.CopyTo(filePath + fileName + "_bak" + DateTime.Now.ToString("yyyy年MM月dd日hh时mm分") + ".xls");
                fi.Delete();
            }
            file1.SaveAs(filePath + fileName + ".xls");
            sys.alert("保存成功！");
        }
    }
}