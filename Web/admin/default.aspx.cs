using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Adapte;

namespace cycms.Web.admin
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (currentAdmin.Name == null)
            {
                Response.Redirect("login.aspx");
                Response.End();
                return;
            }
        }
    }
}