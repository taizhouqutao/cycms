using System;
using System.Data;
using System.Text;
using System.Data.OleDb;
using Maticsoft.DBUtility;//Please add references
namespace cycms.DAL
{
    public partial class ArticleType
    {
        #region  ExtensionMethod
        /// <summary>
        /// 批量更新SpecialityId
        /// </summary>
        public bool updateSpecialityId(string IDlist, Int32 specialityId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update dbo_ArticleType set ");
            strSql.Append("dbo_SpecialityId=@dbo_SpecialityId,");
            strSql.Append(" where ID in (@IDlist)");
            OleDbParameter[] parameters = {
					new OleDbParameter("@dbo_SpecialityId", OleDbType.Integer,4),
					new OleDbParameter("@IDlist", OleDbType.VarChar,200)};
            parameters[0].Value = specialityId;
            parameters[1].Value = IDlist;

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
        #endregion  ExtensionMethod
    }
}
