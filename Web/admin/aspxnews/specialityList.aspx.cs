using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Adapte;
using System.Data;
using System.IO;
namespace cycms.Web.admin.aspxnews
{
    public partial class specialityList : System.Web.UI.Page
    {
        BLL.Speciality bllspeciality = new BLL.Speciality();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!currentAdmin.IsSuper)
            {
                adminOpers.ShowNoPower();
                return;
            }
            if (!Page.IsPostBack)
            {
                BindData();
            }
        }

        private void BindData()
        {
            string strFiter = string.Empty;
            if (ViewState["fiter"] != null)
            {
                strFiter = ViewState["fiter"].ToString();
            }

            DataTable dt = bllspeciality.GetList(strFiter).Tables[0]; 
            this.GridView1.DataSource = dt;
            this.GridView1.DataBind();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string dirPath = Server.MapPath("~/") + GridView1.Rows[e.RowIndex].Cells[2].Text;
            DirectoryInfo di = new DirectoryInfo(dirPath);
            if (di.Exists)
            {
                di.Delete(true);
            }
            string id = this.GridView1.DataKeys[e.RowIndex].Value.ToString();
            bllspeciality.RealDelete(Convert.ToInt32(id));
            this.BindData();
            Response.Write("<script>window.parent.frames['toolbar'].location.reload();window.location.href='specialityList.aspx';</script>");

        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.GridView1.PageIndex = e.NewPageIndex;
            this.BindData();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string strConditions = string.Empty;

            if (this.txtKeyWord.Text != "")
            {
                strConditions += " dbo_name like '%" + this.txtKeyWord.Text + "%'";
            }

            ViewState["fiter"] = strConditions;

            BindData();
        }

        //获取选中的项目id
        private string getSelectedItemsId()
        {
            string selectItems = string.Empty;
            for (int i = 0; i < this.GridView1.Rows.Count; i++)
            {
                CheckBox cb = GridView1.Rows[i].FindControl("chkSelect") as CheckBox;
                if (cb != null && cb.Checked)
                {
                    if (selectItems != string.Empty)
                    {
                        selectItems += ",";
                    }
                    selectItems += this.GridView1.DataKeys[i].Value;
                }
            }
            return selectItems;
        }
    }
}