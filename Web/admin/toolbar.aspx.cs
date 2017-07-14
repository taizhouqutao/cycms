using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Adapte;
using System.Text;
using System.Data;
using System.Xml;

namespace cycms.Web.admin
{
    public partial class toolbar : System.Web.UI.Page
    {
        BLL.Speciality bllspeciality = new BLL.Speciality();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (currentAdmin.Name == null)
            {
                Response.Write("您无权访问该页，错误原因：1.登陆超时；2.非法进入；3.权限不足。请登陆后访问<a href='login.aspx'  target='_parent'>登陆</a>");
                Response.End();
            }
            ShowToolbarContent();
        }

        private void ShowToolbarContent()
        {
            StringBuilder sb = new StringBuilder();
            DataTable dtSpc = new DataTable();
            string[,] channels = currentAdmin.Channels;
            dtSpc = bllspeciality.GetList("1=1 order by id asc").Tables[0];
            DataRow dr = dtSpc.NewRow();
            dr["id"] = "0";
            dr["dbo_name"] = "默认频道";
            dr["dbo_htmlDir"] = "";
            dtSpc.Rows.InsertAt(dr, 0);

            if (currentAdmin.strPower != "")
            {
                string fiters = string.Empty;
                if (currentAdmin.strPower != "super")
                {

                    string strChannel = string.Empty;
                    for (int i = 0; i < channels.GetLength(0); i++)
                    {
                        strChannel += (strChannel == string.Empty) ? "" : ",";
                        strChannel += channels[i, 0];
                    }
                    fiters = "id in(" + strChannel + ")";
                }

                XmlDocument xmldoc = new XmlDocument();
                xmldoc.Load(MapPath("../App_Data/data.xml"));
                XmlNodeList nodelist = xmldoc.SelectNodes("/Root/node");
                sb.Append("<div class='divbig'>");
                sb.Append("<div class='divtop' onclick='javascript:showMenu(this);'>网页配置管理</div>\n");
                foreach (XmlNode node in nodelist)
                {
                    sb.Append("<div class='divitem'><a href='xmlconfig/xmllist.aspx?id=" + node.Attributes["id"].Value + "' target='main'>" + node.Attributes["name"].Value + "列表</a></div>\n");
                }
                sb.Append("<div class='divitem'><a href='FriendLink/FriendLinkList.aspx' target='main'>首页底部图文</a></div>");
                sb.Append("</div>\n");

                DataRow[] drs = dtSpc.Select(fiters);
                for (int i = 0; i < drs.Length; i++)
                {
                    string strSpc = "?spcId=" + drs[i]["id"].ToString();
                    sb.Append("<div class='divbig'>\n");
                    sb.Append("<div class='divtop' onclick='javascript:showMenu(this);'>" + drs[i]["dbo_name"].ToString() + "</div>\n");
                    sb.Append("<div class='divitem'><a  href='aspxnews/articleList.aspx" + strSpc + "' target='main'>内容列表</a></div>\n");
                    sb.Append("<div class='divitem'><a  href='aspxnews/articleAdd.aspx" + strSpc + "' target='main'>添加内容</a></div>\n");

                    if (currentAdmin.strPower == "super" || adminOpers.getChannelPower(drs[i]["id"].ToString(), channels) == "0")
                    {
                        sb.Append("<div class='divitem'><a  href='aspxnews/typeList.aspx" + strSpc + "' target='main'>类别列表</a></div>\n");
                        sb.Append("<div class='divitem'><a  href='aspxnews/typeAdd.aspx" + strSpc + "' target='main'>添加类别</a></div>\n");
                        sb.Append("<div class='divitem'><a  href='aspxnews/staticPage.aspx" + strSpc + "'  target='main'>静态生成</a></div>");
                        sb.Append("<div class='divitem'><a  href='aspxnews/templateEdit.aspx" + strSpc + "' target='main'>管理模板</a></div>");
                        sb.Append("<div class='divitem'><a  href='signalPage/signalPageList.aspx" + strSpc + "' target='main'>简单页面</a></div>");
                        sb.Append("<div class='divitem'><a  href='Themes/ThemesList.aspx" + strSpc + "' target='main'>相关图片</a></div>");
                    }
                    sb.Append("</div>\n");

                }
            }
            if (currentAdmin.strPower != "")
            {
                sb.Append("<div class='divbig'>");
                sb.Append("<div class='divtop' onclick='javascript:showMenu(this);'>文件管理</div>");
                sb.Append("<div class='divitem'><a href='FileManager/fileList.aspx' target='main'>文件列表</a></div>");
                sb.Append("<div class='divitem'><a href='FileManager/fileAdd.aspx' target='main'>添加文件</a></div>");
                sb.Append("<div class='divitem'><a href='FileManager/fileTypeList.aspx' target='main'>文件分类列表</a></div>");
                sb.Append("<div class='divitem'><a href='FileManager/fileTypeAdd.aspx' target='main'>添加文件分类</a></div>");
                sb.Append("</div>");
            }

            if (currentAdmin.strPower == "super")
            {
                sb.Append("<div class='divbig'>");
                sb.Append("<div class='divtop' onclick='javascript:showMenu(this);'>员工信息管理</div>\n");
                //sb.Append("<div class='divitem'><a href='teacherManager/ExcelUpload.aspx' target='main'>Excel上传</a></div>\n");
                sb.Append("<div class='divitem'><a href='teacherManager/teacher_list.aspx' target='main'>员工列表</a></div>\n");
                sb.Append("<div class='divitem'><a href='teacherManager/teacherEdit2.aspx' target='main'>添加员工</a></div>\n");
                sb.Append("</div>\n");

                sb.Append("<div class='divbig'>\n");
                sb.Append("<div class='divtop' onclick='javascript:showMenu(this);'>网站答疑</div>\n");
                sb.Append("<div class='divitem'><a href='guestbook/guestTypeList.aspx' target='main'>产品类型</a></div>");
                sb.Append("<div class='divitem'><a href='guestbook/guestTypeAdd.aspx' target='main'>添加类型</a></div>");
                sb.Append("<div class='divitem'><a href='guestbook/guestbooklist.aspx?spcId=0' target='main'>查看留言</a></div>\n");
                sb.Append("<div class='divitem'><a href='guestbook/mailSetting.aspx' target='main'>邮箱设置</a></div>\n");
                sb.Append("</div>\n");

                sb.Append("<div class='divbig'>\n");
                sb.Append("<div class='divtop' onclick='javascript:showMenu(this);'>频道管理</div>\n");
                sb.Append("<div class='divitem'><a href='aspxnews/specialityList.aspx' target='main'>频道列表</a></div>\n");
                sb.Append("<div class='divitem'><a href='aspxnews/specialityAdd.aspx' target='main'>添加频道</a></div>\n");
                sb.Append("</div>\n");

                sb.Append("<div class='divbig'>\n");
                sb.Append("<div class='divtop' onclick='javascript:showMenu(this);'>系统设置</div>\n");
                sb.Append("<div class='divitem'><a href='systemConfig.aspx' target='main'>系统设置</a></div>\n");
                sb.Append("<div class='divitem'><a href='aspxnews/IpHistory.aspx' target='main'>访问记录</a></div>\n");
                sb.Append("</div>\n");

                sb.Append("<div class='divbig'>\n");
                sb.Append("<div class='divtop' onclick='javascript:showMenu(this);'>管理员</div>\n");
                sb.Append("<div class='divitem'><a href='admin/adminList.aspx' target='main'>管理员管理</a></div>\n");
                sb.Append("<div class='divitem'><a href='admin/adminPassword.aspx' target='main'>添加管理员</a></div>\n");
                sb.Append("</div>\n");
            }

            this.litToolbarContent.Text = sb.ToString();
        }
    }
}