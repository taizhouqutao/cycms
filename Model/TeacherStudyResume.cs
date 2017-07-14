using System;
namespace cycms.Model
{
	/// <summary>
	/// TeacherStudyResume:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class TeacherStudyResume
	{
		public TeacherStudyResume()
		{
            dbo_Remark = "";
        }
		#region Model
		private int _id;
		private string _dbo_starttime;
		private string _dbo_endtime;
		private string _dbo_school;
		private string _dbo_professional;
		private string _dbo_graduatetime;
		private string _dbo_remark;
		private int? _dbo_teacherid;
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
		public string dbo_StartTime
		{
			set{ _dbo_starttime=value;}
			get{return _dbo_starttime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string dbo_EndTime
		{
			set{ _dbo_endtime=value;}
			get{return _dbo_endtime;}
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
		public string dbo_Professional
		{
			set{ _dbo_professional=value;}
			get{return _dbo_professional;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string dbo_GraduateTime
		{
			set{ _dbo_graduatetime=value;}
			get{return _dbo_graduatetime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string dbo_Remark
		{
			set{ _dbo_remark=value;}
			get{return _dbo_remark;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? dbo_TeacherId
		{
			set{ _dbo_teacherid=value;}
			get{return _dbo_teacherid;}
		}
		#endregion Model

	}
}

