using System;
namespace cycms.Model
{
	/// <summary>
	/// Admin:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Admin
	{
		public Admin()
		{
            dbo_LastLoginTime = DateTime.Now;
            dbo_LoginTimes = 0;
            dbo_LastLoginIp = "";
            dbo_Power = "";
        }
		#region Model
		private int _id;
		private string _dbo_username;
		private string _dbo_password;
		private DateTime? _dbo_lastlogintime;
		private string _dbo_lastloginip;
		private string _dbo_power;
		private int? _dbo_logintimes;
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
		public string dbo_UserName
		{
			set{ _dbo_username=value;}
			get{return _dbo_username;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string dbo_PassWord
		{
			set{ _dbo_password=value;}
			get{return _dbo_password;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? dbo_LastLoginTime
		{
			set{ _dbo_lastlogintime=value;}
			get{return _dbo_lastlogintime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string dbo_LastLoginIp
		{
			set{ _dbo_lastloginip=value;}
			get{return _dbo_lastloginip;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string dbo_Power
		{
			set{ _dbo_power=value;}
			get{return _dbo_power;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? dbo_LoginTimes
		{
			set{ _dbo_logintimes=value;}
			get{return _dbo_logintimes;}
		}
		#endregion Model

	}
}

