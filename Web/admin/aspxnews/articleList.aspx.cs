using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Adapte;
using Maticsoft.Common;
using System.Data;

namespace cycms.Web.admin.aspxnews
{
    public partial class articleList : System.Web.UI.Page
    {
        BLL.ArticleType bllarticletype = new BLL.ArticleType();
        BLL.Article bllarticle = new BLL.Article();
        BLL.ArticleImg bllarticleimg = new BLL.ArticleImg();
        Model.Article modelarticle = new Model.Article();
        public string spcId = "0";
        string fiter = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["spcId"] != null)
            {
                spcId = Request.QueryString["spcId"].ToString();
            }
            if (!currentAdmin.validationSpcEditor(spcId))
            {
                adminOpers.ShowNoPower();
                return;
            }

            fiter = "dbo_specialityId=" + spcId + " and dbo_isArticleType=True";
            if (!currentAdmin.validationSpcAdmin(spcId))
            {
                string ids = adminOpers.getChannelPower(spcId, currentAdmin.Channels);
                if (ids == "-2")
                {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "alertNoTypes", "alert('该专题下未创建任何文章类型或者您在该专题下没有任何权限');", true);
                    pnlContent.Visible = false;
                    return;
                }

                fiter = " id in(" + ids + ") ";
            }

            if (!Page.IsPostBack)
            {
                InitPage();
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

        private void InitPage()
        {


            DataTable dt = bllarticletype.GetList(fiter + " order by id asc").Tables[0];
            DataTable dttemp = bllarticletype.getChildNodes(dt, 0);

            this.ddlType.Items.Add(new ListItem("所有类型", "0"));
            FillDdlFatherType(dt, null, 0, (dttemp.Rows.Count <= 1));


        }

        #region 绑定类型
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
                this.ddlType2.Items.Add(new ListItem(fathertypename, fatherid.ToString()));
            }

            DataTable dtChildren = bllarticletype.getChildNodes(dt, fatherid);
            for (int i = 0; i < dtChildren.Rows.Count; i++)
            {
                FillDdlFatherType(dt, dtChildren.Rows[i], layer + 1, (dtChildren.Rows.Count == (i + 1)));
            }
        }
        #endregion

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

            int[] typeids;

            if (ViewState["selectType"] == null)
            {
                if (currentAdmin.validationSpcAdmin(spcId))
                {
                    typeids = bllarticletype.getTypeIdsBySpcId(Convert.ToInt32(spcId));
                }
                else
                {
                    string ids = adminOpers.getChannelPower(spcId, currentAdmin.Channels);
                    string[] strids = ids.Split(',');
                    typeids = new int[strids.Length];
                    for (int i = 0; i < strids.Length; i++)
                    {
                        typeids[i] = Convert.ToInt32(strids[i]);
                    }
                }
            }
            else
            {
                typeids = new int[] { Convert.ToInt32(ViewState["selectType"]) };
            }

            if (typeids.Length == 0)
            {
                // Response.Write(sys.alertAndRedirect("", "" + ));
                Response.Write("<script type='text/javascript'>alert('专题下未创建任何文章类型，请先添加文章类型');window.location.href='typeAdd.aspx?spcId='" + spcId.ToString() + "</script>");
                pnlContent.Visible = false;
                return;
            }

            DataTable dt = bllarticle.getPagerArticle(pageIndex, pageSize, out rowcount, typeids, strFiter);
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


        #region GrieView事件
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string id = this.GridView1.DataKeys[e.RowIndex].Value.ToString();

            int typeid = 0;
            DateTime articlePtime = DateTime.Now;

            modelarticle = bllarticle.GetModel(Convert.ToInt32(id));
            if (modelarticle!=null)
            {
                typeid =Convert.ToInt32(modelarticle.dbo_Typeid);
                articlePtime =Convert.ToDateTime(modelarticle.dbo_Ptime); 
            }

            bllarticle.Delete(Convert.ToInt32(id));
            bllarticleimg.DeleteByArticleId(Convert.ToInt32(id));

            string strDir = sys.getSpcDir(Convert.ToInt32(spcId));

            if (typeid != 0)
            {
                sys.deleteArticleFile(Convert.ToInt32(id), strDir, articlePtime);
            }

            if (sys.IsStatic)
            {
                if (typeid != 0)
                {
                    sys.ToStaticListWithArticleEdit(typeid, strDir);
                }
            }
            else//判断是否需要生成首页
            {
                sys.ToStaticPageWithActive(Convert.ToInt32(spcId));
            }
            this.BindData();

        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.GridView1.PageIndex = e.NewPageIndex;
            this.BindData();
        }
        #endregion

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (this.ddlType.SelectedValue == "")
            {
                return;
            }
            string strConditions = string.Empty;
            int fatherid = Convert.ToInt32(this.ddlType.SelectedValue);

            if (this.txtKeyWord.Text != "")
            {
                switch (this.ddlSearch.SelectedValue)
                {
                    case "标题": strConditions = "dbo_title";
                        break;
                    case "作者": strConditions = "dbo_author";
                        break;
                    default: break;
                }

                if (strConditions != string.Empty)
                {
                    strConditions += " like '%" + this.txtKeyWord.Text + "%'";
                }
            }

            if (this.ddlType.SelectedIndex != 0 && this.ddlType.SelectedIndex != -1)
            {
                ViewState["selectType"] = this.ddlType.SelectedValue;
            }
            else
            {
                ViewState["selectType"] = null;
            }

            ViewState["fiter"] = strConditions;
            ViewState["pageIndex"] = null;
            BindData();
        }

        #region
        // 获取选中的项目id
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
                //1.删除文章并且获取需要重新生成的类型id集合。2.从数据库中删除。3.重新生成相关页面

                string[] ids = selectItems.Split(',');
                int[] typeids = new int[ids.Length];
                int length = 0; //不重复的typeid数目
                // DateTime[] articlePtime = new DateTime[ids.Length];

                int spcId = 0;
                if (Request.QueryString["spcId"] != null)
                {
                    spcId = Convert.ToInt32(Request.QueryString["spcId"]);
                }

                string strDir = string.Empty;

                //不论是否静态生成都尝试删除已有的文件
                //if (sys.IsStatic)
                //{  
                strDir = sys.getSpcDir(spcId);
                DataTable dt = bllarticle.GetList("id in (" + selectItems + ")").Tables[0]; 
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    int typeid = Convert.ToInt32(dt.Rows[i]["dbo_typeid"]);
                    bool ExistTypeId = false;
                    for (int j = 0; j < length; j++)
                    {
                        if (typeid == typeids[j])
                        {
                            ExistTypeId = true;
                        }
                    }
                    if (!ExistTypeId)
                    {
                        typeids[length] = typeid;
                        length++;
                    }
                    //articlePtime[i] = Convert.ToDateTime(dt.Rows[i]["ptime"]);
                    sys.deleteArticleFile(Convert.ToInt32(ids[i]), strDir, Convert.ToDateTime(dt.Rows[i]["dbo_ptime"]));
                }
                //}
                bllarticle.DeleteList(selectItems);
                bllarticleimg.DeleteByArticleIdList(selectItems);


                if (sys.IsStatic)
                {
                    for (int i = 0; i < length; i++)
                    {
                        sys.ToStaticListWithArticleEdit(typeids[i], strDir);
                    }

                    if (Request.QueryString["spcId"] != null)
                    {
                        spcId = Convert.ToInt32(Request.QueryString["spcId"]);
                    }
                    sys.ToStaticPageWithActive(Convert.ToInt32(spcId));
                }

            }
            this.BindData();
        }

        protected void btnChangeType_Click(object sender, EventArgs e)
        {
            string selectItems = getSelectedItemsId();

            if (selectItems != "")
            {

                string[] ids = selectItems.Split(',');
                int[] typeids = new int[ids.Length];
                int length = 0; //不重复的typeid数目
                int spcId = 0;
                if (Request.QueryString["spcId"] != null)
                {
                    spcId = Convert.ToInt32(Request.QueryString["spcId"]);
                }
                string strDir = sys.getSpcDir(spcId);
                if (sys.IsStatic)
                {
                    //把相关的类别页面都重新生成，把被移动到的类型页面重新生成
                    //1.获取相关的类型id。 2.修改数据库。 3.重新静态生成前相关的类型id，生成被移动到的类型页面

                    DataTable dt = bllarticle.GetList("id in (" + selectItems + ")").Tables[0];
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        int typeid = Convert.ToInt32(dt.Rows[i]["dbo_typeid"]);
                        bool ExistTypeId = false;
                        for (int j = 0; j < length; j++)
                        {
                            if (typeid == typeids[j])
                            {
                                ExistTypeId = true;
                            }
                        }
                        if (!ExistTypeId)
                        {
                            typeids[length] = typeid;
                            length++;
                        }
                        //articlePtime[i] = Convert.ToDateTime(dt.Rows[i]["ptime"]);
                        // sys.deleteArticleFile(Convert.ToInt32(ids[i]), strDir, Convert.ToDateTime(dt.Rows[i]["ptime"]));
                    }
                }
                bllarticle.UpdateTypeidByIdList(Convert.ToInt32(this.ddlType2.SelectedValue),selectItems);
                if (sys.IsStatic)
                {
                    for (int i = 0; i < length; i++)
                    {
                        sys.ToStaticListWithArticleEdit(typeids[i], strDir);
                    }
                    sys.ToStaticListWithArticleEdit(Convert.ToInt32(this.ddlType2.SelectedValue), strDir);
                }
            }

            this.BindData();
        }
        #endregion 
    }
}