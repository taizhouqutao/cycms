using System;
using System.Collections.Generic;
using System.Web;
using Adapte;
using System.Data;
using System.Text;
namespace cycms.Web.mobile
{
    /// <summary>
    /// server 的摘要说明
    /// </summary>
    public class server : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            switch (context.Request.Form["type"])
            {
                case "AddGuestBook":
                    {
                        string title = context.Request.Form["title"].Trim();
                        string name = context.Request.Form["name"].Trim();
                        string cellphone = context.Request.Form["cellphone"].Trim();
                        string content = context.Request.Form["content"].Trim();
                        string email = context.Request.Form["email"].Trim();
                        string guesttype = context.Request.Form["guesttype"].Trim();
                        string sex = context.Request.Form["sex"].Trim();
                        string workplace = context.Request.Form["workplace"].Trim();
                        string chuanzhen = context.Request.Form["chuanzhen"].Trim();
                        string address = context.Request.Form["address"].Trim();
                        context.Response.Write(AddGuestBook(title, name, cellphone, content, email, guesttype, sex, workplace, chuanzhen, address));
                        break;
                    }
                case "GetListByPage":
                    {
                        string page = context.Request.Form["page"].Trim();
                        context.Response.Write(GetListByPage(page));
                        break;
                    }
                case "ShowDetail":
                    {
                        string id = context.Request.Form["id"].Trim();
                        context.Response.Write(ShowDetail(id));
                        break;
                    }
            }
        }

        public string AddGuestBook(string title, string name, string cellphone, string content, string email, string guesttype, string sex, string workplace, string chuanzhen, string address)
        {
            BLL.GuestBook bll = new BLL.GuestBook();
            BLL.GuestBookType bllguestbooktype=new BLL.GuestBookType();
            Model.GuestBook model = new Model.GuestBook();
            string strTypeName = bllguestbooktype.GetModel(Convert.ToInt32(guesttype)).dbo_TypeName;
            model.dbo_Address = address;
            model.dbo_CellPhone = cellphone;
            model.dbo_Content = content;
            model.dbo_Email = email;
            model.dbo_Flax = chuanzhen;
            model.dbo_GuestType = Convert.ToInt32(guesttype);
            model.dbo_GuestTypeName = strTypeName;
            model.dbo_IsReply = false;
            model.dbo_Name = name;
            model.dbo_Ptime = DateTime.Now;
            model.dbo_ReplyContent = "";
            model.dbo_Sex = sex;
            model.dbo_Title = title;
            model.dbo_WorkName = workplace;
            bll.Add(model);
            string body = "尊敬的客户您好，您的留言已经收到，我们会尽快处理并回复到您的邮箱，请注意查收" + "<br /><br /><br />该邮箱为" + sys.webName + "回复留言的邮件，请勿直接回复<br /><br / >" + name + ",您在" + DateTime.Now + "的来信:<br>" + title + "<br>" + content;
            //sys.SendEmail(sys.webName + "的回复", body, txtEmail);
            //sys.SendEmail(sys.webName + "的消息", sys.webName + "收到用户：'" + name + " 邮箱：'" + email + "'的新邮件：<br>" + title + "<br>" + content, sys.mailAddress);
            return "1";
        }

        public string GetListByPage(string page)
        {
            BLL.Article bllarticle = new BLL.Article();
            int rowcount, pageIndex, pageSize;
            pageIndex =Convert.ToInt32(page);
            pageSize = 15;
            string[] str = "7".Split(',');
            int[] typeids = new int[str.Length];
            for (int i = 0; i < str.Length; i++)
            {
                typeids[i] = Convert.ToInt32(str[i]);
            }
            DataTable dt = bllarticle.getPagerArticle(pageIndex, pageSize, out rowcount, typeids, "");
            StringBuilder result = new StringBuilder();
            foreach (DataRow dr in dt.Rows)
            {
                result.AppendFormat("<li><a href=\"javascript:showDetail({0})\" data-transition='slide'>{1}<span class=\"ui-li-count\">{2}</span></a></li>", dr["id"], dr["dbo_title"], ((DateTime)dr["dbo_ptime"]).ToString("yyyy-MM-dd"));
            }
            return result.ToString();
        }

        public string ShowDetail(string id)
        {
            string titlename = "",ptime = "",author = "",source = "";
            string Content = sys.ShowArticle(id, out titlename, out author, out ptime, out source,false);
            return titlename + "$" + Content;
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}