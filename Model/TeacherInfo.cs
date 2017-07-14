using System;
namespace cycms.Model
{
	/// <summary>
	/// TeacherInfo:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class TeacherInfo
	{
		public TeacherInfo()
		{
            dbo_Group = 1;
            dbo_Order = 1;
            dbo_ForeignLang = "";
            dbo_EmpNum = "";
        }
		#region Model
		private int _id;
		private string _dbo_loginname;
		private string _dbo_password;
		private string _dbo_name;
		private string _dbo_photo;
		private string _dbo_email;
		private string _dbo_title;
		private string _dbo_degree;
		private string _dbo_professional;
		private int? _dbo_group;
		private string _dbo_infobase;
		private string _dbo_infoteac;
		private string _dbo_infostudy;
		private int? _dbo_order;
		private string _dbo_sex;
		private string _dbo_minzu;
		private string _dbo_birthday;
		private string _dbo_jiguan;
		private string _dbo_party;
		private string _dbo_parthtime;
		private string _dbo_foreignlang;
		private string _dbo_xueli;
		private string _dbo_worktime;
		private string _dbo_emptime;
		private string _dbo_empnum;
		private string _dbo_school;
		private string _dbo_remarks;
		private string _dbo_officephone;
		private string _dbo_homephone;
		private string _dbo_mobilephone;
		private string _dbo_shortnumber;
		private string _dbo_homeaddress;
		private bool _dbo_isdisplay= false;
		/// <summary>
		/// 
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string dbo_LoginName
		{
			set{ _dbo_loginname=value;}
			get{return _dbo_loginname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string dbo_PassWord
		{
			set{ _dbo_password=value;}
			get{return _dbo_password;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string dbo_Name
		{
			set{ _dbo_name=value;}
			get{return _dbo_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string dbo_Photo
		{
			set{ _dbo_photo=value;}
			get{return _dbo_photo;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string dbo_Email
		{
			set{ _dbo_email=value;}
			get{return _dbo_email;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string dbo_Title
		{
			set{ _dbo_title=value;}
			get{return _dbo_title;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string dbo_Degree
		{
			set{ _dbo_degree=value;}
			get{return _dbo_degree;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string dbo_Professional
		{
			set{ _dbo_professional=value;}
			get{return _dbo_professional;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? dbo_Group
		{
			set{ _dbo_group=value;}
			get{return _dbo_group;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string dbo_InfoBase
		{
			set{ _dbo_infobase=value;}
			get{return _dbo_infobase;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string dbo_InfoTeac
		{
			set{ _dbo_infoteac=value;}
			get{return _dbo_infoteac;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string dbo_InfoStudy
		{
			set{ _dbo_infostudy=value;}
			get{return _dbo_infostudy;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? dbo_Order
		{
			set{ _dbo_order=value;}
			get{return _dbo_order;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string dbo_Sex
		{
			set{ _dbo_sex=value;}
			get{return _dbo_sex;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string dbo_Minzu
		{
			set{ _dbo_minzu=value;}
			get{return _dbo_minzu;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string dbo_BirthDay
		{
			set{ _dbo_birthday=value;}
			get{return _dbo_birthday;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string dbo_JiGuan
		{
			set{ _dbo_jiguan=value;}
			get{return _dbo_jiguan;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string dbo_Party
		{
			set{ _dbo_party=value;}
			get{return _dbo_party;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string dbo_ParthTime
		{
			set{ _dbo_parthtime=value;}
			get{return _dbo_parthtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string dbo_ForeignLang
		{
			set{ _dbo_foreignlang=value;}
			get{return _dbo_foreignlang;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string dbo_XueLi
		{
			set{ _dbo_xueli=value;}
			get{return _dbo_xueli;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string dbo_WorkTime
		{
			set{ _dbo_worktime=value;}
			get{return _dbo_worktime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string dbo_EmpTime
		{
			set{ _dbo_emptime=value;}
			get{return _dbo_emptime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string dbo_EmpNum
		{
			set{ _dbo_empnum=value;}
			get{return _dbo_empnum;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string dbo_School
		{
			set{ _dbo_school=value;}
			get{return _dbo_school;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string dbo_Remarks
		{
			set{ _dbo_remarks=value;}
			get{return _dbo_remarks;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string dbo_OfficePhone
		{
			set{ _dbo_officephone=value;}
			get{return _dbo_officephone;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string dbo_HomePhone
		{
			set{ _dbo_homephone=value;}
			get{return _dbo_homephone;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string dbo_MobilePhone
		{
			set{ _dbo_mobilephone=value;}
			get{return _dbo_mobilephone;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string dbo_ShortNumber
		{
			set{ _dbo_shortnumber=value;}
			get{return _dbo_shortnumber;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string dbo_HomeAddress
		{
			set{ _dbo_homeaddress=value;}
			get{return _dbo_homeaddress;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool dbo_IsDisplay
		{
			set{ _dbo_isdisplay=value;}
			get{return _dbo_isdisplay;}
		}
		#endregion Model

	}
}

