using System;
using System.Data;
using System.Text;
using System.Data.OleDb;
using Maticsoft.DBUtility;//Please add references
namespace cycms.DAL
{
	/// <summary>
	/// 数据访问类:IPHistry
	/// </summary>
	public partial class IPHistry
	{
		public IPHistry()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperOleDb.GetMaxID("ID", "dbo_IPHistry"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from dbo_IPHistry");
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
		public bool Add(cycms.Model.IPHistry model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into dbo_IPHistry(");
			strSql.Append("dbo_IPAddress,dbo_Address,dbo_Area,dbo_Ptime,dbo_Browser,dbo_Platform,dbo_PageTitle)");
			strSql.Append(" values (");
			strSql.Append("@dbo_IPAddress,@dbo_Address,@dbo_Area,@dbo_Ptime,@dbo_Browser,@dbo_Platform,@dbo_PageTitle)");
			OleDbParameter[] parameters = {
					new OleDbParameter("@dbo_IPAddress", OleDbType.VarChar,20),
					new OleDbParameter("@dbo_Address", OleDbType.VarChar,255),
					new OleDbParameter("@dbo_Area", OleDbType.VarChar,100),
					new OleDbParameter("@dbo_Ptime", OleDbType.Date),
					new OleDbParameter("@dbo_Browser", OleDbType.VarChar,100),
					new OleDbParameter("@dbo_Platform", OleDbType.VarChar,100),
					new OleDbParameter("@dbo_PageTitle", OleDbType.VarChar,50)};
			parameters[0].Value = model.dbo_IPAddress;
			parameters[1].Value = model.dbo_Address;
			parameters[2].Value = model.dbo_Area;
			parameters[3].Value = model.dbo_Ptime;
			parameters[4].Value = model.dbo_Browser;
			parameters[5].Value = model.dbo_Platform;
			parameters[6].Value = model.dbo_PageTitle;

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
		public bool Update(cycms.Model.IPHistry model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update dbo_IPHistry set ");
			strSql.Append("dbo_IPAddress=@dbo_IPAddress,");
			strSql.Append("dbo_Address=@dbo_Address,");
			strSql.Append("dbo_Area=@dbo_Area,");
			strSql.Append("dbo_Ptime=@dbo_Ptime,");
			strSql.Append("dbo_Browser=@dbo_Browser,");
			strSql.Append("dbo_Platform=@dbo_Platform,");
			strSql.Append("dbo_PageTitle=@dbo_PageTitle");
			strSql.Append(" where ID=@ID");
			OleDbParameter[] parameters = {
					new OleDbParameter("@dbo_IPAddress", OleDbType.VarChar,20),
					new OleDbParameter("@dbo_Address", OleDbType.VarChar,255),
					new OleDbParameter("@dbo_Area", OleDbType.VarChar,100),
					new OleDbParameter("@dbo_Ptime", OleDbType.Date),
					new OleDbParameter("@dbo_Browser", OleDbType.VarChar,100),
					new OleDbParameter("@dbo_Platform", OleDbType.VarChar,100),
					new OleDbParameter("@dbo_PageTitle", OleDbType.VarChar,50),
					new OleDbParameter("@ID", OleDbType.Integer,4)};
			parameters[0].Value = model.dbo_IPAddress;
			parameters[1].Value = model.dbo_Address;
			parameters[2].Value = model.dbo_Area;
			parameters[3].Value = model.dbo_Ptime;
			parameters[4].Value = model.dbo_Browser;
			parameters[5].Value = model.dbo_Platform;
			parameters[6].Value = model.dbo_PageTitle;
			parameters[7].Value = model.ID;

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
			strSql.Append("delete from dbo_IPHistry ");
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
			strSql.Append("delete from dbo_IPHistry ");
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
		public cycms.Model.IPHistry GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,dbo_IPAddress,dbo_Address,dbo_Area,dbo_Ptime,dbo_Browser,dbo_Platform,dbo_PageTitle from dbo_IPHistry ");
			strSql.Append(" where ID=@ID");
			OleDbParameter[] parameters = {
					new OleDbParameter("@ID", OleDbType.Integer,4)
			};
			parameters[0].Value = ID;

			cycms.Model.IPHistry model=new cycms.Model.IPHistry();
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
		public cycms.Model.IPHistry DataRowToModel(DataRow row)
		{
			cycms.Model.IPHistry model=new cycms.Model.IPHistry();
			if (row != null)
			{
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=int.Parse(row["ID"].ToString());
				}
				if(row["dbo_IPAddress"]!=null)
				{
					model.dbo_IPAddress=row["dbo_IPAddress"].ToString();
				}
				if(row["dbo_Address"]!=null)
				{
					model.dbo_Address=row["dbo_Address"].ToString();
				}
				if(row["dbo_Area"]!=null)
				{
					model.dbo_Area=row["dbo_Area"].ToString();
				}
				if(row["dbo_Ptime"]!=null && row["dbo_Ptime"].ToString()!="")
				{
					model.dbo_Ptime=DateTime.Parse(row["dbo_Ptime"].ToString());
				}
				if(row["dbo_Browser"]!=null)
				{
					model.dbo_Browser=row["dbo_Browser"].ToString();
				}
				if(row["dbo_Platform"]!=null)
				{
					model.dbo_Platform=row["dbo_Platform"].ToString();
				}
				if(row["dbo_PageTitle"]!=null)
				{
					model.dbo_PageTitle=row["dbo_PageTitle"].ToString();
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
			strSql.Append("select ID,dbo_IPAddress,dbo_Address,dbo_Area,dbo_Ptime,dbo_Browser,dbo_Platform,dbo_PageTitle ");
			strSql.Append(" FROM dbo_IPHistry ");
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
			strSql.Append("select count(1) FROM dbo_IPHistry ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperSQL.GetSingle(strSql.ToString());
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
			strSql.Append(")AS Row, T.*  from dbo_IPHistry T ");
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
			parameters[0].Value = "dbo_IPHistry";
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

