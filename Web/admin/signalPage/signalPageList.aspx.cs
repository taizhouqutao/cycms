using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Adapte;
using System.Data;
using System.IO;

namespace cycms.Web.admin.signalPage
{
    public partial class signalPageList : System.Web.UI.Page
    {
        string spcId = "1";
        BLL.HtmlPage bllhtmlpage = new BLL.HtmlPage();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["spcId"] != null)
            {
                spcId = Request.QueryString["spcId"].ToString();
            }
            if (!currentAdmin.validationSpcAdmin(spcId))
            {
                adminOpers.ShowNoPower();
                return;
            }

            this.hlkAddpage.NavigateUrl = "signalPageEdit.aspx?spcId=" + spcId;

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

            if (strFiter != "")
            {
                strFiter += " and ";
            }

            strFiter += "dbo_spcId=" + spcId;

            DataTable dt = bllhtmlpage.GetList(strFiter).Tables[0];
            this.GridView1.DataSource = dt;
            this.GridView1.DataBind();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //删除文件
            string filePath = Server.MapPath("~/") + GridView1.Rows[e.RowIndex].Cells[3].Text + GridView1.Rows[e.RowIndex].Cells[2].Text;

            FileInfo fi = new FileInfo(filePath);
            if (fi.Exists)
            {
                fi.Delete();
            }

            //从数据库中删除页面内容
            string id = this.GridView1.DataKeys[e.RowIndex].Value.ToString();
            bllhtmlpage.Delete(Convert.ToInt32(id));
            BindData();
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
                string strField = this.ddlSearchType.SelectedValue;
                strConditions += " " + strField + " like '%" + this.txtKeyWord.Text + "%'";
            }
            DataTable dt = bllhtmlpage.GetList(strConditions).Tables[0]; 
            this.GridView1.DataSource = dt;
            this.GridView1.DataBind();
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