using System;
using System.Collections.Generic;
using Adapte;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace cycms.Web.teacherControl
{
    public partial class password : System.Web.UI.Page
    {
        BLL.TeacherInfo bllteacherinfo = new BLL.TeacherInfo();
        Model.TeacherInfo modelteahcerinfo = new Model.TeacherInfo();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Teacher.Id == null)
            {
                Response.Write(sys.alertAndRedirect("对不起，你无权访问，请登陆", "login.aspx"));
                Response.End();
                return;
            }
            if (!IsPostBack)
            {
                u_name.Text = Teacher.Name;
                u_name.Enabled = false;
            }
        }

        protected void saveBtn_Click(object sender, EventArgs e)
        {
            string id = Teacher.Id;
            string oldpwd = old_pwd.Text.Trim();
            string newpwd = new_pwd.Text.Trim();
            string repwd = re_pwd.Text.Trim();
            if (oldpwd == newpwd)
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "alert('新密码与旧密码一样！');", true);
                return;
            }
            if (newpwd != repwd)
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "alert('新密码与重复密码不一致！');", true);
                return;
            }
            if (bllteacherinfo.GetList("dbo_PassWord = '" + oldpwd + "' and id=" + id).Tables[0].Rows.Count == 0)
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "alert('原始密码不正确！');", true);
                return;
            }
            modelteahcerinfo=bllteacherinfo.GetModel(Convert.ToInt32(id));
            modelteahcerinfo.dbo_PassWord =newpwd ;
            bool result = bllteacherinfo.Update(modelteahcerinfo);
            if (result == true )
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "alert('修改密码成功！');", true);
            }
        }
    }
}