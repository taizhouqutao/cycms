using System;
using System.Data;
using System.Text;
using System.Data.OleDb;
using Maticsoft.DBUtility;//Please add references
namespace cycms.DAL
{
	/// <summary>
	/// 数据访问类:GuestBook
	/// </summary>
	public partial class GuestBook
	{
		public GuestBook()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperOleDb.GetMaxID("ID", "dbo_GuestBook"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from dbo_GuestBook");
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
		public bool Add(cycms.Model.GuestBook model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into dbo_GuestBook(");
			strSql.Append("dbo_Title,dbo_Content,dbo_Name,dbo_Sex,dbo_Email,dbo_IsShow,dbo_Ptime,dbo_IsReply,dbo_ReplyContent,dbo_ReplyTime,dbo_GuestType,dbo_GuestTypeName,dbo_WorkName,dbo_Flax,dbo_CellPhone,dbo_Address)");
			strSql.Append(" values (");
			strSql.Append("@dbo_Title,@dbo_Content,@dbo_Name,@dbo_Sex,@dbo_Email,@dbo_IsShow,@dbo_Ptime,@dbo_IsReply,@dbo_ReplyContent,@dbo_ReplyTime,@dbo_GuestType,@dbo_GuestTypeName,@dbo_WorkName,@dbo_Flax,@dbo_CellPhone,@dbo_Address)");
			OleDbParameter[] parameters = {
					new OleDbParameter("@dbo_Title", OleDbType.VarChar,200),
					new OleDbParameter("@dbo_Content", OleDbType.VarChar,0),
					new OleDbParameter("@dbo_Name", OleDbType.VarChar,20),
					new OleDbParameter("@dbo_Sex", OleDbType.VarChar,4),
					new OleDbParameter("@dbo_Email", OleDbType.VarChar,100),
					new OleDbParameter("@dbo_IsShow", OleDbType.Boolean,1),
					new OleDbParameter("@dbo_Ptime", OleDbType.Date),
					new OleDbParameter("@dbo_IsReply", OleDbType.Boolean,1),
					new OleDbParameter("@dbo_ReplyContent", OleDbType.VarChar,0),
					new OleDbParameter("@dbo_ReplyTime", OleDbType.Date),
					new OleDbParameter("@dbo_GuestType", OleDbType.Integer,4),
					new OleDbParameter("@dbo_GuestTypeName", OleDbType.VarChar,100),
					new OleDbParameter("@dbo_WorkName", OleDbType.VarChar,255),
					new OleDbParameter("@dbo_Flax", OleDbType.VarChar,50),
					new OleDbParameter("@dbo_CellPhone", OleDbType.VarChar,50),
					new OleDbParameter("@dbo_Address", OleDbType.VarChar,255)};
			parameters[0].Value = model.dbo_Title;
			parameters[1].Value = model.dbo_Content;
			parameters[2].Value = model.dbo_Name;
			parameters[3].Value = model.dbo_Sex;
			parameters[4].Value = model.dbo_Email;
			parameters[5].Value = model.dbo_IsShow;
			parameters[6].Value = model.dbo_Ptime;
			parameters[7].Value = model.dbo_IsReply;
			parameters[8].Value = model.dbo_ReplyContent;
			parameters[9].Value = model.dbo_ReplyTime;
			parameters[10].Value = model.dbo_GuestType;
			parameters[11].Value = model.dbo_GuestTypeName;
			parameters[12].Value = model.dbo_WorkName;
			parameters[13].Value = model.dbo_Flax;
			parameters[14].Value = model.dbo_CellPhone;
			parameters[15].Value = model.dbo_Address;

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
		public bool Update(cycms.Model.GuestBook model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update dbo_GuestBook set ");
			strSql.Append("dbo_Title=@dbo_Title,");
			strSql.Append("dbo_Content=@dbo_Content,");
			strSql.Append("dbo_Name=@dbo_Name,");
			strSql.Append("dbo_Sex=@dbo_Sex,");
			strSql.Append("dbo_Email=@dbo_Email,");
			strSql.Append("dbo_IsShow=@dbo_IsShow,");
			strSql.Append("dbo_Ptime=@dbo_Ptime,");
			strSql.Append("dbo_IsReply=@dbo_IsReply,");
			strSql.Append("dbo_ReplyContent=@dbo_ReplyContent,");
			strSql.Append("dbo_ReplyTime=@dbo_ReplyTime,");
			strSql.Append("dbo_GuestType=@dbo_GuestType,");
			strSql.Append("dbo_GuestTypeName=@dbo_GuestTypeName,");
			strSql.Append("dbo_WorkName=@dbo_WorkName,");
			strSql.Append("dbo_Flax=@dbo_Flax,");
			strSql.Append("dbo_CellPhone=@dbo_CellPhone,");
			strSql.Append("dbo_Address=@dbo_Address");
			strSql.Append(" where ID=@ID");
			OleDbParameter[] parameters = {
					new OleDbParameter("@dbo_Title", OleDbType.VarChar,200),
					new OleDbParameter("@dbo_Content", OleDbType.VarChar,0),
					new OleDbParameter("@dbo_Name", OleDbType.VarChar,20),
					new OleDbParameter("@dbo_Sex", OleDbType.VarChar,4),
					new OleDbParameter("@dbo_Email", OleDbType.VarChar,100),
					new OleDbParameter("@dbo_IsShow", OleDbType.Boolean,1),
					new OleDbParameter("@dbo_Ptime", OleDbType.Date),
					new OleDbParameter("@dbo_IsReply", OleDbType.Boolean,1),
					new OleDbParameter("@dbo_ReplyContent", OleDbType.VarChar,0),
					new OleDbParameter("@dbo_ReplyTime", OleDbType.Date),
					new OleDbParameter("@dbo_GuestType", OleDbType.Integer,4),
					new OleDbParameter("@dbo_GuestTypeName", OleDbType.VarChar,100),
					new OleDbParameter("@dbo_WorkName", OleDbType.VarChar,255),
					new OleDbParameter("@dbo_Flax", OleDbType.VarChar,50),
					new OleDbParameter("@dbo_CellPhone", OleDbType.VarChar,50),
					new OleDbParameter("@dbo_Address", OleDbType.VarChar,255),
					new OleDbParameter("@ID", OleDbType.Integer,4)};
			parameters[0].Value = model.dbo_Title;
			parameters[1].Value = model.dbo_Content;
			parameters[2].Value = model.dbo_Name;
			parameters[3].Value = model.dbo_Sex;
			parameters[4].Value = model.dbo_Email;
			parameters[5].Value = model.dbo_IsShow;
			parameters[6].Value = model.dbo_Ptime;
			parameters[7].Value = model.dbo_IsReply;
			parameters[8].Value = model.dbo_ReplyContent;
			parameters[9].Value = model.dbo_ReplyTime;
			parameters[10].Value = model.dbo_GuestType;
			parameters[11].Value = model.dbo_GuestTypeName;
			parameters[12].Value = model.dbo_WorkName;
			parameters[13].Value = model.dbo_Flax;
			parameters[14].Value = model.dbo_CellPhone;
			parameters[15].Value = model.dbo_Address;
			parameters[16].Value = model.ID;

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
			strSql.Append("delete from dbo_GuestBook ");
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
			strSql.Append("delete from dbo_GuestBook ");
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
		public cycms.Model.GuestBook GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,dbo_Title,dbo_Content,dbo_Name,dbo_Sex,dbo_Email,dbo_IsShow,dbo_Ptime,dbo_IsReply,dbo_ReplyContent,dbo_ReplyTime,dbo_GuestType,dbo_GuestTypeName,dbo_WorkName,dbo_Flax,dbo_CellPhone,dbo_Address from dbo_GuestBook ");
			strSql.Append(" where ID=@ID");
			OleDbParameter[] parameters = {
					new OleDbParameter("@ID", OleDbType.Integer,4)
			};
			parameters[0].Value = ID;

			cycms.Model.GuestBook model=new cycms.Model.GuestBook();
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
		public cycms.Model.GuestBook DataRowToModel(DataRow row)
		{
			cycms.Model.GuestBook model=new cycms.Model.GuestBook();
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
				if(row["dbo_Content"]!=null)
				{
					model.dbo_Content=row["dbo_Content"].ToString();
				}
				if(row["dbo_Name"]!=null)
				{
					model.dbo_Name=row["dbo_Name"].ToString();
				}
				if(row["dbo_Sex"]!=null)
				{
					model.dbo_Sex=row["dbo_Sex"].ToString();
				}
				if(row["dbo_Email"]!=null)
				{
					model.dbo_Email=row["dbo_Email"].ToString();
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
				if(row["dbo_Ptime"]!=null && row["dbo_Ptime"].ToString()!="")
				{
					model.dbo_Ptime=DateTime.Parse(row["dbo_Ptime"].ToString());
				}
				if(row["dbo_IsReply"]!=null && row["dbo_IsReply"].ToString()!="")
				{
					if((row["dbo_IsReply"].ToString()=="1")||(row["dbo_IsReply"].ToString().ToLower()=="true"))
					{
						model.dbo_IsReply=true;
					}
					else
					{
						model.dbo_IsReply=false;
					}
				}
				if(row["dbo_ReplyContent"]!=null)
				{
					model.dbo_ReplyContent=row["dbo_ReplyContent"].ToString();
				}
				if(row["dbo_ReplyTime"]!=null && row["dbo_ReplyTime"].ToString()!="")
				{
					model.dbo_ReplyTime=DateTime.Parse(row["dbo_ReplyTime"].ToString());
				}
				if(row["dbo_GuestType"]!=null && row["dbo_GuestType"].ToString()!="")
				{
					model.dbo_GuestType=int.Parse(row["dbo_GuestType"].ToString());
				}
				if(row["dbo_GuestTypeName"]!=null)
				{
					model.dbo_GuestTypeName=row["dbo_GuestTypeName"].ToString();
				}
				if(row["dbo_WorkName"]!=null)
				{
					model.dbo_WorkName=row["dbo_WorkName"].ToString();
				}
				if(row["dbo_Flax"]!=null)
				{
					model.dbo_Flax=row["dbo_Flax"].ToString();
				}
				if(row["dbo_CellPhone"]!=null)
				{
					model.dbo_CellPhone=row["dbo_CellPhone"].ToString();
				}
				if(row["dbo_Address"]!=null)
				{
					model.dbo_Address=row["dbo_Address"].ToString();
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
			strSql.Append("select ID,dbo_Title,dbo_Content,dbo_Name,dbo_Sex,dbo_Email,dbo_IsShow,dbo_Ptime,dbo_IsReply,dbo_ReplyContent,dbo_ReplyTime,dbo_GuestType,dbo_GuestTypeName,dbo_WorkName,dbo_Flax,dbo_CellPhone,dbo_Address ");
			strSql.Append(" FROM dbo_GuestBook ");
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
			strSql.Append("select count(1) FROM dbo_GuestBook ");
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
			strSql.Append(")AS Row, T.*  from dbo_GuestBook T ");
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
			parameters[0].Value = "dbo_GuestBook";
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

