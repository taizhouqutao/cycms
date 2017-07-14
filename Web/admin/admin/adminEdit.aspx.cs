using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Adapte;
using System.Data;
using System.Text;
namespace cycms.Web.admin.admin
{
    public partial class adminEdit : System.Web.UI.Page
    {
        BLL.Admin blladmin = new BLL.Admin();
        BLL.Speciality bllspeciality = new BLL.Speciality();
        BLL.ArticleType bllarticletype = new BLL.ArticleType();
        Model.Admin model = new Model.Admin();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!currentAdmin.IsSuper)
            {
                adminOpers.ShowNoPower();
                return;
            }
            if (Request.QueryString["id"] == null) return;
            showPowerSelect();  
        }

        public void showPowerSelect()
        {
            string adminPower = string.Empty;
            string adminName = string.Empty;
            model = blladmin.GetModel(Convert.ToInt32(Request.QueryString["id"]));
            if (model!=null)
            {
                adminName = model.dbo_UserName;
                adminPower = model.dbo_Power; 
            }
            else
            {
                return;
            }
            if (!Page.IsPostBack)
            {
                this.litName.Text = adminName;
                if (adminPower == "super")
                {
                    this.rbtnSuper.Checked = true;
                    this.rbtnCommon.Checked = false;
                }
                else
                {
                    this.rbtnSuper.Checked = false;
                    this.rbtnCommon.Checked = true;
                }
            }

            DataTable dtSpc = bllspeciality.GetList("1=1 order by id asc").Tables[0];
            DataRow dr = dtSpc.NewRow();
            dr["id"] = "0";
            dr["dbo_name"] = "默认频道";
            dr["dbo_htmlDir"] = "";
            dtSpc.Rows.InsertAt(dr, 0);


            for (int i = 0; i < dtSpc.Rows.Count; i++)
            {
                #region 显示频道权限设置的内容

                string channelId = dtSpc.Rows[i]["id"].ToString();
                string channelName = dtSpc.Rows[i]["dbo_name"].ToString();

                HtmlGenericControl fieldset = new HtmlGenericControl("fieldset");
                fieldset.ID = "fieldset" + channelId;

                HtmlGenericControl legend = new HtmlGenericControl("legend");
                legend.ID = "legend" + channelId;
                pla1.Controls.Add(fieldset);
                fieldset.Controls.Add(legend);

                legend.InnerText = "此管理员在【" + channelName + "】的管理权限";

                Panel p1 = new Panel();
                fieldset.Controls.Add(p1);
                Panel p2 = new Panel();
                fieldset.Controls.Add(p2);
                Panel pTypes = new Panel();
                pTypes.ID = "ChannelTypes" + channelId;
                fieldset.Controls.Add(pTypes);
                Panel p3 = new Panel();
                fieldset.Controls.Add(p3);

                RadioButton rbtn1 = new RadioButton();
                p1.Controls.Add(rbtn1);
                rbtn1.Text = "频道管理员：拥有该频道的所有权限（内容管理，类别管理，静态生成，模板管理）";
                rbtn1.ID = "ChannelAdmin" + channelId;
                rbtn1.GroupName = "ChannelAdmin" + channelId;
                rbtn1.Attributes.Add("onclick", "javascript:showTypes(false,'ChannelTypes" + channelId + "');");

                RadioButton rbtn2 = new RadioButton();
                p2.Controls.Add(rbtn2);
                rbtn2.Text = "频道编辑：仅拥有相对应内容类别的管理权限";
                rbtn2.ID = "ChannelEditor" + channelId;
                rbtn2.GroupName = "ChannelAdmin" + channelId;
                rbtn2.Attributes.Add("onclick", "javascript:showTypes(true,'ChannelTypes" + channelId + "');");


                CheckBoxList chkList = new CheckBoxList();
                chkList.ID = "chkList" + channelId;
                pTypes.Controls.Add(chkList);
                chkList.RepeatDirection = RepeatDirection.Horizontal;

                RadioButton rbtn3 = new RadioButton();
                p3.Controls.Add(rbtn3);
                rbtn3.Text = "在此频道无任何管理权限";
                rbtn3.ID = "Nopower" + channelId;
                rbtn3.GroupName = "ChannelAdmin" + channelId;
                rbtn3.Attributes.Add("onclick", "javascript:showTypes(false,'ChannelTypes" + channelId + "');");

                #endregion

                if (!Page.IsPostBack)
                {
                    #region 添加该频道下的文章类别

                    DataTable dtTypes = bllarticletype.GetList("dbo_fatherid=0 and dbo_specialityId = " + channelId + " order by id asc").Tables[0];
                    for (int j = 0; j < dtTypes.Rows.Count; j++)
                    {
                        chkList.Items.Add(new ListItem(dtTypes.Rows[j]["dbo_typename"].ToString(), dtTypes.Rows[j]["id"].ToString()));
                    }
                    #endregion

                    #region 填充已经有的权限
                    bool IsEditor = false;

                    string power = adminOpers.getChannelPower(channelId, adminOpers.getChannels(adminPower));

                    switch (power)
                    {
                        case "0": rbtn1.Checked = true; break;
                        case "-1": rbtn3.Checked = true; break;
                        default: rbtn2.Checked = true; IsEditor = true; break;
                    }

                    if (IsEditor && power != "-2")
                    {
                        string[] powers = power.Split(',');

                        for (int j = 0; j < chkList.Items.Count; j++)
                        {
                            for (int k = 0; k < powers.Length; k++)
                            {
                                if (chkList.Items[j].Value == powers[k])
                                {
                                    chkList.Items[j].Selected = true;
                                    break;
                                }
                            }
                        }
                    }
                    if (!IsEditor)
                    {
                        pTypes.Style.Add("display", "none");
                    }

                    #endregion
                }

            }
        }

        protected void btn_save_Click(object sender, EventArgs e)
        {
            string strPower = getPowerString();

            if (strPower != "super" && !IsAllowDelete(Request.QueryString["id"].ToString()))
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "alert('必须存在一个超级管理员');", true);
            }
            else
            {
                model=blladmin.GetModel(Convert.ToInt32(Request.QueryString["id"]));
                model.dbo_Power=strPower;
                blladmin.Update(model);
                Response.Redirect("adminList.aspx");
            }
        }

        //判断是否允许删除
        private bool IsAllowDelete(string ids)
        {
            int count = blladmin.GetRecordCount(" dbo_power='super' and id not in(" + ids + ")");
            return count > 0;

        }        

        private string getPowerString()
        {
            if (this.rbtnSuper.Checked)
            {
                return "super";
            }

            StringBuilder sb = new StringBuilder();
            DataTable dtSpc = bllspeciality.GetList("1=1 order by id asc").Tables[0];
            DataRow dr = dtSpc.NewRow();
            dr["id"] = "0";
            dr["dbo_name"] = "默认频道";
            dr["dbo_htmlDir"] = "";
            dtSpc.Rows.InsertAt(dr, 0);

            for (int i = 0; i < dtSpc.Rows.Count; i++)
            {
                string channelId = dtSpc.Rows[i]["id"].ToString();
                string strCAdmin = "ChannelAdmin" + channelId;
                string strCEditor = "ChannelEditor" + channelId;
                string strCNopower = "Nopower" + channelId;
                string strCTypes = "chkList" + channelId;
                string strpType = "ChannelTypes" + channelId;

                RadioButton rbtn1 = pla1.FindControl(strCAdmin) as RadioButton;
                RadioButton rbtn2 = pla1.FindControl(strCEditor) as RadioButton;
                RadioButton rbtn3 = pla1.FindControl(strCNopower) as RadioButton;
                Panel pType = pla1.FindControl(strpType) as Panel;

                if (rbtn1.Checked) // 频道管理员
                {
                    if (sb.Length != 0) { sb.Append("$"); }
                    sb.Append(dtSpc.Rows[i]["id"] + "#" + "0");
                }
                else
                    if (rbtn2.Checked) //频道编辑
                    {
                        if (sb.Length != 0) { sb.Append("$"); }

                        CheckBoxList chklist = pla1.FindControl(strCTypes) as CheckBoxList;
                        string strTypes = string.Empty;
                        DataTable dtTypes = bllarticletype.GetList("1=1").Tables[0]; 
                        for (int j = 0; j < chklist.Items.Count; j++)
                        {
                            if (chklist.Items[j].Selected)
                            {
                                if (strTypes != string.Empty) strTypes += ",";
                                strTypes += bllarticletype.getAllChildren2(dtTypes, Convert.ToInt32(chklist.Items[j].Value)); 
                            }
                        }
                        if (strTypes == string.Empty)
                        {
                            strTypes = "-2";
                        }

                        sb.Append(dtSpc.Rows[i]["id"] + "#" + strTypes);
                        pType.Style.Add("display", "block");
                    }
                    else
                    {
                        pType.Style.Add("display", "none");
                    }

            }
            return sb.ToString();
        }
    }
}