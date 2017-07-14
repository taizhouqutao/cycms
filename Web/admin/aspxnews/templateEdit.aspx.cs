using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Adapte;

namespace cycms.Web.admin.aspxnews
{
    public partial class templateEdit : System.Web.UI.Page
    {
        int editType;
        string spcDir, fileName, fileFullPath, spcId;
        BLL.Speciality bllspeciality = new BLL.Speciality();
        Model.Speciality modelspeciality = new Model.Speciality();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["spcId"] == null)
            {
                return;
            }
            spcId = Request.QueryString["spcId"];

            if (!currentAdmin.validationSpcAdmin(spcId))
            {
                adminOpers.ShowNoPower();
                return;
            }

            initPage();
            this.litSelectEditTpe.Text = "<a href='templateEdit.aspx?spcId=" + spcId.ToString() + "&editType=1'>专题首页</a>&nbsp;&nbsp;&nbsp;&nbsp;"
                                        + "<a href='templateEdit.aspx?spcId=" + spcId.ToString() + "&editType=2'>专题列表页</a>&nbsp;&nbsp;&nbsp;&nbsp;"
                                        + "<a href='templateEdit.aspx?spcId=" + spcId.ToString() + "&editType=3'>专题内容页</a>&nbsp;&nbsp;&nbsp;&nbsp;";
            if (Request.QueryString["spcId"].ToString() == "0")
            {
                this.litSelectEditTpe.Text += "<a href='templateEdit.aspx?spcId=0&editType=4'>搜索页面</a>";
            }
            if (fileName != string.Empty)
            {
                if (!Page.IsPostBack)
                {
                    this.txtContent.Text = sys.readFileContent(fileFullPath);
                }
            }
            else
            {
                this.txtContent.Visible = false;
                this.btnSave.Visible = false;
            }
        }

        private void initPage()
        {

            editType = Convert.ToInt32(Request.QueryString["editType"]);
            modelspeciality = bllspeciality.GetModel(Convert.ToInt32(spcId));
            if (modelspeciality != null)
            {
                spcDir = modelspeciality.dbo_HtmlDir.ToString() + "/";
            }
            fileName = string.Empty;
            switch (editType)
            {
                case 1: fileName = "default.aspx"; litEditType.Text = "首页"; break;
                case 2: fileName = "showList.aspx"; litEditType.Text = "列表页"; break;
                case 3: fileName = "ShowArticle.aspx"; litEditType.Text = "内容页"; break;
                case 4: fileName = "search.aspx"; litEditType.Text = "搜索页"; break;
                default: fileName = "default.aspx"; litEditType.Text = "首页"; break;
            }
            fileFullPath = Server.MapPath("~/") + spcDir + fileName;
            if (editType == 4)
            {
                fileFullPath = Server.MapPath("~/") + "search.aspx";
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            sys.writeFileContent(fileFullPath, this.txtContent.Text);

            Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "alert('修改已保存');", true);
        }
    }
}