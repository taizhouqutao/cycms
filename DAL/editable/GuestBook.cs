using System;
using System.Data;
using System.Text;
using System.Data.OleDb;
using Maticsoft.DBUtility;//Please add references
namespace cycms.DAL
{
    /// <summary>
    /// 数据访问类:GuestBook
    /// </summary>
    public partial class GuestBook
    {
        #region  ExtensionMethod
        /// <summary>
        /// 分页调用
        /// </summary>
        public DataTable ExecutePager(int pageIndex, int pageSize, string whereString, string orderString, out int pageCount, out int recordCount)
        {
            string strKey = "ID"; //主键
            string showString = "*"; //显示的字段
            string queryString = "dbo_V_GuestBook";
            return DbHelperOleDb.ExecutePager(pageIndex, pageSize, strKey, showString, queryString, whereString, orderString, out pageCount, out recordCount);
        }
        #endregion  ExtensionMethod
    }
}
