using System;
using System.Data;
using System.Text;
using System.Data.OleDb;
using Maticsoft.DBUtility;//Please add references
namespace cycms.DAL
{
	/// <summary>
	/// 数据访问类:ArticleImg
	/// </summary>
	public partial class ArticleImg
	{
		public ArticleImg()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperOleDb.GetMaxID("ID", "dbo_ArticleImg"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from dbo_ArticleImg");
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
		public bool Add(cycms.Model.ArticleImg model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into dbo_ArticleImg(");
			strSql.Append("dbo_ImgSrc,dbo_articleId,dbo_SpecialityId,dbo_ImgBigSrc,dbo_ImgArt)");
			strSql.Append(" values (");
			strSql.Append("@dbo_ImgSrc,@dbo_articleId,@dbo_SpecialityId,@dbo_ImgBigSrc,@dbo_ImgArt)");
			OleDbParameter[] parameters = {
					new OleDbParameter("@dbo_ImgSrc", OleDbType.VarChar,0),
					new OleDbParameter("@dbo_articleId", OleDbType.Integer,4),
					new OleDbParameter("@dbo_SpecialityId", OleDbType.Integer,4),
					new OleDbParameter("@dbo_ImgBigSrc", OleDbType.VarChar,0),
					new OleDbParameter("@dbo_ImgArt", OleDbType.VarChar,255)};
			parameters[0].Value = model.dbo_ImgSrc;
			parameters[1].Value = model.dbo_articleId;
			parameters[2].Value = model.dbo_SpecialityId;
			parameters[3].Value = model.dbo_ImgBigSrc;
			parameters[4].Value = model.dbo_ImgArt;

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
		public bool Update(cycms.Model.ArticleImg model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update dbo_ArticleImg set ");
			strSql.Append("dbo_ImgSrc=@dbo_ImgSrc,");
			strSql.Append("dbo_articleId=@dbo_articleId,");
			strSql.Append("dbo_SpecialityId=@dbo_SpecialityId,");
			strSql.Append("dbo_ImgBigSrc=@dbo_ImgBigSrc,");
			strSql.Append("dbo_ImgArt=@dbo_ImgArt");
			strSql.Append(" where ID=@ID");
			OleDbParameter[] parameters = {
					new OleDbParameter("@dbo_ImgSrc", OleDbType.VarChar,0),
					new OleDbParameter("@dbo_articleId", OleDbType.Integer,4),
					new OleDbParameter("@dbo_SpecialityId", OleDbType.Integer,4),
					new OleDbParameter("@dbo_ImgBigSrc", OleDbType.VarChar,0),
					new OleDbParameter("@dbo_ImgArt", OleDbType.VarChar,255),
					new OleDbParameter("@ID", OleDbType.Integer,4)};
			parameters[0].Value = model.dbo_ImgSrc;
			parameters[1].Value = model.dbo_articleId;
			parameters[2].Value = model.dbo_SpecialityId;
			parameters[3].Value = model.dbo_ImgBigSrc;
			parameters[4].Value = model.dbo_ImgArt;
			parameters[5].Value = model.ID;

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
			strSql.Append("delete from dbo_ArticleImg ");
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
			strSql.Append("delete from dbo_ArticleImg ");
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
		public cycms.Model.ArticleImg GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,dbo_ImgSrc,dbo_articleId,dbo_SpecialityId,dbo_ImgBigSrc,dbo_ImgArt from dbo_ArticleImg ");
			strSql.Append(" where ID=@ID");
			OleDbParameter[] parameters = {
					new OleDbParameter("@ID", OleDbType.Integer,4)
			};
			parameters[0].Value = ID;

			cycms.Model.ArticleImg model=new cycms.Model.ArticleImg();
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
		public cycms.Model.ArticleImg DataRowToModel(DataRow row)
		{
			cycms.Model.ArticleImg model=new cycms.Model.ArticleImg();
			if (row != null)
			{
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=int.Parse(row["ID"].ToString());
				}
				if(row["dbo_ImgSrc"]!=null)
				{
					model.dbo_ImgSrc=row["dbo_ImgSrc"].ToString();
				}
				if(row["dbo_articleId"]!=null && row["dbo_articleId"].ToString()!="")
				{
					model.dbo_articleId=int.Parse(row["dbo_articleId"].ToString());
				}
				if(row["dbo_SpecialityId"]!=null && row["dbo_SpecialityId"].ToString()!="")
				{
					model.dbo_SpecialityId=int.Parse(row["dbo_SpecialityId"].ToString());
				}
				if(row["dbo_ImgBigSrc"]!=null)
				{
					model.dbo_ImgBigSrc=row["dbo_ImgBigSrc"].ToString();
				}
				if(row["dbo_ImgArt"]!=null)
				{
					model.dbo_ImgArt=row["dbo_ImgArt"].ToString();
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
			strSql.Append("select ID,dbo_ImgSrc,dbo_articleId,dbo_SpecialityId,dbo_ImgBigSrc,dbo_ImgArt ");
			strSql.Append(" FROM dbo_ArticleImg ");
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
			strSql.Append("select count(1) FROM dbo_ArticleImg ");
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
			strSql.Append(")AS Row, T.*  from dbo_ArticleImg T ");
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
			parameters[0].Value = "dbo_ArticleImg";
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

