using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Adapte;
using System.IO;
namespace cycms.Web.admin.aspxnews
{
    public partial class specialityAdd : System.Web.UI.Page
    {
        BLL.Speciality bllspeciality = new BLL.Speciality();
        Model.Speciality modelspeciality = new Model.Speciality();
        enum MyPageState { add, edit }
        MyPageState theState;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!currentAdmin.IsSuper)
            {
                adminOpers.ShowNoPower();
                return;
            }
            theState = MyPageState.add;
            if (Request.QueryString["id"] != null)
            {
                theState = MyPageState.edit;
                this.btnAdd.Text = "保存";
                if (!Page.IsPostBack)
                {
                    initEdit();
                }
            }

        }

        private void initEdit()
        {
            modelspeciality = bllspeciality.GetModel(Convert.ToInt32(Request.QueryString["id"]));
            if (modelspeciality!=null)
            {
                this.txtName.Text = modelspeciality.dbo_Name;
                this.txtDir.Text = modelspeciality.dbo_HtmlDir;
                this.fckContent.Text = modelspeciality.dbo_ContentHtml;
                this.chkIfshow.Checked = modelspeciality.dbo_IfShow;
                this.txtLinkurl.Text = modelspeciality.dbo_LinkUrl;
                this.txtDir.Enabled = false;
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            string strName = this.txtName.Text;
            string strDir = this.txtDir.Text;
            string strfckContent = this.fckContent.Text;
            bool ifshow = this.chkIfshow.Checked;
            string strlinkurl = this.txtLinkurl.Text;
            string destPath = Server.MapPath("~/") + strDir;
            string sourcePath = Server.MapPath("~/") + "templates/specially/";
            DirectoryInfo di = new DirectoryInfo(destPath);

            DirectoryInfo dirSource = new DirectoryInfo(sourcePath);

            if (theState == MyPageState.add)
            {
                if (di.Exists)
                {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "alert", "alert(\"目录已存在,请重新输入目录名称！\")", true);
                    return;
                }

                //数据库中添加记录
                bllspeciality.Add(new Model.Speciality { dbo_Name = strName,dbo_HtmlDir=strDir,dbo_ContentHtml=strfckContent,dbo_IfShow=ifshow,dbo_LinkUrl=strlinkurl});

                //新增文件夹目录
                di.Create();
                FileInfo[] files = dirSource.GetFiles("*.aspx");

                foreach (FileInfo f in files)
                {
                    f.CopyTo(destPath + "/" + f.Name);
                }

            }
            else if (theState == MyPageState.edit)
            {
                int id = Convert.ToInt32(Request.QueryString["id"]);
                modelspeciality = bllspeciality.GetModel(id);
                modelspeciality.dbo_Name = strName;
                modelspeciality.dbo_HtmlDir = strDir;
                modelspeciality.dbo_ContentHtml = strfckContent;
                modelspeciality.dbo_IfShow = ifshow;
                modelspeciality.dbo_LinkUrl = strlinkurl;
                bllspeciality.Update(modelspeciality);
            }
            Response.Write("<script>window.parent.frames['toolbar'].location.reload();window.location.href='specialityList.aspx';</script>");

        }
    }
}