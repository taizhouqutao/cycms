using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using cycms.Model;
namespace cycms.BLL
{
    /// <summary>
    /// DownLoadFile
    /// </summary>
    public partial class DownLoadFile
    {
        #region  ExtensionMethod
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteByTypeID(int TypeID)
        {
            return dal.DeleteByTypeID(TypeID);
        }

        /// <summary>
        /// 获得视图数据列表
        /// </summary>
        public DataSet GetViewList(string strWhere)
        {
            return dal.GetViewList(strWhere);
        }
        #endregion  ExtensionMethod
    }
}
