using System;
using System.Collections.Generic;
using Adapte;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace cycms.Web.admin.FriendLink
{
    public partial class FriendLinkEdit : System.Web.UI.Page
    {
        BLL.FriendLink bllfriendlink = new BLL.FriendLink();
        Model.FriendLink modelfriendlink = new Model.FriendLink();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!currentAdmin.IsSuper)
            {
                adminOpers.ShowNoPower();
                return;
            }
            if (!IsPostBack)
            {
                Showpage(Request.QueryString["id"]);
            }
        }

        private void Showpage(string id)
        {
            if (id != null)
            {
                modelfriendlink = bllfriendlink.GetModel(Convert.ToInt32(id));
                if(modelfriendlink!=null)
                {
                    txtFactoryLink.Text = modelfriendlink.dbo_FactoryLink;
                    txtFactoryProductName.Text = modelfriendlink.dbo_FactoryProductName;
                    txtProductImgLink.Text = modelfriendlink.dbo_ProductImgLink;
                    txtProductImgName.Text = modelfriendlink.dbo_ProductImgName;
                    txtProductInfo.Text = modelfriendlink.dbo_ProductInfo;
                    Imgshow.ImageUrl = sys.AppPath + modelfriendlink.dbo_ProductImgSrc;
                    Imgshowfactory.ImageUrl = sys.AppPath + modelfriendlink.dbo_FactoryLogoSrc;
                }
            }
            else
            {
                Imgshow.ImageUrl = sys.AppPath + "uploads/teacherPhoto/noPhoto.png";
                Imgshowfactory.ImageUrl = sys.AppPath + "uploads/teacherPhoto/noPhoto.png";
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            string filename = "";
            string smlfilename = "";
            string extendpath = "";
            string filenamefactry = "";
            string smlfilenamefactry = "";
            string extendpathfactry = "";
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
                    if (!Directory.Exists(Server.MapPath("~/UserFiles/Image/" + extendpath)))
                    {
                        Directory.CreateDirectory((Server.MapPath("~/UserFiles/Image/" + extendpath)));
                    }
                    this.fulimg.SaveAs(Server.MapPath("~/UserFiles/Image/" + extendpath) + filename);
                    smlfilename = bifstring + "_SMA_" + fulimg.FileName;
                    ImageUtility.MakeSmallImage(Server.MapPath("~/UserFiles/Image/" + extendpath) + filename, Server.MapPath("~/UserFiles/Image/" + extendpath) + smlfilename, 155, 205);
                    File.Delete(Server.MapPath("~/UserFiles/Image/" + extendpath) + filename);
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "alert", "alert(\"上传的文件只能是图片文件！\")", true);
                    return;
                }
            }
            bool Filesfactory = false;
            if (this.fulimgfactory.HasFile)
            {
                string fileSuffix = System.IO.Path.GetExtension(this.fulimgfactory.FileName).ToLower();
                string[] Suffix = { ".jpg", ".bmp", ".gif", ".png" };
                for (int i = 0; i < Suffix.Length; i++)
                {
                    if (fileSuffix == Suffix[i])
                    {
                        Filesfactory = true;
                    }
                }
                if (Filesfactory == true)
                {
                    Random rd = new Random();
                    DateTime thistime = DateTime.Now;
                    extendpathfactry = thistime.Year + "/" + thistime.Month + "/" + thistime.Day + "/";
                    string bifstring = rd.Next(100, 999).ToString() + thistime.ToString("yyyyMMddhhmmss");
                    filenamefactry = bifstring + fulimgfactory.FileName;
                    if (!Directory.Exists(Server.MapPath("~/UserFiles/Image/" + extendpathfactry)))
                    {
                        Directory.CreateDirectory((Server.MapPath("~/UserFiles/Image/" + extendpathfactry)));
                    }
                    this.fulimgfactory.SaveAs(Server.MapPath("~/UserFiles/Image/" + extendpathfactry) + filenamefactry);
                    smlfilenamefactry = bifstring + "_SMA_" + fulimgfactory.FileName;
                    ImageUtility.MakeSmallImage(Server.MapPath("~/UserFiles/Image/" + extendpathfactry) + filenamefactry, Server.MapPath("~/UserFiles/Image/" + extendpathfactry) + smlfilenamefactry, 62, 175);
                    File.Delete(Server.MapPath("~/UserFiles/Image/" + extendpathfactry) + filenamefactry);
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "alert", "alert(\"上传的文件只能是图片文件！\")", true);
                    return;
                }
            }
            if (Request.QueryString["id"] != null)
            {
                modelfriendlink = bllfriendlink.GetModel(Convert.ToInt32(Request.QueryString["id"]));
                modelfriendlink.dbo_FactoryLink = txtFactoryLink.Text.Trim();
                modelfriendlink.dbo_FactoryProductName = txtFactoryProductName.Text.Trim();
                modelfriendlink.dbo_ProductImgLink = txtProductImgLink.Text.Trim();
                modelfriendlink.dbo_ProductImgName = txtProductImgName.Text.Trim();
                modelfriendlink.dbo_ProductInfo = txtProductInfo.Text.Trim();
                if (Files == true)
                {
                    modelfriendlink.dbo_ProductImgSrc = ("UserFiles/image/" + extendpath + smlfilename);
                }
                if (Filesfactory == true)
                {
                    modelfriendlink.dbo_FactoryLogoSrc = ("UserFiles/image/" + extendpathfactry + smlfilenamefactry);
                }
                bllfriendlink.Update(modelfriendlink);
                Response.Redirect("FriendLinkList.aspx");
            }
            else
            {
                modelfriendlink.dbo_FactoryLink = txtFactoryLink.Text.Trim();
                modelfriendlink.dbo_FactoryProductName = txtFactoryProductName.Text.Trim();
                modelfriendlink.dbo_ProductImgLink = txtProductImgLink.Text.Trim();
                modelfriendlink.dbo_ProductImgName = txtProductImgName.Text.Trim();
                modelfriendlink.dbo_ProductInfo = txtProductInfo.Text.Trim();
                modelfriendlink.dbo_ProductImgSrc = "uploads/teacherPhoto/noPhoto.png";
                modelfriendlink.dbo_FactoryLogoSrc = "uploads/teacherPhoto/noPhoto.png";
                if (Files == true)
                {
                    modelfriendlink.dbo_ProductImgSrc = ("UserFiles/image/" + extendpath + smlfilename);
                }
                if (Filesfactory == true)
                {
                    modelfriendlink.dbo_FactoryLogoSrc = ("UserFiles/image/" + extendpathfactry + filenamefactry);
                }
                bllfriendlink.Add(modelfriendlink);
                Response.Redirect("FriendLinkList.aspx");
            }
        }
    }
}