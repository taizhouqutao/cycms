using System;
namespace cycms.Model
{
	/// <summary>
	/// TeacherUpload:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class TeacherUpload
	{
		public TeacherUpload()
		{}
		#region Model
		private int _id;
		private string _dbo_filetitle;
		private string _dbo_filename;
		private string _dbo_otherinfo;
		private int? _dbo_filesize;
		private int? _dbo_uploaderid;
		private DateTime? _dbo_ptime;
		private string _dbo_downpwd;
		private string _dbo_uploaderteachername;
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
		public string dbo_FileTitle
		{
			set{ _dbo_filetitle=value;}
			get{return _dbo_filetitle;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string dbo_FileName
		{
			set{ _dbo_filename=value;}
			get{return _dbo_filename;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string dbo_OtherInfo
		{
			set{ _dbo_otherinfo=value;}
			get{return _dbo_otherinfo;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? dbo_FileSize
		{
			set{ _dbo_filesize=value;}
			get{return _dbo_filesize;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? dbo_UploaderId
		{
			set{ _dbo_uploaderid=value;}
			get{return _dbo_uploaderid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? dbo_Ptime
		{
			set{ _dbo_ptime=value;}
			get{return _dbo_ptime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string dbo_DownPwd
		{
			set{ _dbo_downpwd=value;}
			get{return _dbo_downpwd;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string dbo_UploaderTeacherName
		{
			set{ _dbo_uploaderteachername=value;}
			get{return _dbo_uploaderteachername;}
		}
		#endregion Model

	}
}

