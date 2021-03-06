﻿using System;
using System.Data;
using System.Text;
using System.Data.OleDb;
using Maticsoft.DBUtility;//Please add references
namespace cycms.DAL
{
	/// <summary>
	/// 数据访问类:TeacherTeachResume
	/// </summary>
	public partial class TeacherTeachResume
	{
		public TeacherTeachResume()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperOleDb.GetMaxID("ID", "dbo_TeacherTeachResume"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from dbo_TeacherTeachResume");
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
		public bool Add(cycms.Model.TeacherTeachResume model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into dbo_TeacherTeachResume(");
			strSql.Append("dbo_StartTime,dbo_EndTime,dbo_TheClass,dbo_Result,dbo_Remark,dbo_TeacherId)");
			strSql.Append(" values (");
			strSql.Append("@dbo_StartTime,@dbo_EndTime,@dbo_TheClass,@dbo_Result,@dbo_Remark,@dbo_TeacherId)");
			OleDbParameter[] parameters = {
					new OleDbParameter("@dbo_StartTime", OleDbType.VarChar,100),
					new OleDbParameter("@dbo_EndTime", OleDbType.VarChar,100),
					new OleDbParameter("@dbo_TheClass", OleDbType.VarChar,200),
					new OleDbParameter("@dbo_Result", OleDbType.VarChar,0),
					new OleDbParameter("@dbo_Remark", OleDbType.VarChar,0),
					new OleDbParameter("@dbo_TeacherId", OleDbType.Integer,4)};
			parameters[0].Value = model.dbo_StartTime;
			parameters[1].Value = model.dbo_EndTime;
			parameters[2].Value = model.dbo_TheClass;
			parameters[3].Value = model.dbo_Result;
			parameters[4].Value = model.dbo_Remark;
			parameters[5].Value = model.dbo_TeacherId;

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
		public bool Update(cycms.Model.TeacherTeachResume model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update dbo_TeacherTeachResume set ");
			strSql.Append("dbo_StartTime=@dbo_StartTime,");
			strSql.Append("dbo_EndTime=@dbo_EndTime,");
			strSql.Append("dbo_TheClass=@dbo_TheClass,");
			strSql.Append("dbo_Result=@dbo_Result,");
			strSql.Append("dbo_Remark=@dbo_Remark,");
			strSql.Append("dbo_TeacherId=@dbo_TeacherId");
			strSql.Append(" where ID=@ID");
			OleDbParameter[] parameters = {
					new OleDbParameter("@dbo_StartTime", OleDbType.VarChar,100),
					new OleDbParameter("@dbo_EndTime", OleDbType.VarChar,100),
					new OleDbParameter("@dbo_TheClass", OleDbType.VarChar,200),
					new OleDbParameter("@dbo_Result", OleDbType.VarChar,0),
					new OleDbParameter("@dbo_Remark", OleDbType.VarChar,0),
					new OleDbParameter("@dbo_TeacherId", OleDbType.Integer,4),
					new OleDbParameter("@ID", OleDbType.Integer,4)};
			parameters[0].Value = model.dbo_StartTime;
			parameters[1].Value = model.dbo_EndTime;
			parameters[2].Value = model.dbo_TheClass;
			parameters[3].Value = model.dbo_Result;
			parameters[4].Value = model.dbo_Remark;
			parameters[5].Value = model.dbo_TeacherId;
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
			strSql.Append("delete from dbo_TeacherTeachResume ");
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
			strSql.Append("delete from dbo_TeacherTeachResume ");
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
		public cycms.Model.TeacherTeachResume GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,dbo_StartTime,dbo_EndTime,dbo_TheClass,dbo_Result,dbo_Remark,dbo_TeacherId from dbo_TeacherTeachResume ");
			strSql.Append(" where ID=@ID");
			OleDbParameter[] parameters = {
					new OleDbParameter("@ID", OleDbType.Integer,4)
			};
			parameters[0].Value = ID;

			cycms.Model.TeacherTeachResume model=new cycms.Model.TeacherTeachResume();
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
		public cycms.Model.TeacherTeachResume DataRowToModel(DataRow row)
		{
			cycms.Model.TeacherTeachResume model=new cycms.Model.TeacherTeachResume();
			if (row != null)
			{
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=int.Parse(row["ID"].ToString());
				}
				if(row["dbo_StartTime"]!=null)
				{
					model.dbo_StartTime=row["dbo_StartTime"].ToString();
				}
				if(row["dbo_EndTime"]!=null)
				{
					model.dbo_EndTime=row["dbo_EndTime"].ToString();
				}
				if(row["dbo_TheClass"]!=null)
				{
					model.dbo_TheClass=row["dbo_TheClass"].ToString();
				}
				if(row["dbo_Result"]!=null)
				{
					model.dbo_Result=row["dbo_Result"].ToString();
				}
				if(row["dbo_Remark"]!=null)
				{
					model.dbo_Remark=row["dbo_Remark"].ToString();
				}
				if(row["dbo_TeacherId"]!=null && row["dbo_TeacherId"].ToString()!="")
				{
					model.dbo_TeacherId=int.Parse(row["dbo_TeacherId"].ToString());
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
			strSql.Append("select ID,dbo_StartTime,dbo_EndTime,dbo_TheClass,dbo_Result,dbo_Remark,dbo_TeacherId ");
			strSql.Append(" FROM dbo_TeacherTeachResume ");
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
			strSql.Append("select count(1) FROM dbo_TeacherTeachResume ");
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
			strSql.Append(")AS Row, T.*  from dbo_TeacherTeachResume T ");
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
			parameters[0].Value = "dbo_TeacherTeachResume";
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

