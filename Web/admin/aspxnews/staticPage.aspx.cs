using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Adapte;
namespace cycms.Web.admin.aspxnews
{
    public partial class staticPage : System.Web.UI.Page
    {
        int spcId = 0;
        int listPages = 0;
        BLL.Article bllarticle = new BLL.Article();
        BLL.ArticleType bllarticletype = new BLL.ArticleType();
        protected void Page_Load(object sender, EventArgs e)
        {
            this.lblMessage.Text = "";
            if (Request.QueryString["spcId"] != null)
            {
                spcId = Convert.ToInt32(Request.QueryString["spcId"]);
            }
            if (!currentAdmin.validationSpcAdmin(spcId.ToString()))
            {
                adminOpers.ShowNoPower();
                return;
            }
            if (!Page.IsPostBack)
            {
                this.litArticleCount.Text = bllarticle.getArticleCountBySpcId(spcId).ToString();
                getDefaultPageInfo();
            }
        }

        private void getDefaultPageInfo()
        {
            DateTime lastEditTime = sys.getLastDefaultEdit(spcId);
            if (lastEditTime != new DateTime(1, 1, 1, 0, 0, 0, 0))
            {
                this.litDefaultLastTime.Visible = true;
                this.btnDeleteFile.Visible = true;
                this.litDefaultLastTime.Text = "上次生成时间：" + lastEditTime.ToString();
            }
            else
            {
                this.litDefaultLastTime.Visible = false;
                this.btnDeleteFile.Visible = false;
            }
        }

        protected void btnExecDefault_Click(object sender, EventArgs e)
        {
            string strDir = sys.getSpcDir(spcId);
            sys.ToStaticDefault(strDir);
            this.lblMessage.Text = "频道首页生成成功！ 执行时间：" + DateTime.Now.ToString("yyyy年MM月dd日hh时mm分ss秒");
            getDefaultPageInfo();
        }

        protected void btnExecList_Click(object sender, EventArgs e)
        {
            if (this.txtListPageCount.Text == "" || this.txtListPageCount.Text == "0")
            {
                this.lblMessage.Text = "没有内容可以生成!";
                return;
            }
            int count = Convert.ToInt32(this.txtListPageCount.Text);
            sys.staticListPages = count;
            ToStaticList(count);
        }

        protected void btnExecContentPageCount_Click(object sender, EventArgs e)
        {
            if (this.txtContentPageCount.Text == "" || this.txtContentPageCount.Text == "0")
            {
                this.lblMessage.Text = "没有内容可以生成!";
                return;
            }
            int count = Convert.ToInt32(this.txtContentPageCount.Text);
            ToStaticContent(count);
        }

        protected void btnExecContentDate_Click(object sender, EventArgs e)
        {
            if (this.txtContentDateStart.Text == "" || this.txtContentDateEnd.Text == "")
            {
                this.lblMessage.Text = "请选择时间";
                return;
            }
            DateTime dtStart = DateTime.Now;
            DateTime dtEnd = DateTime.Now;
            dtStart = Convert.ToDateTime(this.txtContentDateStart.Text);
            dtEnd = Convert.ToDateTime(this.txtContentDateEnd.Text);
            if (dtStart > dtEnd)
            {
                this.lblMessage.Text = "日期错误，开始日子不能大于结束日期！";
                return;
            }
            ToStaticContent(dtStart, dtEnd);
        }

        #region 静态生成列表页
        public void ToStaticList(int count)
        {
            DataTable dt = bllarticletype.GetList("dbo_specialityId=" + spcId).Tables[0]; 
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ToStaticListTypeId(Convert.ToInt32(dt.Rows[i]["id"]), count);
            }

            this.lblMessage.Text = "频道列表页生成成功！共" + dt.Rows.Count.ToString() + "分类,生成" + listPages.ToString() + "页.执行时间：" + DateTime.Now.ToString("yyyy年MM月dd日hh时mm分ss秒");
        }

        public void ToStaticListTypeId(int typeid, int getPages)
        {
            sys.IsLastListPages = false;
            string fileName = string.Empty;
            string strDir = sys.getSpcDir(spcId);
            for (int i = 1; i <= getPages && !sys.IsLastListPages; i++)
            {
                listPages++;
                sys.ToStaticList(strDir, typeid, i, getPages);
            }
            Application.Remove("IsOverPages");
        }

        #endregion

        #region 静态生成内容页
        public void ToStaticContent(int count)
        {
            int[] ids =bllarticletype.getTypeIdsBySpcId(spcId);
            if (ids.Length == 0)
            {
                this.lblMessage.Text = "没有内容可以生成！";
                return;
            }

            string strIds = string.Empty;
            for (int i = 0; i < ids.Length; i++)
            {
                strIds += ids[i].ToString();
                if (i != ids.Length - 1)
                {
                    strIds += ",";
                }
            }
            DataTable dt = bllarticle.GetList("dbo_typeid in(" + strIds + ") order by id desc").Tables[0]; 
            string strDir = sys.getSpcDir(spcId);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                sys.ToStaticContent(strDir, Convert.ToInt32(dt.Rows[i]["id"]), Convert.ToDateTime(dt.Rows[i]["dbo_ptime"]));
            }
            this.lblMessage.Text = "频道内容页生成成功！生成" + dt.Rows.Count.ToString() + "页.执行时间：" + DateTime.Now.ToString("yyyy年MM月dd日hh时mm分ss秒");
        }

        public void ToStaticContent(DateTime dtStart, DateTime dtEnd)
        {
            int[] ids =bllarticletype.getTypeIdsBySpcId(spcId);
            if (ids.Length == 0)
            {
                this.lblMessage.Text = "没有内容可以生成！";
                return;
            }

            string strIds = string.Empty;
            for (int i = 0; i < ids.Length; i++)
            {
                strIds += ids[i].ToString();
                if (i != ids.Length - 1)
                {
                    strIds += ",";
                }
            }

            DataTable dt = bllarticle.GetList("dbo_typeid in (" + strIds + ") and dbo_ptime>=#" + dtStart.ToString() + "# and " + "dbo_ptime<=#" + dtEnd.ToString() + "#").Tables[0]; 
            //Response.Write(dt.Rows.Count);
            string strDir = sys.getSpcDir(spcId);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                sys.ToStaticContent(strDir, Convert.ToInt32(dt.Rows[i]["id"]), Convert.ToDateTime(dt.Rows[i]["dbo_ptime"]));
            }
            this.lblMessage.Text = "内容页生成成功！生成" + dt.Rows.Count.ToString() + "页.执行时间：" + DateTime.Now.ToString("yyyy年MM月dd日hh时mm分ss秒");
        }
        #endregion

        protected void btnDeleteFile_Click(object sender, EventArgs e)
        {
            sys.deleteDefaultPage(spcId);
            getDefaultPageInfo();
        }
    }
}