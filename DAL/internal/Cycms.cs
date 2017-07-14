using System;
using System.Data;
using System.Text;
using System.Data.OleDb;
using Maticsoft.DBUtility;//Please add references
namespace cycms.DAL
{
	/// <summary>
	/// 数据访问类:Cycms
	/// </summary>
	public partial class Cycms
	{
		public Cycms()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperOleDb.GetMaxID("ID", "dbo_Cycms"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from dbo_Cycms");
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
		public bool Add(cycms.Model.Cycms model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into dbo_Cycms(");
			strSql.Append("dbo_IsRunning,dbo_IsStatic,dbo_WebAddress,dbo_WebName,dbo_StaticListPages,dbo_VisitedTimes,dbo_SmtpServer,dbo_MailAddress,dbo_MailName,dbo_MailPwd,dbo_WorkPlace,dbo_LianXiRen,dbo_CellPhone,dbo_Flax,dbo_WorkPohne,dbo_BeiAnHao)");
			strSql.Append(" values (");
			strSql.Append("@dbo_IsRunning,@dbo_IsStatic,@dbo_WebAddress,@dbo_WebName,@dbo_StaticListPages,@dbo_VisitedTimes,@dbo_SmtpServer,@dbo_MailAddress,@dbo_MailName,@dbo_MailPwd,@dbo_WorkPlace,@dbo_LianXiRen,@dbo_CellPhone,@dbo_Flax,@dbo_WorkPohne,@dbo_BeiAnHao)");
			OleDbParameter[] parameters = {
					new OleDbParameter("@dbo_IsRunning", OleDbType.Boolean,1),
					new OleDbParameter("@dbo_IsStatic", OleDbType.Boolean,1),
					new OleDbParameter("@dbo_WebAddress", OleDbType.VarChar,200),
					new OleDbParameter("@dbo_WebName", OleDbType.VarChar,200),
					new OleDbParameter("@dbo_StaticListPages", OleDbType.Integer,4),
					new OleDbParameter("@dbo_VisitedTimes", OleDbType.Integer,4),
					new OleDbParameter("@dbo_SmtpServer", OleDbType.VarChar,200),
					new OleDbParameter("@dbo_MailAddress", OleDbType.VarChar,200),
					new OleDbParameter("@dbo_MailName", OleDbType.VarChar,200),
					new OleDbParameter("@dbo_MailPwd", OleDbType.VarChar,200),
					new OleDbParameter("@dbo_WorkPlace", OleDbType.VarChar,255),
					new OleDbParameter("@dbo_LianXiRen", OleDbType.VarChar,10),
					new OleDbParameter("@dbo_CellPhone", OleDbType.VarChar,50),
					new OleDbParameter("@dbo_Flax", OleDbType.VarChar,50),
					new OleDbParameter("@dbo_WorkPohne", OleDbType.VarChar,50),
					new OleDbParameter("@dbo_BeiAnHao", OleDbType.VarChar,100)};
			parameters[0].Value = model.dbo_IsRunning;
			parameters[1].Value = model.dbo_IsStatic;
			parameters[2].Value = model.dbo_WebAddress;
			parameters[3].Value = model.dbo_WebName;
			parameters[4].Value = model.dbo_StaticListPages;
			parameters[5].Value = model.dbo_VisitedTimes;
			parameters[6].Value = model.dbo_SmtpServer;
			parameters[7].Value = model.dbo_MailAddress;
			parameters[8].Value = model.dbo_MailName;
			parameters[9].Value = model.dbo_MailPwd;
			parameters[10].Value = model.dbo_WorkPlace;
			parameters[11].Value = model.dbo_LianXiRen;
			parameters[12].Value = model.dbo_CellPhone;
			parameters[13].Value = model.dbo_Flax;
			parameters[14].Value = model.dbo_WorkPohne;
			parameters[15].Value = model.dbo_BeiAnHao;

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
		public bool Update(cycms.Model.Cycms model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update dbo_Cycms set ");
			strSql.Append("dbo_IsRunning=@dbo_IsRunning,");
			strSql.Append("dbo_IsStatic=@dbo_IsStatic,");
			strSql.Append("dbo_WebAddress=@dbo_WebAddress,");
			strSql.Append("dbo_WebName=@dbo_WebName,");
			strSql.Append("dbo_StaticListPages=@dbo_StaticListPages,");
			strSql.Append("dbo_VisitedTimes=@dbo_VisitedTimes,");
			strSql.Append("dbo_SmtpServer=@dbo_SmtpServer,");
			strSql.Append("dbo_MailAddress=@dbo_MailAddress,");
			strSql.Append("dbo_MailName=@dbo_MailName,");
			strSql.Append("dbo_MailPwd=@dbo_MailPwd,");
			strSql.Append("dbo_WorkPlace=@dbo_WorkPlace,");
			strSql.Append("dbo_LianXiRen=@dbo_LianXiRen,");
			strSql.Append("dbo_CellPhone=@dbo_CellPhone,");
			strSql.Append("dbo_Flax=@dbo_Flax,");
			strSql.Append("dbo_WorkPohne=@dbo_WorkPohne,");
			strSql.Append("dbo_BeiAnHao=@dbo_BeiAnHao");
			strSql.Append(" where ID=@ID");
			OleDbParameter[] parameters = {
					new OleDbParameter("@dbo_IsRunning", OleDbType.Boolean,1),
					new OleDbParameter("@dbo_IsStatic", OleDbType.Boolean,1),
					new OleDbParameter("@dbo_WebAddress", OleDbType.VarChar,200),
					new OleDbParameter("@dbo_WebName", OleDbType.VarChar,200),
					new OleDbParameter("@dbo_StaticListPages", OleDbType.Integer,4),
					new OleDbParameter("@dbo_VisitedTimes", OleDbType.Integer,4),
					new OleDbParameter("@dbo_SmtpServer", OleDbType.VarChar,200),
					new OleDbParameter("@dbo_MailAddress", OleDbType.VarChar,200),
					new OleDbParameter("@dbo_MailName", OleDbType.VarChar,200),
					new OleDbParameter("@dbo_MailPwd", OleDbType.VarChar,200),
					new OleDbParameter("@dbo_WorkPlace", OleDbType.VarChar,255),
					new OleDbParameter("@dbo_LianXiRen", OleDbType.VarChar,10),
					new OleDbParameter("@dbo_CellPhone", OleDbType.VarChar,50),
					new OleDbParameter("@dbo_Flax", OleDbType.VarChar,50),
					new OleDbParameter("@dbo_WorkPohne", OleDbType.VarChar,50),
					new OleDbParameter("@dbo_BeiAnHao", OleDbType.VarChar,100),
					new OleDbParameter("@ID", OleDbType.Integer,4)};
			parameters[0].Value = model.dbo_IsRunning;
			parameters[1].Value = model.dbo_IsStatic;
			parameters[2].Value = model.dbo_WebAddress;
			parameters[3].Value = model.dbo_WebName;
			parameters[4].Value = model.dbo_StaticListPages;
			parameters[5].Value = model.dbo_VisitedTimes;
			parameters[6].Value = model.dbo_SmtpServer;
			parameters[7].Value = model.dbo_MailAddress;
			parameters[8].Value = model.dbo_MailName;
			parameters[9].Value = model.dbo_MailPwd;
			parameters[10].Value = model.dbo_WorkPlace;
			parameters[11].Value = model.dbo_LianXiRen;
			parameters[12].Value = model.dbo_CellPhone;
			parameters[13].Value = model.dbo_Flax;
			parameters[14].Value = model.dbo_WorkPohne;
			parameters[15].Value = model.dbo_BeiAnHao;
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
			strSql.Append("delete from dbo_Cycms ");
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
			strSql.Append("delete from dbo_Cycms ");
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
		public cycms.Model.Cycms GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,dbo_IsRunning,dbo_IsStatic,dbo_WebAddress,dbo_WebName,dbo_StaticListPages,dbo_VisitedTimes,dbo_SmtpServer,dbo_MailAddress,dbo_MailName,dbo_MailPwd,dbo_WorkPlace,dbo_LianXiRen,dbo_CellPhone,dbo_Flax,dbo_WorkPohne,dbo_BeiAnHao from dbo_Cycms ");
			strSql.Append(" where ID=@ID");
			OleDbParameter[] parameters = {
					new OleDbParameter("@ID", OleDbType.Integer,4)
			};
			parameters[0].Value = ID;

			cycms.Model.Cycms model=new cycms.Model.Cycms();
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
		public cycms.Model.Cycms DataRowToModel(DataRow row)
		{
			cycms.Model.Cycms model=new cycms.Model.Cycms();
			if (row != null)
			{
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=int.Parse(row["ID"].ToString());
				}
				if(row["dbo_IsRunning"]!=null && row["dbo_IsRunning"].ToString()!="")
				{
					if((row["dbo_IsRunning"].ToString()=="1")||(row["dbo_IsRunning"].ToString().ToLower()=="true"))
					{
						model.dbo_IsRunning=true;
					}
					else
					{
						model.dbo_IsRunning=false;
					}
				}
				if(row["dbo_IsStatic"]!=null && row["dbo_IsStatic"].ToString()!="")
				{
					if((row["dbo_IsStatic"].ToString()=="1")||(row["dbo_IsStatic"].ToString().ToLower()=="true"))
					{
						model.dbo_IsStatic=true;
					}
					else
					{
						model.dbo_IsStatic=false;
					}
				}
				if(row["dbo_WebAddress"]!=null)
				{
					model.dbo_WebAddress=row["dbo_WebAddress"].ToString();
				}
				if(row["dbo_WebName"]!=null)
				{
					model.dbo_WebName=row["dbo_WebName"].ToString();
				}
				if(row["dbo_StaticListPages"]!=null && row["dbo_StaticListPages"].ToString()!="")
				{
					model.dbo_StaticListPages=int.Parse(row["dbo_StaticListPages"].ToString());
				}
				if(row["dbo_VisitedTimes"]!=null && row["dbo_VisitedTimes"].ToString()!="")
				{
					model.dbo_VisitedTimes=int.Parse(row["dbo_VisitedTimes"].ToString());
				}
				if(row["dbo_SmtpServer"]!=null)
				{
					model.dbo_SmtpServer=row["dbo_SmtpServer"].ToString();
				}
				if(row["dbo_MailAddress"]!=null)
				{
					model.dbo_MailAddress=row["dbo_MailAddress"].ToString();
				}
				if(row["dbo_MailName"]!=null)
				{
					model.dbo_MailName=row["dbo_MailName"].ToString();
				}
				if(row["dbo_MailPwd"]!=null)
				{
					model.dbo_MailPwd=row["dbo_MailPwd"].ToString();
				}
				if(row["dbo_WorkPlace"]!=null)
				{
					model.dbo_WorkPlace=row["dbo_WorkPlace"].ToString();
				}
				if(row["dbo_LianXiRen"]!=null)
				{
					model.dbo_LianXiRen=row["dbo_LianXiRen"].ToString();
				}
				if(row["dbo_CellPhone"]!=null)
				{
					model.dbo_CellPhone=row["dbo_CellPhone"].ToString();
				}
				if(row["dbo_Flax"]!=null)
				{
					model.dbo_Flax=row["dbo_Flax"].ToString();
				}
				if(row["dbo_WorkPohne"]!=null)
				{
					model.dbo_WorkPohne=row["dbo_WorkPohne"].ToString();
				}
				if(row["dbo_BeiAnHao"]!=null)
				{
					model.dbo_BeiAnHao=row["dbo_BeiAnHao"].ToString();
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
			strSql.Append("select ID,dbo_IsRunning,dbo_IsStatic,dbo_WebAddress,dbo_WebName,dbo_StaticListPages,dbo_VisitedTimes,dbo_SmtpServer,dbo_MailAddress,dbo_MailName,dbo_MailPwd,dbo_WorkPlace,dbo_LianXiRen,dbo_CellPhone,dbo_Flax,dbo_WorkPohne,dbo_BeiAnHao ");
			strSql.Append(" FROM dbo_Cycms ");
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
			strSql.Append("select count(1) FROM dbo_Cycms ");
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
			strSql.Append(")AS Row, T.*  from dbo_Cycms T ");
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
			parameters[0].Value = "dbo_Cycms";
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

