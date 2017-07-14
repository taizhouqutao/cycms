using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Adapte;

namespace cycms.Web.admin
{
    public partial class Login : System.Web.UI.Page
    {
        BLL.Admin blladmin = new BLL.Admin();
        Model.Admin modeladmin = new Model.Admin();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["action"] != null && Request.QueryString["action"].ToString() == "loginout")
            {
                LoginOut();
                return;
            }
        }

        private void LoginOut()
        {
            for (int i = 0; i < Request.Cookies.Count; i++)
            {
                Response.Cookies[Request.Cookies[i].Name].Expires = DateTime.Now.AddDays(-1);
            }

            Response.Redirect("login.aspx");
        }

        protected void IbLogin_Click(object sender, ImageClickEventArgs e)
        {
            this.lblMessage.Text = "";
            //登陆成功需要记录用户ID，用户名，用户权限
            string strUserName = this.txtLogin.Text;
            string strPassword = this.txtPwd.Text;
            string strCheckCode = this.txtCheckCode.Text;
            if (strUserName == "" || strPassword == "" || strCheckCode == "")
            {
                this.lblMessage.Text = "请输入完整的登陆信息！";
                return;
            }

            if (Session["checkCode"] != null && Session["checkCode"].ToString() == strCheckCode)
            {
                strPassword = sys.Encrypt(strPassword);
                modeladmin=blladmin.GetAdminInfo(strUserName, strPassword);
                if (modeladmin!=null)
                {
                    currentAdmin.Name = modeladmin.dbo_UserName.ToString();
                    // CurrentAdmin = sdr["userName"].ToString();

                    currentAdmin.Id = modeladmin.ID.ToString();
                    currentAdmin.strPower = modeladmin.dbo_Power.ToString();
                    blladmin.UserLoginAccess(Convert.ToInt32(currentAdmin.Id));
                    //Response.Write(sys.CurrentAdminPower);
                    Response.Redirect("default.aspx");
                }
                else
                {
                    this.lblMessage.Text = "用户名或密码错误！";
                }
            }
            else
            {
                this.lblMessage.Text = "验证码输入错误！";
            }
        }

        protected void Imagebutton1_Click(object sender, ImageClickEventArgs e)
        {
            this.txtCheckCode.Text = "";
            this.txtLogin.Text = "";
            this.txtPwd.Text = "";
        }
    }
}