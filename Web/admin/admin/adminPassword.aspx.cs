using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Adapte;
using Maticsoft.Common;
namespace cycms.Web.admin.admin
{
    public partial class adminPassword : System.Web.UI.Page
    {
        int editUserId = -1; //默认为-1
        BLL.Admin blladmin = new BLL.Admin();
        Model.Admin modeladmin = new Model.Admin();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["action"] != null && Request.QueryString["action"] == "edit")
            {//用户修改自己的密码
                if (currentAdmin.Id == null)
                {
                    adminOpers.ShowNoPower();
                    return;
                }
                editUserId = Convert.ToInt32(currentAdmin.Id);
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "hiddencancelbutton", "document.getElementById('btnCancel').style.display='none';", true);
            }
            else if (Request.QueryString["id"] != null && PageValidate.IsNumber(Request.QueryString["id"].ToString()))
            {//管理员修改用户的密码
                if (!currentAdmin.IsSuper)
                {
                    adminOpers.ShowNoPower();
                    return;
                }
                editUserId = Convert.ToInt32(Request.QueryString["id"].ToString());
            }
            else if (Request.QueryString["id"] == null)
            {//添加用户
                if (!currentAdmin.IsSuper)
                {
                    adminOpers.ShowNoPower();
                    return;
                }
                editUserId = 0;
            }

            if (editUserId == -1)
            {
                Response.Write("您权访问该页");
                Response.End();
                return;
            }

            if (!Page.IsPostBack && editUserId != 0)
            {
                initPage();
            }

        }

        private void initPage()
        {
            modeladmin = blladmin.GetModel(Convert.ToInt32(editUserId));
            if (modeladmin!=null)
            {
                this.txtUserName.Text = modeladmin.dbo_UserName; 
            }
            this.txtUserName.Enabled = false;
            this.btnAdd.Text = "保存修改";
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            string strUserName = this.txtUserName.Text;
            string strPassword1 = this.txtPassword1.Text;
            string strPassword2 = this.txtPassword2.Text;

            if (strUserName != "" && strPassword1 != "" && strPassword1 == strPassword2)
            {
                if (editUserId == 0) //如果editId==0则为添加
                {
                    strPassword1 = sys.Encrypt(strPassword1);
                    int retval = blladmin.adminAdd(new Model.Admin { dbo_UserName = strUserName, dbo_PassWord = strPassword1 });
                    if (retval == 0)
                    {
                        this.lblMessage.Text = "用户已经存在，请重新输入！";
                    }
                    else
                    {
                        //dal.dalObject.updateOneField("admin", "power", sys.getAdminPages(), "id=" + retval);
                        Response.Redirect("adminList.aspx");
                    }
                }
                else
                {
                    modeladmin = blladmin.GetModel(Convert.ToInt32(editUserId));
                    modeladmin.dbo_PassWord = sys.Encrypt(strPassword1);
                    blladmin.Update(modeladmin);
                    this.lblMessage.Text = "密码修改成功！";
                }

            }
            else
            {
                this.lblMessage.Text = "输入错误，请重新输入!";
            }
        }
    }
}