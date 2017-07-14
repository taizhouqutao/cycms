using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Adapte;
using Maticsoft.Common;

namespace cycms.Web.admin.guestbook
{
    public partial class guestbookReply : System.Web.UI.Page
    {
        string id = null;
        BLL.GuestBook bllguestbook = new BLL.GuestBook();
        Model.GuestBook modelguestbook = new Model.GuestBook();
        BLL.Cycms bllcycms = new BLL.Cycms();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (currentAdmin.strPower == "")
            {
                adminOpers.ShowNoPower();
                return;
            }
            id = Request.QueryString["id"];
            if (id == null || !PageValidate.IsNumber(id))
            {
                Response.End();
                return;
            }

            if (!Page.IsPostBack)
            {
                FillContent();
            }
        }

        protected void FillContent()
        {
            modelguestbook = bllguestbook.GetModel(Convert.ToInt32(id));
            if (modelguestbook!=null)
            {
                this.litContent.Text = modelguestbook.dbo_Content;
                this.litEmail.Text = modelguestbook.dbo_Email;
                this.litGuestTypeName.Text = modelguestbook.dbo_GuestTypeName;
                this.litName.Text = modelguestbook.dbo_Name;
                this.litPtime.Text = modelguestbook.dbo_Ptime.ToString();
                this.txtReplyContent.Text = modelguestbook.dbo_ReplyContent;
                this.litCellPhone.Text = modelguestbook.dbo_CellPhone;
                this.litWorkName.Text = modelguestbook.dbo_WorkName.Trim() != "" ? modelguestbook.dbo_WorkName : "暂未公开";
                this.litAddress.Text = modelguestbook.dbo_Address.Trim() != "" ? modelguestbook.dbo_Address : "暂未公开";
                this.litFlax.Text = modelguestbook.dbo_Flax.Trim() != "" ? modelguestbook.dbo_Flax : "暂未公开";
                if (modelguestbook.dbo_IsReply != true)
                {
                    this.litReplyTime.Text = "未回复";
                }
                else
                {
                    this.litReplyTime.Text = modelguestbook.dbo_ReplyTime.ToString(); 
                }

                bool IsShow = modelguestbook.dbo_IsShow;
                if (IsShow)
                {
                    this.rbtnIsShow.SelectedIndex = 0;
                }
                else
                {
                    this.rbtnIsShow.SelectedIndex = 1;
                }
                this.litSex.Text = modelguestbook.dbo_Sex;
                this.litTitle.Text = modelguestbook.dbo_Title; 
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            modelguestbook = bllguestbook.GetModel(Convert.ToInt32(id));
            modelguestbook.dbo_IsReply = true;
            modelguestbook.dbo_ReplyContent = this.txtReplyContent.Text;
            modelguestbook.dbo_ReplyTime = DateTime.Now;
            modelguestbook.dbo_IsShow = this.rbtnIsShow.Items[0].Selected;
            bllguestbook.Update(modelguestbook);
            //Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "alert('回复成功！');window.location.href='guestbooklist.aspx'", true);
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

            string name = this.litName.Text;
            string ptime = this.litPtime.Text;
            string title = this.litTitle.Text;
            string content = this.litContent.Text;
            string mailto = this.litEmail.Text;
            string subject = sys.webName + "的回复";
            string body = this.txtReplyContent.Text + "<br /><br /><br />该邮箱为" + sys.webName + "回复留言的邮件，请勿直接回复<br /><br / >" + name + ",您在" + ptime + "的来信:<br>" + title + "<br>" + content;

            if (sys.SendEmail(subject, body, mailto))
            {
                sys.alert("回复成功，已经发送到邮箱。请选择其他操作");
            }
            else
            {
                sys.alert("回复成功！但是由于邮箱地址错误或者服务器拒绝无法到达对方邮箱，请直接发送邮件至对方邮箱");
            }
            sys.regisgerScirpt("window.location.href='guestbooklist.aspx'", "redirect");

        }
    }
}