using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Adapte;
using Maticsoft.Common;

namespace cycms.Web.admin.guestbook
{
    public partial class guestTypeAdd : System.Web.UI.Page
    {
        string id = string.Empty;
        BLL.GuestBookType bllguestbooktype = new BLL.GuestBookType();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!currentAdmin.IsSuper)
            {
                adminOpers.ShowNoPower();
                return;
            }
            id = Request.QueryString["id"];
            if (id != null)
            {
                if (!PageValidate.IsNumber(id))
                {
                    Response.End();
                    return;
                }
                if (!Page.IsPostBack)
                {
                    FillContent();
                }
            }
        }

        protected void FillContent()
        {
            this.txtTypeName.Text = bllguestbooktype.GetModel(Convert.ToInt32(id)).dbo_TypeName; 
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (id == string.Empty || id == null)
            { //添加
                bllguestbooktype.Add(new Model.GuestBookType { dbo_TypeName = this.txtTypeName.Text });
            }
            else
            {//编辑 
                bllguestbooktype.Update(new Model.GuestBookType {ID=Convert.ToInt32(id), dbo_TypeName = this.txtTypeName.Text });
            }
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "alert('添加成功！'); window.location.href='guestTypeList.aspx'", true);
        }
    }
}