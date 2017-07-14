using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Adapte;
using System.Data;
namespace cycms.Web.admin.Themes
{
    public partial class ThemesList : System.Web.UI.Page
    {
        string spcId = "0";
        BLL.ArticleImg bllarticleimg = new BLL.ArticleImg();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["spcId"] != null)
            {
                spcId = Request.QueryString["spcId"].ToString();
                hlkAddpage.NavigateUrl = "ThemesAdd.aspx?spcId=" + spcId;
            }
            if (!currentAdmin.validationSpcAdmin(spcId))
            {
                adminOpers.ShowNoPower();
                return;
            }
            if (!Page.IsPostBack)
            {
                BindData(spcId);
            }
        }

        private void BindData(string spcId)
        {
            string strFiter = " dbo_SpecialityId = "+spcId;
            if (ViewState["fiter"] != null && ViewState["fiter"].ToString().Trim()!="")
            {
                strFiter = (ViewState["fiter"].ToString()+" and dbo_SpecialityId = "+spcId);
            }

            DataTable dt = bllarticleimg.GetList(strFiter).Tables[0];
            this.GridView1.DataSource = dt;
            this.GridView1.DataBind();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string id = this.GridView1.DataKeys[e.RowIndex].Value.ToString();
            bllarticleimg.Delete(Convert.ToInt32(id));
            this.BindData(Request.QueryString["spcId"].ToString());
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.GridView1.PageIndex = e.NewPageIndex;
            this.BindData(Request.QueryString["spcId"].ToString());
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string strConditions = string.Empty;

            if (this.txtKeyWord.Text != "")
            {
                strConditions += " dbo_ImgArt like '%" + this.txtKeyWord.Text + "%'";
            }

            ViewState["fiter"] = strConditions;

            BindData(Request.QueryString["spcId"].ToString());
        }

        protected void btnDelSelected_Click(object sender, EventArgs e)
        {
            string selectItems = getSelectedItemsId();
            if (selectItems != "")
            {
                bllarticleimg.DeleteList(selectItems);
                this.BindData(Request.QueryString["spcId"].ToString());

            }
        }

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