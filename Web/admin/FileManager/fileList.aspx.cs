using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Adapte;
using System.Data;

namespace cycms.Web.admin.FileManager
{
    public partial class fileList : System.Web.UI.Page
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
                FillDDL();
            }
        }

        private void FillDDL()
        {
            DataTable dt = blldownloadtype.GetList("1=1 order by id desc").Tables[0]; 
            this.ddlSearchType.DataTextField = "dbo_typeName";
            this.ddlSearchType.DataValueField = "id";
            ddlSearchType.DataSource = dt;
            ddlSearchType.DataBind();
            ddlSearchType.Items.Insert(0, new ListItem("请选择类型", "0"));
        }

        private void BindData()
        {
            string strFiter = "1=1";
            if (ViewState["fiter"] != null && ViewState["fiter"].ToString()!="")
            {
                strFiter = ViewState["fiter"].ToString();
            }
            DataTable dt = blldownloadfile.GetViewList(strFiter + " order by id desc ").Tables[0]; 
            this.GridView1.DataSource = dt;
            this.GridView1.DataBind();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //从数据库中删除页面内容
            string id = this.GridView1.DataKeys[e.RowIndex].Value.ToString();
            blldownloadfile.Delete(Convert.ToInt32(id));
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
                strConditions += " dbo_fileTitle like '%" + strSearch + "%'";
            }

            string TypeId = this.ddlSearchType.SelectedValue;

            if (TypeId != "0")
            {
                if (strConditions != "")
                {
                    strConditions += " and ";
                }
                strConditions += " dbo_TypeId = " + TypeId;
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
                blldownloadfile.DeleteList(selectItems);
                this.BindData();
            }
        }
    }
}