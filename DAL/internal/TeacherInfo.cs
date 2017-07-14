using System;
using System.Data;
using System.Text;
using System.Data.OleDb;
using Maticsoft.DBUtility;//Please add references
namespace cycms.DAL
{
	/// <summary>
	/// 数据访问类:TeacherInfo
	/// </summary>
	public partial class TeacherInfo
	{
		public TeacherInfo()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperOleDb.GetMaxID("ID", "dbo_TeacherInfo"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from dbo_TeacherInfo");
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
		public bool Add(cycms.Model.TeacherInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into dbo_TeacherInfo(");
			strSql.Append("dbo_LoginName,dbo_PassWord,dbo_Name,dbo_Photo,dbo_Email,dbo_Title,dbo_Degree,dbo_Professional,dbo_Group,dbo_InfoBase,dbo_InfoTeac,dbo_InfoStudy,dbo_Order,dbo_Sex,dbo_Minzu,dbo_BirthDay,dbo_JiGuan,dbo_Party,dbo_ParthTime,dbo_ForeignLang,dbo_XueLi,dbo_WorkTime,dbo_EmpTime,dbo_EmpNum,dbo_School,dbo_Remarks,dbo_OfficePhone,dbo_HomePhone,dbo_MobilePhone,dbo_ShortNumber,dbo_HomeAddress,dbo_IsDisplay)");
			strSql.Append(" values (");
			strSql.Append("@dbo_LoginName,@dbo_PassWord,@dbo_Name,@dbo_Photo,@dbo_Email,@dbo_Title,@dbo_Degree,@dbo_Professional,@dbo_Group,@dbo_InfoBase,@dbo_InfoTeac,@dbo_InfoStudy,@dbo_Order,@dbo_Sex,@dbo_Minzu,@dbo_BirthDay,@dbo_JiGuan,@dbo_Party,@dbo_ParthTime,@dbo_ForeignLang,@dbo_XueLi,@dbo_WorkTime,@dbo_EmpTime,@dbo_EmpNum,@dbo_School,@dbo_Remarks,@dbo_OfficePhone,@dbo_HomePhone,@dbo_MobilePhone,@dbo_ShortNumber,@dbo_HomeAddress,@dbo_IsDisplay)");
			OleDbParameter[] parameters = {
					new OleDbParameter("@dbo_LoginName", OleDbType.VarChar,100),
					new OleDbParameter("@dbo_PassWord", OleDbType.VarChar,100),
					new OleDbParameter("@dbo_Name", OleDbType.VarChar,10),
					new OleDbParameter("@dbo_Photo", OleDbType.VarChar,200),
					new OleDbParameter("@dbo_Email", OleDbType.VarChar,100),
					new OleDbParameter("@dbo_Title", OleDbType.VarChar,50),
					new OleDbParameter("@dbo_Degree", OleDbType.VarChar,50),
					new OleDbParameter("@dbo_Professional", OleDbType.VarChar,100),
					new OleDbParameter("@dbo_Group", OleDbType.Integer,4),
					new OleDbParameter("@dbo_InfoBase", OleDbType.VarChar,0),
					new OleDbParameter("@dbo_InfoTeac", OleDbType.VarChar,0),
					new OleDbParameter("@dbo_InfoStudy", OleDbType.VarChar,0),
					new OleDbParameter("@dbo_Order", OleDbType.Integer,4),
					new OleDbParameter("@dbo_Sex", OleDbType.VarChar,100),
					new OleDbParameter("@dbo_Minzu", OleDbType.VarChar,100),
					new OleDbParameter("@dbo_BirthDay", OleDbType.VarChar,50),
					new OleDbParameter("@dbo_JiGuan", OleDbType.VarChar,50),
					new OleDbParameter("@dbo_Party", OleDbType.VarChar,100),
					new OleDbParameter("@dbo_ParthTime", OleDbType.VarChar,50),
					new OleDbParameter("@dbo_ForeignLang", OleDbType.VarChar,100),
					new OleDbParameter("@dbo_XueLi", OleDbType.VarChar,50),
					new OleDbParameter("@dbo_WorkTime", OleDbType.VarChar,50),
					new OleDbParameter("@dbo_EmpTime", OleDbType.VarChar,50),
					new OleDbParameter("@dbo_EmpNum", OleDbType.VarChar,100),
					new OleDbParameter("@dbo_School", OleDbType.VarChar,100),
					new OleDbParameter("@dbo_Remarks", OleDbType.VarChar,200),
					new OleDbParameter("@dbo_OfficePhone", OleDbType.VarChar,50),
					new OleDbParameter("@dbo_HomePhone", OleDbType.VarChar,50),
					new OleDbParameter("@dbo_MobilePhone", OleDbType.VarChar,50),
					new OleDbParameter("@dbo_ShortNumber", OleDbType.VarChar,50),
					new OleDbParameter("@dbo_HomeAddress", OleDbType.VarChar,0),
					new OleDbParameter("@dbo_IsDisplay", OleDbType.Boolean,1)};
			parameters[0].Value = model.dbo_LoginName;
			parameters[1].Value = model.dbo_PassWord;
			parameters[2].Value = model.dbo_Name;
			parameters[3].Value = model.dbo_Photo;
			parameters[4].Value = model.dbo_Email;
			parameters[5].Value = model.dbo_Title;
			parameters[6].Value = model.dbo_Degree;
			parameters[7].Value = model.dbo_Professional;
			parameters[8].Value = model.dbo_Group;
			parameters[9].Value = model.dbo_InfoBase;
			parameters[10].Value = model.dbo_InfoTeac;
			parameters[11].Value = model.dbo_InfoStudy;
			parameters[12].Value = model.dbo_Order;
			parameters[13].Value = model.dbo_Sex;
			parameters[14].Value = model.dbo_Minzu;
			parameters[15].Value = model.dbo_BirthDay;
			parameters[16].Value = model.dbo_JiGuan;
			parameters[17].Value = model.dbo_Party;
			parameters[18].Value = model.dbo_ParthTime;
			parameters[19].Value = model.dbo_ForeignLang;
			parameters[20].Value = model.dbo_XueLi;
			parameters[21].Value = model.dbo_WorkTime;
			parameters[22].Value = model.dbo_EmpTime;
			parameters[23].Value = model.dbo_EmpNum;
			parameters[24].Value = model.dbo_School;
			parameters[25].Value = model.dbo_Remarks;
			parameters[26].Value = model.dbo_OfficePhone;
			parameters[27].Value = model.dbo_HomePhone;
			parameters[28].Value = model.dbo_MobilePhone;
			parameters[29].Value = model.dbo_ShortNumber;
			parameters[30].Value = model.dbo_HomeAddress;
			parameters[31].Value = model.dbo_IsDisplay;

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
		public bool Update(cycms.Model.TeacherInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update dbo_TeacherInfo set ");
			strSql.Append("dbo_LoginName=@dbo_LoginName,");
			strSql.Append("dbo_PassWord=@dbo_PassWord,");
			strSql.Append("dbo_Name=@dbo_Name,");
			strSql.Append("dbo_Photo=@dbo_Photo,");
			strSql.Append("dbo_Email=@dbo_Email,");
			strSql.Append("dbo_Title=@dbo_Title,");
			strSql.Append("dbo_Degree=@dbo_Degree,");
			strSql.Append("dbo_Professional=@dbo_Professional,");
			strSql.Append("dbo_Group=@dbo_Group,");
			strSql.Append("dbo_InfoBase=@dbo_InfoBase,");
			strSql.Append("dbo_InfoTeac=@dbo_InfoTeac,");
			strSql.Append("dbo_InfoStudy=@dbo_InfoStudy,");
			strSql.Append("dbo_Order=@dbo_Order,");
			strSql.Append("dbo_Sex=@dbo_Sex,");
			strSql.Append("dbo_Minzu=@dbo_Minzu,");
			strSql.Append("dbo_BirthDay=@dbo_BirthDay,");
			strSql.Append("dbo_JiGuan=@dbo_JiGuan,");
			strSql.Append("dbo_Party=@dbo_Party,");
			strSql.Append("dbo_ParthTime=@dbo_ParthTime,");
			strSql.Append("dbo_ForeignLang=@dbo_ForeignLang,");
			strSql.Append("dbo_XueLi=@dbo_XueLi,");
			strSql.Append("dbo_WorkTime=@dbo_WorkTime,");
			strSql.Append("dbo_EmpTime=@dbo_EmpTime,");
			strSql.Append("dbo_EmpNum=@dbo_EmpNum,");
			strSql.Append("dbo_School=@dbo_School,");
			strSql.Append("dbo_Remarks=@dbo_Remarks,");
			strSql.Append("dbo_OfficePhone=@dbo_OfficePhone,");
			strSql.Append("dbo_HomePhone=@dbo_HomePhone,");
			strSql.Append("dbo_MobilePhone=@dbo_MobilePhone,");
			strSql.Append("dbo_ShortNumber=@dbo_ShortNumber,");
			strSql.Append("dbo_HomeAddress=@dbo_HomeAddress,");
			strSql.Append("dbo_IsDisplay=@dbo_IsDisplay");
			strSql.Append(" where ID=@ID");
			OleDbParameter[] parameters = {
					new OleDbParameter("@dbo_LoginName", OleDbType.VarChar,100),
					new OleDbParameter("@dbo_PassWord", OleDbType.VarChar,100),
					new OleDbParameter("@dbo_Name", OleDbType.VarChar,10),
					new OleDbParameter("@dbo_Photo", OleDbType.VarChar,200),
					new OleDbParameter("@dbo_Email", OleDbType.VarChar,100),
					new OleDbParameter("@dbo_Title", OleDbType.VarChar,50),
					new OleDbParameter("@dbo_Degree", OleDbType.VarChar,50),
					new OleDbParameter("@dbo_Professional", OleDbType.VarChar,100),
					new OleDbParameter("@dbo_Group", OleDbType.Integer,4),
					new OleDbParameter("@dbo_InfoBase", OleDbType.VarChar,0),
					new OleDbParameter("@dbo_InfoTeac", OleDbType.VarChar,0),
					new OleDbParameter("@dbo_InfoStudy", OleDbType.VarChar,0),
					new OleDbParameter("@dbo_Order", OleDbType.Integer,4),
					new OleDbParameter("@dbo_Sex", OleDbType.VarChar,100),
					new OleDbParameter("@dbo_Minzu", OleDbType.VarChar,100),
					new OleDbParameter("@dbo_BirthDay", OleDbType.VarChar,50),
					new OleDbParameter("@dbo_JiGuan", OleDbType.VarChar,50),
					new OleDbParameter("@dbo_Party", OleDbType.VarChar,100),
					new OleDbParameter("@dbo_ParthTime", OleDbType.VarChar,50),
					new OleDbParameter("@dbo_ForeignLang", OleDbType.VarChar,100),
					new OleDbParameter("@dbo_XueLi", OleDbType.VarChar,50),
					new OleDbParameter("@dbo_WorkTime", OleDbType.VarChar,50),
					new OleDbParameter("@dbo_EmpTime", OleDbType.VarChar,50),
					new OleDbParameter("@dbo_EmpNum", OleDbType.VarChar,100),
					new OleDbParameter("@dbo_School", OleDbType.VarChar,100),
					new OleDbParameter("@dbo_Remarks", OleDbType.VarChar,200),
					new OleDbParameter("@dbo_OfficePhone", OleDbType.VarChar,50),
					new OleDbParameter("@dbo_HomePhone", OleDbType.VarChar,50),
					new OleDbParameter("@dbo_MobilePhone", OleDbType.VarChar,50),
					new OleDbParameter("@dbo_ShortNumber", OleDbType.VarChar,50),
					new OleDbParameter("@dbo_HomeAddress", OleDbType.VarChar,0),
					new OleDbParameter("@dbo_IsDisplay", OleDbType.Boolean,1),
					new OleDbParameter("@ID", OleDbType.Integer,4)};
			parameters[0].Value = model.dbo_LoginName;
			parameters[1].Value = model.dbo_PassWord;
			parameters[2].Value = model.dbo_Name;
			parameters[3].Value = model.dbo_Photo;
			parameters[4].Value = model.dbo_Email;
			parameters[5].Value = model.dbo_Title;
			parameters[6].Value = model.dbo_Degree;
			parameters[7].Value = model.dbo_Professional;
			parameters[8].Value = model.dbo_Group;
			parameters[9].Value = model.dbo_InfoBase;
			parameters[10].Value = model.dbo_InfoTeac;
			parameters[11].Value = model.dbo_InfoStudy;
			parameters[12].Value = model.dbo_Order;
			parameters[13].Value = model.dbo_Sex;
			parameters[14].Value = model.dbo_Minzu;
			parameters[15].Value = model.dbo_BirthDay;
			parameters[16].Value = model.dbo_JiGuan;
			parameters[17].Value = model.dbo_Party;
			parameters[18].Value = model.dbo_ParthTime;
			parameters[19].Value = model.dbo_ForeignLang;
			parameters[20].Value = model.dbo_XueLi;
			parameters[21].Value = model.dbo_WorkTime;
			parameters[22].Value = model.dbo_EmpTime;
			parameters[23].Value = model.dbo_EmpNum;
			parameters[24].Value = model.dbo_School;
			parameters[25].Value = model.dbo_Remarks;
			parameters[26].Value = model.dbo_OfficePhone;
			parameters[27].Value = model.dbo_HomePhone;
			parameters[28].Value = model.dbo_MobilePhone;
			parameters[29].Value = model.dbo_ShortNumber;
			parameters[30].Value = model.dbo_HomeAddress;
			parameters[31].Value = model.dbo_IsDisplay;
			parameters[32].Value = model.ID;

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
			strSql.Append("delete from dbo_TeacherInfo ");
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
			strSql.Append("delete from dbo_TeacherInfo ");
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
		public cycms.Model.TeacherInfo GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,dbo_LoginName,dbo_PassWord,dbo_Name,dbo_Photo,dbo_Email,dbo_Title,dbo_Degree,dbo_Professional,dbo_Group,dbo_InfoBase,dbo_InfoTeac,dbo_InfoStudy,dbo_Order,dbo_Sex,dbo_Minzu,dbo_BirthDay,dbo_JiGuan,dbo_Party,dbo_ParthTime,dbo_ForeignLang,dbo_XueLi,dbo_WorkTime,dbo_EmpTime,dbo_EmpNum,dbo_School,dbo_Remarks,dbo_OfficePhone,dbo_HomePhone,dbo_MobilePhone,dbo_ShortNumber,dbo_HomeAddress,dbo_IsDisplay from dbo_TeacherInfo ");
			strSql.Append(" where ID=@ID");
			OleDbParameter[] parameters = {
					new OleDbParameter("@ID", OleDbType.Integer,4)
			};
			parameters[0].Value = ID;

			cycms.Model.TeacherInfo model=new cycms.Model.TeacherInfo();
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
		public cycms.Model.TeacherInfo DataRowToModel(DataRow row)
		{
			cycms.Model.TeacherInfo model=new cycms.Model.TeacherInfo();
			if (row != null)
			{
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=int.Parse(row["ID"].ToString());
				}
				if(row["dbo_LoginName"]!=null)
				{
					model.dbo_LoginName=row["dbo_LoginName"].ToString();
				}
				if(row["dbo_PassWord"]!=null)
				{
					model.dbo_PassWord=row["dbo_PassWord"].ToString();
				}
				if(row["dbo_Name"]!=null)
				{
					model.dbo_Name=row["dbo_Name"].ToString();
				}
				if(row["dbo_Photo"]!=null)
				{
					model.dbo_Photo=row["dbo_Photo"].ToString();
				}
				if(row["dbo_Email"]!=null)
				{
					model.dbo_Email=row["dbo_Email"].ToString();
				}
				if(row["dbo_Title"]!=null)
				{
					model.dbo_Title=row["dbo_Title"].ToString();
				}
				if(row["dbo_Degree"]!=null)
				{
					model.dbo_Degree=row["dbo_Degree"].ToString();
				}
				if(row["dbo_Professional"]!=null)
				{
					model.dbo_Professional=row["dbo_Professional"].ToString();
				}
				if(row["dbo_Group"]!=null && row["dbo_Group"].ToString()!="")
				{
					model.dbo_Group=int.Parse(row["dbo_Group"].ToString());
				}
				if(row["dbo_InfoBase"]!=null)
				{
					model.dbo_InfoBase=row["dbo_InfoBase"].ToString();
				}
				if(row["dbo_InfoTeac"]!=null)
				{
					model.dbo_InfoTeac=row["dbo_InfoTeac"].ToString();
				}
				if(row["dbo_InfoStudy"]!=null)
				{
					model.dbo_InfoStudy=row["dbo_InfoStudy"].ToString();
				}
				if(row["dbo_Order"]!=null && row["dbo_Order"].ToString()!="")
				{
					model.dbo_Order=int.Parse(row["dbo_Order"].ToString());
				}
				if(row["dbo_Sex"]!=null)
				{
					model.dbo_Sex=row["dbo_Sex"].ToString();
				}
				if(row["dbo_Minzu"]!=null)
				{
					model.dbo_Minzu=row["dbo_Minzu"].ToString();
				}
				if(row["dbo_BirthDay"]!=null)
				{
					model.dbo_BirthDay=row["dbo_BirthDay"].ToString();
				}
				if(row["dbo_JiGuan"]!=null)
				{
					model.dbo_JiGuan=row["dbo_JiGuan"].ToString();
				}
				if(row["dbo_Party"]!=null)
				{
					model.dbo_Party=row["dbo_Party"].ToString();
				}
				if(row["dbo_ParthTime"]!=null)
				{
					model.dbo_ParthTime=row["dbo_ParthTime"].ToString();
				}
				if(row["dbo_ForeignLang"]!=null)
				{
					model.dbo_ForeignLang=row["dbo_ForeignLang"].ToString();
				}
				if(row["dbo_XueLi"]!=null)
				{
					model.dbo_XueLi=row["dbo_XueLi"].ToString();
				}
				if(row["dbo_WorkTime"]!=null)
				{
					model.dbo_WorkTime=row["dbo_WorkTime"].ToString();
				}
				if(row["dbo_EmpTime"]!=null)
				{
					model.dbo_EmpTime=row["dbo_EmpTime"].ToString();
				}
				if(row["dbo_EmpNum"]!=null)
				{
					model.dbo_EmpNum=row["dbo_EmpNum"].ToString();
				}
				if(row["dbo_School"]!=null)
				{
					model.dbo_School=row["dbo_School"].ToString();
				}
				if(row["dbo_Remarks"]!=null)
				{
					model.dbo_Remarks=row["dbo_Remarks"].ToString();
				}
				if(row["dbo_OfficePhone"]!=null)
				{
					model.dbo_OfficePhone=row["dbo_OfficePhone"].ToString();
				}
				if(row["dbo_HomePhone"]!=null)
				{
					model.dbo_HomePhone=row["dbo_HomePhone"].ToString();
				}
				if(row["dbo_MobilePhone"]!=null)
				{
					model.dbo_MobilePhone=row["dbo_MobilePhone"].ToString();
				}
				if(row["dbo_ShortNumber"]!=null)
				{
					model.dbo_ShortNumber=row["dbo_ShortNumber"].ToString();
				}
				if(row["dbo_HomeAddress"]!=null)
				{
					model.dbo_HomeAddress=row["dbo_HomeAddress"].ToString();
				}
				if(row["dbo_IsDisplay"]!=null && row["dbo_IsDisplay"].ToString()!="")
				{
					if((row["dbo_IsDisplay"].ToString()=="1")||(row["dbo_IsDisplay"].ToString().ToLower()=="true"))
					{
						model.dbo_IsDisplay=true;
					}
					else
					{
						model.dbo_IsDisplay=false;
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
			strSql.Append("select ID,dbo_LoginName,dbo_PassWord,dbo_Name,dbo_Photo,dbo_Email,dbo_Title,dbo_Degree,dbo_Professional,dbo_Group,dbo_InfoBase,dbo_InfoTeac,dbo_InfoStudy,dbo_Order,dbo_Sex,dbo_Minzu,dbo_BirthDay,dbo_JiGuan,dbo_Party,dbo_ParthTime,dbo_ForeignLang,dbo_XueLi,dbo_WorkTime,dbo_EmpTime,dbo_EmpNum,dbo_School,dbo_Remarks,dbo_OfficePhone,dbo_HomePhone,dbo_MobilePhone,dbo_ShortNumber,dbo_HomeAddress,dbo_IsDisplay ");
			strSql.Append(" FROM dbo_TeacherInfo ");
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
			strSql.Append("select count(1) FROM dbo_TeacherInfo ");
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
			strSql.Append(")AS Row, T.*  from dbo_TeacherInfo T ");
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
			parameters[0].Value = "dbo_TeacherInfo";
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

