using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Adapte;
using System.Net;
using System.IO;
using System.Text;
using System.Xml;
namespace cycms.Web
{
    public partial class scripts : System.Web.UI.Page
    {
        public static int CacheNum = 50;
        BLL.Article bllarticle = new BLL.Article();
        Model.Article modelarticle = new Model.Article();
        BLL.IPHistry blliphistry = new BLL.IPHistry();
        Model.IPHistry modeliphistry = new Model.IPHistry();
        XmlDocument xmldoc = new XmlDocument();
        protected void Page_Load(object sender, EventArgs e)
        {
            string op = Request.QueryString["op"];
            if (op == null)
            {
                return;
            }
            switch (op)
            {
                case "getArticleClick":
                    getArticleVisitedCount();
                    break;
                case "GetIPInfo":
                    GetIPInfo();
                    break;
                default: break;
            }
        }

        public void getArticleVisitedCount()
        {
            int num = 0;
            try
            {
                NameValueCollection nv = sys.ArticleVisitedCollections;
                if (nv == null)
                {
                    nv = new NameValueCollection(CacheNum);
                }
                int articleId = Convert.ToInt32(Request.QueryString["articleId"]);

                if (nv[articleId.ToString()] == null)
                {
                    num = Convert.ToInt32(bllarticle.GetModel(articleId).dbo_Click) + 1;
                }
                else
                {
                    num = Convert.ToInt32(nv[articleId.ToString()]) + 1;
                }
                nv[articleId.ToString()] = num.ToString();
                if (nv.Count >= CacheNum)
                {
                    bllarticle.updateClicks(nv);
                    nv.Clear();
                }
                bllarticle.updateClicks(nv);
                sys.ArticleVisitedCollections = nv;
            }
            catch
            {

            }
            Response.Write("document.write(\"" + num.ToString() + "\");");

        }

        public void GetIPInfo()
        {
            string UserIp = Request.UserHostAddress;
            string url = "http://www.youdao.com/smartresult-xml/search.s?type=ip&q=" + UserIp;
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(url);
            req.Method = "GET";
            try
            {
                using (WebResponse wr = req.GetResponse())
                {
                    Stream resStream = wr.GetResponseStream();
                    xmldoc.Load(resStream);
                    modeliphistry.dbo_Area = xmldoc.SelectSingleNode("/smartresult/product/location").InnerText;
                    modeliphistry.dbo_Ptime = DateTime.Now;
                    modeliphistry.dbo_IPAddress = UserIp;
                    modeliphistry.dbo_Address = Request.QueryString["url"];
                    modeliphistry.dbo_Browser = Request.Browser.Browser + " " + Request.Browser.Version;
                    modeliphistry.dbo_Platform = sys.GetOSNameByUserAgent(Request.UserAgent);
                    modeliphistry.dbo_PageTitle = Request.QueryString["title"];
                    blliphistry.Add(modeliphistry);
                }
            }
            catch
            {
                modeliphistry.dbo_Area = "地址分析服务器出错";
                modeliphistry.dbo_Ptime = DateTime.Now;
                modeliphistry.dbo_IPAddress = UserIp;
                modeliphistry.dbo_Address = Request.QueryString["url"];
                modeliphistry.dbo_Browser = Request.Browser.Browser + " " + Request.Browser.Version;
                modeliphistry.dbo_Platform = sys.GetOSNameByUserAgent(Request.UserAgent);
                modeliphistry.dbo_PageTitle = Request.QueryString["title"];
                blliphistry.Add(modeliphistry);
            }
        }
    }
}