using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using System.Web;
using Maticsoft.Common;
using System.Net.Mail;
using System.Web.UI;
using System.Collections.Specialized;
using System.Xml;
using System.Data;
namespace Adapte
{
    public class sys : System.Web.UI.Page
    {
        #region 可逆加密
        /// <summary>
        /// 可逆加密
        /// </summary>
        /// <param name="strText">明文</param>
        /// <param name="strEncrKey">加密密钥，采用八位密钥加密，密钥必须大于等于8位，加密密钥必须与解密密钥相同，否则不能正确解密</param>
        /// <returns>结果返回加密后的密文</returns>
        public static string str_DesEncrypt(string strText, string strEncrKey)
        {
            byte[] byKey = null;
            byte[] IV = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };
            try
            {
                byKey = System.Text.Encoding.UTF8.GetBytes(strEncrKey.Substring(0, 8));
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                byte[] inputByteArray = System.Text.Encoding.UTF8.GetBytes(strText);
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(byKey, IV), CryptoStreamMode.Write);

                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                return Convert.ToBase64String(ms.ToArray());
            }
            catch (System.Exception error)
            {
                return "error:" + error.Message + "\r";
            }
        }
        #endregion

        #region 可逆解密
        /// <summary>
        /// 可逆解密
        /// </summary>
        /// <param name="strText">密文</param>
        /// <param name="sDecrKey">解密密钥，采用八位密钥解密，密钥必须大于等于8位，解密密钥必须与加密密钥相同才能正确解密</param>
        /// <returns>结果返回解密后的明文</returns>
        public static string str_DesDecrypt(string strText, string sDecrKey)
        {
            byte[] byKey = null;
            byte[] IV = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };
            byte[] inputByteArray = new Byte[strText.Length];
            try
            {
                byKey = System.Text.Encoding.UTF8.GetBytes(sDecrKey.Substring(0, 8));
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                inputByteArray = Convert.FromBase64String(strText);
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(byKey, IV), CryptoStreamMode.Write);

                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                System.Text.Encoding encoding = new System.Text.UTF8Encoding();
                return encoding.GetString(ms.ToArray());
            }
            catch (System.Exception error)
            {
                return "error:" + error.Message + "\r";
            }
        }
        #endregion

        #region 加密算法
        /// <summary>
        /// ews的加密算法
        /// </summary>
        /// <param name="cleanString"></param>
        /// <returns></returns>
        public static string Encrypt(string cleanString)
        {
            byte[] bytes = new UnicodeEncoding().GetBytes(cleanString);
            return BitConverter.ToString(((HashAlgorithm)CryptoConfig.CreateFromName("MD5")).ComputeHash(bytes));
        }
        #endregion

        #region 网站名称
        public static string webName
        {
            get
            {
                object webaddress = HttpContext.Current.Application["webName"];
                return webaddress == null ? "" : webaddress.ToString();
            }
            set
            {
                HttpContext.Current.Application["webName"] = value;
            }
        }
        #endregion

        #region 网站虚拟目录
        public static string AppPath
        {
            get
            {
                string thePath = HttpContext.Current.Request.ApplicationPath;
                return thePath == "/" ? "/" : thePath + "/";
            }

        }
        #endregion

        #region 当前系统是否为开放状态
        public static bool IsRunning
        {
            get
            {

                if (HttpContext.Current.Application["IsRunning"] == null)
                {
                    sys.initSys();
                }

                return Convert.ToBoolean(HttpContext.Current.Application["IsRunning"]);

            }
            set
            {
                HttpContext.Current.Application["IsRunning"] = value;
            }
        }
        #endregion

        #region 获取当前系统是否为静态生成状态默认为非静态生成
        public static bool IsStatic
        {
            get
            {
                if (HttpContext.Current.Application["IsStatic"] == null)
                {
                    return false;
                }
                else
                {
                    return Convert.ToBoolean(HttpContext.Current.Application["IsStatic"]);
                }
            }
            set
            {
                HttpContext.Current.Application["IsStatic"] = value;
            }
        }
        #endregion

        #region 网站地址
        public static string webAddress
        {
            get
            {
                object webaddress = HttpContext.Current.Application["webAddress"];
                return webaddress == null ? "" : webaddress.ToString();
            }
            set
            {
                HttpContext.Current.Application["webAddress"] = value;
            }
        }
        #endregion

        #region 访问次数统计
        public static string VisitedTimes
        {
            get
            {
                try
                {
                    cycms.BLL.Cycms bll = new cycms.BLL.Cycms();
                    cycms.Model.Cycms model = new cycms.Model.Cycms();
                    int n = 0;
                    if (HttpContext.Current.Application["visitedTimes"] != null)
                    {
                        n = Convert.ToInt32(HttpContext.Current.Application["visitedTimes"]);
                    }
                    else
                    {
                        n = Convert.ToInt32(Maticsoft.Common.ConfigHelper.GetConfigInt("visitedTimes"));
                    }

                    if (n % 10 == 0)
                    {
                        model = bll.GetModel(bll.GetMaxId() - 1);
                        model.dbo_VisitedTimes = n;
                        bll.Update(model);
                    }
                    return n.ToString();
                }
                catch
                {
                    return "0";
                }
            }
            set
            {
                if (Maticsoft.Common.PageValidate.IsNumber(value))
                {
                    HttpContext.Current.Application["visitedTimes"] = value;
                }
            }
        }

        #endregion

        #region 静态生成时自动生成的列表页数
        public static int staticListPages
        {
            get
            {
                return Convert.ToInt32(HttpContext.Current.Application["staticListPages"]);
            }
            set
            {
                cycms.BLL.Cycms bll = new cycms.BLL.Cycms();
                cycms.Model.Cycms model = new cycms.Model.Cycms();
                HttpContext.Current.Application["staticListPages"] = value;
                model=bll.GetModel(bll.GetMaxId() - 1);
                model.dbo_StaticListPages = value;
                bll.Update(model);
            }

        }

        #endregion

        #region 发送邮件

        #region 邮箱服务器地址
        public static string smtpServer
        {
            //get { return System.Configuration.ConfigurationManager.AppSettings["smtpServer"]; }
            get
            {
                if (HttpContext.Current.Application["smtpServer"] != null)
                {
                    return HttpContext.Current.Application["smtpServer"].ToString();
                }
                return "";
            }
            set
            {
                HttpContext.Current.Application["smtpServer"] = value;
            }
        }
        #endregion

        #region 邮箱地址
        public static string mailAddress
        {
            //get { return System.Configuration.ConfigurationManager.AppSettings["mailAddress"]; }
            get
            {
                if (HttpContext.Current.Application["mailAddress"] != null)
                {
                    return HttpContext.Current.Application["mailAddress"].ToString();
                }
                return "";
            }
            set
            {
                HttpContext.Current.Application["mailAddress"] = value;
            }
        }
        #endregion

        #region 邮箱用户名
        public static string mailName
        {
            //get { return System.Configuration.ConfigurationManager.AppSettings["mailName"]; }
            get
            {
                if (HttpContext.Current.Application["mailName"] != null)
                {
                    return HttpContext.Current.Application["mailName"].ToString();
                }
                return "";
            }
            set
            {
                HttpContext.Current.Application["mailName"] = value;
            }

        }

        #endregion

        #region 邮箱密码
        public static string mailPwd
        {
            //get { return System.Configuration.ConfigurationManager.AppSettings["mailPwd"]; }

            get
            {
                if (HttpContext.Current.Application["mailPwd"] != null)
                {
                    return HttpContext.Current.Application["mailPwd"].ToString();
                }
                return "";
            }
            set
            {
                HttpContext.Current.Application["mailPwd"] = value;
            }
        }

        #endregion
        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="subject">邮件标题</param>
        /// <param name="mailBody">邮件内容</param>
        /// <param name="sendAddress">发送邮箱</param>
        /// <param name="sendSmtp">发送邮箱服务器地址</param>
        /// <param name="senduid">发送邮箱用户名</param>
        /// <param name="sendpwd">发送邮箱密码</param>
        /// <param name="mailToAddress">接收邮箱地址</param>
        /// <returns></returns>
        public static bool SendEmail(string subject, string mailBody, string sendAddress, string sendSmtp, string senduid, string sendpwd, string mailToAddress)
        {

            //.Net2.0的方法发送邮件
            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(sys.webName + " <" + sendAddress + ">");
                mail.To.Add(new MailAddress(mailToAddress));
                mail.Subject = subject;
                mail.Body = mailBody;
                mail.IsBodyHtml = true;
                mail.Priority = MailPriority.Normal;

                SmtpClient smtpClient = new SmtpClient(sendSmtp);
                smtpClient.UseDefaultCredentials = false;
                smtpClient.EnableSsl = true;
                smtpClient.Credentials = new System.Net.NetworkCredential(sendAddress, sendpwd);
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpClient.Send(mail);
                mail.Dispose();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool SendEmail(string subject, string mailBody, string mailToAddress)
        {
            return SendEmail(subject, mailBody, mailAddress, smtpServer, mailName, mailPwd, mailToAddress);
        }
        #endregion

        #region 联系人
        public static string lianXiren
        {
            get
            {
                object lianXiren = HttpContext.Current.Application["lianXiren"];
                return lianXiren == null ? "" : lianXiren.ToString();
            }
            set
            {
                HttpContext.Current.Application["lianXiren"] = value;
            }
        }
        #endregion

        #region 手机
        public static string cellPhone
        {
            get
            {
                object cellPhone = HttpContext.Current.Application["cellPhone"];
                return cellPhone == null ? "" : cellPhone.ToString();
            }
            set
            {
                HttpContext.Current.Application["cellPhone"] = value;
            }
        }
        #endregion

        #region 电话
        public static string workPhone
        {
            get
            {
                object workPhone = HttpContext.Current.Application["workPhone"];
                return workPhone == null ? "" : workPhone.ToString();
            }
            set
            {
                HttpContext.Current.Application["workPhone"] = value;
            }
        }
        #endregion

        #region 传真
        public static string flax
        {
            get
            {
                object flax = HttpContext.Current.Application["flax"];
                return flax == null ? "" : flax.ToString();
            }
            set
            {
                HttpContext.Current.Application["flax"] = value;
            }
        }
        #endregion

        #region 地址
        public static string workPlace
        {
            get
            {
                object workPlace = HttpContext.Current.Application["workPlace"];
                return workPlace == null ? "" : workPlace.ToString();
            }
            set
            {
                HttpContext.Current.Application["workPlace"] = value;
            }
        }
        #endregion

        #region 备案号
        public static string beiAnHao
        {
            get
            {
                object beiAnHao = HttpContext.Current.Application["beiAnHao"];
                return beiAnHao == null ? "" : beiAnHao.ToString();
            }
            set
            {
                HttpContext.Current.Application["beiAnHao"] = value;
            }
        }
        #endregion

        #region 初始化系统
        public static void initSys()
        {
            cycms.BLL.Cycms bll = new cycms.BLL.Cycms();
            cycms.Model.Cycms model=new cycms.Model.Cycms();
            try
            {
                model = bll.GetModel(bll.GetMaxId()-1);
                if (model!=null)
                {
                    IsRunning = Convert.ToBoolean(model.dbo_IsRunning);
                    IsStatic = model.dbo_IsStatic;
                    webAddress = model.dbo_WebAddress;
                    webName = model.dbo_WebName;
                    VisitedTimes = model.dbo_VisitedTimes.ToString();
                    staticListPages =Convert.ToInt32(model.dbo_StaticListPages);
                    smtpServer = model.dbo_SmtpServer;
                    mailAddress = model.dbo_MailAddress;
                    mailName = model.dbo_MailName;
                    mailPwd = model.dbo_MailPwd;
                    lianXiren = model.dbo_LianXiRen;
                    cellPhone = model.dbo_CellPhone;
                    workPhone = model.dbo_WorkPohne;
                    flax = model.dbo_Flax;
                    workPlace = model.dbo_WorkPlace;
                    beiAnHao = model.dbo_BeiAnHao;
                }
            }
            catch
            { }
        }
        #endregion

        #region 系统关闭
        public static void endSys()
        {
            cycms.BLL.Cycms bll = new cycms.BLL.Cycms();
            cycms.Model.Cycms model = new cycms.Model.Cycms();
            cycms.BLL.Article bllarticle = new cycms.BLL.Article();
            model = bll.GetModel(bll.GetMaxId() - 1);
            if (model != null)
            {
                model.dbo_IsRunning = IsRunning;
                model.dbo_IsStatic = IsStatic;
                model.dbo_WebAddress = webAddress;
                model.dbo_WebName = webName;
                model.dbo_VisitedTimes =Convert.ToInt32(VisitedTimes);
                bll.Update(model);
            }
            NameValueCollection nv = ArticleVisitedCollections;
            bllarticle.updateClicks(nv);
            nv.Clear();
        }
        #endregion

        #region 填充路径
        public static void fillPath(string strDir, out string pagePath, out string destPath)
        {
            pagePath = "http://" + HttpContext.Current.Request.Url.Host + ":" + HttpContext.Current.Request.ServerVariables.Get("SERVER_PORT");
            pagePath += sys.AppPath;

            destPath = HttpContext.Current.Server.MapPath("~/");

            if (strDir != "")
            {
                destPath += strDir + "\\";
                pagePath += strDir + "/";
            }
        }

        #endregion

        #region 写入文件内容
        public static void writeFileContent(string filePath, string content)
        {
            try
            {
                FileInfo fi = new FileInfo(filePath);
                using (FileStream fs = fi.Create())
                {
                    StreamWriter sw = new StreamWriter(fs, System.Text.Encoding.UTF8);
                    sw.Write(content);
                    sw.Flush();
                    sw.Close();
                    sw.Dispose();
                }
            }
            catch
            {
                Page p = (Page)HttpContext.Current.Handler;
                p.ClientScript.RegisterStartupScript(p.GetType(), "", "alert('内容写入发生错误，请确认文件是否存在或者您是否有权限修改该文件！');", true);
            }
        }

        #endregion

        #region 抓取页面内容并保存
        public static void DownLoadPage(string pagePath, string destPath)
        {
            try
            {
                System.Net.WebClient myWebClient = new System.Net.WebClient();
                myWebClient.Encoding = System.Text.Encoding.UTF8;
                string content = myWebClient.DownloadString(pagePath);
                sys.writeFileContent(destPath, content);
            }
            catch (Exception err)
            {
                HttpContext.Current.Response.Write(err.Message);
            }
        }
        #endregion

        #region 获取专题的目录
        public static string getSpcDir(int spcId)
        {
            cycms.BLL.Speciality bll = new cycms.BLL.Speciality();
            cycms.Model.Speciality model = new cycms.Model.Speciality();
            string dir = string.Empty;
            model = bll.GetModel(spcId);
            if (model != null)
            {
                dir = model.dbo_HtmlDir.ToString();
            }
            return dir;
        }
        #endregion

        #region 静态生成专题首页
        public static void ToStaticDefault(string strDir)
        {
            string pagePath, destPath;
            fillPath(strDir, out pagePath, out destPath);
            string m_pagePath = pagePath + "default.aspx";
            string m_destPath = destPath + "default.html";
            sys.DownLoadPage(m_pagePath, m_destPath);
        }

        /// <summary>
        /// 重载，需要从数据库中查询出对应专题ID的目录
        /// </summary>
        /// <param name="strDir"></param>
        public static void ToStaticDefault(int spcId)
        {
            string strDir = getSpcDir(spcId);
            string pagePath, destPath;
            fillPath(strDir, out pagePath, out destPath);
            string m_pagePath = pagePath + "default.aspx";
            string m_destPath = destPath + "default.html";
            sys.DownLoadPage(m_pagePath, m_destPath);
        }

        #endregion

        #region 删除某个专题的首页
        public static void deleteDefaultPage(int spcId)
        {
            string strDir = "";
            if (spcId != 0)
            {
                strDir = getSpcDir(spcId);
            }
            string pagePath, destPath;
            fillPath(strDir, out pagePath, out destPath);
            destPath += "default.html";


            FileInfo fi = new FileInfo(destPath);
            if (fi.Exists)
            {
                fi.Delete();
            }
        }
        #endregion

        #region 删除文章后重新生成
        public static void deleteArticleFile(int articleid, string strDir, DateTime articlePtime)
        {
            string pagePath, destPath;
            sys.fillPath(strDir, out pagePath, out destPath);
            destPath += "content\\" + articlePtime.ToString("yyyyMM") + "\\" + articleid.ToString() + ".html";
            FileInfo fi = new FileInfo(destPath);
            if (fi.Exists)
            {
                fi.Delete();
            }

        }
        #endregion

        #region 移动文章内容文件
        public static void MoveArticleFile(string sourceDir, string destDir, DateTime ptime, string articleId)
        {
            DirectoryInfo di = new DirectoryInfo(destDir + "\\" + ptime.ToString("yyyyMM"));
            if (!di.Exists)
            {
                di.Create();
            }
            FileInfo sourceFile = new FileInfo(sourceDir + ptime.ToString("yyyyMM") + "\\" + articleId + ".html");
            FileInfo destFile = new FileInfo(destDir + ptime.ToString("yyyyMM") + "\\" + articleId + ".html");
            if (sourceFile.Exists && destFile.Exists)
            {
                destFile.Delete();
            }
            if (sourceFile.Exists)
            {
                sourceFile.MoveTo(destDir + "\\" + ptime.ToString("yyyyMM") + "\\" + articleId + ".html");
            }

        }
        #endregion

        #region 静态生成列表页
        public static void ToStaticList(string strDir, int typeid, int page, int count)
        {
            string pagePath, destPath;
            fillPath(strDir, out pagePath, out destPath);
            string dirPath = destPath + "list\\";
            DirectoryInfo di = new DirectoryInfo(dirPath);
            if (!di.Exists)
            {
                di.Create();
            }

            string m_pagePath = pagePath + "showList.aspx?typeid=" + typeid.ToString() + "&page=" + page.ToString() + "&staticPages=" + count.ToString(); //如果是静态生成则加一个需要生成多要页的参数
            string m_destPath = dirPath + "list_" + typeid.ToString() + "_" + page.ToString() + ".html";
            sys.DownLoadPage(m_pagePath, m_destPath);
        }
        #endregion

        #region 静态生成内容页
        public static void ToStaticContent(string strDir, int strArticleId, DateTime articlePtime)
        {
            string pagePath, destPath;
            fillPath(strDir, out pagePath, out destPath);

            string dirPath = destPath + "content\\" + articlePtime.ToString("yyyyMM") + "\\";
            DirectoryInfo di = new DirectoryInfo(dirPath);
            if (!di.Exists)
            {
                di.Create();
            }
            string m_pagePath = pagePath + "ShowArticle.aspx?id=" + strArticleId.ToString();
            string m_destPath = dirPath + strArticleId.ToString() + ".html";
            // HttpContext.Current.Response.Write(m_pagePath + "<br />");
            sys.DownLoadPage(m_pagePath, m_destPath);
        }
        #endregion

        #region 判断文件的后缀
        public static string GetEnd(string fileName)
        {
            int i = fileName.LastIndexOf('.');
            if (i < fileName.Length - 1)
            {
                return fileName.Substring(i + 1);
            }
            else
            {
                return fileName;
            }

        }
        #endregion

        #region 某篇文章改动以后要重新静态生成的首页和专题页和列表页
        public static void ToStaticListWithArticleEdit(int articleTypeid, string strDir)
        {
            cycms.BLL.ArticleType bllarticletype = new cycms.BLL.ArticleType();
            sys.ToStaticDefault("");
            if (strDir != "")
            {
                sys.ToStaticDefault(strDir);
            }
            int[] parentTypes = bllarticletype.getAllParentNodesid(articleTypeid);
            for (int i = 0; i < parentTypes.Length; i++)
            {
                sys.ToStaticList(strDir, parentTypes[i], 1, 1); //列表页只重新生成相关类别的第一页
            }
        }
        #endregion

        #region 动态模式下生成首页
        public static void ToStaticPageWithActive(int spcId)
        {
            string pagePath, destPath;
            fillPath("", out pagePath, out destPath);
            string m_destPath = destPath + "default.html";

            FileInfo fi = new FileInfo(m_destPath);
            if (fi.Exists)
            {
                ToStaticDefault("");
            }
            if (spcId != 0)
            {
                string strDir = sys.getSpcDir(spcId);
                fillPath(strDir, out pagePath, out destPath);
                m_destPath = destPath + "default.html";
                FileInfo fi2 = new FileInfo(m_destPath);
                if (fi2.Exists)
                {
                    ToStaticDefault(strDir);
                }
            }
        }
        #endregion

        #region 根据专题id获取首页最近一次生成时间
        public static DateTime getLastDefaultEdit(int spcId)
        {
            string strDir = "";
            if (spcId != 0)
            {
                strDir = getSpcDir(spcId);
            }
            string pagePath, destPath;
            fillPath(strDir, out pagePath, out destPath);
            destPath += "default.html";
            return getFileLastEditTime(destPath);
        }
        #endregion

        #region 判断当前静态列表页生成是否超过最多的页数
        public static bool IsLastListPages
        {
            get
            {
                if (HttpContext.Current.Application["IsOverPages"] != null)
                {
                    return Convert.ToBoolean(HttpContext.Current.Application["IsOverPages"]);
                }
                else
                {
                    return false;
                }
            }
            set
            {
                HttpContext.Current.Application["IsOverPages"] = value;
            }
        }

        #endregion

        #region 获取文件最近一次修改时间
        public static DateTime getFileLastEditTime(string filePath)
        {
            FileInfo fi = new FileInfo(filePath);
            if (fi.Exists)
            {
                return fi.LastWriteTime;
            }
            else
            {
                return new DateTime(1, 1, 1, 0, 0, 0, 0);
            }
        }
        #endregion

        #region 读取文件内容
        public static string readFileContent(string filePath)
        {
            string fileContent = string.Empty;
            FileInfo fi = new FileInfo(filePath);
            if (fi.Exists)
            {
                using (FileStream fs = fi.OpenRead())
                {
                    StreamReader sr = new StreamReader(fs, System.Text.Encoding.UTF8);
                    fileContent = sr.ReadToEnd();
                    sr.Close();
                    sr.Dispose();
                    fs.Close();
                }
            }
            return fileContent;
        }
        #endregion

        #region 向浏览器写入脚本
        public static string alertAndRedirect(string message, string url)
        {
            return "<script type='text/javascript'>alert('" + message + "');window.top.location.href='" + url + "';\n</script>";
        }

        public static string TopRedirect(string url)
        {
            return "<script type='text/javascript'>;window.top.location.href='" + url + "';\n</script>";
        }

        public static void alert(string message)
        {
            Page p = System.Web.HttpContext.Current.Handler as Page;
            if (p != null)
            {
                p.ClientScript.RegisterStartupScript(p.GetType(), "", "alert('" + message + "');\n", true);
            }
        }

        public static void regisgerScirpt(string script)
        {
            Page p = System.Web.HttpContext.Current.Handler as Page;
            if (p != null)
            {
                p.ClientScript.RegisterStartupScript(p.GetType(), "", script, true);
            }
        }

        public static void regisgerScirpt(string script, string key)
        {
            Page p = System.Web.HttpContext.Current.Handler as Page;
            if (p != null)
            {
                p.ClientScript.RegisterStartupScript(p.GetType(), key, script, true);
            }
        }

        #endregion

        #region 文章访问次数的集合
        public static NameValueCollection ArticleVisitedCollections
        {
            get
            {
                return HttpContext.Current.Application["ArticleVisitedCollections"] as NameValueCollection;
            }
            set
            {
                HttpContext.Current.Application["ArticleVisitedCollections"] = value;

            }
        }
        #endregion

        #region 获取当前被请求的页面的名称
        public static string RequestFileName()
        {
            string vPath = HttpContext.Current.Request.Path;
            string fileName = vPath.Substring(vPath.LastIndexOf("/") + 1);
            fileName = fileName.Split('.')[0];
            return fileName;

        }
        #endregion

        #region 显示App_Data的XML内容
        public static string showXML(string nodeid, string type, string pathxml)
        {
            string resulthtml = "";
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(pathxml);
            XmlNode nodelist = xmldoc.SelectSingleNode("/Root/node[@id='" + nodeid + "']");
            if (type == "imglink")
            {
                foreach (XmlNode node in nodelist.ChildNodes)
                {
                    resulthtml += "<a href=\"" + node.Attributes["href"].Value + "\" target=\"_blank\"><img width=\"" + node.ParentNode.Attributes["bimgwidth"].Value + "\" height=\"" + node.ParentNode.Attributes["bimghigh"].Value + "\" src=\"" + sys.AppPath + node.Attributes["src"].Value + "\" alt=\"" + node.Attributes["alt"].Value + "\" /></a>";
                }
            }
            else if (type == "txtlink")
            {
                foreach (XmlNode node in nodelist.ChildNodes)
                {
                    resulthtml += "<a href=\"" + node.Attributes["href"].Value + "\" title=\"" + node.Attributes["alt"].Value + "\" target=\"_blank\">" + node.Attributes["alt"].Value + "</a>";
                }
            }
            else if (type == "imgandtxtlink")
            {
                resulthtml+="<ul class=\"imgandname\">";
                foreach (XmlNode node in nodelist.ChildNodes)
                {
                    resulthtml += "<li><a class=\"linkimage\" href=\"" + node.Attributes["href"].Value + "\" target=\"_blank\"><img width=\"" + node.ParentNode.Attributes["bimgwidth"].Value + "\" height=\"" + node.ParentNode.Attributes["bimghigh"].Value + "\"  src=\"" + sys.AppPath + node.Attributes["src"].Value + "\" alt=\"" + node.Attributes["alt"].Value + "\" title=\"" + node.Attributes["alt"].Value + "\"/></a><a class=\"linkname\" href=\"" + node.Attributes["href"].Value + "\" title=\"" + node.Attributes["alt"].Value + "\" target=\"_blank\">" + node.Attributes["alt"].Value + "</a></li>";
                }
                resulthtml += "</ul>";
            }
            else if (type == "simgandtxtlinkandbimg")
            {
                resulthtml += "<div class=\"imgandrun\"><ul id=\"mycarousel\" class=\"jcarousel jcarousel-skin-tango\">";
                int i = 1;
                foreach (XmlNode node in nodelist.ChildNodes)
                {
                    resulthtml += "<li><a id=\"a_" + node.Attributes["id"].Value + "\" target=\"_blank\" onmouseover=\"show_pdinfo('" + node.Attributes["id"].Value + "',this)\" class=\"" + (i == 1 ? "select" : "") + "\" href=\"" + node.Attributes["href"].Value + "\"><img src=\"" + sys.AppPath + node.Attributes["smallsrc"].Value + "\" width=\"" + node.ParentNode.Attributes["simgwidth"].Value + "\" height=\"" + node.ParentNode.Attributes["simghigh"].Value + "\" title=\"" + node.Attributes["alt"].Value + "\" alt=\"" + node.Attributes["alt"].Value + "\"/></a></li>";
                    i = i + 1;
                }
                resulthtml += "</ul></div>";
                if (nodelist.ChildNodes.Count > 0)
                {
                    XmlNode node=nodelist.ChildNodes[0];
                    resulthtml += "<div id=\"txtandrun\" nowid=\"" + node.Attributes["id"].Value + "\"><h1><a target=\"_blank\" title=\"" + node.Attributes["alt"].Value + "\" href=\"" + node.Attributes["href"].Value + "\">" + node.Attributes["alt"].Value + "</a></h1><p>" + node.Attributes["content"].Value + "</p></div>";
                }
                resulthtml += "<div class=\"hidden\">";
                foreach (XmlNode node in nodelist.ChildNodes)
                {
                    resulthtml += "<div id=\"pd_" + node.Attributes["id"].Value + "\" class=\"product_info\" goodid=\"" + node.Attributes["id"].Value + "\"><h1><a target=\"_blank\" title=\"" + node.Attributes["alt"].Value + "\" href=\"" + node.Attributes["href"].Value + "\">" + node.Attributes["alt"].Value + "</a></h1><p>" + node.Attributes["content"].Value + "</p></div>";
                }
                resulthtml += "</div>";
                if (nodelist.ChildNodes.Count > 0)
                {
                    XmlNode node=nodelist.ChildNodes[0];
                    resulthtml += "<div id=\"bigimg\"><a target=\"_blank\" title=\"" + node.Attributes["alt"].Value + "\" href=\"" + node.Attributes["href"].Value + "\"><img src=\"" + sys.AppPath + node.Attributes["src"].Value + "\" width=\"" + node.ParentNode.Attributes["bimgwidth"].Value + "\" height=\"" + node.ParentNode.Attributes["bimghigh"].Value + "\" title=\"" + node.Attributes["alt"].Value + "\" alt=\"" + node.Attributes["alt"].Value + "\"/></a></div>";
                }
                resulthtml += "<div class=\"hidden\">";
                foreach (XmlNode node in nodelist.ChildNodes)
                {
                    resulthtml += "<div id=\"im_" + node.Attributes["id"].Value + "\"><a target=\"_blank\" title=\"" + node.Attributes["alt"].Value + "\" href=\"" + node.Attributes["href"].Value + "\"><img src=\"" + sys.AppPath + node.Attributes["src"].Value + "\" width=\"" + node.ParentNode.Attributes["bimgwidth"].Value + "\" height=\"" + node.ParentNode.Attributes["bimghigh"].Value + "\" title=\"" + node.Attributes["alt"].Value + "\" alt=\"" + node.Attributes["alt"].Value + "\"/></a></div>";
                }
                resulthtml += "</div>";
            }
            return resulthtml;
        }
        #endregion

        #region 格式化字符串,取字符串前 strLength 位，其他的用...代替.计算字符串长度。汉字两个字节，字母一个字节FormatString(string str,int len)
        /// <summary>
        /// 格式化字符串,取字符串前 strLength 位，其他的用...代替.计算字符串长度。汉字两个字节，字母一个字节
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="strLength">字符串长度</param>
        /// <returns></returns>
        public static string FormatStr(string str, int len)
        {
            ASCIIEncoding ascii = new ASCIIEncoding();
            int tempLen = 0;
            string tempString = "";
            byte[] s = ascii.GetBytes(str);
            for (int i = 0; i < s.Length; i++)
            {
                if ((int)s[i] == 63)
                {
                    tempLen += 2;
                }
                else
                {
                    tempLen += 1;
                }
                try
                {
                    tempString += str.Substring(i, 1);
                }
                catch
                {
                    break;
                }
                if (tempLen > len) break;

            }

            //如果截过则加上半个省略号 
            byte[] mybyte = System.Text.Encoding.Default.GetBytes(str);
            if (mybyte.Length > len)
                tempString += "...";
            tempString = tempString.Replace(" ", "&nbsp;&nbsp;");
            tempString = tempString.Replace("<", "&lt;");
            tempString = tempString.Replace(">", "&gt;");
            tempString = tempString.Replace('\n'.ToString(), "<br>");
            return tempString;
        }
        #endregion

        #region 获取文章列表，不分页调用
        public static string getArticleList(int recordNum, int titleLength, string strTypeids, bool IsShowTime, string articleDirPath)
        {
            cycms.BLL.Article bll = new cycms.BLL.Article();
            try
            {
                string[] str = strTypeids.Split(',');
                int[] typeids = new int[str.Length];
                for (int i = 0; i < str.Length; i++)
                {
                    typeids[i] = Convert.ToInt32(str[i]);
                }
                StringBuilder sb = new StringBuilder();
                int rowcount;
                DataTable dt = bll.getPagerArticle(1, recordNum, out rowcount, typeids, "");
                sb.Append("<ul id=\"newgoodinf\">\n");
                if (dt.Rows.Count > 0)
                {
                    //NameValueCollection nv = getTypeSpcDir();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        string articleLink = articleDirPath;

                        if (sys.IsStatic) //静态生成的时候显示的文章列表连接
                        {
                            articleLink += "content/" + Convert.ToDateTime(dt.Rows[i]["dbo_Ptime"]).ToString("yyyyMM") + "/" + dt.Rows[i]["id"].ToString() + ".html";
                        }
                        else
                        { //非静态生成的时候文章列表链接

                            articleLink += "showArticle.aspx?id=" + dt.Rows[i]["id"].ToString();
                            //articleLink += "content/" + dt.Rows[i]["id"].ToString() + ".aspx";
                        }

                        string strTitle = dt.Rows[i]["dbo_title"].ToString();
                        strTitle = FormatStr(strTitle, titleLength);
                        sb.Append("<li>");
                        if (IsShowTime)
                        {
                            sb.Append("<p class=\"newtime\">" + ((DateTime)dt.Rows[i]["dbo_ptime"]).ToString("yyyy-MM-dd") + "</p>");
                        }
                        //sb.Append("<a href='" + articleLink + "' title='" + dt.Rows[i]["title"].ToString() + "' target='_blank'>" + strTitle + "</a></li>\n");
                        sb.Append("<p class=\"newcontent\"><a href='" + articleLink + "' title='" + dt.Rows[i]["dbo_title"].ToString() + "' target='_blank'>" + strTitle + "</a></p>");
                        if (dt.Rows[i]["dbo_isLock"] != System.DBNull.Value && dt.Rows[i]["dbo_isLock"].ToString() == "True")
                        {
                            sb.Append("<img class='lockPic' src='" + sys.AppPath + "images/lock.gif'>");
                        }
                        sb.Append("</li>");
                    }
                    sb.Append("</ul>\n");
                }
                else
                {
                    sb.Append("暂无内容…\n");
                }

                return sb.ToString();
            }
            catch (Exception)
            {
                return "参数错误！";
            }
        }
        #endregion

        #region 显示文章内容
        public static string ShowArticle(string id, out string pageTitle, out string author, out string ptime, out string source,bool showcount=true)
        {
            cycms.BLL.Article bll = new cycms.BLL.Article();
            if (!PageValidate.IsNumber(id))
            {
                pageTitle = "参数错误！";
                author = "";
                ptime = "";
                source = "";
                return "参数错误！";
            }
            pageTitle = string.Empty;
            StringBuilder sb = new StringBuilder();
            cycms.Model.Article sdr = bll.GetModel(Convert.ToInt32(id)); 
            sb.Append("<div id='articleContainer'>");
            if (sdr!=null)
            {
                if (sdr.dbo_IsLock == true)
                {
                    if (Teacher.Id == null)
                    {
                        pageTitle = "对不起，你没有权限阅读本内容";
                        author = "";
                        ptime = "";
                        source = "";
                        return "<div class='nopremission'>对不起，你没有权限阅读本内容</div>";
                    }
                }
                pageTitle = sdr.dbo_Title;
                sb.Append("<div class='title'>" + sdr.dbo_Title + "</div>\n");
                sb.Append("<div class='content'>" + sdr.dbo_Content+ "</div>\n");

                string strfujian = sdr.dbo_Fujian;
                if (strfujian != "")
                {
                    string appPath = sys.AppPath;
                    string[] fujians = strfujian.Split('/');
                    sb.Append("<div class='fujian'>\n");
                    sb.Append("本文附件：");
                    sb.Append("<ul id='fujian'>\n");
                    for (int i = 0; i < fujians.Length; i++)
                    {
                        string filePath = appPath + "uploads/" + fujians[i];
                        sb.Append("<li><a rel='external' href='" + filePath + "'>" + fujians[i] + "</a></li>\n");
                        //sb.Append("<div class='fujian'>本文附件：<a href='" + appPath + "uploads/" + strfujian + "'>" + strfujian + "</a></div>");
                    }
                    sb.Append("</ul>\n");
                    sb.Append("</div>\n");
                }

                sb.Append("<div style='width:100%;'><div class='otherInfo'>");
                sb.Append("<ul>");
                sb.Append("<li>发布：" +sdr.dbo_Author + "</li>\n");
                sb.Append("<li>文章来源：" +sdr.dbo_Source+ "</li>\n");
                if (showcount == true)
                {
                    sb.Append("<li>点击次数：<script type='text/javascript' src='" + sys.AppPath + "scripts.aspx?op=getArticleClick&articleId=" + sdr.ID + "'></script></li>\n");
                }
                sb.Append("<li>发布时间：" + Convert.ToDateTime(sdr.dbo_Ptime).ToString("yyyy年MM月dd日") + "</li>\n");
                sb.Append("</ul>");
                sb.Append("</div><div class='clear'></div></div>");
            }
            author = sdr.dbo_Author;
            ptime = Convert.ToDateTime(sdr.dbo_Ptime).ToString("yyyy年MM月dd日");
            source = sdr.dbo_Source;
            sb.Append("</div>\n");
            return sb.ToString();
        }
        #endregion

        #region 获取列表页路径
        public static string nodeLink(int nodeId)
        {
            string Path = sys.AppPath;
            if (sys.IsStatic)
            {
                return Path + "list/list_" + nodeId.ToString() + "_1" + ".html";
            }
            else
            {
                return Path + "showList.aspx?typeid=" + nodeId.ToString();
            }
        }
        public static string nodeLink(int nodeId, string SpcDir)
        {
            string Path = sys.AppPath;
            if (sys.IsStatic)
            {
                return Path + SpcDir + "list/list_" + nodeId.ToString() + "_1" + ".html";
            }
            else
            {
                return Path + SpcDir + "showList.aspx?typeid=" + nodeId.ToString();
            }
        }

        #endregion

        #region 文章列表页显示DataTable的内容
        public static string ShowDataTable(DataTable dt, int titleLength, bool IsShowTime, string strDir)
        {
            StringBuilder sb = new StringBuilder();


            if (dt.Rows.Count > 0)
            {
                sb.Append("<ul>\n");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string articleLink = string.Empty;

                    if (sys.IsStatic) //静态生成的时候显示的文章列表链接
                    {
                        articleLink += strDir + "content/" + Convert.ToDateTime(dt.Rows[i]["dbo_ptime"]).ToString("yyyyMM") + "/" + dt.Rows[i]["id"].ToString() + ".html";
                    }
                    else
                    { //非静态生成的时候文章列表链接

                        articleLink += "showArticle.aspx?id=" + dt.Rows[i]["id"].ToString();
                    }
                    string title = dt.Rows[i]["dbo_title"].ToString();
                    title = FormatStr(title, titleLength);

                    sb.Append("<li>");
                    sb.Append("<a href='" + articleLink + "' title='" + dt.Rows[i]["dbo_title"].ToString() + "' target='_blank'>" + title + "</a>");
                    if (dt.Rows[i]["dbo_isLock"] != System.DBNull.Value && dt.Rows[i]["dbo_isLock"].ToString() == "True")
                    {
                        sb.Append("<img class='lockPic' src='" + sys.AppPath + "images/lock.gif'>");
                    }
                    sb.Append("</li>\n");

                    if (IsShowTime)
                    {
                        sb.Append("<li class='showTimeStyle'>" + Convert.ToDateTime(dt.Rows[i]["dbo_ptime"]).ToString("[yyyy-MM-dd]") + "</li>");
                    }
                }
                sb.Append("</ul>\n");
            }
            else
            {
                sb.Append("暂无内容…\n");
            }


            return sb.ToString();
        }

        #endregion

        #region 获取文章分页标签
        public static string ShowPager(int rowcount, int pageSize, int pageIndex, string linkWords)
        {
            //如果当前为静态生成状态，linkwords传递的是类型id

            StringBuilder sb = new StringBuilder();

            if (rowcount != 0)
            {
                int pagecount = (rowcount + pageSize - 1) / pageSize;
                pageIndex = pageIndex == 0 ? 1 : pageIndex;
                int start;
                start = pageIndex > 5 ? pageIndex - 5 : 1;
                start = start > pagecount - 9 ? pagecount - 9 : start;
                start = start > 0 ? start : 1;

                if (PageValidate.IsNumber(linkWords))
                {
                    if (sys.IsStatic && HttpContext.Current.Request.QueryString["staticPages"] != null)
                    {
                        sb.Append("<div id='articleNav' class='articleNav'><a class='pageCell' href='list_" + linkWords + "_1.html'>&laquo;</a>");

                    }
                    else
                    {
                        sb.Append("<div id='articleNav' class='articleNav'><a class='pageCell' href='?page=1&typeid=" + linkWords + "'>&laquo;</a>");
                    }
                }
                else
                {
                    sb.Append("<div id='articleNav' class='articleNav'><a class='pageCell' href='?page=1&" + linkWords + "'>&laquo;</a>");
                }
                for (int i = start; i < start + 10 && i <= pagecount; i++)
                {
                    if (i == pageIndex)
                    {
                        sb.Append("<span class='currentPage'>" + i.ToString() + "</span>");
                    }
                    else
                    {
                        string links = "?page=" + i.ToString() + "&typeid=" + linkWords;
                        if (PageValidate.IsNumber(linkWords))
                        {
                            if (sys.IsStatic && HttpContext.Current.Request.QueryString["staticPages"] != null)
                            {
                                int getPages = Convert.ToInt32(HttpContext.Current.Request.QueryString["staticPages"]); //静态生成方式
                                if (i <= getPages)
                                {
                                    links = "list_" + linkWords + "_" + i.ToString() + ".html";
                                }
                                else
                                {
                                    links = "../" + links;
                                }

                            }
                        }
                        else
                        {
                            links = "?page=" + i.ToString() + "&" + linkWords;
                        }
                        sb.Append("<a class='pageCell' href='" + links + "'>" + i.ToString() + "</a>");
                    }
                }

                if (PageValidate.IsNumber(linkWords))
                {
                    if (sys.IsStatic && HttpContext.Current.Request.QueryString["staticPages"] != null)
                    {
                        sb.Append("<a class='pageCell' href='?page=" + pagecount.ToString() + "&typeid=" + linkWords + "'>&raquo;</a></div>");
                    }
                    else
                    {
                        sb.Append("<a class='pageCell' href='?page=" + pagecount.ToString() + "&typeid=" + linkWords + "'>&raquo;</a></div>");
                    }
                }
                else
                {
                    sb.Append("<a class='pageCell' href='?page=" + pagecount.ToString() + "&" + linkWords + "'>&raquo;</a></div>");
                }

                //if (sys.IsStatic)
                //{
                //    linkWords = "typeid=" + linkWords;
                //}
                //sb.Append("<a class='pageCell' href='?page=" + pagecount.ToString() + " &" + linkWords + "'>&raquo;</a></div>");
            }
            return sb.ToString();
        }
        #endregion

        #region 重载，获取文章列表，列表页调用，如果不是根节点则分类显示子节点内容
        /// <summary>
        /// 重载，获取文章列表，列表页调用，如果不是根节点则分类显示子节点内容
        /// </summary>
        /// <param name="strpageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="listCount">如果不是根节点时列出的行数</param>
        /// <param name="titleLength"></param>
        /// <param name="typeid"></param>
        /// <param name="fontimage"></param>
        /// <param name="IsShowTime"></param>
        /// <returns></returns>
        public static string getArticlePager(string strpageIndex, int pageSize, int titleLength, string typeid, bool IsShowTime, int listCount)
        {
            cycms.BLL.ArticleType bllarticletype = new cycms.BLL.ArticleType();
            cycms.BLL.Article bllarticle = new cycms.BLL.Article();
            //如果要分开像以前那样显示的话如果当前节点还有子节点则不用pageIndex，只分类显示出该节点下的所有分类及分类中的一部分文章，不需要分页
            //执行完了以后把IsLastListPages 设置为true
            try
            {
                StringBuilder sb = new StringBuilder();

                DataTable dtFather = bllarticletype.getChildNodes(Convert.ToInt32(typeid));
                if (dtFather.Rows.Count == 0)
                { //显示根节点的内容
                    sb.Append(getArticlePager(strpageIndex, pageSize, titleLength, typeid, IsShowTime));
                }
                else
                {
                    int[] typeids = new int[1];
                    int rowcount;
                    for (int i = 0; i < dtFather.Rows.Count; i++)
                    {
                        typeids[0] = Convert.ToInt32(dtFather.Rows[i]["id"]);
                        DataTable dt = bllarticle.getPagerArticle(1, listCount, out rowcount, typeids, "");
                        string theTypeName = string.Empty;
                        object obj = bllarticletype.GetModel(typeids[0]).dbo_TypeName; 
                        if (obj != null)
                        {
                            theTypeName = obj.ToString();
                        }
                        sb.Append("<div class='ArticleListContent'>");

                        sb.Append("<div class=\"title2\">\n");
                        sb.Append("<div class=\"title2_1\" >" + theTypeName + "</div>\n");
                        sb.Append("<div class=\"title2_2\" ><a href='" + nodeLink(typeids[0]) + "'>更多&raquo;</a></div>\n");
                        sb.Append("</div>\n");
                        sb.Append(ShowDataTable(dt, titleLength, IsShowTime, "../"));
                        sb.Append("</div>\n");
                    }
                    IsLastListPages = true;
                }
                return sb.ToString();
            }
            catch (Exception)
            {
                return "参数错误！";
            }

        }
        #endregion

        #region 获取文章列表，列表页调用
        public static string getArticlePager(string strpageIndex, int pageSize, int titleLength, string typeid, bool IsShowTime)
        {
            cycms.BLL.ArticleType bllarticletype = new cycms.BLL.ArticleType();
            cycms.BLL.Article bllarticle = new cycms.BLL.Article();
            try
            {
                //如果要分开像以前那样显示的话如果当前节点还有子节点则不用pageIndex，只分类显示出该节点下的所有分类及分类中的一部分文章，不需要分页
                //执行完了以后把IsLastListPages 设置为true

                int pageIndex = Convert.ToInt32(strpageIndex);
                StringBuilder sb = new StringBuilder();

                int rowcount;
                int[] typeids = new int[1];
                typeids[0] = Convert.ToInt32(typeid);
                DataTable dt = bllarticle.getPagerArticle(pageIndex, pageSize, out rowcount, typeids, "");
                string theTypeName = string.Empty;
                object obj = bllarticletype.GetModel(typeids[0]).dbo_TypeName; 
                if (obj != null)
                {
                    theTypeName = obj.ToString();
                }

                int totalPage = (rowcount + pageSize - 1) / pageSize;

                //如果当前访问的列表页面超过了最大的页面则把超过标识为true，为静态生时获得这个变量以判断是否需要继续静态生成
                if (pageIndex >= totalPage)
                {
                    IsLastListPages = true;
                }
                sb.Append("<div class=\"title2\">");
                sb.Append("<div class=\"title2_1\" >" + theTypeName + "</div>");
                sb.Append("<div class=\"title2_2\" ></div>");
                sb.Append("</div>");
                //sb.Append("<div class='ArticleListContent'>\n<div class='theTitle'><img src=\"" + sys.AppPath + "images/Main_Title_Bz.jpg\" alt=\"\"  /> " + theTypeName + "</div>\n");
                sb.Append(ShowDataTable(dt, titleLength, IsShowTime, "../"));
                //sb.Append("</div>\n");

                sb.Append(ShowPager(rowcount, pageSize, pageIndex, typeids[0].ToString()));
                return sb.ToString();
            }
            catch (Exception)
            {
                return "参数错误！";
            }
        }
        #endregion

        #region 获取当前页面上级虚拟路径
        public static string RequestPathName()
        {
            string vPath = HttpContext.Current.Request.Path;
            string[] filenames = vPath.Split('/');
            string fileName = filenames[filenames.Length - 2];
            return fileName;
        }
        #endregion

        #region 文章标题搜索
        public static string getArticleSearch(string strpageIndex, int pageSize, string keyword, int titleLength, int[] typeids, bool IsShowTime)
        {
            cycms.BLL.Article bllarticle = new cycms.BLL.Article();
            try
            {
                if (keyword == "")
                {
                    return "请输入查询内容";
                }
                keyword = keyword.Trim();
                if (keyword.IndexOf("'") != -1 || keyword.IndexOf("--") != -1)
                {
                    return "输入的字符非法";
                }
                int pageIndex = Convert.ToInt32(strpageIndex);
                StringBuilder sb = new StringBuilder();
                int rowcount;
                //int[] typeids = new int[1];
                //typeids[0] = typeid;  
                DataTable dt = bllarticle.getPagerArticle(pageIndex, pageSize, out rowcount, typeids, " dbo_title like '%" + keyword + "%'");

                sb.Append("<div class=\"title2\">");
                sb.Append("<div class=\"title2_1\" > 内容搜索&nbsp;&nbsp;关键字：\"" + keyword + "\"&nbsp;&nbsp; 共找到相关文章" + rowcount.ToString() + "篇" + "</div>");
                sb.Append("<div class=\"title2_2\" ></div>");
                sb.Append("</div>");
                //sb.Append("<div style='border-bottom:solid 1px #cccccc;'>\n<div class='theTitle' style='width:727px;'><img src=\"" + sys.AppPath  + "images/Main_Title_Bz.jpg\" alt=\"\"  /> 文章搜索&nbsp;&nbsp;关键字：\"" + keyword + "\"&nbsp;&nbsp; 共找到相关文章" + rowcount.ToString() + "篇</div>\n");
                //  sb.Append(ShowDataTable(dt,titleLength,IsShowTime,sys.AppPath=="/"?sys.AppPath:sys.AppPath + "/"));



                if (dt.Rows.Count > 0)
                {
                    sb.Append("<ul>\n");
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        string articleLink = string.Empty;

                        string strDir = string.Empty;
                        object obj = dt.Rows[i]["dbo_htmldir"];
                        if (obj != null && obj.ToString() != "")
                        {
                            strDir = obj.ToString() + "/";
                        }
                        if (sys.IsStatic) //静态生成的时候显示的文章列表链接
                        {
                            articleLink += strDir + "content/" + Convert.ToDateTime(dt.Rows[i]["dbo_ptime"]).ToString("yyyyMM") + "/" + dt.Rows[i]["id"].ToString() + ".html";
                        }
                        else
                        { //非静态生成的时候文章列表链接

                            articleLink += "showArticle.aspx?id=" + dt.Rows[i]["id"].ToString();
                        }
                        string title = dt.Rows[i]["dbo_title"].ToString();
                        title = FormatStr(title, titleLength);

                        //sb.Append("<li>");
                        //sb.Append("<a href='" + articleLink + "' title='" + dt.Rows[i]["title"].ToString() + "' target='_blank'>" + title + "</a>");

                        //sb.Append("</li>\n");

                        sb.Append("<li>");
                        sb.Append("<a href='" + articleLink + "' title='" + dt.Rows[i]["dbo_title"].ToString() + "' target='_blank'>" + title + "</a>");
                        if (dt.Rows[i]["dbo_isLock"] != System.DBNull.Value && dt.Rows[i]["dbo_isLock"].ToString() == "True")
                        {
                            sb.Append("<img class='lockPic' src='" + sys.AppPath + "images/lock.gif'>");
                        }
                        sb.Append("</li>\n");

                        if (IsShowTime)
                        {
                            sb.Append("<li class='showTimeStyle'>" + Convert.ToDateTime(dt.Rows[i]["dbo_ptime"]).ToString("yyyy-MM-dd") + "</li>");
                        }



                    }
                    sb.Append("</ul>\n");
                }
                else
                {
                    // sb.Append("没有搜索到关键字“"+keyword+"”的内容\n");
                }

                //sb.Append("</div>\n");
                sb.Append(ShowPager(rowcount, pageSize, pageIndex, "kw=" + HttpContext.Current.Server.UrlEncode(keyword)));
                return sb.ToString();
            }
            catch (Exception)
            {
                return "参数错误！";
            }
        }
        #endregion

        #region  去掉HTML标记函数
        /// <summary>
        /// 去除HTML标记
        /// </summary>
        /// <param name="NoHTML">包括HTML的源码 </param>
        /// <returns>已经去除后的文字</returns>
        public static string NoHTML(string Htmlstring)
        {
            //删除脚本
            Htmlstring = Regex.Replace(Htmlstring, @"<script[^>]*?>.*?</script>", "", RegexOptions.IgnoreCase);
            //删除HTML
            Htmlstring = Regex.Replace(Htmlstring, @"<(.[^>]*)>", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"([\r\n])[\s]+", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"-->", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"<!--.*", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(quot|#34);", "\"", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(amp|#38);", "&", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(lt|#60);", "<", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(gt|#62);", ">", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(nbsp|#160);", " ", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(iexcl|#161);", "\xa1", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(cent|#162);", "\xa2", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(pound|#163);", "\xa3", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(copy|#169);", "\xa9", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&#(\d+);", "", RegexOptions.IgnoreCase);
            Htmlstring.Replace("<", "");
            Htmlstring.Replace(">", "");
            Htmlstring.Replace("\r\n", "");
            Htmlstring = Regex.Replace(Htmlstring, @"&(ldquo);", " ", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(rdquo);", " ", RegexOptions.IgnoreCase);
            Htmlstring = HttpContext.Current.Server.HtmlEncode(Htmlstring).Trim();
            return Htmlstring;
        }
        #endregion

        #region 首页底部图文
        public static string ShowDefaultBottom()
        {
            cycms.BLL.FriendLink bll = new cycms.BLL.FriendLink();
            DataTable data = bll.GetList("1=1").Tables[0];
            string result = "";
            result += "<ul class=\"compaylist\">";
            for (int i=0;i<data.Rows.Count;i++)
            {
                if (i == 0)
                {
                    result += "<li class=\"select\"><a onclick=\"factory_select('" + data.Rows[i]["id"] + "',this)\">" + data.Rows[i]["dbo_FactoryProductName"] + "</a></li>";
                }
                else if (i == data.Rows.Count - 1)
                {
                    result += "<li class=\"lastli\"><a onclick=\"factory_select('" + data.Rows[i]["id"] + "',this)\">" + data.Rows[i]["dbo_FactoryProductName"] + "</a></li>";
                }
                else
                {
                    result += "<li class=\"\"><a onclick=\"factory_select('" + data.Rows[i]["id"] + "',this)\">" + data.Rows[i]["dbo_FactoryProductName"] + "</a></li>";
                }
            }
            result += "</ul><div class=\"compaydetail\">";
            for (int i = 0; i < data.Rows.Count; i++)
            {
                if (i == 0)
                {
                    result += "<div id=\"f_" + data.Rows[i]["id"] + "\" class=\"factoryunion select\">";
                }
                else
                {
                    result += "<div id=\"f_" + data.Rows[i]["id"] + "\" class=\"factoryunion\">";
                }
                result += "<div class=\"factleft\"><h2><a target=\"_blank\" href=\"" + data.Rows[i]["dbo_FactoryLink"] + "\">" + data.Rows[i]["dbo_FactoryProductName"] + "</a></h2><a target=\"_blank\" href=\"" + data.Rows[i]["dbo_FactoryLink"] + "\"><img alt=\"" + data.Rows[i]["dbo_FactoryProductName"] + "\" width=\"175\" height=\"62\" title=\"" + data.Rows[i]["dbo_FactoryProductName"] + "\" src=\"" + data.Rows[i]["dbo_FactoryLogoSrc"] + "\"/></a></div>";
                result += "<div class=\"factmiddle\">" + data.Rows[i]["dbo_ProductInfo"] + "</div>";
                result += "<div class=\"factright\"><a target=\"_blank\" href=\"" + data.Rows[i]["dbo_ProductImgLink"] + "\"><img width=\"205\" height=\"155\" title=\"" + data.Rows[i]["dbo_ProductImgName"] + "\" alt=\"" + data.Rows[i]["dbo_ProductImgName"] + "\" src=\"" + data.Rows[i]["dbo_ProductImgSrc"] + "\"/></a></div>";
                result += "</div>";
            }
            result += "</div>";
            return result;
        }
        #endregion

        #region 这是是获取操作系统名称的代码：
        /// <summary>
        /// 根据 User Agent 获取操作系统名称
        /// </summary>
        public static string GetOSNameByUserAgent(string userAgent)
        {
            string osVersion = "未知";
            if (userAgent.Contains("NT 6.2"))
            {
                osVersion = "Windows 8";
            }
            if (userAgent.Contains("NT 6.1"))
            {
                osVersion = "Windows 7";
            }
            if (userAgent.Contains("NT 6.0"))
            {
                osVersion = "Windows Vista/Server 2008";
            }
            else if (userAgent.Contains("NT 5.2"))
            {
                osVersion = "Windows Server 2003";
            }
            else if (userAgent.Contains("NT 5.1"))
            {
                osVersion = "Windows XP";
            }
            else if (userAgent.Contains("NT 5"))
            {
                osVersion = "Windows 2000";
            }
            else if (userAgent.Contains("NT 4"))
            {
                osVersion = "Windows NT4";
            }
            else if (userAgent.Contains("Me"))
            {
                osVersion = "Windows Me";
            }
            else if (userAgent.Contains("98"))
            {
                osVersion = "Windows 98";
            }
            else if (userAgent.Contains("95"))
            {
                osVersion = "Windows 95";
            }
            else if (userAgent.Contains("Mac"))
            {
                osVersion = "Mac";
            }
            else if (userAgent.Contains("Unix"))
            {
                osVersion = "UNIX";
            }
            else if (userAgent.Contains("Linux"))
            {
                osVersion = "Linux";
            }
            else if (userAgent.Contains("SunOS"))
            {
                osVersion = "SunOS";
            }
            return osVersion;
        }
        #endregion

    }
}
