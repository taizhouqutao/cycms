using System;
namespace cycms.Model
{
	/// <summary>
	/// DownLoadType:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class DownLoadType
	{
		public DownLoadType()
		{}
		#region Model
		private int _id;
		private string _dbo_typename;
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
		#endregion Model

	}
}

