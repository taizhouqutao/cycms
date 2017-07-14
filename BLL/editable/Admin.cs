using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using cycms.Model;
using System.Web;
namespace cycms.BLL
{
    /// <summary>
    /// Admin
    /// </summary>
    public partial class Admin
    {
        #region  ExtensionMethod
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public cycms.Model.Admin GetAdminInfo(string dbo_UserName, string dbo_PassWord)
        {
            return dal.GetAdminInfo(dbo_UserName, dbo_PassWord);
        }

        /// <summary>
        /// 更新登陆信息
        /// </summary>
        public void UserLoginAccess(int ID)
        {
            Model.Admin model = GetModel(ID);
            model.dbo_LastLoginTime = DateTime.Now;
            model.dbo_LastLoginIp = HttpContext.Current.Request.UserHostAddress;
            model.dbo_LoginTimes = model.dbo_LoginTimes + 1;
            Update(model);
        }

        /// <summary>
        /// 添加管理用户
        /// </summary>
        public int adminAdd(Model.Admin model)
        {
            if (!dal.IfExciet(model.dbo_UserName))
            {
                Add(model);
                return 1;
            }
            else
            {
                return 0;
            }
        }
        #endregion  ExtensionMethod
    }
}
