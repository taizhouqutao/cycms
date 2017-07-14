using System;
using System.Collections.Generic;
using Adapte;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace cycms.Web.admin.teacherManager
{
    public partial class teacherInfo : System.Web.UI.Page
    {
        string teacherId = null;
        BLL.TeacherInfo bllteacherinfo = new BLL.TeacherInfo();
        BLL.TeacherWorkResume bllteacherworkresume = new BLL.TeacherWorkResume();
        BLL.TeacherStudyResume bllteacherstudayresume = new BLL.TeacherStudyResume();
        BLL.TeacherTeachResume bllteacherteachresume = new BLL.TeacherTeachResume();
        protected void Page_Load(object sender, EventArgs e)
        {
            teacherId = Request.QueryString["id"];
            if (!currentAdmin.IsSuper)
            {
                adminOpers.ShowNoPower();
                return;
            }
            if (!IsPostBack)
            {
                if (teacherId != null)
                {
                    BindData();
                    BindGridViews();
                }
            }
        }

        private void BindData()
        {
            //string id = teacherId;
            DataTable dt = bllteacherinfo.GetList("id=" + teacherId).Tables[0]; 
            if (dt == null || dt.Rows.Count == 0)
            {
                return;
            }
            litname.Text = dt.Rows[0]["dbo_name"] == System.DBNull.Value ? "" : dt.Rows[0]["dbo_name"].ToString();
            litLoginName.Text = dt.Rows[0]["dbo_loginName"] == System.DBNull.Value ? "" : dt.Rows[0]["dbo_loginName"].ToString();
            litsex.Text = dt.Rows[0]["dbo_sex"] == System.DBNull.Value ? "" : dt.Rows[0]["dbo_sex"].ToString();
            litminzu.Text = dt.Rows[0]["dbo_minzu"] == System.DBNull.Value ? "" : dt.Rows[0]["dbo_minzu"].ToString();
            litbirthday.Text = dt.Rows[0]["dbo_birthday"] == System.DBNull.Value ? "" : dt.Rows[0]["dbo_birthday"].ToString();
            if (dt.Rows[0]["dbo_birthday"].ToString() != "")
            {
                litbirthday.Text = Convert.ToDateTime(dt.Rows[0]["dbo_birthday"]).ToString("yyyy-MM-dd");
            }
            litparty.Text = dt.Rows[0]["dbo_party"] == System.DBNull.Value ? "" : dt.Rows[0]["dbo_party"].ToString();
            litparty_time.Text = dt.Rows[0]["dbo_party_time"] == System.DBNull.Value ? "" : dt.Rows[0]["dbo_party_time"].ToString();
            if (dt.Rows[0]["dbo_party_time"].ToString() != "")
            {
                litparty_time.Text = Convert.ToDateTime(dt.Rows[0]["dbo_party_time"]).ToString("yyyy-MM-dd");
            }
            litdegree.Text = dt.Rows[0]["dbo_degree"] == System.DBNull.Value ? "" : dt.Rows[0]["dbo_degree"].ToString();
            litschool.Text = dt.Rows[0]["dbo_school"] == System.DBNull.Value ? "" : dt.Rows[0]["dbo_school"].ToString();
            litxueli.Text = dt.Rows[0]["dbo_xueli"] == System.DBNull.Value ? "" : dt.Rows[0]["dbo_xueli"].ToString();
            litRemarks.Text = dt.Rows[0]["dbo_remarks"] == System.DBNull.Value ? "" : dt.Rows[0]["dbo_remarks"].ToString();
            litwork_time.Text = dt.Rows[0]["dbo_work_time"] == System.DBNull.Value ? "" : dt.Rows[0]["dbo_work_time"].ToString();
            if (dt.Rows[0]["dbo_work_time"].ToString() != "")
            {
                litwork_time.Text = Convert.ToDateTime(dt.Rows[0]["dbo_work_time"]).ToString("yyyy-MM-dd");
            }
            littitle.Text = dt.Rows[0]["dbo_title"] == System.DBNull.Value ? "" : dt.Rows[0]["dbo_title"].ToString();
            litemp_time.Text = dt.Rows[0]["dbo_emp_time"] == System.DBNull.Value ? "" : dt.Rows[0]["dbo_emp_time"].ToString();
            if (dt.Rows[0]["dbo_emp_time"].ToString() != "")
            {
                litemp_time.Text = Convert.ToDateTime(dt.Rows[0]["dbo_emp_time"]).ToString("yyyy-MM-dd");
            }
            litinfo_base.Text = dt.Rows[0]["dbo_info_base"] == System.DBNull.Value ? "" : dt.Rows[0]["dbo_info_base"].ToString();
            //litinfo_teac.Text = dt.Rows[0]["dbo_info_teac"] == System.DBNull.Value ? "" : dt.Rows[0]["dbo_info_teac"].ToString();
            litinfo_study.Text = dt.Rows[0]["dbo_info_study"] == System.DBNull.Value ? "" : dt.Rows[0]["dbo_info_study"].ToString();
            string strPhoto = (dt.Rows[0]["dbo_photo"] == System.DBNull.Value) ? "" : dt.Rows[0]["dbo_photo"].ToString();
            if (strPhoto.Trim() == "")
            {
                strPhoto = "noPhoto.png";
            }
            photo.ImageUrl = @"\uploads\teacherPhoto\" + strPhoto;
            littitle.Text = (dt.Rows[0]["dbo_title"] == System.DBNull.Value) ? "" : dt.Rows[0]["dbo_title"].ToString();
            litProfessional.Text = (dt.Rows[0]["dbo_professional"] == System.DBNull.Value) ? "" : dt.Rows[0]["dbo_professional"].ToString();
            litEmail.Text = (dt.Rows[0]["dbo_email"] == System.DBNull.Value) ? "" : dt.Rows[0]["dbo_email"].ToString();
            litJiGuan.Text = (dt.Rows[0]["dbo_jiguan"] == System.DBNull.Value) ? "" : dt.Rows[0]["dbo_jiguan"].ToString();
            litHomeAddress.Text = (dt.Rows[0]["dbo_homeAddress"] == System.DBNull.Value) ? "" : dt.Rows[0]["dbo_homeAddress"].ToString();
            litOfficePhone.Text = (dt.Rows[0]["dbo_officePhone"] == System.DBNull.Value) ? "" : dt.Rows[0]["dbo_officePhone"].ToString();
            litHomePhone.Text = (dt.Rows[0]["dbo_homePhone"] == System.DBNull.Value) ? "" : dt.Rows[0]["dbo_homePhone"].ToString();
            litMobilePhone.Text = (dt.Rows[0]["dbo_mobilePhone"] == System.DBNull.Value) ? "" : dt.Rows[0]["dbo_mobilePhone"].ToString();
            litShortNum.Text = (dt.Rows[0]["dbo_shortNumber"] == System.DBNull.Value) ? "" : dt.Rows[0]["dbo_shortNumber"].ToString();

        }

        protected void BindGridViews()
        {
            DataTable dt1 = bllteacherworkresume.GetList("dbo_teacherId=" + teacherId).Tables[0];
            this.GridView1.DataSource = dt1;
            this.GridView1.DataBind();

            DataTable dt2 = bllteacherstudayresume.GetList("dbo_teacherId=" + teacherId).Tables[0]; 
            this.GridView2.DataSource = dt2;
            this.GridView2.DataBind();

            DataTable dt3 = bllteacherteachresume.GetList("dbo_teacherId=" + teacherId).Tables[0]; 
            this.GridView3.DataSource = dt3;
            this.GridView3.DataBind();
        }
    }
}