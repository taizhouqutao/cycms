using System;
using System.Data;
using System.Text;
using System.Data.OleDb;
using Maticsoft.DBUtility;//Please add references
namespace cycms.DAL
{
	/// <summary>
	/// 数据访问类:HtmlPage
	/// </summary>
	public partial class HtmlPage
	{
		public HtmlPage()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperOleDb.GetMaxID("ID", "dbo_HtmlPage"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from dbo_HtmlPage");
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
		public bool Add(cycms.Model.HtmlPage model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into dbo_HtmlPage(");
			strSql.Append("dbo_HtmlName,dbo_PageTitle,dbo_PageContent,dbo_Template,dbo_PagePath,dbo_Ptime,dbo_SpcId,dbo_IsShow)");
			strSql.Append(" values (");
			strSql.Append("@dbo_HtmlName,@dbo_PageTitle,@dbo_PageContent,@dbo_Template,@dbo_PagePath,@dbo_Ptime,@dbo_SpcId,@dbo_IsShow)");
			OleDbParameter[] parameters = {
					new OleDbParameter("@dbo_HtmlName", OleDbType.VarChar,50),
					new OleDbParameter("@dbo_PageTitle", OleDbType.VarChar,200),
					new OleDbParameter("@dbo_PageContent", OleDbType.VarChar,0),
					new OleDbParameter("@dbo_Template", OleDbType.VarChar,50),
					new OleDbParameter("@dbo_PagePath", OleDbType.VarChar,200),
					new OleDbParameter("@dbo_Ptime", OleDbType.Date),
					new OleDbParameter("@dbo_SpcId", OleDbType.Integer,4),
					new OleDbParameter("@dbo_IsShow", OleDbType.Boolean,1)};
			parameters[0].Value = model.dbo_HtmlName;
			parameters[1].Value = model.dbo_PageTitle;
			parameters[2].Value = model.dbo_PageContent;
			parameters[3].Value = model.dbo_Template;
			parameters[4].Value = model.dbo_PagePath;
			parameters[5].Value = model.dbo_Ptime;
			parameters[6].Value = model.dbo_SpcId;
			parameters[7].Value = model.dbo_IsShow;

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
		public bool Update(cycms.Model.HtmlPage model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update dbo_HtmlPage set ");
			strSql.Append("dbo_HtmlName=@dbo_HtmlName,");
			strSql.Append("dbo_PageTitle=@dbo_PageTitle,");
			strSql.Append("dbo_PageContent=@dbo_PageContent,");
			strSql.Append("dbo_Template=@dbo_Template,");
			strSql.Append("dbo_PagePath=@dbo_PagePath,");
			strSql.Append("dbo_Ptime=@dbo_Ptime,");
			strSql.Append("dbo_SpcId=@dbo_SpcId,");
			strSql.Append("dbo_IsShow=@dbo_IsShow");
			strSql.Append(" where ID=@ID");
			OleDbParameter[] parameters = {
					new OleDbParameter("@dbo_HtmlName", OleDbType.VarChar,50),
					new OleDbParameter("@dbo_PageTitle", OleDbType.VarChar,200),
					new OleDbParameter("@dbo_PageContent", OleDbType.VarChar,0),
					new OleDbParameter("@dbo_Template", OleDbType.VarChar,50),
					new OleDbParameter("@dbo_PagePath", OleDbType.VarChar,200),
					new OleDbParameter("@dbo_Ptime", OleDbType.Date),
					new OleDbParameter("@dbo_SpcId", OleDbType.Integer,4),
					new OleDbParameter("@dbo_IsShow", OleDbType.Boolean,1),
					new OleDbParameter("@ID", OleDbType.Integer,4)};
			parameters[0].Value = model.dbo_HtmlName;
			parameters[1].Value = model.dbo_PageTitle;
			parameters[2].Value = model.dbo_PageContent;
			parameters[3].Value = model.dbo_Template;
			parameters[4].Value = model.dbo_PagePath;
			parameters[5].Value = model.dbo_Ptime;
			parameters[6].Value = model.dbo_SpcId;
			parameters[7].Value = model.dbo_IsShow;
			parameters[8].Value = model.ID;

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
			strSql.Append("delete from dbo_HtmlPage ");
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
			strSql.Append("delete from dbo_HtmlPage ");
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
		public cycms.Model.HtmlPage GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,dbo_HtmlName,dbo_PageTitle,dbo_PageContent,dbo_Template,dbo_PagePath,dbo_Ptime,dbo_SpcId,dbo_IsShow from dbo_HtmlPage ");
			strSql.Append(" where ID=@ID");
			OleDbParameter[] parameters = {
					new OleDbParameter("@ID", OleDbType.Integer,4)
			};
			parameters[0].Value = ID;

			cycms.Model.HtmlPage model=new cycms.Model.HtmlPage();
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
		public cycms.Model.HtmlPage DataRowToModel(DataRow row)
		{
			cycms.Model.HtmlPage model=new cycms.Model.HtmlPage();
			if (row != null)
			{
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=int.Parse(row["ID"].ToString());
				}
				if(row["dbo_HtmlName"]!=null)
				{
					model.dbo_HtmlName=row["dbo_HtmlName"].ToString();
				}
				if(row["dbo_PageTitle"]!=null)
				{
					model.dbo_PageTitle=row["dbo_PageTitle"].ToString();
				}
				if(row["dbo_PageContent"]!=null)
				{
					model.dbo_PageContent=row["dbo_PageContent"].ToString();
				}
				if(row["dbo_Template"]!=null)
				{
					model.dbo_Template=row["dbo_Template"].ToString();
				}
				if(row["dbo_PagePath"]!=null)
				{
					model.dbo_PagePath=row["dbo_PagePath"].ToString();
				}
				if(row["dbo_Ptime"]!=null && row["dbo_Ptime"].ToString()!="")
				{
					model.dbo_Ptime=DateTime.Parse(row["dbo_Ptime"].ToString());
				}
				if(row["dbo_SpcId"]!=null && row["dbo_SpcId"].ToString()!="")
				{
					model.dbo_SpcId=int.Parse(row["dbo_SpcId"].ToString());
				}
				if(row["dbo_IsShow"]!=null && row["dbo_IsShow"].ToString()!="")
				{
					if((row["dbo_IsShow"].ToString()=="1")||(row["dbo_IsShow"].ToString().ToLower()=="true"))
					{
						model.dbo_IsShow=true;
					}
					else
					{
						model.dbo_IsShow=false;
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
			strSql.Append("select ID,dbo_HtmlName,dbo_PageTitle,dbo_PageContent,dbo_Template,dbo_PagePath,dbo_Ptime,dbo_SpcId,dbo_IsShow ");
			strSql.Append(" FROM dbo_HtmlPage ");
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
			strSql.Append("select count(1) FROM dbo_HtmlPage ");
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
			strSql.Append(")AS Row, T.*  from dbo_HtmlPage T ");
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
			parameters[0].Value = "dbo_HtmlPage";
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

