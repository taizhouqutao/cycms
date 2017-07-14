using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Adapte;

namespace cycms.Web.admin
{
    public partial class main : System.Web.UI.Page
    {
        BLL.Speciality bllSpeciality = new BLL.Speciality();
        BLL.ArticleType bllarticletype = new BLL.ArticleType();
        BLL.Admin blladmin = new BLL.Admin();
        BLL.Article bllarticle = new BLL.Article();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (currentAdmin.Id == null)
            {
                Response.Write("您无权访问该页，错误原因：1.登陆超时；2.非法进入；3.权限不足。请登陆后访问<a href='login.aspx'  target='_parent'>登陆</a>");
                Response.End();
            }

            if (currentAdmin.strPower == "")
            {
                this.litMessage.Text = "<div class=\"row\">对不起，你没有任何管理权限，请联系管理员设置相应权限！</div>";
                this.Panel1.Visible = false;
                return;
            }

            //统计前台显示的内容

            this.litSysIsRunning.Text = sys.IsRunning ? "开放" : "关闭";
            this.litIsStatic.Text = sys.IsStatic ? "静态模式" : "动态模式";
            this.litChinnalNum.Text = (bllSpeciality.GetRecordCount("1=1")+1).ToString();
            this.litArticleTypeNum.Text = bllarticletype.GetRecordCount("1=1").ToString();
            this.litArticleNum.Text = bllarticle.GetRecordCount("1=1").ToString();
            this.litAdminNum.Text = blladmin.GetRecordCount("1=1").ToString();
        }
    }
}