using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace Adapte
{
    public class currentAdmin
    {
        public static string Name
        {
            get
            {
                if (HttpContext.Current.Request.Cookies["adminName"] != null)
                {
                    return HttpContext.Current.Request.Cookies["adminName"].Value;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                HttpContext.Current.Response.Cookies["adminName"].Value = value;
            }
        }

        public static string Id
        {
            get
            {
                if (HttpContext.Current.Request.Cookies["adminId"] != null)
                {
                    return sys.str_DesDecrypt(HttpContext.Current.Request.Cookies["adminId"].Value, currentAdmin.Name + "chaoycycms");
                }
                else
                {
                    return null;
                }
            }
            set
            {
                HttpContext.Current.Response.Cookies["adminId"].Value = sys.str_DesEncrypt(value, currentAdmin.Name + "chaoycycms");
            }
        }

        public static string strPower
        {
            get
            {
                if (HttpContext.Current.Request.Cookies["adminPower"] != null)
                {
                    string power = HttpContext.Current.Request.Cookies["adminPower"].Value;
                    return sys.str_DesDecrypt(power, currentAdmin.Name + "chaoycycms");
                }
                else
                {
                    return null;
                }
            }
            set
            {
                string power = sys.str_DesEncrypt(value, currentAdmin.Name + "chaoycycms");
                HttpContext.Current.Response.Cookies["adminPower"].Value = power;
            }
        }

        public static string[,] Channels
        {
            get
            {
                if (strPower == "super" || strPower == "")
                {
                    return null;
                }

                string[] p = strPower.Split('$');
                string[,] channels = new string[p.Length, 2];

                for (int i = 0; i < p.Length; i++)
                {
                    string[] CT = p[i].Split('#');
                    channels[i, 0] = CT[0];
                    channels[i, 1] = CT[1];
                }
                return channels;
            }
        }

        public static bool IsSuper
        {
            get
            {
                if (strPower == "super")
                {
                    return true;
                }
                return false;
            }
        }

        public static bool validationSpcEditor(string spcId)
        {
            try
            {
                if (IsSuper)
                {
                    return true;
                }
                for (int i = 0; i < Channels.GetLength(0); i++)
                {
                    if (Channels[i, 0] == spcId)
                    {
                        return true;
                    }
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public static bool validationSpcAdmin(string spcId)
        {
            try
            {
                if (IsSuper)
                {
                    return true;
                }
                for (int i = 0; i < Channels.GetLength(0); i++)
                {
                    if (Channels[i, 0] == spcId && Channels[i, 1] == "0")
                    {
                        return true;
                    }
                }
                return false;
            }
            catch
            {
                return false;
            }
        }           
    }

    public class adminOpers
    {
        /*频道id#频道类型权限$频道id#频道类型权限*/
        public static string[,] getChannels(string strPower)
        {
            if (strPower == "super" || strPower == "")
            {
                return null;
            }

            string[] p = strPower.Split('$');
            string[,] channels = new string[p.Length, 2];

            for (int i = 0; i < p.Length; i++)
            {
                string[] CT = p[i].Split('#');
                channels[i, 0] = CT[0];
                channels[i, 1] = CT[1];
            }
            return channels;

        }

        public static string ChannelsToString(string[,] channel)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < channel.GetLength(0); i++)
            {
                if (sb.Length != 0)
                {
                    sb.Append("$");
                }
                sb.Append(channel[i, 0] + "#" + channel[i, 1]);

            }
            return sb.ToString();
        }

        //频道管理员返回0，频道编辑返回有权限的类型(频道里面没有任何编辑权限则为-2)，没有任何权限返回-1
        public static string getChannelPower(string channelId, string[,] Channels)
        {
            if (Channels == null)
            {
                return "-1";
            }
            string[,] channels = Channels;
            for (int i = 0; i < Channels.GetLength(0); i++)
            {
                if (channels[i, 0] == channelId)
                {
                    return channels[i, 1];
                }
            }
            return "-1";
        }

        public static void ShowNoPower()
        {
            HttpContext.Current.Response.Write("您无权访问该页，错误原因：1.非法进入；2.权限不足。请登陆后访问！");
            HttpContext.Current.Response.End();
        }
    }
}
