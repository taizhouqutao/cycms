using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Adapte;
using System.Data;
namespace cycms.Web.admin.admin
{
    public partial class adminList : System.Web.UI.Page
    {
        BLL.Admin blladmin = new BLL.Admin();
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

            DataTable dt = blladmin.GetList(strFiter).Tables[0];
            this.GridView1.DataSource = dt;
            this.GridView1.DataBind();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string id = this.GridView1.DataKeys[e.RowIndex].Value.ToString();
            if (this.IsAllowDelete(id))
            {
                blladmin.Delete(Convert.ToInt32(id));
                this.BindData();
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "alertNotDelete", "alert('不允许删除改用户，必须存在一个超级管理员！')", true);
            }
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
                strConditions += " dbo_userName like '%" + this.txtKeyWord.Text + "%'";
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

        protected void btnDelSelected_Click(object sender, EventArgs e)
        {
            string selectItems = getSelectedItemsId();
            if (selectItems != "")
            {
                if (this.IsAllowDelete(selectItems))
                {
                    blladmin.DeleteList(selectItems);
                    this.BindData();
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "alertNotDelete", "alert('不允许删除改用户，必须存在一个超级管理员！')", true);
                }
            }
        }

        //判断是否允许删除
        private bool IsAllowDelete(string ids)
        {
            int count = blladmin.GetRecordCount(" dbo_power='super' and id not in(" + ids + ")");
            return count > 0;

        }     
    }
}