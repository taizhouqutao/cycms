using System;
using System.Data;
using System.Text;
using System.Data.OleDb;
using Maticsoft.DBUtility;//Please add references
namespace cycms.DAL
{
	/// <summary>
	/// 数据访问类:DownLoadFile
	/// </summary>
	public partial class DownLoadFile
	{
		public DownLoadFile()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperOleDb.GetMaxID("ID", "dbo_DownLoadFile"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from dbo_DownLoadFile");
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
		public bool Add(cycms.Model.DownLoadFile model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into dbo_DownLoadFile(");
			strSql.Append("dbo_FileName,dbo_FileTitle,dbo_FileSize,dbo_Ptime,dbo_OtherInfo,dbo_TypeId,dbo_IsLock)");
			strSql.Append(" values (");
			strSql.Append("@dbo_FileName,@dbo_FileTitle,@dbo_FileSize,@dbo_Ptime,@dbo_OtherInfo,@dbo_TypeId,@dbo_IsLock)");
			OleDbParameter[] parameters = {
					new OleDbParameter("@dbo_FileName", OleDbType.VarChar,100),
					new OleDbParameter("@dbo_FileTitle", OleDbType.VarChar,100),
					new OleDbParameter("@dbo_FileSize", OleDbType.Integer,4),
					new OleDbParameter("@dbo_Ptime", OleDbType.Date),
					new OleDbParameter("@dbo_OtherInfo", OleDbType.VarChar,0),
					new OleDbParameter("@dbo_TypeId", OleDbType.Integer,4),
					new OleDbParameter("@dbo_IsLock", OleDbType.Boolean,1)};
			parameters[0].Value = model.dbo_FileName;
			parameters[1].Value = model.dbo_FileTitle;
			parameters[2].Value = model.dbo_FileSize;
			parameters[3].Value = model.dbo_Ptime;
			parameters[4].Value = model.dbo_OtherInfo;
			parameters[5].Value = model.dbo_TypeId;
			parameters[6].Value = model.dbo_IsLock;

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
		public bool Update(cycms.Model.DownLoadFile model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update dbo_DownLoadFile set ");
			strSql.Append("dbo_FileName=@dbo_FileName,");
			strSql.Append("dbo_FileTitle=@dbo_FileTitle,");
			strSql.Append("dbo_FileSize=@dbo_FileSize,");
			strSql.Append("dbo_Ptime=@dbo_Ptime,");
			strSql.Append("dbo_OtherInfo=@dbo_OtherInfo,");
			strSql.Append("dbo_TypeId=@dbo_TypeId,");
			strSql.Append("dbo_IsLock=@dbo_IsLock");
			strSql.Append(" where ID=@ID");
			OleDbParameter[] parameters = {
					new OleDbParameter("@dbo_FileName", OleDbType.VarChar,100),
					new OleDbParameter("@dbo_FileTitle", OleDbType.VarChar,100),
					new OleDbParameter("@dbo_FileSize", OleDbType.Integer,4),
					new OleDbParameter("@dbo_Ptime", OleDbType.Date),
					new OleDbParameter("@dbo_OtherInfo", OleDbType.VarChar,0),
					new OleDbParameter("@dbo_TypeId", OleDbType.Integer,4),
					new OleDbParameter("@dbo_IsLock", OleDbType.Boolean,1),
					new OleDbParameter("@ID", OleDbType.Integer,4)};
			parameters[0].Value = model.dbo_FileName;
			parameters[1].Value = model.dbo_FileTitle;
			parameters[2].Value = model.dbo_FileSize;
			parameters[3].Value = model.dbo_Ptime;
			parameters[4].Value = model.dbo_OtherInfo;
			parameters[5].Value = model.dbo_TypeId;
			parameters[6].Value = model.dbo_IsLock;
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
			strSql.Append("delete from dbo_DownLoadFile ");
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
			strSql.Append("delete from dbo_DownLoadFile ");
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
		public cycms.Model.DownLoadFile GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,dbo_FileName,dbo_FileTitle,dbo_FileSize,dbo_Ptime,dbo_OtherInfo,dbo_TypeId,dbo_IsLock from dbo_DownLoadFile ");
			strSql.Append(" where ID=@ID");
			OleDbParameter[] parameters = {
					new OleDbParameter("@ID", OleDbType.Integer,4)
			};
			parameters[0].Value = ID;

			cycms.Model.DownLoadFile model=new cycms.Model.DownLoadFile();
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
		public cycms.Model.DownLoadFile DataRowToModel(DataRow row)
		{
			cycms.Model.DownLoadFile model=new cycms.Model.DownLoadFile();
			if (row != null)
			{
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=int.Parse(row["ID"].ToString());
				}
				if(row["dbo_FileName"]!=null)
				{
					model.dbo_FileName=row["dbo_FileName"].ToString();
				}
				if(row["dbo_FileTitle"]!=null)
				{
					model.dbo_FileTitle=row["dbo_FileTitle"].ToString();
				}
				if(row["dbo_FileSize"]!=null && row["dbo_FileSize"].ToString()!="")
				{
					model.dbo_FileSize=int.Parse(row["dbo_FileSize"].ToString());
				}
				if(row["dbo_Ptime"]!=null && row["dbo_Ptime"].ToString()!="")
				{
					model.dbo_Ptime=DateTime.Parse(row["dbo_Ptime"].ToString());
				}
				if(row["dbo_OtherInfo"]!=null)
				{
					model.dbo_OtherInfo=row["dbo_OtherInfo"].ToString();
				}
				if(row["dbo_TypeId"]!=null && row["dbo_TypeId"].ToString()!="")
				{
					model.dbo_TypeId=int.Parse(row["dbo_TypeId"].ToString());
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
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,dbo_FileName,dbo_FileTitle,dbo_FileSize,dbo_Ptime,dbo_OtherInfo,dbo_TypeId,dbo_IsLock ");
			strSql.Append(" FROM dbo_DownLoadFile ");
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
			strSql.Append("select count(1) FROM dbo_DownLoadFile ");
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
			strSql.Append(")AS Row, T.*  from dbo_DownLoadFile T ");
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
			parameters[0].Value = "dbo_DownLoadFile";
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

