using System;
using System.Data;
using System.Text;
using System.Data.OleDb;
using Maticsoft.DBUtility;//Please add references
namespace cycms.DAL
{
	/// <summary>
	/// 数据访问类:Article
	/// </summary>
	public partial class Article
	{
		public Article()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperOleDb.GetMaxID("ID", "dbo_Article"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from dbo_Article");
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
		public bool Add(cycms.Model.Article model)
		{
			StringBuilder strSql=new StringBuilder();
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
		public bool Update(cycms.Model.Article model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update dbo_Article set ");
			strSql.Append("dbo_Title=@dbo_Title,");
			strSql.Append("dbo_Typeid=@dbo_Typeid,");
			strSql.Append("dbo_Content=@dbo_Content,");
			strSql.Append("dbo_Author=@dbo_Author,");
			strSql.Append("dbo_Source=@dbo_Source,");
			strSql.Append("dbo_Click=@dbo_Click,");
			strSql.Append("dbo_Ptime=@dbo_Ptime,");
			strSql.Append("dbo_Fujian=@dbo_Fujian,");
			strSql.Append("dbo_IsLock=@dbo_IsLock,");
			strSql.Append("dbo_IsTop=@dbo_IsTop");
			strSql.Append(" where ID=@ID");
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
					new OleDbParameter("@dbo_IsTop", OleDbType.Boolean,1),
					new OleDbParameter("@ID", OleDbType.Integer,4)};
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
			parameters[10].Value = model.ID;

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
			strSql.Append("delete from dbo_Article ");
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
			strSql.Append("delete from dbo_Article ");
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
		public cycms.Model.Article GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,dbo_Title,dbo_Typeid,dbo_Content,dbo_Author,dbo_Source,dbo_Click,dbo_Ptime,dbo_Fujian,dbo_IsLock,dbo_IsTop from dbo_Article ");
			strSql.Append(" where ID=@ID");
			OleDbParameter[] parameters = {
					new OleDbParameter("@ID", OleDbType.Integer,4)
			};
			parameters[0].Value = ID;

			cycms.Model.Article model=new cycms.Model.Article();
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
		public cycms.Model.Article DataRowToModel(DataRow row)
		{
			cycms.Model.Article model=new cycms.Model.Article();
			if (row != null)
			{
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=int.Parse(row["ID"].ToString());
				}
				if(row["dbo_Title"]!=null)
				{
					model.dbo_Title=row["dbo_Title"].ToString();
				}
				if(row["dbo_Typeid"]!=null && row["dbo_Typeid"].ToString()!="")
				{
					model.dbo_Typeid=int.Parse(row["dbo_Typeid"].ToString());
				}
				if(row["dbo_Content"]!=null)
				{
					model.dbo_Content=row["dbo_Content"].ToString();
				}
				if(row["dbo_Author"]!=null)
				{
					model.dbo_Author=row["dbo_Author"].ToString();
				}
				if(row["dbo_Source"]!=null)
				{
					model.dbo_Source=row["dbo_Source"].ToString();
				}
				if(row["dbo_Click"]!=null && row["dbo_Click"].ToString()!="")
				{
					model.dbo_Click=int.Parse(row["dbo_Click"].ToString());
				}
				if(row["dbo_Ptime"]!=null && row["dbo_Ptime"].ToString()!="")
				{
					model.dbo_Ptime=DateTime.Parse(row["dbo_Ptime"].ToString());
				}
				if(row["dbo_Fujian"]!=null)
				{
					model.dbo_Fujian=row["dbo_Fujian"].ToString();
				}
				if(row["dbo_IsLock"]!=null && row["dbo_IsLock"].ToString()!="")
				{
					if((row["dbo_IsLock"].ToString()=="1")||(row["dbo_IsLock"].ToString().ToLower()=="true"))
					{
						model.dbo_IsLock=true;
					}
					else
					{
						model.dbo_IsLock=false;
					}
				}
				if(row["dbo_IsTop"]!=null && row["dbo_IsTop"].ToString()!="")
				{
					if((row["dbo_IsTop"].ToString()=="1")||(row["dbo_IsTop"].ToString().ToLower()=="true"))
					{
						model.dbo_IsTop=true;
					}
					else
					{
						model.dbo_IsTop=false;
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
			strSql.Append("select ID,dbo_Title,dbo_Typeid,dbo_Content,dbo_Author,dbo_Source,dbo_Click,dbo_Ptime,dbo_Fujian,dbo_IsLock,dbo_IsTop ");
			strSql.Append(" FROM dbo_Article ");
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
			strSql.Append("select count(1) FROM dbo_Article ");
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
			strSql.Append(")AS Row, T.*  from dbo_Article T ");
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
			parameters[0].Value = "dbo_Article";
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

