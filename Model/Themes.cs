using System;
namespace cycms.Model
{
	/// <summary>
	/// Themes:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Themes
	{
		public Themes()
		{}
		#region Model
		private int _id;
		private string _dbo_themesname;
		private bool _dbo_ifuse= false;
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
		public string dbo_ThemesName
		{
			set{ _dbo_themesname=value;}
			get{return _dbo_themesname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool dbo_Ifuse
		{
			set{ _dbo_ifuse=value;}
			get{return _dbo_ifuse;}
		}
		#endregion Model

	}
}

