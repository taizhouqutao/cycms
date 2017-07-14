using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using cycms.Model;

namespace cycms.BLL
{
    /// <summary>
    /// TeacherInfo
    /// </summary>
    public partial class TeacherInfo
    {
        #region  ExtensionMethod
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public cycms.Model.TeacherInfo GetAdminInfo(string dbo_LoginName, string dbo_PassWord)
        {
            return dal.GetAdminInfo(dbo_LoginName, dbo_PassWord);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add_ReturnID(cycms.Model.TeacherInfo model)
        {
            if (!dal.IfExciet(model.dbo_LoginName))
            {
                return dal.Add_ReturnID(model);
            }
            else
            {
                return 0;
            }
        }
        #endregion  ExtensionMethod
    }
}
