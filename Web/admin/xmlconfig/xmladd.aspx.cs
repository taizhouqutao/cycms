using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using Adapte;
using System.IO;
namespace cycms.Web.admin.xmlconfig
{
    public partial class xmladd : System.Web.UI.Page
    {
        public string titlename = "";
        XmlDocument xmldoc = new XmlDocument();
        protected void Page_Load(object sender, EventArgs e)
        {
            xmldoc.Load(MapPath("../../App_Data/data.xml"));
            XmlNode node = xmldoc.SelectSingleNode("/Root/node[@id='" + Request.QueryString["nodeid"] + "']");
            if (node.Attributes["type"].Value == "txtlink")
            {
                Panel1.Visible = false;
            }
            if (node.Attributes["type"].Value != "simgandtxtlinkandbimg")
            {
                Panel2.Visible = false;
            }
            if (!IsPostBack)
            {
                Showpage(Request.QueryString["id"], Request.QueryString["nodeid"]);
            }
        }

        private void Showpage(string id, string nodeid)
        {
            if (id != null)
            {
                XmlNode node = xmldoc.SelectSingleNode("/Root/node[@id='" + nodeid + "']");
                XmlNode linknode = node.SelectSingleNode("link[@id='" + id + "']");
                txtName.Text = linknode.Attributes["alt"].Value;
                txtHref.Text = linknode.Attributes["href"].Value;
                if (node.Attributes["type"].Value != "txtlink")
                {
                    Imgshow.ImageUrl = sys.AppPath + linknode.Attributes["src"].Value;
                }
                if (node.Attributes["type"].Value == "simgandtxtlinkandbimg")
                {
                    txtContent.Text = linknode.Attributes["content"].Value;
                }
            }
            else
            {
                Imgshow.ImageUrl = sys.AppPath + "uploads/teacherPhoto/noPhoto.png";
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            XmlNode node = xmldoc.SelectSingleNode("/Root/node[@id='" + Request.QueryString["nodeid"] + "']");
            string filename = "";
            string bigfilename="";
            string smlfilename="";
            string extendpath = "";
            bool Files = false;
            if (this.fulimg.HasFile)
            {
                string fileSuffix = System.IO.Path.GetExtension(this.fulimg.FileName).ToLower();
                string[] Suffix = { ".jpg", ".bmp", ".gif", ".png" };
                for (int i = 0; i < Suffix.Length; i++)
                {
                    if (fileSuffix == Suffix[i])
                    {
                        Files = true;
                    }
                }
                if (Files == true)
                {
                    Random rd = new Random();
                    DateTime thistime = DateTime.Now;
                    extendpath = thistime.Year + "/" + thistime.Month + "/" + thistime.Day + "/";
                    string bifstring = rd.Next(100, 999).ToString() + thistime.ToString("yyyyMMddhhmmss");
                    filename = bifstring + fulimg.FileName;
                    if(!Directory.Exists(Server.MapPath("~/UserFiles/Image/" + extendpath)))
                    {
                        Directory.CreateDirectory((Server.MapPath("~/UserFiles/Image/" + extendpath)));
                    }
                    this.fulimg.SaveAs(Server.MapPath("~/UserFiles/Image/" + extendpath) + filename);
                    if(node.Attributes["bimgwidth"]!=null)
                    {
                        bigfilename=bifstring+"_BIG_"+ fulimg.FileName;
                        ImageUtility.MakeSmallImage(Server.MapPath("~/UserFiles/Image/" + extendpath) + filename, Server.MapPath("~/UserFiles/Image/" + extendpath) + bigfilename, Convert.ToInt32(node.Attributes["bimghigh"].Value), Convert.ToInt32(node.Attributes["bimgwidth"].Value));
                    }
                    if (node.Attributes["simgwidth"] != null)
                    {
                        smlfilename = bifstring + "_SMA_" + fulimg.FileName;
                        ImageUtility.MakeSmallImage(Server.MapPath("~/UserFiles/Image/" + extendpath) + filename, Server.MapPath("~/UserFiles/Image/"+extendpath) + smlfilename, Convert.ToInt32(node.Attributes["simghigh"].Value), Convert.ToInt32(node.Attributes["simgwidth"].Value));
                    }
                    File.Delete(Server.MapPath("~/UserFiles/Image/" + extendpath) + filename);
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "alert", "alert(\"上传的文件只能是图片文件！\")", true);
                    return;
                }
            }
            if (Request.QueryString["id"] != null)
            {
                XmlElement xmlement = xmldoc.SelectSingleNode("/Root/node/link[@id='" + Request.QueryString["id"] + "']") as XmlElement;
                xmlement.SetAttribute("href", txtHref.Text.Trim());
                if (bigfilename != "")
                {
                    xmlement.SetAttribute("src", "UserFiles/image/" + extendpath + bigfilename);
                }
                if (smlfilename != "")
                {
                    xmlement.SetAttribute("smallsrc", "UserFiles/image/" + extendpath + smlfilename);
                }
                xmlement.SetAttribute("alt", txtName.Text.Trim());
                if (node.Attributes["type"].Value == "simgandtxtlinkandbimg")
                {
                    xmlement.SetAttribute("content", txtContent.Text.Trim());
                }
                xmldoc.Save(MapPath("../../App_Data/data.xml"));
                Response.Redirect("xmllist.aspx?id=" + Request.QueryString["nodeid"]);
            }
            else
            {
                XmlElement xmlement = xmldoc.CreateElement("link");
                xmlement.SetAttribute("id", Guid.NewGuid().ToString());
                xmlement.SetAttribute("href", txtHref.Text.Trim());
                if (bigfilename != "")
                {
                    xmlement.SetAttribute("src", "UserFiles/image/" + extendpath + bigfilename);
                }
                if (smlfilename != "")
                {
                    xmlement.SetAttribute("smallsrc", "UserFiles/image/"+extendpath+ smlfilename);
                }
                xmlement.SetAttribute("alt", txtName.Text.Trim());
                if (node.Attributes["type"].Value == "simgandtxtlinkandbimg")
                {
                    xmlement.SetAttribute("content", txtContent.Text.Trim());
                }
                node.PrependChild(xmlement);
                xmldoc.Save(MapPath("../../App_Data/data.xml"));
                Response.Redirect("xmllist.aspx?id=" + Request.QueryString["nodeid"]);
            }
        }
    }
}