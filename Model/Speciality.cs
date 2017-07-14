using System;
namespace cycms.Model
{
	/// <summary>
	/// Speciality:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Speciality
	{
		public Speciality()
		{}
		#region Model
		private int _id;
		private string _dbo_name;
		private string _dbo_htmldir;
		private string _dbo_contenthtml;
		private bool _dbo_ifshow= false;
		private string _dbo_linkurl;
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
		public string dbo_Name
		{
			set{ _dbo_name=value;}
			get{return _dbo_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string dbo_HtmlDir
		{
			set{ _dbo_htmldir=value;}
			get{return _dbo_htmldir;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string dbo_ContentHtml
		{
			set{ _dbo_contenthtml=value;}
			get{return _dbo_contenthtml;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool dbo_IfShow
		{
			set{ _dbo_ifshow=value;}
			get{return _dbo_ifshow;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string dbo_LinkUrl
		{
			set{ _dbo_linkurl=value;}
			get{return _dbo_linkurl;}
		}
		#endregion Model

	}
}

