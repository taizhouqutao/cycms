using System;
using System.Data;
using System.Text;
using System.Data.OleDb;
using Maticsoft.DBUtility;//Please add references
namespace cycms.DAL
{
    /// <summary>
    /// 数据访问类:DownLoadFile
    /// </summary>
    public partial class DownLoadFile
    {
        #region  ExtensionMethod
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteByTypeID(int TypeID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from dbo_DownLoadFile ");
            strSql.Append(" where dbo_TypeId = @dbo_TypeId");
            OleDbParameter[] parameters = {
                new OleDbParameter("@dbo_TypeId", OleDbType.Integer,4)
            };
            parameters[0].Value = TypeID;
            int rows = DbHelperOleDb.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 获得视图数据列表
        /// </summary>
        public DataSet GetViewList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,dbo_FileName,dbo_FileTitle,dbo_FileSize,dbo_Ptime,dbo_OtherInfo,dbo_TypeId,dbo_IsLock,dbo_TypeName ");
            strSql.Append(" FROM dbo_V_DownLoadFile ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperOleDb.Query(strSql.ToString());
        }
        #endregion  ExtensionMethod
    }
}
