using System;
namespace cycms.Model
{
	/// <summary>
	/// DownLoadFile:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class DownLoadFile
	{
		public DownLoadFile()
		{
            dbo_Ptime = DateTime.Now;
        }
		#region Model
		private int _id;
		private string _dbo_filename;
		private string _dbo_filetitle;
		private int? _dbo_filesize;
		private DateTime? _dbo_ptime;
		private string _dbo_otherinfo;
		private int? _dbo_typeid;
		private bool _dbo_islock= false;
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
		public string dbo_FileName
		{
			set{ _dbo_filename=value;}
			get{return _dbo_filename;}
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
		public int? dbo_FileSize
		{
			set{ _dbo_filesize=value;}
			get{return _dbo_filesize;}
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
		public string dbo_OtherInfo
		{
			set{ _dbo_otherinfo=value;}
			get{return _dbo_otherinfo;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? dbo_TypeId
		{
			set{ _dbo_typeid=value;}
			get{return _dbo_typeid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool dbo_IsLock
		{
			set{ _dbo_islock=value;}
			get{return _dbo_islock;}
		}
		#endregion Model

	}
}

