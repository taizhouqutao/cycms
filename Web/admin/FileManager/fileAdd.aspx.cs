using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Adapte;
using System.Data;
using System.IO;

namespace cycms.Web.admin.FileManager
{
    public partial class fileAdd : System.Web.UI.Page
    {
        string fileId = string.Empty;
        BLL.DownLoadType blldownloadtype = new BLL.DownLoadType();
        BLL.DownLoadFile blldownloadfile = new BLL.DownLoadFile();
        Model.DownLoadFile modeldownloadfile = new Model.DownLoadFile();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (currentAdmin.strPower == "")
            {
                adminOpers.ShowNoPower();
                return;
            }
            fileId = Request.QueryString["id"];

            if (!Page.IsPostBack)
            {
                FillDDL();
            }
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

        private void FillDDL()
        {
            DataTable dt = blldownloadtype.GetList("1=1 order by id").Tables[0];
            this.ddlFileType.DataTextField = "dbo_typeName";
            this.ddlFileType.DataValueField = "id";
            ddlFileType.DataSource = dt;
            ddlFileType.DataBind();
            ddlFileType.Items.Insert(0, new ListItem("请选择类型", "0"));
        }

        protected void FillContent()
        {
            modeldownloadfile = blldownloadfile.GetModel(Convert.ToInt32(fileId));
            string FileName = string.Empty;
            if (modeldownloadfile!=null)
            {
                this.txtFileTitle.Text = "";
                if (modeldownloadfile.dbo_FileTitle!= null)
                {
                    txtFileTitle.Text = modeldownloadfile.dbo_FileTitle;
                }
                this.fileInfo.Text = modeldownloadfile.dbo_OtherInfo;
                FileName = modeldownloadfile.dbo_FileName;
                string fileType = modeldownloadfile.dbo_TypeId.ToString(); 
                for (int i = 0; i < this.ddlFileType.Items.Count; i++)
                {
                    if (this.ddlFileType.Items[i].Value == fileType)
                    {
                        this.ddlFileType.Items[i].Selected = true;
                        break;
                    }
                }

                this.chkIsLock.Checked = modeldownloadfile.dbo_IsLock;

            }
            if (FileName != string.Empty)
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                string appPath = sys.AppPath;
                sb.Append("当前的文件：");
                sb.Append("<ul id='fujian'>\n");
                string filePath = appPath + "uploads/" + FileName;
                sb.Append("<li><a href='" + filePath + "' target='_blank'>" + FileName + "</a></li>\n");
                sb.Append("</ul>\n");
                this.litFujian.Text = sb.ToString();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (this.ddlFileType.SelectedIndex == 0)
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "alert('请选择文件类型')", true);
                return;
            }

            string strTitle = this.txtFileTitle.Text;
            string fileInfo = this.fileInfo.Text;
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
                    while (File.Exists(Server.MapPath("../../") + "uploads/" + fileRename))
                    {
                        tryTimes++;
                        fileRename = fileName + "(" + tryTimes.ToString() + ")" + fileExtension;
                    }

                    string fullFileName = Server.MapPath("../../") + "uploads/" + fileRename;
                    FileUpload1.SaveAs(fullFileName);
                }
            }

            string typeId = this.ddlFileType.SelectedValue;
            fileSize = fileSize / 1000;

            if (FileUpload1.HasFile || fileId == null)
            {
                modeldownloadfile.dbo_FileTitle = strTitle;
                modeldownloadfile.dbo_FileName = fileRename;
                modeldownloadfile.dbo_FileSize = fileSize;
                modeldownloadfile.dbo_Ptime = DateTime.Now;
                modeldownloadfile.dbo_OtherInfo = fileInfo;
                modeldownloadfile.dbo_TypeId =Convert.ToInt32(typeId);
                modeldownloadfile.dbo_IsLock = this.chkIsLock.Checked;
            }
            else
            {
                modeldownloadfile = blldownloadfile.GetModel(Convert.ToInt32(fileId));
                modeldownloadfile.dbo_FileTitle = strTitle;
                modeldownloadfile.dbo_Ptime = DateTime.Now;
                modeldownloadfile.dbo_TypeId = Convert.ToInt32(typeId);
                modeldownloadfile.dbo_OtherInfo = fileInfo;
                modeldownloadfile.dbo_IsLock = this.chkIsLock.Checked;
            }

            if (fileId == null)
            {
                blldownloadfile.Add(modeldownloadfile);
            }
            else
            {
                blldownloadfile.Update(modeldownloadfile);
            }
            Response.Redirect("fileList.aspx");
        }
    }
}