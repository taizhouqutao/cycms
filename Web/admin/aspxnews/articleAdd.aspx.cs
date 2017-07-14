using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Adapte;
using System.Data;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Net;

namespace cycms.Web.admin.aspxnews
{
    public partial class articleAdd : System.Web.UI.Page
    {
        BLL.ArticleType bllarticletype = new BLL.ArticleType();
        Model.Article modelarticle = new Model.Article();
        BLL.Article bllarticle = new BLL.Article();
        BLL.ArticleImg bllarticleimg = new BLL.ArticleImg();
        enum MyPageState { add, edit }
        MyPageState theState;
        string spcId = "0";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["spcId"] != null)
            {
                spcId = Request.QueryString["spcId"].ToString();
                this.btnBackToList.Attributes.Add("onclick", "javascript:window.location.href='articleList.aspx?spcId=" + spcId + "'");
            }

            if (!currentAdmin.validationSpcEditor(spcId))
            {
                adminOpers.ShowNoPower();
                return;
            }

            theState = MyPageState.add;
            if (Request.QueryString["id"] != null)
            {
                theState = MyPageState.edit;
            }
            InitPage();

        }

        private void InitPage()
        {

            string fiter = "dbo_specialityId=" + spcId + " and dbo_isArticleType=True";

            if (!currentAdmin.validationSpcAdmin(spcId))
            {
                string ids = adminOpers.getChannelPower(spcId, currentAdmin.Channels);
                if (ids == "-2")
                {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "alertNoTypes", "alert('专题下未创建任何文章类型或者您在该专题下没有任何权限');", true);
                    pnlContent.Visible = false;
                    return;
                }
                fiter = " id in(" + ids + ") ";
            }


            DataTable dt = bllarticletype.GetList(fiter + " order by id asc").Tables[0];
            DataTable dttemp = bllarticletype.getChildNodes(dt, 0);

            if (dttemp.Rows.Count == 0)
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "alertNoTypes", "alert('专题下未创建任何文章类型，请先添加文章类型');", true);
                pnlContent.Visible = false;
                return;
            }

            if (!Page.IsPostBack)
            {
                this.ddlType.Items.Add(new ListItem("请选择分类", "0"));
                FillDdlFatherType(dt, null, 0, (dttemp.Rows.Count <= 1));
                this.txtSource.Text = sys.webName;
                this.txtAuthor.Text = currentAdmin.Name;
            }
            if (!Page.IsPostBack && theState == MyPageState.edit)
            {
                this.btnSubmit.Text = "保存修改";
                FillContent();
            }

        }

        private void FillContent()
        {
            modelarticle = bllarticle.GetModel(Convert.ToInt32(Request.QueryString["id"].ToString()));
            if (modelarticle!=null)
            {
                this.txtTitle.Text = modelarticle.dbo_Title;
                this.txtAuthor.Text = modelarticle.dbo_Author;
                this.txtSource.Text = modelarticle.dbo_Source;
                this.txtClick.Text = modelarticle.dbo_Click.ToString();
                this.fckContent.Text = modelarticle.dbo_Content;
                string strfujian = modelarticle.dbo_Fujian;

                if (bllarticleimg.GetRecordCount("dbo_articleId=" + Request.QueryString["id"]) > 0)
                {
                    this.chkIsAddImgToDb.Checked = true;
                }

                this.chkIsLock.Checked = modelarticle.dbo_IsLock;
                this.chkIsTop.Checked = modelarticle.dbo_IsTop;
                if (strfujian != null && strfujian != "")
                {
                    StringBuilder sb = new StringBuilder();
                    string appPath = sys.AppPath;
                    string[] fujians = strfujian.Split('/');
                    sb.Append("本文已有附件：");
                    sb.Append("<ul id='fujian'>\n");
                    for (int i = 0; i < fujians.Length; i++)
                    {
                        string filePath = appPath + "uploads/" + fujians[i];
                        sb.Append("<li><a href='" + filePath + "' target='_blank'>" + fujians[i] + "</a><input style='margin-left:20px;' type='button' value='删除' onclick='javascript:deleteFile(this)' /></li>\n");
                        //sb.Append("<div class='fujian'>本文附件：<a href='" + appPath + "uploads/" + strfujian + "'>" + strfujian + "</a></div>");
                    }
                    sb.Append("</ul>\n");
                    this.litFujian.Text = sb.ToString();

                }
                string type = modelarticle.dbo_Typeid.ToString();

                for (int i = 0; i < this.ddlType.Items.Count; i++)
                {
                    if (type == this.ddlType.Items[i].Value)
                    {
                        this.ddlType.Items[i].Selected = true;
                    }
                }
            }
        }

        private void FillDdlFatherType(DataTable dt, DataRow fatherRow, int layer, bool IsTypeEnd)
        {
            int fatherid = 0;
            if (fatherRow != null)
            {
                fatherid = Convert.ToInt32(fatherRow["id"]);
                string fathertypename = fatherRow["dbo_typename"].ToString();
                if (!IsTypeEnd)
                {
                    fathertypename = "├" + fathertypename;
                }
                else
                {
                    fathertypename = "└" + fathertypename;
                }

                for (int i = 2; i < layer; i++)
                {
                    fathertypename = "　" + fathertypename;
                }


                if (layer != 1)
                {
                    fathertypename = "│" + fathertypename;
                }

                this.ddlType.Items.Add(new ListItem(fathertypename, fatherid.ToString()));
            }


            DataTable dtChildren =bllarticletype.getChildNodes(dt, fatherid);

            for (int i = 0; i < dtChildren.Rows.Count; i++)
            {
                FillDdlFatherType(dt, dtChildren.Rows[i], layer + 1, (dtChildren.Rows.Count == (i + 1)));
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string strTitle = this.txtTitle.Text;
            string strAuthor = this.txtAuthor.Text;
            string strClick = this.txtClick.Text;
            string strSource = this.txtSource.Text;
            string strType = this.ddlType.SelectedValue;
            string strContent = this.fckContent.Text;
            HttpFileCollection thefiles = Request.Files;

            bool IsAddImgToDb = this.chkIsAddImgToDb.Checked;

            if (strType == "0" || strType == "")
            {
                this.lblTypeMessage.Text = "请选择文章分类";
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "alert", "alert(\"请选择文章分类！\")", true);
                return;
            }

            //检查所有文件的后缀名是否为允许上传的类型
            for (int ifile = 0; ifile < thefiles.Count; ifile++)
            {
                HttpPostedFile file = thefiles[ifile];
                string fileName = file.FileName.ToLower();
                if (fileName != "" && file.ContentLength != 0)
                {
                    string fileExtension = System.IO.Path.GetExtension(fileName); //扩展名
                    fileName = System.IO.Path.GetFileNameWithoutExtension(fileName); //文件名
                    bool AllowUpload = false;
                    string strFileType = System.Configuration.ConfigurationManager.AppSettings["AllowFileTypes"].ToString();
                    string[] filetypes = strFileType.Split(',');

                    for (int i = 0; i < filetypes.Length; i++)
                    {
                        if (fileExtension == "." + filetypes[i].ToLower())
                        {
                            AllowUpload = true; break;
                        }
                    }
                    if (!AllowUpload)
                    {
                        Page.ClientScript.RegisterStartupScript(Page.GetType(), "alertfileNotAllow", "alert('您上传的附件中含有不允许上传的附件类型，请重新添加')", true);
                        return;
                    }
                }
            }

            string uploadFileNames = string.Empty;
            for (int ifile = 0; ifile < thefiles.Count; ifile++)
            {
                HttpPostedFile file = thefiles[ifile];
                string fileName = file.FileName;
                if (file.ContentLength != 0)
                {
                    fileName = fileName.ToLower();
                    string fileExtension = System.IO.Path.GetExtension(fileName); //扩展名
                    fileName = System.IO.Path.GetFileNameWithoutExtension(fileName); //文件名
                    //fileName = fileName.Substring(fileName.LastIndexOf('\\'), fileName.LastIndexOf('.')); //文件名

                    //判断文件是否已经存在，如果存在则重命名，直到文件名不存在
                    string fileRename = fileName + fileExtension;
                    int tryTimes = 0;
                    while (File.Exists(Server.MapPath("../../") + "uploads/" + fileRename))
                    {
                        tryTimes++;
                        fileRename = fileName + "(" + tryTimes.ToString() + ")" + fileExtension;
                    }

                    uploadFileNames += (uploadFileNames == string.Empty) ? fileRename : "/" + fileRename; //多个文件用符号‘/’隔开

                    string fullFileName = Server.MapPath("../../") + "uploads/" + fileRename;
                    file.SaveAs(fullFileName);
                }
            }

            string oldFujian = Request.Form["_fujianOld"];
            if (oldFujian != "")
            {
                uploadFileNames += (uploadFileNames == string.Empty) ? oldFujian : "/" + oldFujian; //多个文件用符号‘/’隔开

            }


            string[] strSrcs = getPics(ref strContent);
            this.fckContent.Text = strContent;
            int articleId;
            if (theState == MyPageState.add)
            {
                articleId=bllarticle.Add_ReturnID(new Model.Article { dbo_Title = strTitle, dbo_Typeid = Convert.ToInt32(strType), dbo_Content = strContent, dbo_Author = strAuthor, dbo_Source = strSource, dbo_Click = Convert.ToInt32(strClick), dbo_Fujian = uploadFileNames, dbo_IsLock = this.chkIsLock.Checked, dbo_IsTop = this.chkIsTop.Checked, dbo_Ptime=DateTime.Now });

                //只添加一张图片到数据库中
                if (strSrcs.Length > 0 && IsAddImgToDb)
                {
                    bllarticleimg.Add(new Model.ArticleImg { dbo_ImgSrc = strSrcs[0], dbo_articleId = articleId, dbo_ImgBigSrc = strSrcs[0], dbo_SpecialityId = Convert.ToInt32(Request.QueryString["spcId"]), dbo_ImgArt = strTitle });
                }
            }
            else
            {
                articleId = Convert.ToInt32(Request.QueryString["id"]);
                modelarticle = bllarticle.GetModel(articleId);
                modelarticle.dbo_Title = strTitle;
                modelarticle.dbo_Content = strContent;
                modelarticle.dbo_Author = strAuthor;
                modelarticle.dbo_Source = strSource;
                modelarticle.dbo_Click = strClick==""?0:Convert.ToInt32(strClick);
                modelarticle.dbo_Fujian = uploadFileNames;
                modelarticle.dbo_IsLock = this.chkIsLock.Checked;
                modelarticle.dbo_IsTop = this.chkIsTop.Checked;
                modelarticle.dbo_Ptime = DateTime.Now;
                bllarticle.Update(modelarticle);
                bllarticleimg.DeleteByArticleId(articleId);

                //只添加一张图片到数据库中
                if (strSrcs.Length > 0 && IsAddImgToDb)
                {
                    bllarticleimg.Add(new Model.ArticleImg { dbo_ImgSrc = strSrcs[0], dbo_articleId = articleId, dbo_ImgBigSrc = strSrcs[0], dbo_SpecialityId = Convert.ToInt32(Request.QueryString["spcId"]), dbo_ImgArt = strTitle });
                }
            }

            string spcId = "0";

            if (Request.QueryString["spcId"] != null)
            {
                spcId = Request.QueryString["spcId"].ToString();
            }

            if (sys.IsStatic)
            {
                string strDir = sys.getSpcDir(Convert.ToInt32(spcId));
                sys.ToStaticListWithArticleEdit(Convert.ToInt32(this.ddlType.SelectedValue), strDir);
                sys.ToStaticContent(strDir, articleId, DateTime.Now);
            }
            else //判断是否需要生成首页
            {
                sys.ToStaticPageWithActive(Convert.ToInt32(spcId));
            }

            Response.Redirect("articleList.aspx?spcId=" + spcId);

        }


        #region 检索出所有的图片,并且判断是否需要替换
        private string[] getPics(ref string articleContent)
        {
            bool IsDownPic = this.chkDownPic.Checked;
            bool IsAddShuiYinToImg = this.chkIsAddShuiYinToImg.Checked;

            Regex reg = new Regex("<img.* src=(['\"]?)(?<src>[^\"]*)\\1.*/>", RegexOptions.IgnoreCase);
            MatchCollection matches = reg.Matches(articleContent);
            string[] strSrcs = new string[matches.Count];
            for (int i = 0; i < matches.Count; i++)
            {
                string src = matches[i].Groups["src"].Value;


                //如果是网络图片并且选中了下载图片则把图片下载过来
                //并且替换原来字符串中的内容
                if (src.Substring(0, 7).ToLower() == "http://")
                {
                    if (IsDownPic)
                    {
                        string appPath = sys.AppPath;
                        string fckFilePath = appPath + "UserFiles/";
                        string fckFilePath3 = "UserFiles/";
                        string fileName = DateTime.Now.ToString("yyyyMMddHHmmss") + "_" + i.ToString() + "." + sys.GetEnd(src);
                        string fckFilePath2 = "UserFiles\\";
                        string downLoadPath = Server.MapPath("~/") + fckFilePath2 + "image\\" + fileName;

                        if (DownPic(src, downLoadPath))
                        {
                            articleContent = articleContent.Replace(src, fckFilePath + "image/" + fileName);
                            src = fckFilePath3 + "image/" + fileName;
                        }
                        if (IsAddShuiYinToImg)
                        {
                            ShuiYinToImage(downLoadPath);
                        }
                    }
                }
                else
                {
                    string theFilePath = Server.MapPath("~/") + "UserFiles\\Image\\" + Path.GetFileName(src);
                    if (IsAddShuiYinToImg)
                    {
                        ShuiYinToImage(theFilePath);
                    }
                    src="UserFiles\\Image\\" + Path.GetFileName(src);
                }


                strSrcs[i] = src;
            }
            return strSrcs;
        }
        #endregion

        #region 下载图片
        private bool DownPic(string source, string savePath)
        {
            try
            {
                WebClient mywebClient = new WebClient();
                mywebClient.DownloadFile(source, savePath);
                return true;
            }
            catch (Exception err)
            {
                Response.Write(err.Message);
                return false;
            }
        }
        #endregion

        #region 添加图片水印
        public void ShuiYinToImage(string imgPath)
        {

            try
            {
                ImageModification imgM = new ImageModification();
                imgM.ModifyImagePath = imgPath;
                imgM.DrawedImagePath = Server.MapPath("~/") + "UserFiles\\shuiyinSource.png";

                imgM.LucencyPercent = 80;
                imgM.BottoamSpace = 50;
                imgM.RightSpace = 260;
                imgM.DrawImage();
            }
            catch
            {

            }

        }
        #endregion
    }
}