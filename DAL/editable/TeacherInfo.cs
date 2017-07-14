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
        #region  ExtensionMethod
        /// <summary>
        /// 登陆用户查看
        /// </summary>
        public cycms.Model.TeacherInfo GetAdminInfo(string dbo_LoginName, string dbo_PassWord)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,dbo_LoginName,dbo_PassWord,dbo_Name,dbo_Photo,dbo_Email,dbo_Title,dbo_Degree,dbo_Professional,dbo_Group,dbo_InfoBase,dbo_InfoTeac,dbo_InfoStudy,dbo_Order,dbo_Sex,dbo_Minzu,dbo_BirthDay,dbo_JiGuan,dbo_Party,dbo_ParthTime,dbo_ForeignLang,dbo_XueLi,dbo_WorkTime,dbo_EmpTime,dbo_EmpNum,dbo_School,dbo_Remarks,dbo_OfficePhone,dbo_HomePhone,dbo_MobilePhone,dbo_ShortNumber,dbo_HomeAddress,dbo_IsDisplay from dbo_TeacherInfo ");
            strSql.Append(" where dbo_LoginName=@dbo_LoginName");
            strSql.Append(" and dbo_PassWord=@dbo_PassWord");
            OleDbParameter[] parameters = {
					new OleDbParameter("@dbo_LoginName", OleDbType.VarChar,100),
                    new OleDbParameter("@dbo_PassWord", OleDbType.VarChar,100)
			};
            parameters[0].Value = dbo_LoginName;
            parameters[1].Value = dbo_PassWord;
            cycms.Model.TeacherInfo model = new cycms.Model.TeacherInfo();
            DataSet ds = DbHelperOleDb.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add_ReturnID(cycms.Model.TeacherInfo model)
        {
            StringBuilder strSql = new StringBuilder();
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

            object obj = DbHelperOleDb.GetSingle(strSql.ToString(), parameters);
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
        /// 是否存在用户查看
        /// </summary>
        public bool IfExciet(string dbo_LoginName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,dbo_LoginName,dbo_PassWord,dbo_Name,dbo_Photo,dbo_Email,dbo_Title,dbo_Degree,dbo_Professional,dbo_Group,dbo_InfoBase,dbo_InfoTeac,dbo_InfoStudy,dbo_Order,dbo_Sex,dbo_Minzu,dbo_BirthDay,dbo_JiGuan,dbo_Party,dbo_ParthTime,dbo_ForeignLang,dbo_XueLi,dbo_WorkTime,dbo_EmpTime,dbo_EmpNum,dbo_School,dbo_Remarks,dbo_OfficePhone,dbo_HomePhone,dbo_MobilePhone,dbo_ShortNumber,dbo_HomeAddress,dbo_IsDisplay from dbo_TeacherInfo ");
            strSql.Append(" where dbo_LoginName=@dbo_LoginName");
            OleDbParameter[] parameters = {
					new OleDbParameter("@dbo_LoginName", OleDbType.VarChar,100)
			};
            parameters[0].Value = dbo_LoginName;
            cycms.Model.Admin model = new cycms.Model.Admin();
            DataSet ds = DbHelperOleDb.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion  ExtensionMethod
    }
}
