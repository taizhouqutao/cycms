using System;
namespace cycms.Model
{
	/// <summary>
	/// GuestBook:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class GuestBook
	{
		public GuestBook()
		{
            dbo_Ptime = DateTime.Now;
            dbo_ReplyTime = DateTime.Now;
        }
		#region Model
		private int _id;
		private string _dbo_title;
		private string _dbo_content;
		private string _dbo_name;
		private string _dbo_sex;
		private string _dbo_email;
		private bool _dbo_isshow= false;
		private DateTime? _dbo_ptime;
		private bool _dbo_isreply= false;
		private string _dbo_replycontent;
		private DateTime? _dbo_replytime;
		private int? _dbo_guesttype;
		private string _dbo_guesttypename;
		private string _dbo_workname;
		private string _dbo_flax;
		private string _dbo_cellphone;
		private string _dbo_address;
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
		public string dbo_Content
		{
			set{ _dbo_content=value;}
			get{return _dbo_content;}
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
		public string dbo_Sex
		{
			set{ _dbo_sex=value;}
			get{return _dbo_sex;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string dbo_Email
		{
			set{ _dbo_email=value;}
			get{return _dbo_email;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool dbo_IsShow
		{
			set{ _dbo_isshow=value;}
			get{return _dbo_isshow;}
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
		public bool dbo_IsReply
		{
			set{ _dbo_isreply=value;}
			get{return _dbo_isreply;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string dbo_ReplyContent
		{
			set{ _dbo_replycontent=value;}
			get{return _dbo_replycontent;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? dbo_ReplyTime
		{
			set{ _dbo_replytime=value;}
			get{return _dbo_replytime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? dbo_GuestType
		{
			set{ _dbo_guesttype=value;}
			get{return _dbo_guesttype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string dbo_GuestTypeName
		{
			set{ _dbo_guesttypename=value;}
			get{return _dbo_guesttypename;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string dbo_WorkName
		{
			set{ _dbo_workname=value;}
			get{return _dbo_workname;}
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
		public string dbo_CellPhone
		{
			set{ _dbo_cellphone=value;}
			get{return _dbo_cellphone;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string dbo_Address
		{
			set{ _dbo_address=value;}
			get{return _dbo_address;}
		}
		#endregion Model

	}
}

