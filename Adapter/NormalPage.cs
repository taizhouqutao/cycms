using System;
using System.Collections.Generic;
using System.Text;
using Maticsoft.Common;
using System.Data;
namespace Adapte
{
    public class NormalPage : System.Web.UI.Page
    {
        public string titlename = "";
        public string ptime = "";
        public string author = "";
        public string source = "";
        public string Content = "";
        public string pnlLoginShow = "block";
        public string pnlLogined = "none";
        public string litLoginName = "";
        public string guestBooklistShow = "none";
        public string guestBookformShow = "block";
        public string guestType = "";
        public string lefthtml = "";
        public string nowposition = "";
        public string linknowposition = "";
        public string specialityname = "";
        public string imageleft = "";
        cycms.BLL.Article bllarticle = new cycms.BLL.Article();
        cycms.BLL.ArticleType bllarticletype = new cycms.BLL.ArticleType();
        cycms.BLL.ArticleImg bllarticleimg = new cycms.BLL.ArticleImg();
        cycms.BLL.GuestBookType bllguestbooktype = new cycms.BLL.GuestBookType();
        cycms.BLL.GuestBook bllguestbook = new cycms.BLL.GuestBook();
        cycms.BLL.HtmlPage bllhtmlpage = new cycms.BLL.HtmlPage();
        cycms.BLL.Speciality bllspeciality = new cycms.BLL.Speciality();
        cycms.BLL.Cycms bllcycms = new cycms.BLL.Cycms();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!sys.IsRunning)
            {
                Response.Write("站点维护中，请稍后访问");
                Response.End();
                return;
            }
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

            switch (sys.RequestFileName().ToLower())
            {
                case "showlist":
                    {
                        showlist();
                    } break;
                case "showarticle":
                    {
                        ShowArticle();
                    } break;
                case "dsource":
                    {
                        if (Request.QueryString["id"] == null || Request.QueryString["id"] == "")
                        {
                            Response.End();
                            return;
                        }
                        if (!Page.IsPostBack)
                        {
                            dSource();
                        }
                        else
                        {
                            dSourcePostBack(Request.Form["txtDownPass"]);
                        }
                    } break;
                case "logincenter":
                    {
                        loginCenter();
                    } break;
                case "default":
                    {
                        Default();
                    } break;
                case "guestbook":
                    {
                        fillguestBooktype(Request.QueryString["Gtypeid"]);
                        fillImg(0);
                        if (!Page.IsPostBack)
                        {
                            guestbook();
                        }
                        else
                        {
                            guestbookpostback(Request.Form["txtTitle"], Request.Form["ddlGuestType"], Request.Form["txtName"], Request.Form["txtEmail"], Request.Form["rbtnSex"], Request.Form["txtContent"], Request.Form["txtWorkPlace"], Request.Form["txtChuanZhen"], Request.Form["txtCellphone"], Request.Form["txtAddress"]);
                        }
                    } break;
                case "search":
                    {
                        search();
                    } break;
            }
        }

        #region pageload
        private void showlist()
        {
            if (Request.QueryString["typeid"] != null && PageValidate.IsNumber(Request.QueryString["typeid"]))
            {
                cycms.Model.ArticleType sdr = bllarticletype.GetModel(Convert.ToInt32(Request.QueryString["typeid"]));
                if (sdr!=null)
                {
                    titlename = sdr.dbo_TypeName.ToString();
                    nowposition = sdr.dbo_TypeName;
                    linknowposition = sys.AppPath + "Showlist.aspx?typeid=" + sdr.ID;
                    fillImg(Convert.ToInt32(sdr.dbo_SpecialityId));
                    filltype(Convert.ToInt32(sdr.dbo_SpecialityId));
                }
            }
        }

        private void ShowArticle()
        {
            if (Request.QueryString["id"] != null &&PageValidate.IsNumber(Request.QueryString["id"]))
            {
                Content = sys.ShowArticle(Request.QueryString["id"], out titlename, out author, out ptime, out source);
                string typeid = bllarticle.GetModel(Convert.ToInt32(Request.QueryString["id"])).dbo_Typeid.ToString();
                cycms.Model.ArticleType sdr = bllarticletype.GetModel(Convert.ToInt32(typeid));
                if (sdr!=null)
                {
                    nowposition =sdr.dbo_TypeName; 
                    linknowposition = sys.AppPath + "Showlist.aspx?typeid=" +sdr.ID;
                    fillImg(Convert.ToInt32(sdr.dbo_SpecialityId));
                    filltype(Convert.ToInt32(sdr.dbo_SpecialityId));
                }
            }
        }

        private void dSource()
        {
        }

        private void loginCenter()
        {
            if (Request.QueryString["t"] == null || Request.QueryString["t"] == "")
            {
                Response.End();
                return;
            }
            string type = Request.QueryString["t"];
            if (type != null)
            {
                type = type.Trim();
            }
            switch (type)
            {
                case "teacherLogin": teacherLogin(); break;
                case "teacherLoginOut": teacherLoginOut(); break;
                default: Response.End(); return;
            }
        }

        private void Default()
        {
        }

        private void guestbook()
        {
            if (Request.QueryString["s"] == "0") //查看回复
            {
                guestBookformShow = "none";
                guestBooklistShow = "block";
            }
            else
            {   //我要留言              
                BindType();
            }   
        }

        private void search()
        {
            fillImg(0);
            filltype(0);
        }
        #endregion

        #region pagepostback
        private void dSourcePostBack(string password)
        {
        }

        private void guestbookpostback(string txtTitle, string ddlGuestType, string txtName, string txtEmail, string rbtnSex, string txtContent, string txtWorkPlace, string txtChuanZhen, string txtCellphone, string txtAddress)
        {
            string strTitle = sys.NoHTML(txtTitle);
            string strType = ddlGuestType;
            string strName = sys.NoHTML(txtName);
            string Email = txtEmail;
            string sex = rbtnSex;
            string strContent = sys.NoHTML(txtContent);
            string strTypeName = bllguestbooktype.GetModel(Convert.ToInt32(strType)).dbo_TypeName;
            string strWorkPlace = sys.NoHTML(txtWorkPlace);
            string strChuanZhen = sys.NoHTML(txtChuanZhen);
            string strCellphone = sys.NoHTML(txtCellphone);
            string strAddress = sys.NoHTML(txtAddress);  
            bllguestbook.Add(new cycms.Model.GuestBook { dbo_Title = strTitle, dbo_Content = strContent, dbo_Name = strName, dbo_Sex = sex, dbo_Email = Email, dbo_Ptime = DateTime.Now, dbo_GuestType =Convert.ToInt32(strType), dbo_GuestTypeName = strTypeName, dbo_Address=strAddress, dbo_Flax=strChuanZhen, dbo_CellPhone=strCellphone, dbo_WorkName=strWorkPlace,dbo_ReplyContent="" });
            string body = "尊敬的客户您好，您的留言已经收到，我们会尽快处理并回复到您的邮箱，请注意查收" + "<br /><br /><br />该邮箱为" + sys.webName + "回复留言的邮件，请勿直接回复<br /><br / >" + strName + ",您在" + DateTime.Now + "的来信:<br>" + strTitle + "<br>" + strContent;
            //sys.SendEmail(sys.webName + "的回复", body, txtEmail);
            sys.SendEmail(sys.webName + "的消息", sys.webName + "收到用户：'" + txtName + " 邮箱：'" + Email + "'的新邮件：<br>" + strTitle + "<br>" + strContent, sys.mailAddress);
            Response.Write("<script type=\"text/javascript\">alert('留言成功，我们会尽快回复到您的邮箱，请注意查收');window.location.href='guestbook.aspx?s=1';</script>");
        }
        #endregion

        #region 自定义方法
        protected void teacherLogin()
        {

        }

        protected void teacherLoginOut()
        {
            Teacher.Name = null;
            Teacher.Id = null;
            Teacher.RealName = null;

            if (Request.QueryString["rurl"] == null)
            {
                string redirectUrl = Request.ServerVariables["HTTP_REFERER"];
                if (redirectUrl == null)
                {
                    redirectUrl = "default.aspx";
                }

                Response.Write("<script type=\"text/javascript\">window.location.href='" + redirectUrl + "'</script>");
            }
            else
            {
                Response.Write("<script type=\"text/javascript\">window.location.href='" + Request.QueryString["rurl"] + "'</script>");
            }
        }

        protected void fillguestBooktype(string Gtypeid)
        {
            if (Gtypeid != null)
            {

            }
            else
            {
                nowposition = "我要咨询";
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
            }
        }

        protected void fillImg(int Spid)
        {
            DataTable dt = bllarticleimg.GetList("dbo_SpecialityId="+Spid).Tables[0];
            imageleft += "<div class=\"imglist\"><ul>";
            if (dt.Rows.Count == 0)
            {
                imageleft += "<li><a class=\"zoom\" href=\"#github1\"><img src=\"" + sys.AppPath + "uploads/teacherPhoto/noPhoto.png\" width=\"196\" height=\"142\" alt=\"暂无图片\" title=\"暂无图片\" /></a></li>";
            }
            foreach (DataRow dr in dt.Rows)
            {
                imageleft += "<li><a class=\"zoom\" href=\"#github" + dr["id"] + "\"><img src=\"" + sys.AppPath+dr["dbo_ImgSrc"] + "\" width=\"196\" height=\"142\" alt=\"" + dr["dbo_ImgArt"] + "\" title=\"" + dr["dbo_ImgArt"] + "\" /></a></li>";
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

        protected void BindType()
        {
            DataTable dt = bllguestbooktype.GetList("1=1 order by id asc").Tables[0];
            foreach (DataRow dr in dt.Rows)
            {
                guestType += "<option value=\"" + dr["id"].ToString() + "\">" + dr["dbo_typeName"].ToString() + "</option>";
            }
        }
        #endregion

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
