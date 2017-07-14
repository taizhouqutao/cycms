using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Adapte;
using Maticsoft.Common;
using System.Data;

namespace cycms.Web.admin.guestbook
{
    public partial class guestbooklist : System.Web.UI.Page
    {
        BLL.GuestBookType bllguestbooktype = new BLL.GuestBookType();
        BLL.GuestBook bllguestbook = new BLL.GuestBook();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (currentAdmin.strPower == "")
            {
                adminOpers.ShowNoPower();
                return;
            }

            if (!Page.IsPostBack)
            {
                FillDDL();

                if (Request.QueryString["spcId"] != null && Request.QueryString["spcId"] == "10")
                {
                    for (int i = 0; i < this.ddlGuestType.Items.Count; i++)
                    {
                        if (ddlGuestType.Items[i].Value == "6")
                        {
                            this.ddlGuestType.Items[i].Selected = true;

                            string strFiter = string.Empty;
                            if (this.ddlGuestType.SelectedIndex > 0)
                            {
                                if (strFiter != string.Empty)
                                {
                                    strFiter += " and ";
                                }
                                strFiter += "dbo_guestType=" + this.ddlGuestType.SelectedValue;
                            }
                            ViewState["fiter"] = strFiter;
                        }
                        this.ddlGuestType.Visible = false;
                    }
                }
                else if (Request.QueryString["spcId"] != null && Request.QueryString["spcId"] == "0")
                {
                    string strFiter = string.Empty;
                    for (int i = 0; i < this.ddlGuestType.Items.Count; i++)
                    {
                        if (ddlGuestType.Items[i].Value == "6")
                        {
                            ddlGuestType.Items.Remove(ddlGuestType.Items[i]);
                        }
                    }


                    if (this.ddlGuestType.SelectedIndex > 0)
                    {
                        if (strFiter != string.Empty)
                        {
                            strFiter += " and ";
                        }
                        strFiter += "dbo_guestType<>6";
                    }
                    ViewState["fiter"] = strFiter;
                }
                BindData();
            }

            if (Request.Form["__EVENTTARGET"] != null)
            {
                string eve = Request.Form["__EVENTTARGET"].ToString();
                // Response.Write(eve);
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

        protected void FillDDL()
        {
            DataTable dt = bllguestbooktype.GetList("1=1").Tables[0]; 

            this.ddlGuestType.DataTextField = "dbo_typeName";
            this.ddlGuestType.DataValueField = "id";
            this.ddlGuestType.DataSource = dt;
            this.ddlGuestType.DataBind();
            this.ddlGuestType.Items.Insert(0, new ListItem("所有", "0"));
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string strFiter = string.Empty;
            if (this.txtKeyWord.Text.Trim() != "")
            {
                strFiter = " " + this.ddlSearchType.SelectedValue + " like '%" + this.txtKeyWord.Text + "%'";
            }

            if (this.ddlGuestType.SelectedIndex > 0)
            {
                if (strFiter != string.Empty)
                {
                    strFiter += " and ";
                }
                strFiter += "dbo_guestType=" + this.ddlGuestType.SelectedValue;
            }
            ViewState["fiter"] = strFiter;

            ViewState["pageIndex"] = 1;
            BindData();
        }

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

        protected void btnDelSelected_Click(object sender, EventArgs e)
        {
            string selectItems = getSelectedItemsId();
            if (selectItems != "")
            {
                bllguestbook.DeleteList(selectItems);
            }
            this.BindData();
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
            DataTable dt = bllguestbook.getPagerRecords(pageIndex,pageSize,out rowcount,strFiter); 
            this.GridView1.DataSource = dt;
            this.GridView1.DataBind();
            ShowPageNav(rowcount, pageIndex, pageSize);
            #endregion

        }
        #endregion

        #region 显示分页按钮
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

            this.litCounts.Text = "每页显示" + pageSize.ToString() + "条信件，共有" + pagecount.ToString() + "页," + rowcount + "条信件";
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
        #endregion

        #region GrieView事件
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string id = this.GridView1.DataKeys[e.RowIndex].Value.ToString();
            bllguestbook.Delete(Convert.ToInt32(id));
            this.BindData();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.GridView1.PageIndex = e.NewPageIndex;
            this.BindData();
        }
        #endregion
    }
}