using System;
using System.Collections.Generic;
using System.Xml;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using Adapte;
namespace cycms.Web.mobile
{
    public class Product
    {
        public string P_Name="";
        public string P_Info="";
    }
    public partial class Default : System.Web.UI.Page
    {

        public string CPJS = "";
        public string JDAL = "";
        public string guestType = "";
        public string NewList = "";
        public Product Product1 = new Product();
        public Product Product2 = new Product();
        public Product Product3 = new Product();
        BLL.FriendLink bllfriendLink = new BLL.FriendLink();
        BLL.GuestBookType bllguestbooktype = new BLL.GuestBookType();
        BLL.Speciality bllspeciality = new BLL.Speciality();
        string xmlpath = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FullDefault();
                FullProduct();
                FullGuestBook();
                FullShowList();
            }
        }

        private void FullDefault()
        {
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(MapPath("~/App_Data/data.xml"));
            StringBuilder strCpjs = new StringBuilder();
            XmlNode nodelist = xmldoc.SelectSingleNode("/Root/node[@id='guid1']");
            foreach (XmlNode node in nodelist.ChildNodes)
            {
                strCpjs.AppendFormat(@"
                <li>
                    <a href='#{3}' data-transition='slide'>
                    <img class='productimg' height='70' width='70' src='{0}'>
                    <h2>{1}</h2>
                    <p>{2}</p>
                    </a>
                </li>", sys.AppPath + node.Attributes["smallsrc"].Value, node.Attributes["alt"].Value, node.Attributes["content"].Value, node.Attributes["href"].Value);
            }
            CPJS = strCpjs.ToString();

            StringBuilder strJdal = new StringBuilder();
            List<Model.FriendLink> list = bllfriendLink.GetModelList("1=1");
            foreach (Model.FriendLink unit in list)
            {
                strJdal.AppendFormat(@"
                <li>
                    <a href='#{0}' data-transition='slide'>
                    <img class='productimg' height='70' width='70' src='{1}'>
                    <h2>{2}</h2>
                    <p>{3}</p>
                    </a>
                </li>", unit.dbo_ProductImgLink, sys.AppPath + unit.dbo_ProductImgSrc,unit.dbo_FactoryProductName,unit.dbo_ProductInfo);
            }
            JDAL = strJdal.ToString();
        }

        private void FullProduct()
        {
            DataTable specialitydt = bllspeciality.GetList("1=1 order by id asc").Tables[0];
            Product1.P_Name = specialitydt.Select("dbo_HtmlDir='product1'")[0]["dbo_Name"].ToString();
            Product1.P_Info = specialitydt.Select("dbo_HtmlDir='product1'")[0]["dbo_ContentHtml"].ToString();
            Product2.P_Name = specialitydt.Select("dbo_HtmlDir='product2'")[0]["dbo_Name"].ToString();
            Product2.P_Info = specialitydt.Select("dbo_HtmlDir='product2'")[0]["dbo_ContentHtml"].ToString();
            Product3.P_Name = specialitydt.Select("dbo_HtmlDir='product3'")[0]["dbo_Name"].ToString();
            Product3.P_Info = specialitydt.Select("dbo_HtmlDir='product3'")[0]["dbo_ContentHtml"].ToString();
        }

        private void FullGuestBook()
        {
            DataTable dt = bllguestbooktype.GetList("1=1 order by id asc").Tables[0];
            foreach (DataRow dr in dt.Rows)
            {
                guestType += "<option value=\"" + dr["id"].ToString() + "\">" + dr["dbo_typeName"].ToString() + "</option>";
            }
        }

        private void FullShowList()
        {
            BLL.Article bllarticle = new BLL.Article();
            int rowcount, pageIndex, pageSize;
            pageIndex = 1;
            pageSize = 15;
            string[] str = "7".Split(',');
            int[] typeids = new int[str.Length];
            for (int i = 0; i < str.Length; i++)
            {
                typeids[i] = Convert.ToInt32(str[i]);
            }
            DataTable dt = bllarticle.getPagerArticle(pageIndex, pageSize, out rowcount, typeids, "");
            int pagecount = (rowcount + pageSize - 1) / pageSize;
            StringBuilder result = new StringBuilder();
            foreach (DataRow dr in dt.Rows)
            {
                result.AppendFormat("<li><a href=\"javascript:showDetail({0})\" data-transition='slide'>{1}<span class=\"ui-li-count\">{2}</span></a></li>", dr["id"], dr["dbo_title"], ((DateTime)dr["dbo_ptime"]).ToString("yyyy-MM-dd"));
            }
            NewList = result.ToString();
            hidPagecount_list.Value = pagecount.ToString();
            hidPageNow_list.Value = pageIndex.ToString();
            if (pagecount == pageIndex || pagecount == 0)
            {
                listMore.InnerHtml = "没有更多内容了";
            }
        }
    }
}