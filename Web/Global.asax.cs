using System;
using System.Web;
using System.Collections;
using System.ComponentModel;
using System.Web.SessionState;
using System.Configuration;
using System.Data;
using System.IO;
using System.Web.Security;
using Adapte;
namespace cycms.Web 
{
	/// <summary>
	/// Global 的摘要说明。
	/// </summary>
	public class Global : System.Web.HttpApplication
	{
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		public Global()
		{
			InitializeComponent();
		}	
		
		protected void Application_Start(Object sender, EventArgs e)
		{
            sys.initSys();
		}
 
		protected void Session_Start(Object sender, EventArgs e)
		{
            try
            {
                int times = Convert.ToInt32(sys.VisitedTimes);
                times++;
                sys.VisitedTimes = times.ToString();
            }
            catch
            { 
                
            }
		}
		protected void Application_BeginRequest(Object sender, EventArgs e)
		{
            if (!sys.IsRunning && Request.Url.AbsolutePath.IndexOf("admin") == -1)
            {
                Response.Write("站点维护中，请稍后访问");
                Response.End();
                return;
            }
		}
		protected void Application_EndRequest(Object sender, EventArgs e)
		{
		}
		protected void Application_AuthenticateRequest(Object sender, EventArgs e)
		{
		}
		protected void Application_Error(Object sender, EventArgs e)
		{
			Exception err = Server.GetLastError();
            if (err != null)
            {

                string message = err.Message;

                Response.Redirect("/error.html?message=" + Server.UrlEncode(message));
                Response.Write(message);
            }
		}
		protected void Session_End(Object sender, EventArgs e)
		{		
			
		}
		protected void Application_End(Object sender, EventArgs e)
		{
            sys.endSys();
		}
			
		#region Web 窗体设计器生成的代码
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{    
			this.components = new System.ComponentModel.Container();
		}
		#endregion
	}
}

