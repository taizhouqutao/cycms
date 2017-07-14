using System;
using System.Data;
using System.Text;
using System.Data.OleDb;
using Maticsoft.DBUtility;//Please add references
namespace cycms.DAL
{
	/// <summary>
	/// 数据访问类:FriendLink
	/// </summary>
	public partial class FriendLink
	{
		public FriendLink()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperOleDb.GetMaxID("ID", "dbo_FriendLink"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from dbo_FriendLink");
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
		public bool Add(cycms.Model.FriendLink model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into dbo_FriendLink(");
			strSql.Append("dbo_FactoryLink,dbo_FactoryProductName,dbo_FactoryLogoSrc,dbo_ProductImgLink,dbo_ProductImgSrc,dbo_ProductImgName,dbo_ProductInfo)");
			strSql.Append(" values (");
			strSql.Append("@dbo_FactoryLink,@dbo_FactoryProductName,@dbo_FactoryLogoSrc,@dbo_ProductImgLink,@dbo_ProductImgSrc,@dbo_ProductImgName,@dbo_ProductInfo)");
			OleDbParameter[] parameters = {
					new OleDbParameter("@dbo_FactoryLink", OleDbType.VarChar,255),
					new OleDbParameter("@dbo_FactoryProductName", OleDbType.VarChar,50),
					new OleDbParameter("@dbo_FactoryLogoSrc", OleDbType.VarChar,255),
					new OleDbParameter("@dbo_ProductImgLink", OleDbType.VarChar,255),
					new OleDbParameter("@dbo_ProductImgSrc", OleDbType.VarChar,255),
					new OleDbParameter("@dbo_ProductImgName", OleDbType.VarChar,255),
					new OleDbParameter("@dbo_ProductInfo", OleDbType.VarChar,0)};
			parameters[0].Value = model.dbo_FactoryLink;
			parameters[1].Value = model.dbo_FactoryProductName;
			parameters[2].Value = model.dbo_FactoryLogoSrc;
			parameters[3].Value = model.dbo_ProductImgLink;
			parameters[4].Value = model.dbo_ProductImgSrc;
			parameters[5].Value = model.dbo_ProductImgName;
			parameters[6].Value = model.dbo_ProductInfo;

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
		public bool Update(cycms.Model.FriendLink model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update dbo_FriendLink set ");
			strSql.Append("dbo_FactoryLink=@dbo_FactoryLink,");
			strSql.Append("dbo_FactoryProductName=@dbo_FactoryProductName,");
			strSql.Append("dbo_FactoryLogoSrc=@dbo_FactoryLogoSrc,");
			strSql.Append("dbo_ProductImgLink=@dbo_ProductImgLink,");
			strSql.Append("dbo_ProductImgSrc=@dbo_ProductImgSrc,");
			strSql.Append("dbo_ProductImgName=@dbo_ProductImgName,");
			strSql.Append("dbo_ProductInfo=@dbo_ProductInfo");
			strSql.Append(" where ID=@ID");
			OleDbParameter[] parameters = {
					new OleDbParameter("@dbo_FactoryLink", OleDbType.VarChar,255),
					new OleDbParameter("@dbo_FactoryProductName", OleDbType.VarChar,50),
					new OleDbParameter("@dbo_FactoryLogoSrc", OleDbType.VarChar,255),
					new OleDbParameter("@dbo_ProductImgLink", OleDbType.VarChar,255),
					new OleDbParameter("@dbo_ProductImgSrc", OleDbType.VarChar,255),
					new OleDbParameter("@dbo_ProductImgName", OleDbType.VarChar,255),
					new OleDbParameter("@dbo_ProductInfo", OleDbType.VarChar,0),
					new OleDbParameter("@ID", OleDbType.Integer,4)};
			parameters[0].Value = model.dbo_FactoryLink;
			parameters[1].Value = model.dbo_FactoryProductName;
			parameters[2].Value = model.dbo_FactoryLogoSrc;
			parameters[3].Value = model.dbo_ProductImgLink;
			parameters[4].Value = model.dbo_ProductImgSrc;
			parameters[5].Value = model.dbo_ProductImgName;
			parameters[6].Value = model.dbo_ProductInfo;
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
			strSql.Append("delete from dbo_FriendLink ");
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
			strSql.Append("delete from dbo_FriendLink ");
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
		public cycms.Model.FriendLink GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,dbo_FactoryLink,dbo_FactoryProductName,dbo_FactoryLogoSrc,dbo_ProductImgLink,dbo_ProductImgSrc,dbo_ProductImgName,dbo_ProductInfo from dbo_FriendLink ");
			strSql.Append(" where ID=@ID");
			OleDbParameter[] parameters = {
					new OleDbParameter("@ID", OleDbType.Integer,4)
			};
			parameters[0].Value = ID;

			cycms.Model.FriendLink model=new cycms.Model.FriendLink();
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
		public cycms.Model.FriendLink DataRowToModel(DataRow row)
		{
			cycms.Model.FriendLink model=new cycms.Model.FriendLink();
			if (row != null)
			{
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=int.Parse(row["ID"].ToString());
				}
				if(row["dbo_FactoryLink"]!=null)
				{
					model.dbo_FactoryLink=row["dbo_FactoryLink"].ToString();
				}
				if(row["dbo_FactoryProductName"]!=null)
				{
					model.dbo_FactoryProductName=row["dbo_FactoryProductName"].ToString();
				}
				if(row["dbo_FactoryLogoSrc"]!=null)
				{
					model.dbo_FactoryLogoSrc=row["dbo_FactoryLogoSrc"].ToString();
				}
				if(row["dbo_ProductImgLink"]!=null)
				{
					model.dbo_ProductImgLink=row["dbo_ProductImgLink"].ToString();
				}
				if(row["dbo_ProductImgSrc"]!=null)
				{
					model.dbo_ProductImgSrc=row["dbo_ProductImgSrc"].ToString();
				}
				if(row["dbo_ProductImgName"]!=null)
				{
					model.dbo_ProductImgName=row["dbo_ProductImgName"].ToString();
				}
				if(row["dbo_ProductInfo"]!=null)
				{
					model.dbo_ProductInfo=row["dbo_ProductInfo"].ToString();
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
			strSql.Append("select ID,dbo_FactoryLink,dbo_FactoryProductName,dbo_FactoryLogoSrc,dbo_ProductImgLink,dbo_ProductImgSrc,dbo_ProductImgName,dbo_ProductInfo ");
			strSql.Append(" FROM dbo_FriendLink ");
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
			strSql.Append("select count(1) FROM dbo_FriendLink ");
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
			strSql.Append(")AS Row, T.*  from dbo_FriendLink T ");
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
			parameters[0].Value = "dbo_FriendLink";
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

