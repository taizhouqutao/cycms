using System;
namespace cycms.Model
{
	/// <summary>
	/// IPHistry:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class IPHistry
	{
		public IPHistry()
		{}
		#region Model
		private int _id;
		private string _dbo_ipaddress;
		private string _dbo_address;
		private string _dbo_area;
		private DateTime? _dbo_ptime;
		private string _dbo_browser;
		private string _dbo_platform;
		private string _dbo_pagetitle;
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
		public string dbo_IPAddress
		{
			set{ _dbo_ipaddress=value;}
			get{return _dbo_ipaddress;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string dbo_Address
		{
			set{ _dbo_address=value;}
			get{return _dbo_address;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string dbo_Area
		{
			set{ _dbo_area=value;}
			get{return _dbo_area;}
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
		public string dbo_Browser
		{
			set{ _dbo_browser=value;}
			get{return _dbo_browser;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string dbo_Platform
		{
			set{ _dbo_platform=value;}
			get{return _dbo_platform;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string dbo_PageTitle
		{
			set{ _dbo_pagetitle=value;}
			get{return _dbo_pagetitle;}
		}
		#endregion Model

	}
}

