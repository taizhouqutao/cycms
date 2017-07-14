using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Adapte;
using System.Data;

namespace cycms.Web.admin
{
    public partial class systemConfig : System.Web.UI.Page
    {
        BLL.Speciality bllspeciality = new BLL.Speciality();
        BLL.Cycms bllcycms = new BLL.Cycms();
        Model.Cycms modelcycms = new Model.Cycms();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (currentAdmin.strPower != "super")
            {
                Response.Write("您无权访问该页，错误原因：1.登陆超时；2.非法进入；3.权限不足。请登陆后访问<a href='login.aspx'  target='_parent'>登陆</a>");
                Response.End();
            }
            if (!Page.IsPostBack)
            {
                cycms.Model.Cycms modelcycms = bllcycms.GetModel(bllcycms.GetMaxId() - 1);
                sys.workPlace = modelcycms.dbo_WorkPlace;
                sys.lianXiren = modelcycms.dbo_LianXiRen;
                sys.cellPhone = modelcycms.dbo_CellPhone;
                sys.workPhone = modelcycms.dbo_WorkPohne;
                sys.flax = modelcycms.dbo_Flax;
                sys.mailAddress = modelcycms.dbo_MailAddress;
                sys.smtpServer = modelcycms.dbo_SmtpServer;
                sys.mailName = modelcycms.dbo_MailName;
                sys.mailPwd = modelcycms.dbo_MailPwd;
                sys.beiAnHao = modelcycms.dbo_BeiAnHao;

                this.chkSysIsRun.Checked = sys.IsRunning;
                this.rbtnIsStatic.SelectedIndex = sys.IsStatic ? 0 : 1;
                this.txtWebAddress.Text = sys.webAddress;
                this.txtWebName.Text = sys.webName;
                this.txtLianXiRen.Text = sys.lianXiren;
                this.txtCellPhone.Text = sys.cellPhone;
                this.txtFlax.Text = sys.flax;
                this.txtWorkPlace.Text = sys.workPlace;
                this.txtWorkPhone.Text = sys.workPhone;
                this.txtBeiAnHao.Text = sys.beiAnHao;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            bool IsRunning = this.chkSysIsRun.Checked;
            bool IsStatic = this.rbtnIsStatic.SelectedValue == "0" ? true : false;
            string webName = this.txtWebName.Text;
            string webAddress = this.txtWebAddress.Text;
            if (sys.IsStatic != IsStatic || sys.IsRunning != IsRunning) //状态转换以后执行的动作
            {
                sys.IsStatic = IsStatic; //修改系统状态，使静态生成的页面是当前状态
                sys.IsRunning = IsRunning;

                //只重新生成所有专题的首页
                DataTable dt = bllspeciality.GetAllList().Tables[0];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (sys.IsStatic)
                    {
                        sys.ToStaticDefault(Convert.ToInt32(dt.Rows[i]["id"]));
                    }
                    else
                    {
                        sys.deleteDefaultPage(Convert.ToInt32(dt.Rows[i]["id"]));
                    }
                }

                //生成首页
                if (sys.IsStatic)
                {
                    sys.ToStaticDefault("");
                }
                else
                {
                    sys.deleteDefaultPage(0);
                }

            }
            sys.webName = webName;
            sys.webAddress = webAddress;
            sys.lianXiren = txtLianXiRen.Text;
            sys.workPhone = txtWorkPhone.Text;
            sys.workPlace = txtWorkPlace.Text;
            sys.cellPhone = txtCellPhone.Text;
            sys.flax = txtFlax.Text;
            sys.beiAnHao = txtBeiAnHao.Text;
            modelcycms = bllcycms.GetModel(bllcycms.GetMaxId() - 1);
            modelcycms.dbo_IsRunning = sys.IsRunning;
            modelcycms.dbo_IsStatic = sys.IsStatic;
            modelcycms.dbo_WebAddress = sys.webAddress;
            modelcycms.dbo_WebName = sys.webName;
            modelcycms.dbo_LianXiRen = sys.lianXiren;
            modelcycms.dbo_WorkPohne = sys.workPhone;
            modelcycms.dbo_WorkPlace = sys.workPlace;
            modelcycms.dbo_CellPhone = sys.cellPhone;
            modelcycms.dbo_Flax = sys.flax;
            modelcycms.dbo_VisitedTimes =Convert.ToInt32(sys.VisitedTimes);
            modelcycms.dbo_BeiAnHao = sys.beiAnHao;
            bllcycms.Update(modelcycms);
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "alertMessage", "alert('状态修改成功！')", true);
        }
    }
}