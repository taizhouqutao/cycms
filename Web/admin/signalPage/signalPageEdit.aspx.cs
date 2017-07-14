using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using Adapte;

namespace cycms.Web.admin.signalPage
{
    public partial class signalPageEdit : System.Web.UI.Page
    {
        enum MyPageState { add, edit }
        BLL.Speciality bllspeciality = new BLL.Speciality();
        BLL.HtmlPage bllhtmlpage = new BLL.HtmlPage();
        Model.HtmlPage modelhtmlpage = new Model.HtmlPage();
        MyPageState theState = MyPageState.add;
        string spcId;
        string signalPageId;
        string templatePath;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Request.QueryString["spcId"] != null)
            {
                spcId = Request.QueryString["spcId"];
            }

            this.btnBackToList.Attributes.Add("onclick", "javascript:window.location.href='signalPageList.aspx?spcId=" + spcId + "'");
            if (!currentAdmin.validationSpcAdmin(spcId))
            {
                adminOpers.ShowNoPower();
                return;
            }

            if (Request.QueryString["id"] != null)
            {
                signalPageId = Request.QueryString["id"];
                theState = MyPageState.edit;

                this.hlkEditTemplate.Text = "编辑模板";
                this.hlkEditTemplate.NavigateUrl = "?id=" + signalPageId + "&spcId=" + spcId + "&editT=1";


                this.hlkEditContent.Text = "编辑内容";
                this.hlkEditContent.NavigateUrl = "?id=" + signalPageId + "&spcId=" + spcId;

                if (Request.QueryString["editT"] != null && Request.QueryString["editT"].ToString() == "1")
                {
                    this.pnlTemplate.Visible = true;
                    this.pnlContent.Visible = false;
                }
                else
                {
                    this.pnlTemplate.Visible = false;
                    this.pnlContent.Visible = true;
                }
            }

            InitPage();
        }

        public void InitPage()
        {
            if (spcId == "0")
            {
                this.litPagePath.Text = "/";
            }
            else
            {
                string strDir = bllspeciality.GetModel(Convert.ToInt32(spcId)).dbo_HtmlDir; 
                this.litPagePath.Text = "/" + strDir + "/";
            }


            if (theState == MyPageState.edit)
            {
                if (!Page.IsPostBack)
                {
                    this.txtFileName.Enabled = false;
                    modelhtmlpage = bllhtmlpage.GetModel(Convert.ToInt32(signalPageId));
                    if (modelhtmlpage!=null)
                    {
                        txtFileName.Text = modelhtmlpage.dbo_HtmlName;
                        txtTitle.Text = modelhtmlpage.dbo_PageTitle;
                        fckContent.Text = modelhtmlpage.dbo_PageContent;
                        chkIfshow.Checked = modelhtmlpage.dbo_IsShow; 
                    }
                }
            }


            templatePath = Server.MapPath("~") + this.litPagePath.Text.Replace("/", "\\") + this.txtFileName.Text + ".aspx";

            if (theState == MyPageState.edit && !Page.IsPostBack)
            {
                if (!Page.IsPostBack)
                {
                    if (Request.QueryString["editT"] != null && Request.QueryString["editT"].ToString() == "1")
                    {
                        this.txtContent.Text = sys.readFileContent(templatePath);
                    }
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string pagetitle = txtTitle.Text;
            string pageContent = fckContent.Text;
            string pageFileName = this.txtFileName.Text;
            string pagePath = litPagePath.Text;
            string isshow = chkIfshow.Checked.ToString();
            if (theState == MyPageState.add)
            {
                //新增一张页面到对应的目录下面(从template/signalpage/目录下复制)     
                if (bllhtmlpage.GetList("dbo_htmlName='"+pageFileName+"'").Tables[0].Rows.Count>0)
                {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "alert('该文件名已经存在，请使用其他的文件名！');", true);
                    return;
                }
                string sourcePath = Server.MapPath("~/") + "templates\\signalpage\\";
                DirectoryInfo dirSource = new DirectoryInfo(sourcePath);
                FileInfo fi = new FileInfo(sourcePath + "signalPage.aspx");
                fi.CopyTo(templatePath);
                bllhtmlpage.Add(new Model.HtmlPage { dbo_HtmlName = pageFileName, dbo_Template = "", dbo_Ptime = DateTime.Now, dbo_PageTitle = pagetitle, dbo_PagePath = pagePath, dbo_PageContent = pageContent, dbo_SpcId = Convert.ToInt32(spcId), dbo_IsShow = Convert.ToBoolean(isshow) });

                Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "alert('修改已保存');window.location.href='signalPageList.aspx?spcId=" + spcId + "'", true);
            }
            else
            {
                bllhtmlpage.Update(new Model.HtmlPage { ID =Convert.ToInt32(signalPageId), dbo_HtmlName = pageFileName, dbo_Template = "", dbo_Ptime = DateTime.Now, dbo_PageTitle = pagetitle, dbo_PagePath = pagePath, dbo_PageContent = pageContent, dbo_SpcId = Convert.ToInt32(spcId), dbo_IsShow = Convert.ToBoolean(isshow) });
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "alert('修改已保存');", true);
            }

        }

        protected void btnEditTemplate_Click(object sender, EventArgs e)
        {
            //编辑模板
            sys.writeFileContent(templatePath, this.txtContent.Text);
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "alert('修改已保存');", true);
        }
    }
}