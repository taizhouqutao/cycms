using System;
using System.Data;
using System.Text;
using System.Data.OleDb;
using Maticsoft.DBUtility;//Please add references
namespace cycms.DAL
{
    public partial class Admin
    {
        #region  ExtensionMethod
        /// <summary>
        /// 登陆用户查看
        /// </summary>
        public cycms.Model.Admin GetAdminInfo(string dbo_UserName, string dbo_PassWord)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,dbo_UserName,dbo_PassWord,dbo_LastLoginTime,dbo_LastLoginIp,dbo_Power,dbo_LoginTimes from dbo_Admin ");
            strSql.Append(" where dbo_UserName=@dbo_UserName");
            strSql.Append(" and dbo_PassWord=@dbo_PassWord");
            OleDbParameter[] parameters = {
					new OleDbParameter("@dbo_UserName", OleDbType.VarChar,100),
                    new OleDbParameter("@dbo_PassWord", OleDbType.VarChar,100)
			};
            parameters[0].Value = dbo_UserName;
            parameters[1].Value = dbo_PassWord;
            cycms.Model.Admin model = new cycms.Model.Admin();
            DataSet ds = DbHelperOleDb.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 是否存在用户查看
        /// </summary>
        public bool IfExciet(string dbo_UserName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,dbo_UserName,dbo_PassWord,dbo_LastLoginTime,dbo_LastLoginIp,dbo_Power,dbo_LoginTimes from dbo_Admin ");
            strSql.Append(" where dbo_UserName=@dbo_UserName");
            OleDbParameter[] parameters = {
					new OleDbParameter("@dbo_UserName", OleDbType.VarChar,100)
			};
            parameters[0].Value = dbo_UserName;
            cycms.Model.Admin model = new cycms.Model.Admin();
            DataSet ds = DbHelperOleDb.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion ExtensionMethod
    }
}
