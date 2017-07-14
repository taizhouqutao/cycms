using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using cycms.Model;
using System.Collections.Specialized;
namespace cycms.BLL
{
    /// <summary>
    /// HtmlPage
    /// </summary>
    public partial class IPHistry
    {
        /// <summary>
        /// 分页调用
        /// </summary>
        public DataTable getPagerArticle(int pageIndex, int pageSize, out int rowcount, string strFiter)
        {
            int pageCount = 0;
            string orderString = " id desc ";  //排序
            if (string.IsNullOrEmpty(strFiter) || strFiter.Trim() == "")
                strFiter = "where 1=1 ";
            else
                strFiter = "where " + strFiter;
            return dal.ExecutePager(pageIndex, pageSize, strFiter, orderString, out pageCount, out rowcount);
        }
    }
}
