using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Adapte;
namespace cycms.Web.control
{
    public partial class Top : System.Web.UI.UserControl
    {
        public string Toptablink = "";
        BLL.Speciality bllspeciality = new BLL.Speciality();
        BLL.ArticleType bllarticletype = new BLL.ArticleType();
        BLL.HtmlPage bllhtmlpage = new BLL.HtmlPage();
        protected void Page_Load(object sender, EventArgs e)
        {
            fulllist();
        }

        private void fulllist()
        {
            DataTable specialitydt = bllspeciality.GetList("1=1 order by id asc").Tables[0];
            Toptablink = "<ul>";
            Toptablink += "<li class=\"first\"><a href=\"" + sys.AppPath + "default.aspx\">首页</a></li>";
            foreach (DataRow dr in specialitydt.Rows)
            {
                Toptablink += "<li>";
                if (dr["dbo_ifshow"].ToString() == "True")
                {
                    Toptablink += "<a href=\"" + sys.AppPath + dr["dbo_htmlDir"].ToString() + "/\">" + dr["dbo_name"].ToString() + "</a>";
                }
                else
                {
                    Toptablink += "<a href=\"" + dr["dbo_linkurl"].ToString() + "\">" + dr["dbo_name"].ToString() + "</a>";
                }
                Toptablink += "</li>";
            }
            Toptablink += "<li class=\"last\"><a href=\"" + sys.AppPath + "guestBook.aspx?s=1\">联系我们</a></li></ul>";
        }
    }
}