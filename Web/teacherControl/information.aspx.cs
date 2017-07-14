using System;
using System.Collections.Generic;
using Adapte;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
namespace cycms.Web.teacherControl
{
    public partial class information : System.Web.UI.Page
    {
        //修改教师信息
        BLL.TeacherInfo bllteacherinfo = new BLL.TeacherInfo();
        BLL.TeacherWorkResume bllteacherworkresume = new BLL.TeacherWorkResume();
        BLL.TeacherStudyResume bllteacherstudayresume = new BLL.TeacherStudyResume();
        BLL.TeacherTeachResume bllteacherteachresume = new BLL.TeacherTeachResume();
        Model.TeacherInfo modelteacherinfo = new Model.TeacherInfo();
        Model.TeacherWorkResume modelteacherworkresume = new Model.TeacherWorkResume();
        Model.TeacherStudyResume modelstudyresume = new Model.TeacherStudyResume();
        Model.TeacherTeachResume modelteachresum = new Model.TeacherTeachResume();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Teacher.Id == null)
            {
                Response.Write(sys.alertAndRedirect("对不起，你无权访问，请登陆", "login.aspx"));
                Response.End();
                return;
            }
            if (!IsPostBack)
            {
                BindData();
                BindGridViews();
                this.txtLoginName.Enabled = false;
            }
        }

        private void BindData()
        {
            string id = Teacher.Id;
            modelteacherinfo = bllteacherinfo.GetModel(Convert.ToInt32(id));
            if (modelteacherinfo == null)
            {
                return;
            }
            txtLoginName.Text = modelteacherinfo.dbo_LoginName;
            name.Text = modelteacherinfo.dbo_Name;
            sex.Text = modelteacherinfo.dbo_Sex;
            minzu.Text = modelteacherinfo.dbo_Minzu;
            if (modelteacherinfo.dbo_BirthDay!= "")
            {
                birthday.Text = Convert.ToDateTime(modelteacherinfo.dbo_BirthDay).ToString("yyyy-MM-dd");
            }
            party.Text = modelteacherinfo.dbo_Party;
            if (modelteacherinfo.dbo_ParthTime!= "")
            {
                party_time.Text = Convert.ToDateTime(modelteacherinfo.dbo_ParthTime).ToString("yyyy-MM-dd");
            }
            degree.Text = modelteacherinfo.dbo_Degree;
            school.Text = modelteacherinfo.dbo_School;
            xueli.Text = modelteacherinfo.dbo_XueLi;
            txtRemarks.Text = modelteacherinfo.dbo_Remarks; 
            if (modelteacherinfo.dbo_WorkTime!= "")
            {
                work_time.Text = Convert.ToDateTime(modelteacherinfo.dbo_WorkTime).ToString("yyyy-MM-dd");
            }
            title.Text = modelteacherinfo.dbo_Title;
            if (modelteacherinfo.dbo_EmpTime!= "")
            {
                emp_time.Text = Convert.ToDateTime(modelteacherinfo.dbo_EmpTime).ToString("yyyy-MM-dd");
            }
            info_base.Text = modelteacherinfo.dbo_InfoBase;
            info_teac.Text = modelteacherinfo.dbo_InfoTeac;
            info_study.Text = modelteacherinfo.dbo_InfoStudy;
            string strPhoto = (modelteacherinfo.dbo_Photo.Trim() == "") ? "" : modelteacherinfo.dbo_Photo;
            if (strPhoto.Trim() == "")
            {
                strPhoto = "noPhoto.png";
            }
            photo.ImageUrl = @"\uploads\teacherPhoto\" + strPhoto;
            title.Text = modelteacherinfo.dbo_Title;
            txtProfessional.Text = modelteacherinfo.dbo_Professional;
            txtEmail.Text = modelteacherinfo.dbo_Email;
            txtJiGuan.Text = modelteacherinfo.dbo_JiGuan;
            txtHomeAddress.Text = modelteacherinfo.dbo_HomeAddress;
            txtOfficePhone.Text = modelteacherinfo.dbo_OfficePhone;
            txtHomePhone.Text = modelteacherinfo.dbo_HomePhone;
            txtMobilePhone.Text = modelteacherinfo.dbo_MobilePhone;
            txtShortNum.Text = modelteacherinfo.dbo_ShortNumber; 
        }

        protected void saveBtn_Click(object sender, EventArgs e)
        {
            string id = Teacher.Id;
            modelteacherinfo = bllteacherinfo.GetModel(Convert.ToInt32(id));
            modelteacherinfo.dbo_Name = name.Text.Trim();
            modelteacherinfo.dbo_Sex = sex.Text.Trim();
            modelteacherinfo.dbo_Minzu = minzu.Text.Trim();
            modelteacherinfo.dbo_BirthDay = birthday.Text.Trim();
            modelteacherinfo.dbo_Party = party.Text.Trim();
            modelteacherinfo.dbo_ParthTime = party_time.Text.Trim();
            modelteacherinfo.dbo_Degree = degree.Text.Trim();
            modelteacherinfo.dbo_School = school.Text.Trim();
            modelteacherinfo.dbo_XueLi = xueli.Text.Trim();
            modelteacherinfo.dbo_Remarks = txtRemarks.Text.Trim();
            modelteacherinfo.dbo_WorkTime = work_time.Text.Trim();
            modelteacherinfo.dbo_Title = title.Text.Trim();
            modelteacherinfo.dbo_EmpTime = emp_time.Text.Trim();
            modelteacherinfo.dbo_InfoBase = info_base.Text.Trim();
            modelteacherinfo.dbo_InfoTeac = info_teac.Text.Trim();
            modelteacherinfo.dbo_InfoStudy = info_study.Text.Trim();
            modelteacherinfo.dbo_Professional = txtProfessional.Text.Trim();
            modelteacherinfo.dbo_Email = txtEmail.Text.Trim();
            modelteacherinfo.dbo_JiGuan = txtJiGuan.Text.Trim();
            modelteacherinfo.dbo_HomeAddress = txtHomeAddress.Text.Trim();
            modelteacherinfo.dbo_OfficePhone = txtOfficePhone.Text.Trim();
            modelteacherinfo.dbo_HomePhone = txtHomePhone.Text.Trim();
            modelteacherinfo.dbo_MobilePhone = txtMobilePhone.Text.Trim();
            modelteacherinfo.dbo_ShortNumber = txtShortNum.Text.Trim();
            bool result = bllteacherinfo.Update(modelteacherinfo);

            if (this.file1.HasFile)
            {
                string Extension = System.IO.Path.GetExtension(this.file1.FileName);

                //判断文件是否允许上传               
                bool AllowUpload = false;
                string strFileType = System.Configuration.ConfigurationManager.AppSettings["AllowFileTypes"].ToString();
                string[] filetypes = strFileType.Split(',');

                for (int i = 0; i < filetypes.Length; i++)
                {
                    if (Extension == "." + filetypes[i].ToLower())
                    {
                        AllowUpload = true; break;
                    }
                }
                if (!AllowUpload)
                {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "alertfileNotAllow", "alert('您上传的的图片为不允许上传的类型，请重新添加')", true);
                    return;
                }

                string fileName = DateTime.Now.ToString("yyyyMMddhhmmss");
                file1.SaveAs(Server.MapPath(@"\uploads\teacherPhoto\" + fileName + Extension));
                modelteacherinfo = bllteacherinfo.GetModel(Convert.ToInt32(id));
                modelteacherinfo.dbo_Photo = fileName + Extension;
                bllteacherinfo.Update(modelteacherinfo);
                this.photo.ImageUrl = sys.AppPath+"uploads/teacherPhoto/" + fileName + Extension;
            }

            if (result ==true)
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "", "alert('保存成功！');", true);
            }

        }

        protected void BindGridViews()
        {
            DataTable dt1 = bllteacherworkresume.GetList("dbo_TeacherId=" + Teacher.Id).Tables[0];
            this.GridView1.DataSource = dt1;
            this.GridView1.DataBind();

            DataTable dt2 = bllteacherstudayresume.GetList("dbo_TeacherId=" + Teacher.Id).Tables[0];
            this.GridView2.DataSource = dt2;
            this.GridView2.DataBind();

            DataTable dt3 = bllteacherteachresume.GetList("dbo_TeacherId=" + Teacher.Id).Tables[0];
            this.GridView3.DataSource = dt3;
            this.GridView3.DataBind();
        }

        protected void btnSubmit1_Click(object sender, EventArgs e)
        {
            string start = this.txtStartTime1.Text;
            string end = this.txtendTime1.Text;
            string unit = this.txt_workunit.Text;
            string duty = this.txt_workduty.Text;

            if (ViewState["EditId1"] == null)
            {//添加
                modelteacherworkresume.dbo_StartTime = start;
                modelteacherworkresume.dbo_EndTime = end;
                modelteacherworkresume.dbo_Unit = unit;
                modelteacherworkresume.dbo_Duty = duty;
                modelteacherworkresume.dbo_TeacherId = Convert.ToInt32(Teacher.Id);
                bllteacherworkresume.Add(modelteacherworkresume);

                BindGridViews();
                sys.regisgerScirpt("window.location.hash='resumes1';\n", "tags");
                sys.alert("添加成功！");
            }
            else
            {//编辑

                string editId = ViewState["EditId1"].ToString();
                modelteacherworkresume = bllteacherworkresume.GetModel(Convert.ToInt32(editId));
                modelteacherworkresume.dbo_StartTime = start;
                modelteacherworkresume.dbo_EndTime = end;
                modelteacherworkresume.dbo_Unit = unit;
                modelteacherworkresume.dbo_Duty = duty;
                bllteacherworkresume.Update(modelteacherworkresume);
                this.BindGridViews();
                ViewState["EditId1"] = null;
                sys.regisgerScirpt("window.location.hash='resumes1';\n", "tags");
                sys.alert("编辑成功！");
            }
            this.txtStartTime1.Text = "";
            this.txtendTime1.Text = "";
            this.txt_workunit.Text = "";
            this.txt_workduty.Text = "";
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "myEdit")
            {
                ViewState["EditId1"] = e.CommandArgument;
                modelteacherworkresume = bllteacherworkresume.GetModel(Convert.ToInt32(e.CommandArgument));
                {
                    this.txtStartTime1.Text = modelteacherworkresume.dbo_StartTime;
                    this.txtendTime1.Text = modelteacherworkresume.dbo_EndTime;
                    this.txt_workunit.Text = modelteacherworkresume.dbo_Unit;
                    this.txt_workduty.Text = modelteacherworkresume.dbo_Duty; 
                }
                this.btnSubmit1.Text = "保存";
                //输出客户端脚本显示编辑内容 
                sys.regisgerScirpt("document.getElementById('pnl1').style.display = 'block';\n document.getElementById('btnAdd1').style.display='none';\n");
                sys.regisgerScirpt("window.location.hash='resumes1';\n", "tags");

            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string id = this.GridView1.DataKeys[e.RowIndex].Value.ToString();
            bllteacherworkresume.Delete(Convert.ToInt32(id));
            this.BindGridViews();
            sys.regisgerScirpt("window.location.hash='resumes1'");
        }

        protected void btnCancel1_Click(object sender, EventArgs e)
        {
            sys.regisgerScirpt("window.location.hash='resumes1'");
            ViewState["EditId1"] = null;
            this.btnSubmit1.Text = "添加";
            this.txtStartTime1.Text = "";
            this.txtendTime1.Text = "";
            this.txt_workunit.Text = "";
            this.txt_workduty.Text = "";
        }


        protected void GridView2_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string id = this.GridView2.DataKeys[e.RowIndex].Value.ToString();
            bllteacherstudayresume.Delete(Convert.ToInt32(id));
            this.BindGridViews();
            sys.regisgerScirpt("window.location.hash='resumes2'");
        }

        protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "myEdit")
            {
                ViewState["EditId2"] = e.CommandArgument;
                modelstudyresume = bllteacherstudayresume.GetModel(Convert.ToInt32(e.CommandArgument));
                if (modelstudyresume != null)
                {
                    this.txtStartTime2.Text = modelstudyresume.dbo_StartTime;
                    this.txtendTime2.Text = modelstudyresume.dbo_EndTime;
                    this.txtSchool.Text = modelstudyresume.dbo_School;
                    this.txtStudyProfessional.Text = modelstudyresume.dbo_Professional;
                    this.txtGraduateTime.Text = modelstudyresume.dbo_GraduateTime;
                }
                this.btnSubmit2.Text = "保存";
                //输出客户端脚本显示编辑内容 
                sys.regisgerScirpt("document.getElementById('pnl2').style.display = 'block';\n document.getElementById('btnAdd2').style.display='none';\n");
                sys.regisgerScirpt("window.location.hash='resumes2';\n", "tags");

            }
        }

        protected void btnSubmit2_Click(object sender, EventArgs e)
        {

            string start = this.txtStartTime2.Text;
            string end = this.txtendTime2.Text;
            string school = this.txtSchool.Text;
            string professional = this.txtStudyProfessional.Text;
            string graduateTime = this.txtGraduateTime.Text;

            if (ViewState["EditId2"] == null)
            {//添加
                modelstudyresume.dbo_StartTime = start;
                modelstudyresume.dbo_EndTime = end;
                modelstudyresume.dbo_School = school;
                modelstudyresume.dbo_Professional = professional;
                modelstudyresume.dbo_GraduateTime = graduateTime;
                modelstudyresume.dbo_TeacherId = Convert.ToInt32(Teacher.Id);
                bllteacherstudayresume.Add(modelstudyresume);

                BindGridViews();
                sys.regisgerScirpt("window.location.hash='resumes2';\n", "tags");
                sys.alert("添加成功！");
            }
            else
            {//编辑
                string editId = ViewState["EditId2"].ToString();
                modelstudyresume = bllteacherstudayresume.GetModel(Convert.ToInt32(editId));
                modelstudyresume.dbo_StartTime = start;
                modelstudyresume.dbo_EndTime = end;
                modelstudyresume.dbo_School = school;
                modelstudyresume.dbo_Professional = professional;
                modelstudyresume.dbo_GraduateTime = graduateTime;
                bllteacherstudayresume.Update(modelstudyresume);
                this.BindGridViews();
                ViewState["EditId2"] = null;
                sys.regisgerScirpt("window.location.hash='resumes2';\n", "tags");
                sys.alert("编辑成功！");
            }

            this.txtStartTime2.Text = "";
            this.txtendTime2.Text = "";
            this.txtSchool.Text = "";
            this.txtStudyProfessional.Text = "";
            this.txtGraduateTime.Text = "";
        }

        protected void btnCancel2_Click(object sender, EventArgs e)
        {
            sys.regisgerScirpt("window.location.hash='resumes2'");
            ViewState["EditId2"] = null;
            this.txtStartTime2.Text = "";
            this.txtendTime2.Text = "";
            this.txtSchool.Text = "";
            this.txtStudyProfessional.Text = "";
            this.txtGraduateTime.Text = "";
        }


        protected void GridView3_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string id = this.GridView3.DataKeys[e.RowIndex].Value.ToString();
            bllteacherteachresume.Delete(Convert.ToInt32(id));
            this.BindGridViews();
            sys.regisgerScirpt("window.location.hash='resumes3'");
        }

        protected void GridView3_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "myEdit")
            {
                ViewState["EditId3"] = e.CommandArgument;
                modelteachresum = bllteacherteachresume.GetModel(Convert.ToInt32(e.CommandArgument));
                if (modelteachresum != null)
                {
                    this.txtStartTime3.Text = modelteachresum.dbo_StartTime;
                    this.txtendTime3.Text = modelteachresum.dbo_EndTime;
                    this.txtTheClass.Text = modelteachresum.dbo_TheClass;
                    this.txtResult.Text = modelteachresum.dbo_Result;
                }
                this.btnSubmit3.Text = "保存";
                //输出客户端脚本显示编辑内容 
                sys.regisgerScirpt("document.getElementById('pnl3').style.display = 'block';\n document.getElementById('btnAdd3').style.display='none';\n");
                sys.regisgerScirpt("window.location.hash='resumes3';\n", "tags");

            }
        }

        protected void btnSubmit3_Click(object sender, EventArgs e)
        {
            string start = this.txtStartTime3.Text;
            string end = this.txtendTime3.Text;
            string theClass = this.txtTheClass.Text;
            string result = this.txtResult.Text;

            if (ViewState["EditId3"] == null)
            {//添加
                modelteachresum.dbo_StartTime = start;
                modelteachresum.dbo_EndTime = end;
                modelteachresum.dbo_TheClass = theClass;
                modelteachresum.dbo_Result = result;
                modelteachresum.dbo_TeacherId = Convert.ToInt32(Teacher.Id);
                bllteacherteachresume.Add(modelteachresum);

                BindGridViews();
                sys.regisgerScirpt("window.location.hash='resumes3';\n", "tags");
                sys.alert("添加成功！");
            }
            else
            {//编辑
                string editId = ViewState["EditId3"].ToString();
                modelteachresum = bllteacherteachresume.GetModel(Convert.ToInt32(editId));
                modelteachresum.dbo_StartTime = start;
                modelteachresum.dbo_EndTime = end;
                modelteachresum.dbo_TheClass = theClass;
                modelteachresum.dbo_Result = result;
                bllteacherteachresume.Update(modelteachresum);
                this.BindGridViews();
                ViewState["EditId3"] = null;
                sys.regisgerScirpt("window.location.hash='resumes3';\n", "tags");
                sys.alert("编辑成功！");
            }

            this.txtStartTime3.Text = "";
            this.txtendTime3.Text = "";
            this.txtTheClass.Text = "";
            this.txtResult.Text = "";
        }

        protected void btnCancel3_Click(object sender, EventArgs e)
        {
            sys.regisgerScirpt("window.location.hash='resumes3'");
            ViewState["EditId3"] = null;
            this.txtStartTime3.Text = "";
            this.txtendTime3.Text = "";
            this.txtTheClass.Text = "";
            this.txtResult.Text = "";

        }
    }
}