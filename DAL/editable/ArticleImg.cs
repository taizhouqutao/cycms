using System;
using System.Data;
using System.Text;
using System.Data.OleDb;
using Maticsoft.DBUtility;//Please add references
namespace cycms.DAL
{
    public partial class ArticleImg
    {
        #region  ExtensionMethod
        /// <summary>
        /// 根据文章ID删除一条数据
        /// </summary>
        public bool DeleteByArticleId(int ArticleId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from dbo_ArticleImg ");
            strSql.Append(" where dbo_articleId=@ArticleId");
            OleDbParameter[] parameters = {
					new OleDbParameter("@ArticleId", OleDbType.Integer,4)
			};
            parameters[0].Value = ArticleId;

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
        /// 根据文章列表ID删除一条数据
        /// </summary>
        public bool DeleteByArticleIdList(string ArticleIdList)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from dbo_ArticleImg ");
            strSql.Append(" where dbo_articleId in (" + ArticleIdList + ")  ");
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
        #endregion  ExtensionMethod
    }
}
