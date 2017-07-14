using System;
namespace cycms.Model
{
	/// <summary>
	/// ArticleImg:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class ArticleImg
	{
		public ArticleImg()
		{}
		#region Model
		private int _id;
		private string _dbo_imgsrc;
		private int? _dbo_articleid;
		private int? _dbo_specialityid;
		private string _dbo_imgbigsrc;
		private string _dbo_imgart;
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
		public string dbo_ImgSrc
		{
			set{ _dbo_imgsrc=value;}
			get{return _dbo_imgsrc;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? dbo_articleId
		{
			set{ _dbo_articleid=value;}
			get{return _dbo_articleid;}
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
		public string dbo_ImgBigSrc
		{
			set{ _dbo_imgbigsrc=value;}
			get{return _dbo_imgbigsrc;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string dbo_ImgArt
		{
			set{ _dbo_imgart=value;}
			get{return _dbo_imgart;}
		}
		#endregion Model

	}
}

