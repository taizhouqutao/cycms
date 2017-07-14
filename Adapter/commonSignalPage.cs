using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
namespace Adapte
{
    public class commonSignalPage : System.Web.UI.Page
    {
        public string PageContent = string.Empty;
        public string articleTitle = string.Empty;
        public string lefthtml = string.Empty;
        public string nowposition = string.Empty;
        public string linknowposition = string.Empty;
        public string specialityname = string.Empty;
        public string imageleft = "";
        cycms.BLL.HtmlPage bllhtmlpage = new cycms.BLL.HtmlPage();
        cycms.BLL.ArticleImg bllarticleimg = new cycms.BLL.ArticleImg();
        cycms.BLL.ArticleType bllarticletype = new cycms.BLL.ArticleType();
        cycms.BLL.Speciality bllspeciality = new cycms.BLL.Speciality();
        cycms.BLL.Cycms bllcycms = new cycms.BLL.Cycms();
        protected void Page_Load(object sender, EventArgs e)
        {
            cycms.Model.Cycms modelcycms = bllcycms.GetModel(bllcycms.GetMaxId() - 1);
            sys.workPlace = modelcycms.dbo_WorkPlace;
            sys.lianXiren = modelcycms.dbo_LianXiRen;
            sys.cellPhone = modelcycms.dbo_CellPhone;
            sys.workPhone = modelcycms.dbo_WorkPohne;
            sys.flax = modelcycms.dbo_Flax;
            sys.mailAddress = modelcycms.dbo_MailAddress;
            sys.smtpServer = modelcycms.dbo_SmtpServer;
            sys.mailName = modelcycms.dbo_MailName;
            sys.mailPwd = modelcycms.dbo_MailPwd;
            sys.beiAnHao = modelcycms.dbo_BeiAnHao;

            string htmlName = sys.RequestFileName();
            DataTable sdr = bllhtmlpage.GetList("dbo_htmlName='" + htmlName + "'").Tables[0];
            if (sdr.Rows.Count>0)
            {
                articleTitle = Page.Title = sdr.Rows[0]["dbo_pagetitle"].ToString();
                PageContent = sdr.Rows[0]["dbo_PageContent"].ToString();
                nowposition = sdr.Rows[0]["dbo_pagetitle"].ToString();
                linknowposition = sys.AppPath + sdr.Rows[0]["dbo_pagepath"].ToString().Substring(1) + sdr.Rows[0]["dbo_htmlName"].ToString() + ".aspx";
                fillImg(Convert.ToInt32(sdr.Rows[0]["dbo_SpcId"]));
                filltype(Convert.ToInt32(sdr.Rows[0]["dbo_SpcId"]));
            }
        }

        protected void fillImg(int Spid)
        {
            DataTable dt = bllarticleimg.GetList("dbo_SpecialityId=" + Spid).Tables[0];
            imageleft += "<div class=\"imglist\"><ul>";
            if (dt.Rows.Count == 0)
            {
                imageleft += "<li><a class=\"zoom\" href=\"#github1\"><img src=\"" + sys.AppPath + "uploads/teacherPhoto/noPhoto.png\" width=\"196\" height=\"142\" alt=\"暂无图片\" title=\"暂无图片\" /></a></li>";
            }
            foreach (DataRow dr in dt.Rows)
            {
                imageleft += "<li><a class=\"zoom\" href=\"#github" + dr["id"] + "\"><img src=\"" + sys.AppPath + dr["dbo_ImgSrc"] + "\" width=\"196\" height=\"142\" alt=\"" + dr["dbo_ImgArt"] + "\" title=\"" + dr["dbo_ImgArt"] + "\" /></a></li>";
            }
            imageleft += "</ul></div>";
            if (dt.Rows.Count == 0)
            {
                imageleft += "<div class=\"hidden\" id=\"github1\"><img src=\"" + sys.AppPath + "uploads/teacherPhoto/noPhoto.png\" alt=\"暂无图片\" title=\"暂无图片\" /></div>";
            }
            foreach (DataRow dr in dt.Rows)
            {
                imageleft += "<div class=\"hidden\" id=\"github" + dr["id"] + "\"><img src=\"" + sys.AppPath + dr["dbo_ImgBigSrc"] + "\" alt=\"" + dr["dbo_ImgArt"] + "\" title=\"" + dr["dbo_ImgArt"] + "\" /></div>";
            }
        }

        protected void filltype(int specialityid)
        {
            lefthtml = "";
            DataTable dttype = bllarticletype.GetList("dbo_specialityid=" + specialityid).Tables[0];
            DataTable htmlpage = bllhtmlpage.GetList("dbo_SPCID=" + specialityid).Tables[0];
            if (specialityid == 0)
            {
                specialityname = "网站首页";
            }
            else
            {
                specialityname = bllspeciality.GetModel(specialityid).dbo_Name;
            }
            if (dttype.Rows.Count > 0)
            {
                int i = 1;
                foreach (DataRow dr in dttype.Rows)
                {
                    if (i == dttype.Rows.Count && htmlpage.Rows.Count == 0)
                    {
                        if (dr["dbo_isArticleType"].ToString() == "True")
                        {
                            lefthtml += "<div class=\"sonlistback botsonlistback\"><a href=\"" + sys.AppPath + "ShowList.aspx?typeid=" + dr["id"] + "\">" + dr["dbo_typename"] + "</a></div>";
                        }
                        else
                        {
                            lefthtml += "<div class=\"sonlistback botsonlistback\"><a href=\"" + dr["dbo_linkUrl"] + "\">" + dr["dbo_typename"] + "</a></div>";
                        }
                    }
                    else
                    {
                        if (dr["dbo_isArticleType"].ToString() == "True")
                        {
                            lefthtml += "<div class=\"sonlistback midsonlistback\"><a href=\"" + sys.AppPath + "ShowList.aspx?typeid=" + dr["id"] + "\">" + dr["dbo_typename"] + "</a></div>";
                        }
                        else
                        {
                            lefthtml += "<div class=\"sonlistback midsonlistback\"><a href=\"" + dr["dbo_linkUrl"] + "\">" + dr["dbo_typename"] + "</a></div>";
                        }
                        i = i + 1;
                    }
                }
            }
            if (htmlpage.Rows.Count > 0)
            {
                int i = 1;
                foreach (DataRow dr in htmlpage.Rows)
                {
                    if (i == htmlpage.Rows.Count)
                    {
                        lefthtml += "<div class=\"sonlistback botsonlistback\"><a href=\"" + sys.AppPath + dr["dbo_pagepath"].ToString().Substring(1) + dr["dbo_htmlname"] + ".aspx\">" + dr["dbo_pagetitle"] + "</a></div>";
                    }
                    else
                    {
                        lefthtml += "<div class=\"sonlistback midsonlistback\"><a href=\"" + sys.AppPath + dr["dbo_pagepath"].ToString().Substring(1) + dr["dbo_htmlname"] + ".aspx\">" + dr["dbo_pagetitle"] + "</a></div>";
                        i = i + 1;
                    }
                }
            }
        }
    }
}
