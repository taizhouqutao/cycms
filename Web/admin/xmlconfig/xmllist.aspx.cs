using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Xml;

namespace cycms.Web.admin.xmlconfig
{
    public partial class xmllist : System.Web.UI.Page
    {
        public string titlename = "";
        public string nodetype = "";
        XmlDocument xmldoc = new XmlDocument();
        protected void Page_Load(object sender, EventArgs e)
        {
            xmldoc.Load(MapPath("../../App_Data/data.xml"));
            titlename = xmldoc.SelectSingleNode("/Root/node[@id='" + Request.QueryString["id"] + "']").Attributes["name"].Value;
            nodetype = xmldoc.SelectSingleNode("/Root/node[@id='" + Request.QueryString["id"] + "']").Attributes["type"].Value;
            hlkAddpage.NavigateUrl = "xmladd.aspx?nodeid=" + Request.QueryString["id"];
            if (nodetype == "txtlink")
            {
                Panel1.Visible = false;
                Panel2.Visible = true;
            }
            else
            {
                Panel1.Visible = true;
                Panel2.Visible = false;
            }
            if (!Page.IsPostBack)
            {
                BindData(Request.QueryString["id"]);
            }
        }

        private void BindData(string nodeid)
        {
            if (nodetype != "txtlink")
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("id", typeof(string));
                dt.Columns.Add("href", typeof(string));
                dt.Columns.Add("alt", typeof(string));
                dt.Columns.Add("src", typeof(string));
                XmlNode node = xmldoc.SelectSingleNode("/Root/node[@id='" + nodeid + "']");
                foreach (XmlNode sonnode in node.ChildNodes)
                {
                    dt.Rows.Add(sonnode.Attributes["id"].Value, sonnode.Attributes["href"].Value, sonnode.Attributes["alt"].Value, sonnode.Attributes["src"].Value);
                }
                this.GridView1.DataSource = dt;
                this.GridView1.DataBind();
            }
            else
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("id", typeof(string));
                dt.Columns.Add("href", typeof(string));
                dt.Columns.Add("alt", typeof(string));
                XmlNode node = xmldoc.SelectSingleNode("/Root/node[@id='" + nodeid + "']");
                foreach (XmlNode sonnode in node.ChildNodes)
                {
                    dt.Rows.Add(sonnode.Attributes["id"].Value, sonnode.Attributes["href"].Value, sonnode.Attributes["alt"].Value);
                }
                this.GridView2.DataSource = dt;
                this.GridView2.DataBind();
            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string id = this.GridView1.DataKeys[e.RowIndex].Value.ToString();
            XmlNode xmlnode = xmldoc.SelectSingleNode("/Root/node/link[@id='" + id + "']");
            xmlnode.ParentNode.RemoveChild(xmlnode);
            xmldoc.Save(MapPath("../../App_Data/data.xml"));
            Response.Write("<script>window.location.href='xmllist.aspx?id=" + Request.QueryString["id"] + "';</script>");

        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.GridView1.PageIndex = e.NewPageIndex;
            this.BindData(Request.QueryString["id"]);
        }

        protected void GridView2_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string id = this.GridView2.DataKeys[e.RowIndex].Value.ToString();
            XmlNode xmlnode = xmldoc.SelectSingleNode("/Root/node/link[@id='" + id + "']");
            xmlnode.ParentNode.RemoveChild(xmlnode);
            xmldoc.Save(MapPath("../../App_Data/data.xml"));
            Response.Write("<script>window.location.href='xmllist.aspx?id=" + Request.QueryString["id"] + "';</script>");
        }

        protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.GridView2.PageIndex = e.NewPageIndex;
            this.BindData(Request.QueryString["id"]);
        }
    }
}