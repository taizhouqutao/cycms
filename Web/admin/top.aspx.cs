using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Adapte;

namespace cycms.Web.admin
{
    public partial class top : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.litMessage.Text = "管理员:" + currentAdmin.Name + ",欢迎你";
            this.litMessage.Text += "    " + DateTime.Now.ToString("yyyy年MM月dd日");
            this.hlDefault.NavigateUrl = sys.AppPath;
        }
    }
}