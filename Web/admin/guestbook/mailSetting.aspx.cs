using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Adapte;

namespace cycms.Web.admin.guestbook
{
    public partial class mailSetting : System.Web.UI.Page
    {
        BLL.Cycms bllcycms = new BLL.Cycms();
        Model.Cycms modelcycms = new Model.Cycms();
        protected void Page_Load(object sender, EventArgs e)
        {
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

                this.txtmailAddress.Text = sys.mailAddress;
                this.txtsmtpServer.Text = sys.smtpServer;
                this.txtmailName.Text = sys.mailName;
                this.txtmailPwd.Text = sys.mailPwd;
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            sys.mailAddress = this.txtmailAddress.Text;
            sys.smtpServer = this.txtsmtpServer.Text;
            sys.mailName = this.txtmailName.Text;
            sys.mailPwd = this.txtmailPwd.Text;

            modelcycms = bllcycms.GetModel(bllcycms.GetMaxId() - 1);
            modelcycms.dbo_SmtpServer = sys.smtpServer;
            modelcycms.dbo_MailAddress = sys.mailAddress;
            modelcycms.dbo_MailName = sys.mailName;
            modelcycms.dbo_MailPwd = sys.mailPwd;
            bllcycms.Update(modelcycms);
            sys.alert("保存成功！");
        }
    }
}