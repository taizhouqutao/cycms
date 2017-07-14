using System;
namespace cycms.Model
{
	/// <summary>
	/// HtmlPage:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class HtmlPage
	{
		public HtmlPage()
		{
            dbo_Ptime = DateTime.Now;
        }
		#region Model
		private int _id;
		private string _dbo_htmlname;
		private string _dbo_pagetitle;
		private string _dbo_pagecontent;
		private string _dbo_template;
		private string _dbo_pagepath;
		private DateTime? _dbo_ptime;
		private int? _dbo_spcid;
		private bool _dbo_isshow= false;
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
		public string dbo_HtmlName
		{
			set{ _dbo_htmlname=value;}
			get{return _dbo_htmlname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string dbo_PageTitle
		{
			set{ _dbo_pagetitle=value;}
			get{return _dbo_pagetitle;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string dbo_PageContent
		{
			set{ _dbo_pagecontent=value;}
			get{return _dbo_pagecontent;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string dbo_Template
		{
			set{ _dbo_template=value;}
			get{return _dbo_template;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string dbo_PagePath
		{
			set{ _dbo_pagepath=value;}
			get{return _dbo_pagepath;}
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
		public int? dbo_SpcId
		{
			set{ _dbo_spcid=value;}
			get{return _dbo_spcid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool dbo_IsShow
		{
			set{ _dbo_isshow=value;}
			get{return _dbo_isshow;}
		}
		#endregion Model

	}
}

