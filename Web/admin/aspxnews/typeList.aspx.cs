using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Adapte;
using System.Data;
using System.Text;
namespace cycms.Web.admin.aspxnews
{
    public partial class typeList : System.Web.UI.Page
    {
        string spcId = "0";
        BLL.ArticleType bllarticletype = new BLL.ArticleType();
        BLL.Article bllarticle = new BLL.Article();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["spcId"] != null)
            {
                spcId = Request.QueryString["spcId"].ToString();
            }
            if (!currentAdmin.validationSpcAdmin(spcId))
            {
                adminOpers.ShowNoPower();
                return;
            }
            if (Request.QueryString["action"] != null && Request.QueryString["action"].ToString() == "delete" && Request.QueryString["typeid"] != null)
            {
                string typeids = string.Empty;
                typeids = bllarticletype.DeleteNode(Convert.ToInt32(Request.QueryString["typeid"]));
                DataTable dt = bllarticletype.GetList("id in(" + typeids + ")").Tables[0];
                bllarticle.DeleteArticlesByTypeids(typeids);


                string spcDir = sys.getSpcDir(Convert.ToInt32(spcId));
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    sys.deleteArticleFile(Convert.ToInt32(dt.Rows[i]["id"].ToString()), spcDir, Convert.ToDateTime(dt.Rows[i]["dbo_ptime"]));
                }
                Response.Redirect("typeList.aspx?spcId=" + spcId);
            }
            else
            {
                showTypeList();
            }
        }

        private void showTypeList()
        {
            //显示类型的树状列表
            //编辑，删除、添加字节点
            //选出所有的类型

            DataTable dt = bllarticletype.GetList("dbo_specialityId=" + spcId+" order by id asc ").Tables[0];
            int count = dt.Rows.Count;
            DataRow dr = null;
            StringBuilder sb = new StringBuilder();
            sb.Append(" <table id='table1' class='mytable' cellpadding='0' cellspacing='0' >\n<tr class='myrow' style='background-image:url(../images/title.gif); height:31px;text-align:center;'>"
                      + "\n<td>节点ID</td>\n<td>标题</td>\n<td>添加子节点</td>\n<td>编辑</td>\n<td>删除</td>\n</tr>\n");
            sb.Append(writeTree(dt, dr, 0));
            sb.Append("</table>");
            this.litContent.Text = sb.ToString();
        }

        #region 输出树状列表

        private string writeTree(DataTable dt, DataRow fatherRow, int layer)
        {
            string spcId = "0";
            if (Request.QueryString["spcId"] != null)
            {
                spcId = Request.QueryString["spcId"].ToString();
            }
            StringBuilder sb = new StringBuilder();
            DataTable dtChildren = null;

            int fatherid = 0;
            if (fatherRow != null) fatherid = Convert.ToInt32(fatherRow["id"]);
            dtChildren =bllarticletype.getChildNodes(dt, fatherid);

            if (fatherRow != null)
            {
                sb.Append("<tr>\n");
                sb.Append("      <td>" + fatherRow["id"].ToString() + "</td>\n");

                if (dtChildren.Rows.Count > 0)
                {
                    sb.Append("      <td class='typename' valign='middle'><span style='padding-left:" + (layer * 30).ToString() + "px;'></span><img src='../images/th.gif' border='0'><img src='../images/dir.bmp' border='0'>");
                }
                else
                {
                    sb.Append("      <td class='typename' valign='middle'><span style='padding-left:" + (layer * 30).ToString() + "px;'></span><img src='../images/tn.gif' border='0'><img src='../images/dir.bmp' border='0'>");
                }

                sb.Append("      " + fatherRow["dbo_typename"].ToString() + "</td>\n");
                sb.Append("      <td class='childTypeAdd'><a href='typeAdd.aspx?fatherid=" + fatherRow["id"].ToString() + "&spcId=" + spcId + "'>添加子节点</a></td>\n");
                sb.Append("      <td class='typeEdit' valign='middle'><a href='typeAdd.aspx?typeid=" + fatherRow["id"].ToString() + "&spcId=" + spcId + "'>编辑</a></td>\n");
                sb.Append("      <td class='typeDelete' valign='middle'><a href='typeLIst.aspx?action=delete&typeid=" + fatherRow["id"].ToString() + "&spcId=" + spcId + "' onclick='return confirm(\"将删除该节点及子节点下的所有内容，确定吗？\");'>删除</a></td>\n");


                sb.Append("</tr>\n");

            }
            //if (fatherRow != null)
            //{
            //    dt.Rows.Remove(fatherRow);
            //}

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dtChildren.Rows.Count; i++)
                {
                    sb.Append(writeTree(dt, dtChildren.Rows[i], layer + 1));
                }
            }
            return sb.ToString();

        }

        #endregion
    }
}