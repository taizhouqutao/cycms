using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Adapte;
using System.Data;

namespace cycms.Web.admin.FileManager
{
    public partial class fileTypeList : System.Web.UI.Page
    {
        BLL.DownLoadType blldownloadtype = new BLL.DownLoadType();
        BLL.DownLoadFile blldownloadfile = new BLL.DownLoadFile();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (currentAdmin.strPower == "")
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
            string strFiter = "1=1 ";
            if (ViewState["fiter"] != null)
            {
                strFiter = ViewState["fiter"].ToString();
            }
            DataTable dt = blldownloadtype.GetList(strFiter + " order by id desc").Tables[0]; 
            this.GridView1.DataSource = dt;
            this.GridView1.DataBind();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //从数据库中删除页面内容
            string id = this.GridView1.DataKeys[e.RowIndex].Value.ToString();
            blldownloadtype.Delete(Convert.ToInt32(id));
            BindData();
            //同时删除该类型下面的所有文件
            blldownloadfile.DeleteByTypeID(Convert.ToInt32(id));
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.GridView1.PageIndex = e.NewPageIndex;
            this.BindData();
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