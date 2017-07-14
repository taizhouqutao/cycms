using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Adapte;
using System.Data;
namespace cycms.Web.admin.aspxnews
{
    public partial class typeAdd : System.Web.UI.Page
    {
        BLL.Speciality bllspeciality = new BLL.Speciality();
        BLL.ArticleType bllarticletype = new BLL.ArticleType();
        BLL.Article bllarticle = new BLL.Article();
        Model.ArticleType modelarticletype = new Model.ArticleType();
        enum MyPageState { add, edit }
        MyPageState theState;

        string spcId = "0";
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

            theState = MyPageState.add;
            if (Request.QueryString["typeid"] != null)
            {
                theState = MyPageState.edit;
                this.btnAdd.Text = "保存";
            }
            if (!Page.IsPostBack)
            {
                initEdit();
            }
        }

        private void initEdit()
        {
            if (spcId == "0")
            {
                this.litSpcName.Text = "默认专题";
            }
            else
            {
                this.litSpcName.Text = bllspeciality.GetModel(Convert.ToInt32(spcId)).dbo_Name; 
            }


            DataTable dt = bllarticletype.GetList("dbo_specialityId=" + spcId+ " order by id asc ").Tables[0]; 
            DataTable dttemp = getChildNodes(dt, 0);

            #region 关于类型
            this.ddlFatherType.Items.Add(new ListItem("作为根类型", "0"));
            FillDdlFatherType(dt, null, 0, (dttemp.Rows.Count <= 1));

            string fatherTypeId = "0";
            string strSpecialityId = "0";
            bool IsDisplay = true;
            bool IsArticleType = true;
            if (theState == MyPageState.edit)
            {
                modelarticletype = bllarticletype.GetModel(Convert.ToInt32(Request.QueryString["typeid"]));
                if (modelarticletype!=null)
                {
                    this.txtTypeName.Text = modelarticletype.dbo_TypeName;
                    this.txtLinkUrl.Text = modelarticletype.dbo_LinkUrl;
                    fatherTypeId = modelarticletype.dbo_Fatherid.ToString();
                    strSpecialityId = modelarticletype.dbo_SpecialityId.ToString();
                    IsDisplay = modelarticletype.dbo_IsDisplay;
                    IsArticleType = modelarticletype.dbo_IsArticleType; 
                }
            }
            else if (Request.QueryString["fatherid"] != null)
            {
                fatherTypeId = Request.QueryString["fatherid"].ToString();
                this.ddlFatherType.Enabled = false;
            }
            if (fatherTypeId != "0")
            {
                for (int i = 0; i < ddlFatherType.Items.Count; i++)
                {
                    if (ddlFatherType.Items[i].Value == fatherTypeId)
                    {
                        this.ddlFatherType.Items[i].Selected = true;
                        break;
                    }
                }
            }
            #endregion

            this.chkIsDisplay.Checked = IsDisplay;
            this.chkIsArticleType.Checked = IsArticleType;

            #region 关于专题
            if (theState == MyPageState.edit)
            {
                this.ddlSpeciality.Items.Add(new ListItem("默认专题", "0"));
                DataTable dtSpecialitys = bllspeciality.GetList("1=1 order by id desc").Tables[0]; 
                for (int i = 0; i < dtSpecialitys.Rows.Count; i++)
                {
                    this.ddlSpeciality.Items.Add(new ListItem(dtSpecialitys.Rows[i]["dbo_name"].ToString(), dtSpecialitys.Rows[i]["id"].ToString()));
                }

                if (strSpecialityId != "0")
                {
                    for (int i = 0; i < ddlSpeciality.Items.Count; i++)
                    {
                        if (ddlSpeciality.Items[i].Value == strSpecialityId)
                        {
                            this.ddlSpeciality.Items[i].Selected = true;
                            break;
                        }
                    }
                }
                this.litSpcName.Visible = false;
            }
            else
            {
                this.ddlSpeciality.Visible = false;
            }

            #endregion
        }

        private void FillDdlFatherType(DataTable dt, DataRow fatherRow, int layer, bool IsTypeEnd)
        {
            int fatherid = 0;
            if (fatherRow != null)
            {
                if (theState == MyPageState.edit && Request.QueryString["typeid"].ToString() == fatherRow["id"].ToString())
                {
                    return;
                }
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

                this.ddlFatherType.Items.Add(new ListItem(fathertypename, fatherid.ToString()));
            }


            DataTable dtChildren =bllarticletype.getChildNodes(dt, fatherid);

            for (int i = 0; i < dtChildren.Rows.Count; i++)
            {
                FillDdlFatherType(dt, dtChildren.Rows[i], layer + 1, (dtChildren.Rows.Count == (i + 1)));
            }
        }

        private DataTable getChildNodes(DataTable dt, int fatherid)
        {
            DataTable dtChildren = new DataTable();
            dtChildren.Columns.Add("id", typeof(System.Int32));
            dtChildren.Columns.Add("dbo_typename", typeof(System.String));
            dtChildren.Columns.Add("dbo_linkUrl", typeof(System.String));
            dtChildren.Columns.Add("dbo_fatherid", typeof(System.Int32));

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (Convert.ToInt32(dt.Rows[i]["dbo_fatherid"]) == fatherid)
                {
                    DataRow dr = dtChildren.NewRow();
                    dr["id"] = dt.Rows[i]["id"];
                    dr["dbo_typename"] = dt.Rows[i]["dbo_typename"];
                    dr["dbo_linkUrl"] = dt.Rows[i]["dbo_linkUrl"];
                    dr["dbo_fatherid"] = dt.Rows[i]["dbo_fatherid"];
                    dtChildren.Rows.Add(dr);
                }
            }

            return dtChildren;
        }


        protected void btnAdd_Click(object sender, EventArgs e)
        {

            string typeName = this.txtTypeName.Text;
            string linkUrl = this.txtLinkUrl.Text;
            int fatherid = Convert.ToInt32(this.ddlFatherType.SelectedValue);
            bool IsDisplay = this.chkIsDisplay.Checked;
            bool IsArticleType = this.chkIsArticleType.Checked;
            //int spcId = Convert.ToInt32(this.ddlSpeciality.SelectedValue);
            int spcId = 0;
            if (Request.QueryString["spcId"] != null)
            {
                spcId = Convert.ToInt32(Request.QueryString["spcId"]);
            }
            if (this.ddlSpeciality.SelectedValue != "" && Convert.ToInt32(this.ddlSpeciality.SelectedValue) != spcId)
            {
                spcId = Convert.ToInt32(this.ddlSpeciality.SelectedValue);
            }
            if (theState == MyPageState.add)
            {
                bllarticletype.Add(new Model.ArticleType { dbo_TypeName=typeName,dbo_Fatherid=fatherid,dbo_LinkUrl=linkUrl,dbo_IsDisplay=IsDisplay,dbo_IsArticleType=IsArticleType,dbo_SpecialityId=spcId });
            }
            else if (theState == MyPageState.edit)
            {
                int typeid = Convert.ToInt32(Request.QueryString["typeid"]);
                string typeids =bllarticletype.getAllChildren(typeid);
                int sourceSpc = (Request.QueryString["spcId"] == null ? 0 : Convert.ToInt32(Request.QueryString["spcId"]));

                if (Convert.ToInt32(sourceSpc) != spcId)
                {
                    bllarticletype.updateSpecialityId(typeids, spcId);
                    DataTable dt = bllarticle.GetList("dbo_typeid in(" + typeids + ")").Tables[0]; 
                    string sourceSpcDir = sys.getSpcDir(sourceSpc);
                    string destSpcDir = sys.getSpcDir(spcId);
                    sourceSpcDir = (sourceSpcDir == "" ? "" : sourceSpcDir + "\\");
                    destSpcDir = (destSpcDir == "" ? "" : destSpcDir + "\\");

                    string sourceDir = Server.MapPath("~/") + sourceSpcDir + "content\\";
                    string destDir = Server.MapPath("~/") + destSpcDir + "content\\";
                    System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(destDir);
                    if (!di.Exists)
                    {
                        di.Create();
                    }
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        sys.MoveArticleFile(sourceDir, destDir, Convert.ToDateTime(dt.Rows[i]["dbo_ptime"]), dt.Rows[i]["id"].ToString());
                    }
                }
                bllarticletype.Update(new Model.ArticleType {dbo_TypeName=typeName,dbo_Fatherid=fatherid,dbo_LinkUrl=linkUrl,dbo_IsDisplay=IsDisplay,dbo_IsArticleType=IsArticleType,dbo_SpecialityId=spcId,ID=typeid });
            }
            Response.Write("<script>window.location.href='typelist.aspx?spcId=" + spcId.ToString() + "'</script>");
        }
    }
}