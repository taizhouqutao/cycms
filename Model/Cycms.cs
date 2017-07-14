using System;
namespace cycms.Model
{
	/// <summary>
	/// Cycms:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Cycms
	{
		public Cycms()
		{}
		#region Model
		private int _id;
		private bool _dbo_isrunning= false;
		private bool _dbo_isstatic= false;
		private string _dbo_webaddress;
		private string _dbo_webname;
		private int? _dbo_staticlistpages;
		private int? _dbo_visitedtimes;
		private string _dbo_smtpserver;
		private string _dbo_mailaddress;
		private string _dbo_mailname;
		private string _dbo_mailpwd;
		private string _dbo_workplace;
		private string _dbo_lianxiren;
		private string _dbo_cellphone;
		private string _dbo_flax;
		private string _dbo_workpohne;
		private string _dbo_beianhao;
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
		public bool dbo_IsRunning
		{
			set{ _dbo_isrunning=value;}
			get{return _dbo_isrunning;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool dbo_IsStatic
		{
			set{ _dbo_isstatic=value;}
			get{return _dbo_isstatic;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string dbo_WebAddress
		{
			set{ _dbo_webaddress=value;}
			get{return _dbo_webaddress;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string dbo_WebName
		{
			set{ _dbo_webname=value;}
			get{return _dbo_webname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? dbo_StaticListPages
		{
			set{ _dbo_staticlistpages=value;}
			get{return _dbo_staticlistpages;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? dbo_VisitedTimes
		{
			set{ _dbo_visitedtimes=value;}
			get{return _dbo_visitedtimes;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string dbo_SmtpServer
		{
			set{ _dbo_smtpserver=value;}
			get{return _dbo_smtpserver;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string dbo_MailAddress
		{
			set{ _dbo_mailaddress=value;}
			get{return _dbo_mailaddress;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string dbo_MailName
		{
			set{ _dbo_mailname=value;}
			get{return _dbo_mailname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string dbo_MailPwd
		{
			set{ _dbo_mailpwd=value;}
			get{return _dbo_mailpwd;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string dbo_WorkPlace
		{
			set{ _dbo_workplace=value;}
			get{return _dbo_workplace;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string dbo_LianXiRen
		{
			set{ _dbo_lianxiren=value;}
			get{return _dbo_lianxiren;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string dbo_CellPhone
		{
			set{ _dbo_cellphone=value;}
			get{return _dbo_cellphone;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string dbo_Flax
		{
			set{ _dbo_flax=value;}
			get{return _dbo_flax;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string dbo_WorkPohne
		{
			set{ _dbo_workpohne=value;}
			get{return _dbo_workpohne;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string dbo_BeiAnHao
		{
			set{ _dbo_beianhao=value;}
			get{return _dbo_beianhao;}
		}
		#endregion Model

	}
}

