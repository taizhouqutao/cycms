using System;
using System.Data;
using System.Text;
using System.Data.OleDb;
using Maticsoft.DBUtility;//Please add references
namespace cycms.DAL
{
	/// <summary>
	/// 数据访问类:Speciality
	/// </summary>
	public partial class Speciality
	{
		public Speciality()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperOleDb.GetMaxID("ID", "dbo_Speciality"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from dbo_Speciality");
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
		public bool Add(cycms.Model.Speciality model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into dbo_Speciality(");
			strSql.Append("dbo_Name,dbo_HtmlDir,dbo_ContentHtml,dbo_IfShow,dbo_LinkUrl)");
			strSql.Append(" values (");
			strSql.Append("@dbo_Name,@dbo_HtmlDir,@dbo_ContentHtml,@dbo_IfShow,@dbo_LinkUrl)");
			OleDbParameter[] parameters = {
					new OleDbParameter("@dbo_Name", OleDbType.VarChar,200),
					new OleDbParameter("@dbo_HtmlDir", OleDbType.VarChar,50),
					new OleDbParameter("@dbo_ContentHtml", OleDbType.VarChar,0),
					new OleDbParameter("@dbo_IfShow", OleDbType.Boolean,1),
					new OleDbParameter("@dbo_LinkUrl", OleDbType.VarChar,200)};
			parameters[0].Value = model.dbo_Name;
			parameters[1].Value = model.dbo_HtmlDir;
			parameters[2].Value = model.dbo_ContentHtml;
			parameters[3].Value = model.dbo_IfShow;
			parameters[4].Value = model.dbo_LinkUrl;

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
		public bool Update(cycms.Model.Speciality model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update dbo_Speciality set ");
			strSql.Append("dbo_Name=@dbo_Name,");
			strSql.Append("dbo_HtmlDir=@dbo_HtmlDir,");
			strSql.Append("dbo_ContentHtml=@dbo_ContentHtml,");
			strSql.Append("dbo_IfShow=@dbo_IfShow,");
			strSql.Append("dbo_LinkUrl=@dbo_LinkUrl");
			strSql.Append(" where ID=@ID");
			OleDbParameter[] parameters = {
					new OleDbParameter("@dbo_Name", OleDbType.VarChar,200),
					new OleDbParameter("@dbo_HtmlDir", OleDbType.VarChar,50),
					new OleDbParameter("@dbo_ContentHtml", OleDbType.VarChar,0),
					new OleDbParameter("@dbo_IfShow", OleDbType.Boolean,1),
					new OleDbParameter("@dbo_LinkUrl", OleDbType.VarChar,200),
					new OleDbParameter("@ID", OleDbType.Integer,4)};
			parameters[0].Value = model.dbo_Name;
			parameters[1].Value = model.dbo_HtmlDir;
			parameters[2].Value = model.dbo_ContentHtml;
			parameters[3].Value = model.dbo_IfShow;
			parameters[4].Value = model.dbo_LinkUrl;
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
			strSql.Append("delete from dbo_Speciality ");
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
			strSql.Append("delete from dbo_Speciality ");
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
		public cycms.Model.Speciality GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,dbo_Name,dbo_HtmlDir,dbo_ContentHtml,dbo_IfShow,dbo_LinkUrl from dbo_Speciality ");
			strSql.Append(" where ID=@ID");
			OleDbParameter[] parameters = {
					new OleDbParameter("@ID", OleDbType.Integer,4)
			};
			parameters[0].Value = ID;

			cycms.Model.Speciality model=new cycms.Model.Speciality();
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
		public cycms.Model.Speciality DataRowToModel(DataRow row)
		{
			cycms.Model.Speciality model=new cycms.Model.Speciality();
			if (row != null)
			{
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=int.Parse(row["ID"].ToString());
				}
				if(row["dbo_Name"]!=null)
				{
					model.dbo_Name=row["dbo_Name"].ToString();
				}
				if(row["dbo_HtmlDir"]!=null)
				{
					model.dbo_HtmlDir=row["dbo_HtmlDir"].ToString();
				}
				if(row["dbo_ContentHtml"]!=null)
				{
					model.dbo_ContentHtml=row["dbo_ContentHtml"].ToString();
				}
				if(row["dbo_IfShow"]!=null && row["dbo_IfShow"].ToString()!="")
				{
					if((row["dbo_IfShow"].ToString()=="1")||(row["dbo_IfShow"].ToString().ToLower()=="true"))
					{
						model.dbo_IfShow=true;
					}
					else
					{
						model.dbo_IfShow=false;
					}
				}
				if(row["dbo_LinkUrl"]!=null)
				{
					model.dbo_LinkUrl=row["dbo_LinkUrl"].ToString();
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
			strSql.Append("select ID,dbo_Name,dbo_HtmlDir,dbo_ContentHtml,dbo_IfShow,dbo_LinkUrl ");
			strSql.Append(" FROM dbo_Speciality ");
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
			strSql.Append("select count(1) FROM dbo_Speciality ");
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
			strSql.Append(")AS Row, T.*  from dbo_Speciality T ");
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
			parameters[0].Value = "dbo_Speciality";
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

