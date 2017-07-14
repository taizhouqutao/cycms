using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using cycms.Model;
namespace cycms.BLL
{
    /// <summary>
    /// GuestBook
    /// </summary>
    public partial class GuestBook
    {
        #region  ExtensionMethod
        /// <summary>
        /// 分页调用
        /// </summary>
        public DataTable getPagerRecords(int pageIndex, int pageSize, out int rowcount, string strFiter)
        {
            int pageCount = 0;
            string orderString = "";  //排序
            if (!string.IsNullOrEmpty(strFiter) && strFiter.Trim() != "")
            {
                strFiter = "where " + strFiter;
            }
            return dal.ExecutePager(pageIndex, pageSize, strFiter, orderString, out pageCount, out rowcount);
        }
        #endregion  ExtensionMethod
    }
}
