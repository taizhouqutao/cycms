using System;
using System.Collections.Generic;
using Adapte;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Maticsoft.Common;
using System.Data;
namespace cycms.Web.admin.aspxnews
{
    public partial class IpHistory : System.Web.UI.Page
    {
        BLL.IPHistry blliphistry = new BLL.IPHistry();
        string fiter = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindData();
            }
            if (Request.Form["__EVENTTARGET"] != null)
            {
                string eve = Request.Form["__EVENTTARGET"].ToString();
                if (eve.StartsWith("lbtnNav") && eve.Length > 7)
                {
                    string oper = eve.Substring(7);
                    switch (oper)
                    {
                        case "Frist": ViewState["pageIndex"] = 1;
                            break;
                        case "Pre": ViewState["pageIndex"] = Convert.ToInt32(ViewState["pageIndex"]) - 1;
                            break;
                        case "Next": ViewState["pageIndex"] = Convert.ToInt32(ViewState["pageIndex"]) + 1;
                            break;
                        default: if (PageValidate.IsNumber(oper)) { ViewState["pageIndex"] = oper; }
                            break;
                    }
                    BindData();
                }
            }
        }

        #region 绑定GridView数据
        private void BindData()
        {

            string strFiter = string.Empty;
            if (ViewState["fiter"] != null)
            {
                strFiter = ViewState["fiter"].ToString();
            }



            #region 自定义分页
            int rowcount, pageIndex, pageSize;
            pageIndex = 1;
            if (ViewState["pageIndex"] != null)
            {
                pageIndex = Convert.ToInt32(ViewState["pageIndex"]);
            }
            else
            {
                ViewState["pageIndex"] = pageIndex;
            }

            pageSize = this.GridView1.PageSize;


            DataTable dt = blliphistry.getPagerArticle(pageIndex, pageSize, out rowcount, strFiter);
            //DataTable dt = dal.article.getPagerArticle(pageIndex, pageSize, out rowcount, strFiter, spcId);

            ShowPageNav(rowcount, pageIndex, pageSize);

            #endregion

            //没有定义分页，从数据库中查询出所有的内容，数据大的时候效率低
            //DataTable dt = dal.article.GetArticleList(strFiter, spcId);

            this.GridView1.DataSource = dt;
            this.GridView1.DataBind();

        }
        #endregion

        private void ShowPageNav(int rowcount, int pageIndex, int pageSize)
        {
            int pagecount = (rowcount + pageSize - 1) / pageSize;

            LinkButton lbFrist = CreateLinkButton("lbtnNavFrist", "1", "首页");
            if (pageIndex == 1)
            {
                lbFrist.Enabled = false;
            }
            phNav.Controls.Add(lbFrist);

            LinkButton lbpre = CreateLinkButton("lbtnNavPre", (pageIndex - 1).ToString(), "上一页");
            if (pageIndex == 1)
            {
                lbpre.Enabled = false;
            }

            phNav.Controls.Add(lbpre);
            int start;
            start = pageIndex > 10 ? pageIndex - 10 : 1;
            start = start > pagecount - 19 ? pagecount - 19 : start;
            start = start > 0 ? start : 1;

            for (int i = start; i < start + 20 && i <= pagecount; i++)
            {
                LinkButton lb = CreateLinkButton("lbtnNav" + i.ToString(), i.ToString(), i.ToString());
                if (i == pageIndex)
                {
                    lb.Enabled = false;
                }
                phNav.Controls.Add(lb);
            }

            LinkButton lbnext = CreateLinkButton("lbtnNavNext", (pageIndex + 1).ToString(), "下一页");
            if (pageIndex == pagecount || pagecount == 0)
            {
                lbnext.Enabled = false;
            }
            phNav.Controls.Add(lbnext);

            LinkButton lbLast = CreateLinkButton("lbtnNavLast", pagecount.ToString(), "末页");
            if (pageIndex == pagecount)
            {
                lbLast.Enabled = false;
            }
            phNav.Controls.Add(lbLast);

            this.litCounts.Text = "每页显示" + pageSize.ToString() + "篇文章，共有" + pagecount.ToString() + "页," + rowcount + "篇文章";
        }

        private LinkButton CreateLinkButton(string ControlId, string commandArgumeng, string text)
        {
            LinkButton lbtn = new LinkButton();
            lbtn.ID = ControlId;
            //lbtn.Click += new EventHandler(LinkButtonNav_Click);
            lbtn.CommandArgument = commandArgumeng;
            lbtn.Text = text;
            return lbtn;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string strConditions = string.Empty;
            if (this.txtStart.Text != "")
            {
                strConditions += "dbo_Ptime>=#" + txtStart.Text.Trim() + "# ";
            }
            if (this.txtEnd.Text != "")
            {
                strConditions += "and dbo_Ptime<=#" + txtEnd.Text.Trim() + "# ";
            }
            ViewState["fiter"] = strConditions;
            ViewState["pageIndex"] = null;
            BindData();
        }

        protected void btnDelSelected_Click(object sender, EventArgs e)
        {
            string selectItems = getSelectedItemsId();
            blliphistry.DeleteList(selectItems);
            this.BindData();
        }

        #region GrieView事件
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string id = this.GridView1.DataKeys[e.RowIndex].Value.ToString();
            blliphistry.Delete(Convert.ToInt32(id));
            this.BindData();

        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.GridView1.PageIndex = e.NewPageIndex;
            this.BindData();
        }
        #endregion

        //获取选中的项目id
        private string getSelectedItemsId()
        {
            string selectItems = string.Empty;
            for (int i = 0; i < this.GridView1.Rows.Count; i++)
            {
                CheckBox cb = GridView1.Rows[i].FindControl("chkSelect") as CheckBox;
                if (cb != null && cb.Checked)
                {
                    if (selectItems != string.Empty)
                    {
                        selectItems += ",";
                    }
                    selectItems += this.GridView1.DataKeys[i].Value;
                }
            }
            return selectItems;
        }
    }
}