using System;
using System.Collections.Generic;
using Adapte;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace cycms.Web.teacherControl
{
    public partial class main : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Teacher.Id == null)
            {
                Response.End();
                return;
            }

            //统计前台显示的内容

            this.litSysIsRunning.Text = sys.IsRunning ? "开放" : "关闭";
            //this.litIsStatic.Text = sys.IsStatic ? "静态模式" : "动态模式";
            //this.litChinnalNum.Text = (dal.dalObject.getCount("speciality", "") + 1).ToString();
            //this.litArticleTypeNum.Text = dal.dalObject.getCount("articleType", "").ToString();
            //this.litArticleNum.Text = dal.dalObject.getCount("article", "").ToString();
            //this.litAdminNum.Text = dal.dalObject.getCount("admin", "").ToString();

        }
    }
}