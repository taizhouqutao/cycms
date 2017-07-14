using System;
namespace cycms.Model
{
	/// <summary>
	/// FriendLink:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class FriendLink
	{
		public FriendLink()
		{}
		#region Model
		private int _id;
		private string _dbo_factorylink;
		private string _dbo_factoryproductname;
		private string _dbo_factorylogosrc;
		private string _dbo_productimglink;
		private string _dbo_productimgsrc;
		private string _dbo_productimgname;
		private string _dbo_productinfo;
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
		public string dbo_FactoryLink
		{
			set{ _dbo_factorylink=value;}
			get{return _dbo_factorylink;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string dbo_FactoryProductName
		{
			set{ _dbo_factoryproductname=value;}
			get{return _dbo_factoryproductname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string dbo_FactoryLogoSrc
		{
			set{ _dbo_factorylogosrc=value;}
			get{return _dbo_factorylogosrc;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string dbo_ProductImgLink
		{
			set{ _dbo_productimglink=value;}
			get{return _dbo_productimglink;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string dbo_ProductImgSrc
		{
			set{ _dbo_productimgsrc=value;}
			get{return _dbo_productimgsrc;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string dbo_ProductImgName
		{
			set{ _dbo_productimgname=value;}
			get{return _dbo_productimgname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string dbo_ProductInfo
		{
			set{ _dbo_productinfo=value;}
			get{return _dbo_productinfo;}
		}
		#endregion Model

	}
}

