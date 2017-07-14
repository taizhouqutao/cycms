using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
namespace Adapte
{
    public class Teacher
    {
        public static string Name
        {
            get
            {
                if (HttpContext.Current.Request.Cookies["Name"] != null && HttpContext.Current.Request.Cookies["Name"].Value != "")
                {
                    return HttpContext.Current.Server.UrlDecode(HttpContext.Current.Request.Cookies["Name"].Value);
                }
                else
                {
                    return null;
                }
            }
            set
            {
                HttpContext.Current.Response.Cookies["Name"].Value = HttpContext.Current.Server.UrlEncode(value);
            }
        }
        public static string Id
        {
            get
            {
                if (HttpContext.Current.Request.Cookies["Id"] != null && HttpContext.Current.Request.Cookies["Id"].Value != "")
                {
                    return HttpContext.Current.Server.UrlDecode(HttpContext.Current.Request.Cookies["Id"].Value);
                }
                else
                {
                    return null;
                }
            }
            set
            {
                HttpContext.Current.Response.Cookies["Id"].Value = HttpContext.Current.Server.UrlEncode(value);
            }

        }

        public static string RealName
        {
            get
            {
                if (HttpContext.Current.Request.Cookies["RealName"] != null && HttpContext.Current.Request.Cookies["RealName"].Value != "")
                {
                    return HttpContext.Current.Server.UrlDecode(HttpContext.Current.Request.Cookies["RealName"].Value);
                }
                else
                {
                    return null;
                }
            }
            set
            {
                HttpContext.Current.Response.Cookies["RealName"].Value = HttpContext.Current.Server.UrlEncode(value);
            }

        }
    }
}
