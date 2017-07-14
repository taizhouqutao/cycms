using System;
using System.Data;
using System.Text;
using System.Data.OleDb;
using Maticsoft.DBUtility;//Please add references

namespace cycms.DAL
{
    public partial class IPHistry
    {
        public DataTable ExecutePager(int pageIndex, int pageSize, string whereString, string orderString, out int pageCount, out int recordCount)
        {
            string strKey = "ID"; //主键
            string showString = "*"; //显示的字段
            string queryString = "dbo_IPHistry";
            return DbHelperOleDb.ExecutePager(pageIndex, pageSize, strKey, showString, queryString, whereString, orderString, out pageCount, out recordCount);
        }
    }
}
