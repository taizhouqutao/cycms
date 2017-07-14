using System;
using System.Collections.Generic;
using Adapte;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace cycms.Web.teacherControl
{
    public partial class login : System.Web.UI.Page
    {
        BLL.TeacherInfo bllteacherinfo = new BLL.TeacherInfo();
        Model.TeacherInfo modelteacherinfo = new Model.TeacherInfo();
        protected void Page_Load(object sender, EventArgs e)
        {

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
                modelteacherinfo = bllteacherinfo.GetAdminInfo(strUserName, strPassword);
                if (modelteacherinfo != null)
                {
                    Teacher.Name = modelteacherinfo.dbo_LoginName;
                    Teacher.Id = modelteacherinfo.ID.ToString();
                    Teacher.RealName = modelteacherinfo.dbo_Name; 
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