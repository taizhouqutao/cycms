using System;
using System.Collections.Generic;
using Adapte;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
namespace cycms.Web.admin.Themes
{
    public partial class ThemesAdd : System.Web.UI.Page
    {
        BLL.ArticleImg bllarticleimg = new BLL.ArticleImg();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Showpage(Request.QueryString["id"]);
            }
        }

        private void Showpage(string id)
        {
            if (id != null)
            {
                Model.ArticleImg modelarticle = bllarticleimg.GetModel(Convert.ToInt32(id));
                txtName.Text = modelarticle.dbo_ImgArt;
                Imgshow.ImageUrl = sys.AppPath + modelarticle.dbo_ImgSrc;
            }
            else
            {
                Imgshow.ImageUrl = sys.AppPath + "uploads/teacherPhoto/noPhoto.png";
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            string filename = "";
            string bigfilename = "";
            string smlfilename = "";
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
                    if (!Directory.Exists(Server.MapPath("~/UserFiles/Image/" + extendpath)))
                    {
                        Directory.CreateDirectory((Server.MapPath("~/UserFiles/Image/" + extendpath)));
                    }
                    this.fulimg.SaveAs(Server.MapPath("~/UserFiles/Image/" + extendpath) + filename);

                    smlfilename = bifstring + "_SMA_" + fulimg.FileName;
                    ImageUtility.MakeSmallImage(Server.MapPath("~/UserFiles/Image/" + extendpath) + filename, Server.MapPath("~/UserFiles/Image/" + extendpath) + smlfilename, 142, 196);
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "alert", "alert(\"上传的文件只能是图片文件！\")", true);
                    return;
                }
            }
            if (Request.QueryString["id"] != null)
            {
                Model.ArticleImg model = bllarticleimg.GetModel(Convert.ToInt32(Request.QueryString["id"]));
                if (filename != "")
                {
                    model.dbo_ImgBigSrc="UserFiles/image/" + extendpath + filename;
                }
                if (smlfilename != "")
                {
                    model.dbo_ImgSrc = "UserFiles/image/" + extendpath + smlfilename;
                }
                model.dbo_ImgArt = txtName.Text.Trim();
                bllarticleimg.Update(model);
                Response.Redirect("ThemesList.aspx?spcId=" + Request.QueryString["spcId"]);
            }
            else
            {
                Model.ArticleImg model = new Model.ArticleImg();
                model.dbo_articleId =0;
                model.dbo_SpecialityId =Convert.ToInt32(Request.QueryString["spcId"]);
                if (filename != "")
                {
                    model.dbo_ImgBigSrc = "UserFiles/image/" + extendpath + filename;
                }
                if (smlfilename != "")
                {
                    model.dbo_ImgSrc = "UserFiles/image/" + extendpath + smlfilename;
                }
                model.dbo_ImgArt=txtName.Text.Trim();
                bllarticleimg.Add(model);
                Response.Redirect("ThemesList.aspx?spcId=" + Request.QueryString["spcId"]);
            }
        }
    }
}