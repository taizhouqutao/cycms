using System;
namespace cycms.Model
{
	/// <summary>
	/// TeacherTeachResume:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class TeacherTeachResume
	{
		public TeacherTeachResume()
		{
            dbo_Remark = "";
        }
		#region Model
		private int _id;
		private string _dbo_starttime;
		private string _dbo_endtime;
		private string _dbo_theclass;
		private string _dbo_result;
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
		public string dbo_TheClass
		{
			set{ _dbo_theclass=value;}
			get{return _dbo_theclass;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string dbo_Result
		{
			set{ _dbo_result=value;}
			get{return _dbo_result;}
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

