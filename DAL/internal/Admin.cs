using System;
using System.Data;
using System.Text;
using System.Data.OleDb;
using Maticsoft.DBUtility;//Please add references
namespace cycms.DAL
{
	/// <summary>
	/// 数据访问类:Admin
	/// </summary>
	public partial class Admin
	{
		public Admin()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperOleDb.GetMaxID("ID", "dbo_Admin"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from dbo_Admin");
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
		public bool Add(cycms.Model.Admin model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into dbo_Admin(");
			strSql.Append("dbo_UserName,dbo_PassWord,dbo_LastLoginTime,dbo_LastLoginIp,dbo_Power,dbo_LoginTimes)");
			strSql.Append(" values (");
			strSql.Append("@dbo_UserName,@dbo_PassWord,@dbo_LastLoginTime,@dbo_LastLoginIp,@dbo_Power,@dbo_LoginTimes)");
			OleDbParameter[] parameters = {
					new OleDbParameter("@dbo_UserName", OleDbType.VarChar,100),
					new OleDbParameter("@dbo_PassWord", OleDbType.VarChar,100),
					new OleDbParameter("@dbo_LastLoginTime", OleDbType.Date),
					new OleDbParameter("@dbo_LastLoginIp", OleDbType.VarChar,15),
					new OleDbParameter("@dbo_Power", OleDbType.VarChar,0),
					new OleDbParameter("@dbo_LoginTimes", OleDbType.Integer,4)};
			parameters[0].Value = model.dbo_UserName;
			parameters[1].Value = model.dbo_PassWord;
			parameters[2].Value = model.dbo_LastLoginTime;
			parameters[3].Value = model.dbo_LastLoginIp;
			parameters[4].Value = model.dbo_Power;
			parameters[5].Value = model.dbo_LoginTimes;

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
		public bool Update(cycms.Model.Admin model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update dbo_Admin set ");
			strSql.Append("dbo_UserName=@dbo_UserName,");
			strSql.Append("dbo_PassWord=@dbo_PassWord,");
			strSql.Append("dbo_LastLoginTime=@dbo_LastLoginTime,");
			strSql.Append("dbo_LastLoginIp=@dbo_LastLoginIp,");
			strSql.Append("dbo_Power=@dbo_Power,");
			strSql.Append("dbo_LoginTimes=@dbo_LoginTimes");
			strSql.Append(" where ID=@ID");
			OleDbParameter[] parameters = {
					new OleDbParameter("@dbo_UserName", OleDbType.VarChar,100),
					new OleDbParameter("@dbo_PassWord", OleDbType.VarChar,100),
					new OleDbParameter("@dbo_LastLoginTime", OleDbType.Date),
					new OleDbParameter("@dbo_LastLoginIp", OleDbType.VarChar,15),
					new OleDbParameter("@dbo_Power", OleDbType.VarChar,0),
					new OleDbParameter("@dbo_LoginTimes", OleDbType.Integer,4),
					new OleDbParameter("@ID", OleDbType.Integer,4)};
			parameters[0].Value = model.dbo_UserName;
			parameters[1].Value = model.dbo_PassWord;
			parameters[2].Value = model.dbo_LastLoginTime;
			parameters[3].Value = model.dbo_LastLoginIp;
			parameters[4].Value = model.dbo_Power;
			parameters[5].Value = model.dbo_LoginTimes;
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
			strSql.Append("delete from dbo_Admin ");
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
			strSql.Append("delete from dbo_Admin ");
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
		public cycms.Model.Admin GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,dbo_UserName,dbo_PassWord,dbo_LastLoginTime,dbo_LastLoginIp,dbo_Power,dbo_LoginTimes from dbo_Admin ");
			strSql.Append(" where ID=@ID");
			OleDbParameter[] parameters = {
					new OleDbParameter("@ID", OleDbType.Integer,4)
			};
			parameters[0].Value = ID;

			cycms.Model.Admin model=new cycms.Model.Admin();
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
		public cycms.Model.Admin DataRowToModel(DataRow row)
		{
			cycms.Model.Admin model=new cycms.Model.Admin();
			if (row != null)
			{
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=int.Parse(row["ID"].ToString());
				}
				if(row["dbo_UserName"]!=null)
				{
					model.dbo_UserName=row["dbo_UserName"].ToString();
				}
				if(row["dbo_PassWord"]!=null)
				{
					model.dbo_PassWord=row["dbo_PassWord"].ToString();
				}
				if(row["dbo_LastLoginTime"]!=null && row["dbo_LastLoginTime"].ToString()!="")
				{
					model.dbo_LastLoginTime=DateTime.Parse(row["dbo_LastLoginTime"].ToString());
				}
				if(row["dbo_LastLoginIp"]!=null)
				{
					model.dbo_LastLoginIp=row["dbo_LastLoginIp"].ToString();
				}
				if(row["dbo_Power"]!=null)
				{
					model.dbo_Power=row["dbo_Power"].ToString();
				}
				if(row["dbo_LoginTimes"]!=null && row["dbo_LoginTimes"].ToString()!="")
				{
					model.dbo_LoginTimes=int.Parse(row["dbo_LoginTimes"].ToString());
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
			strSql.Append("select ID,dbo_UserName,dbo_PassWord,dbo_LastLoginTime,dbo_LastLoginIp,dbo_Power,dbo_LoginTimes ");
			strSql.Append(" FROM dbo_Admin ");
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
			strSql.Append("select count(1) FROM dbo_Admin ");
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
			strSql.Append(")AS Row, T.*  from dbo_Admin T ");
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
			parameters[0].Value = "dbo_Admin";
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

