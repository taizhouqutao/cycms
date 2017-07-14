using System;
using System.Collections.Generic;
using Adapte;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
namespace cycms.Web.teacherControl
{
    public partial class resourcesAdd : System.Web.UI.Page
    {
        BLL.TeacherUpload bllteacherupload = new BLL.TeacherUpload();
        Model.TeacherUpload modelteahcerupload = new Model.TeacherUpload();
        string fileId = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Teacher.Id == null)
            {
                Response.Write(sys.alertAndRedirect("对不起，你无权访问，请登陆", "login.aspx"));
                Response.End();
                return;
            }

            fileId = Request.QueryString["id"];

            if (fileId != null && fileId != "")
            {
                if (!Page.IsPostBack)
                {
                    FillContent();
                    RequiredFieldValidator2.Enabled = false;
                    this.btnSubmit.Text = "保存编辑";
                }
            }
        }

        protected void FillContent()
        {
            Model.TeacherUpload sdr = bllteacherupload.GetModel(Convert.ToInt32(fileId)); 
            string FileName = string.Empty;
            if (sdr!=null)
            {
                txtFileTitle.Text = sdr.dbo_FileTitle;
                this.fileInfo.Text = sdr.dbo_OtherInfo;
                FileName = sdr.dbo_FileName;
                this.txtDownPwd.Text = sdr.dbo_DownPwd;
            }
            if (FileName != string.Empty)
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                string appPath = sys.AppPath;
                sb.Append("当前的文件：");
                sb.Append("<ul id='fujian'>\n");
                string filePath = appPath + "uploads/teacherUploads/" + FileName;
                sb.Append("<li><a href='" + filePath + "' target='_blank'>" + FileName + "</a></li>\n");
                sb.Append("</ul>\n");
                this.litFujian.Text = sb.ToString();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            string strTitle = this.txtFileTitle.Text;
            string fileInfo = this.fileInfo.Text;
            string strDownPwd = this.txtDownPwd.Text.Trim();
            string fileName = string.Empty;// FileUpload1.FileName;
            string fileRename = string.Empty;
            int fileSize = 0;

            if (FileUpload1.HasFile)
            {
                fileName = FileUpload1.FileName;
                string fileExtension = System.IO.Path.GetExtension(fileName);
                fileSize = FileUpload1.PostedFile.ContentLength;

                //检查文件的后缀名是否为允许上传的类型
                fileName = System.IO.Path.GetFileNameWithoutExtension(fileName); //文件名
                bool AllowUpload = false;
                string strFileType = System.Configuration.ConfigurationManager.AppSettings["AllowFileTypes"].ToString();
                string[] filetypes = strFileType.Split(',');

                for (int i = 0; i < filetypes.Length; i++)
                {
                    if (fileExtension == "." + filetypes[i].ToLower())
                    {
                        AllowUpload = true; break;
                    }
                }
                if (!AllowUpload)
                {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "alertfileNotAllow", "alert('您选择的文件是不允许上传的类型，请重新添加')", true);
                    return;
                }

                fileRename = fileName + fileExtension;
                if (fileSize != 0)
                {
                    //判断文件是否已经存在，如果存在则重命名，直到文件名不存在
                    int tryTimes = 0;
                    while (File.Exists(Server.MapPath("../") + "uploads/teacherUploads/" + fileRename))
                    {
                        tryTimes++;
                        fileRename = fileName + "(" + tryTimes.ToString() + ")" + fileExtension;
                    }

                    string fullFileName = Server.MapPath("../") + "uploads/teacherUploads/" + fileRename;
                    FileUpload1.SaveAs(fullFileName);
                }
            }

            fileSize = fileSize / 1000;

            string[] keys = null;
            string[] vals = null;

            if (FileUpload1.HasFile || fileId == null)
            {
                keys = new string[] { "fileTitle", "fileName", "otherInfo", "fileSize", "uploaderId", "uploaderTeacherName", "ptime", "downPwd" };
                vals = new string[] { strTitle, fileRename, fileInfo, fileSize.ToString(), Teacher.Id, Teacher.RealName, DateTime.Now.ToString(), strDownPwd };

                modelteahcerupload.dbo_FileTitle = strTitle;
                modelteahcerupload.dbo_FileName = fileRename;
                modelteahcerupload.dbo_FileSize = fileSize;
                modelteahcerupload.dbo_Ptime = DateTime.Now;
                modelteahcerupload.dbo_OtherInfo = fileInfo;
                modelteahcerupload.dbo_UploaderId =Convert.ToInt32(Teacher.Id);
                modelteahcerupload.dbo_UploaderTeacherName = Teacher.RealName;
                modelteahcerupload.dbo_DownPwd = strDownPwd;
            }
            else
            {
                modelteahcerupload = bllteacherupload.GetModel(Convert.ToInt32(fileId));
                modelteahcerupload.dbo_FileTitle = strTitle;
                modelteahcerupload.dbo_Ptime = DateTime.Now;
                modelteahcerupload.dbo_OtherInfo = fileInfo;
                modelteahcerupload.dbo_DownPwd = strDownPwd;
            }

            if (fileId == null)
            {
                bllteacherupload.Add(modelteahcerupload);
            }
            else
            {
                bllteacherupload.Update(modelteahcerupload);
            }
            Response.Redirect("resources.aspx");
        }
    }
}