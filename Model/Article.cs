using System;
namespace cycms.Model
{
	/// <summary>
	/// Article:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Article
	{
		public Article()
		{
            dbo_Ptime = DateTime.Now;
        }
		#region Model
		private int _id;
		private string _dbo_title;
		private int? _dbo_typeid;
		private string _dbo_content;
		private string _dbo_author;
		private string _dbo_source;
		private int? _dbo_click;
		private DateTime? _dbo_ptime;
		private string _dbo_fujian;
		private bool _dbo_islock= false;
		private bool _dbo_istop= false;
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
		public string dbo_Title
		{
			set{ _dbo_title=value;}
			get{return _dbo_title;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? dbo_Typeid
		{
			set{ _dbo_typeid=value;}
			get{return _dbo_typeid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string dbo_Content
		{
			set{ _dbo_content=value;}
			get{return _dbo_content;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string dbo_Author
		{
			set{ _dbo_author=value;}
			get{return _dbo_author;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string dbo_Source
		{
			set{ _dbo_source=value;}
			get{return _dbo_source;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? dbo_Click
		{
			set{ _dbo_click=value;}
			get{return _dbo_click;}
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
		public string dbo_Fujian
		{
			set{ _dbo_fujian=value;}
			get{return _dbo_fujian;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool dbo_IsLock
		{
			set{ _dbo_islock=value;}
			get{return _dbo_islock;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool dbo_IsTop
		{
			set{ _dbo_istop=value;}
			get{return _dbo_istop;}
		}
		#endregion Model

	}
}

