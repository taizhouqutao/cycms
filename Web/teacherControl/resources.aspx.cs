using System;
using System.Collections.Generic;
using Adapte;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
namespace cycms.Web.teacherControl
{
    public partial class resources : System.Web.UI.Page
    {
        BLL.TeacherUpload bllteacherupload = new BLL.TeacherUpload();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Teacher.Id == null)
            {
                Response.Write(sys.alertAndRedirect("对不起，你无权访问，请登陆", "login.aspx"));
                Response.End();
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

            if (strFiter != "")
            {
                strFiter += " and ";
            }

            strFiter += " dbo_UploaderId = " + Teacher.Id;
            DataTable dt = bllteacherupload.GetList(strFiter).Tables[0];
            this.GridView1.DataSource = dt;
            this.GridView1.DataBind();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //从数据库中删除
            string id = this.GridView1.DataKeys[e.RowIndex].Value.ToString();
            bllteacherupload.Delete(Convert.ToInt32(id));
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
            string strSearch = this.txtKeyWord.Text;
            strSearch = strSearch.Replace("'", "");

            if (strSearch != "")
            {
                strConditions += " dbo_FileTitle like '%" + strSearch + "%'";
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
                bllteacherupload.DeleteList(selectItems);
                this.BindData();
            }
        }
    }
}