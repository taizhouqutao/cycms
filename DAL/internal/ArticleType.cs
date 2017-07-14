using System;
using System.Data;
using System.Text;
using System.Data.OleDb;
using Maticsoft.DBUtility;//Please add references
namespace cycms.DAL
{
	/// <summary>
	/// 数据访问类:ArticleType
	/// </summary>
	public partial class ArticleType
	{
		public ArticleType()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperOleDb.GetMaxID("ID", "dbo_ArticleType"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from dbo_ArticleType");
			strSql.Append(" where ID=@ID");
			OleDbParameter[] parameters = {
					new OleDbParameter("@ID", OleDbType.Integer,4)
			};
			parameters[0].Value = ID;

			return DbHelperOleDb.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(cycms.Model.ArticleType model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into dbo_ArticleType(");
			strSql.Append("dbo_TypeName,dbo_LinkUrl,dbo_Fatherid,dbo_IsDisplay,dbo_SpecialityId,dbo_IsArticleType)");
			strSql.Append(" values (");
			strSql.Append("@dbo_TypeName,@dbo_LinkUrl,@dbo_Fatherid,@dbo_IsDisplay,@dbo_SpecialityId,@dbo_IsArticleType)");
			OleDbParameter[] parameters = {
					new OleDbParameter("@dbo_TypeName", OleDbType.VarChar,50),
					new OleDbParameter("@dbo_LinkUrl", OleDbType.VarChar,200),
					new OleDbParameter("@dbo_Fatherid", OleDbType.Integer,4),
					new OleDbParameter("@dbo_IsDisplay", OleDbType.Boolean,1),
					new OleDbParameter("@dbo_SpecialityId", OleDbType.Integer,4),
					new OleDbParameter("@dbo_IsArticleType", OleDbType.Boolean,1)};
			parameters[0].Value = model.dbo_TypeName;
			parameters[1].Value = model.dbo_LinkUrl;
			parameters[2].Value = model.dbo_Fatherid;
			parameters[3].Value = model.dbo_IsDisplay;
			parameters[4].Value = model.dbo_SpecialityId;
			parameters[5].Value = model.dbo_IsArticleType;

			int rows=DbHelperOleDb.ExecuteSql(strSql.ToString(),parameters);
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
		/// 更新一条数据
		/// </summary>
		public bool Update(cycms.Model.ArticleType model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update dbo_ArticleType set ");
			strSql.Append("dbo_TypeName=@dbo_TypeName,");
			strSql.Append("dbo_LinkUrl=@dbo_LinkUrl,");
			strSql.Append("dbo_Fatherid=@dbo_Fatherid,");
			strSql.Append("dbo_IsDisplay=@dbo_IsDisplay,");
			strSql.Append("dbo_SpecialityId=@dbo_SpecialityId,");
			strSql.Append("dbo_IsArticleType=@dbo_IsArticleType");
			strSql.Append(" where ID=@ID");
			OleDbParameter[] parameters = {
					new OleDbParameter("@dbo_TypeName", OleDbType.VarChar,50),
					new OleDbParameter("@dbo_LinkUrl", OleDbType.VarChar,200),
					new OleDbParameter("@dbo_Fatherid", OleDbType.Integer,4),
					new OleDbParameter("@dbo_IsDisplay", OleDbType.Boolean,1),
					new OleDbParameter("@dbo_SpecialityId", OleDbType.Integer,4),
					new OleDbParameter("@dbo_IsArticleType", OleDbType.Boolean,1),
					new OleDbParameter("@ID", OleDbType.Integer,4)};
			parameters[0].Value = model.dbo_TypeName;
			parameters[1].Value = model.dbo_LinkUrl;
			parameters[2].Value = model.dbo_Fatherid;
			parameters[3].Value = model.dbo_IsDisplay;
			parameters[4].Value = model.dbo_SpecialityId;
			parameters[5].Value = model.dbo_IsArticleType;
			parameters[6].Value = model.ID;

			int rows=DbHelperOleDb.ExecuteSql(strSql.ToString(),parameters);
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
		/// 删除一条数据
		/// </summary>
		public bool Delete(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from dbo_ArticleType ");
			strSql.Append(" where ID=@ID");
			OleDbParameter[] parameters = {
					new OleDbParameter("@ID", OleDbType.Integer,4)
			};
			parameters[0].Value = ID;

			int rows=DbHelperOleDb.ExecuteSql(strSql.ToString(),parameters);
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
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from dbo_ArticleType ");
			strSql.Append(" where ID in ("+IDlist + ")  ");
			int rows=DbHelperOleDb.ExecuteSql(strSql.ToString());
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
		/// 得到一个对象实体
		/// </summary>
		public cycms.Model.ArticleType GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,dbo_TypeName,dbo_LinkUrl,dbo_Fatherid,dbo_IsDisplay,dbo_SpecialityId,dbo_IsArticleType from dbo_ArticleType ");
			strSql.Append(" where ID=@ID");
			OleDbParameter[] parameters = {
					new OleDbParameter("@ID", OleDbType.Integer,4)
			};
			parameters[0].Value = ID;

			cycms.Model.ArticleType model=new cycms.Model.ArticleType();
			DataSet ds=DbHelperOleDb.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public cycms.Model.ArticleType DataRowToModel(DataRow row)
		{
			cycms.Model.ArticleType model=new cycms.Model.ArticleType();
			if (row != null)
			{
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=int.Parse(row["ID"].ToString());
				}
				if(row["dbo_TypeName"]!=null)
				{
					model.dbo_TypeName=row["dbo_TypeName"].ToString();
				}
				if(row["dbo_LinkUrl"]!=null)
				{
					model.dbo_LinkUrl=row["dbo_LinkUrl"].ToString();
				}
				if(row["dbo_Fatherid"]!=null && row["dbo_Fatherid"].ToString()!="")
				{
					model.dbo_Fatherid=int.Parse(row["dbo_Fatherid"].ToString());
				}
				if(row["dbo_IsDisplay"]!=null && row["dbo_IsDisplay"].ToString()!="")
				{
					if((row["dbo_IsDisplay"].ToString()=="1")||(row["dbo_IsDisplay"].ToString().ToLower()=="true"))
					{
						model.dbo_IsDisplay=true;
					}
					else
					{
						model.dbo_IsDisplay=false;
					}
				}
				if(row["dbo_SpecialityId"]!=null && row["dbo_SpecialityId"].ToString()!="")
				{
					model.dbo_SpecialityId=int.Parse(row["dbo_SpecialityId"].ToString());
				}
				if(row["dbo_IsArticleType"]!=null && row["dbo_IsArticleType"].ToString()!="")
				{
					if((row["dbo_IsArticleType"].ToString()=="1")||(row["dbo_IsArticleType"].ToString().ToLower()=="true"))
					{
						model.dbo_IsArticleType=true;
					}
					else
					{
						model.dbo_IsArticleType=false;
					}
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,dbo_TypeName,dbo_LinkUrl,dbo_Fatherid,dbo_IsDisplay,dbo_SpecialityId,dbo_IsArticleType ");
			strSql.Append(" FROM dbo_ArticleType ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperOleDb.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM dbo_ArticleType ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperOleDb.GetSingle(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.ID desc");
			}
			strSql.Append(")AS Row, T.*  from dbo_ArticleType T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperOleDb.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			OleDbParameter[] parameters = {
					new OleDbParameter("@tblName", OleDbType.VarChar, 255),
					new OleDbParameter("@fldName", OleDbType.VarChar, 255),
					new OleDbParameter("@PageSize", OleDbType.Integer),
					new OleDbParameter("@PageIndex", OleDbType.Integer),
					new OleDbParameter("@IsReCount", OleDbType.Boolean),
					new OleDbParameter("@OrderType", OleDbType.Boolean),
					new OleDbParameter("@strWhere", OleDbType.VarChar,1000),
					};
			parameters[0].Value = "dbo_ArticleType";
			parameters[1].Value = "ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperOleDb.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

