using System;
using System.Data;
using System.Text;
using System.Data.OleDb;
using Maticsoft.DBUtility;//Please add references

namespace cycms.DAL
{
    public partial class Article
    {
        #region  ExtensionMethod
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add_ReturnID(cycms.Model.Article model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into dbo_Article(");
            strSql.Append("dbo_Title,dbo_Typeid,dbo_Content,dbo_Author,dbo_Source,dbo_Click,dbo_Ptime,dbo_Fujian,dbo_IsLock,dbo_IsTop)");
            strSql.Append(" values (");
            strSql.Append("@dbo_Title,@dbo_Typeid,@dbo_Content,@dbo_Author,@dbo_Source,@dbo_Click,@dbo_Ptime,@dbo_Fujian,@dbo_IsLock,@dbo_IsTop)");
            OleDbParameter[] parameters = {
					new OleDbParameter("@dbo_Title", OleDbType.VarChar,200),
					new OleDbParameter("@dbo_Typeid", OleDbType.Integer,4),
					new OleDbParameter("@dbo_Content", OleDbType.VarChar,0),
					new OleDbParameter("@dbo_Author", OleDbType.VarChar,20),
					new OleDbParameter("@dbo_Source", OleDbType.VarChar,200),
					new OleDbParameter("@dbo_Click", OleDbType.Integer,4),
					new OleDbParameter("@dbo_Ptime", OleDbType.Date),
					new OleDbParameter("@dbo_Fujian", OleDbType.VarChar,0),
					new OleDbParameter("@dbo_IsLock", OleDbType.Boolean,1),
					new OleDbParameter("@dbo_IsTop", OleDbType.Boolean,1)};
            parameters[0].Value = model.dbo_Title;
            parameters[1].Value = model.dbo_Typeid;
            parameters[2].Value = model.dbo_Content;
            parameters[3].Value = model.dbo_Author;
            parameters[4].Value = model.dbo_Source;
            parameters[5].Value = model.dbo_Click;
            parameters[6].Value = model.dbo_Ptime;
            parameters[7].Value = model.dbo_Fujian;
            parameters[8].Value = model.dbo_IsLock;
            parameters[9].Value = model.dbo_IsTop;

            object obj = DbHelperOleDb.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }

        public bool DeleteArticlesByTypeids(string typeids)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from dbo_Article ");
            strSql.Append(" where dbo_typeid in (" + typeids + ")");
            int rows = DbHelperOleDb.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UpdateTypeidByIdList(int typeid, string IdList)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update dbo_Article set ");
            strSql.Append("dbo_Typeid=@dbo_Typeid");
            strSql.Append(" where ID in (" + IdList + ") ");
            OleDbParameter[] parameters = {
                new OleDbParameter("@dbo_Typeid", OleDbType.Integer,4)
                                          };
            parameters[0].Value = typeid;
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

        public DataTable ExecutePager(int pageIndex, int pageSize, string whereString, string orderString, out int pageCount, out int recordCount)
        {
            string strKey = "ID"; //主键
            string showString = "*"; //显示的字段
            string queryString = "dbo_V_Article";
            return DbHelperOleDb.ExecutePager(pageIndex, pageSize, strKey, showString, queryString, whereString, orderString, out pageCount, out recordCount);
        }
        #endregion  ExtensionMethod
    }
}
