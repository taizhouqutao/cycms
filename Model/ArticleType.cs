using System;
namespace cycms.Model
{
	/// <summary>
	/// ArticleType:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class ArticleType
	{
		public ArticleType()
		{}
		#region Model
		private int _id;
		private string _dbo_typename;
		private string _dbo_linkurl;
		private int? _dbo_fatherid;
		private bool _dbo_isdisplay= false;
		private int? _dbo_specialityid;
		private bool _dbo_isarticletype= false;
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
		public string dbo_TypeName
		{
			set{ _dbo_typename=value;}
			get{return _dbo_typename;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string dbo_LinkUrl
		{
			set{ _dbo_linkurl=value;}
			get{return _dbo_linkurl;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? dbo_Fatherid
		{
			set{ _dbo_fatherid=value;}
			get{return _dbo_fatherid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool dbo_IsDisplay
		{
			set{ _dbo_isdisplay=value;}
			get{return _dbo_isdisplay;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? dbo_SpecialityId
		{
			set{ _dbo_specialityid=value;}
			get{return _dbo_specialityid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool dbo_IsArticleType
		{
			set{ _dbo_isarticletype=value;}
			get{return _dbo_isarticletype;}
		}
		#endregion Model

	}
}

