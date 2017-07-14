using System;
using System.Collections.Generic;
using Adapte;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace cycms.Web.teacherControl
{
    public partial class top : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Teacher.Id == null)
            {
                Response.End();
                return;
            }

            this.litMessage.Text = "欢迎你:" + Teacher.RealName + "员工";
            this.litMessage.Text += "    " + DateTime.Now.ToString("yyyy年MM月dd日");
            this.hlDefault.NavigateUrl = sys.AppPath;
        }
    }
}