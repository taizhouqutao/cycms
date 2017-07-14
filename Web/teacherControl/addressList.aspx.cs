using System;
using System.Collections.Generic;
using Adapte;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
namespace cycms.Web.teacherControl
{
    public partial class addressList : System.Web.UI.Page
    {
        BLL.TeacherInfo bllteacherinfo = new BLL.TeacherInfo();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Teacher.Id == null)
            {
                Response.Write(sys.alertAndRedirect("请登陆后访问", "login.aspx"));
                Response.End();
                return;
            }
            if (!Page.IsPostBack)
            {
                BindData();
            }
        }

        protected void BindData()
        {
            string strFiter = "1=1";
            if (ViewState["fiter"] != null && ViewState["fiter"].ToString().Trim()!="")
            {
                strFiter = ViewState["fiter"].ToString();
            }

            DataTable dt = bllteacherinfo.GetList(strFiter + " order by dbo_Order desc").Tables[0];
            this.GridView1.DataSource = dt;
            this.GridView1.DataBind();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            this.GridView1.PageIndex = 0;
            ViewState.Remove("fiter");
            if (this.txtKeyWord.Text != "")
            {
                string txtKw = this.txtKeyWord.Text.Trim().Replace("'", "");
                string strFiter = " " + this.ddlSearchType.SelectedValue + " like '%" + txtKw + "%' ";
                ViewState["fiter"] = strFiter;
            }
            BindData();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.GridView1.PageIndex = e.NewPageIndex;
            BindData();
        }
    }
}