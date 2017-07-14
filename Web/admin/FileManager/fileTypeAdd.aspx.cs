using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Maticsoft.Common;

namespace cycms.Web.admin.FileManager
{
    public partial class fileTypeAdd : System.Web.UI.Page
    {
        BLL.DownLoadType blldownloadtype = new BLL.DownLoadType();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
            {
                if (!PageValidate.IsNumber(Request.QueryString["id"]))
                {
                    return;
                }
                if (!Page.IsPostBack)
                {
                    this.txtFileTypeName.Text = blldownloadtype.GetModel(Convert.ToInt32(Request.QueryString["id"])).dbo_TypeName; 
                    this.btnAdd.Text = "保存编辑";
                }
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
            {
                blldownloadtype.Update(new Model.DownLoadType { ID = Convert.ToInt32(Request.QueryString["id"]), dbo_TypeName = this.txtFileTypeName.Text });
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "alert('编辑成功!');window.location.href='fileTypeList.aspx'", true);
            }
            else
            {
                blldownloadtype.Add(new Model.DownLoadType { dbo_TypeName = this.txtFileTypeName.Text });
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "alert('添加成功!');window.location.href='fileTypeList.aspx'", true);
            }

        }
    }
}