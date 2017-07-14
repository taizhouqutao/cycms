using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using cycms.Model;
using System.Collections;
namespace cycms.BLL
{
    public partial class ArticleType
    {
        #region  ExtensionMethod
        #region 获取某个节点所有子节点
        public string getAllChildren(int[] fatherid)
        {
            string strChidlrens = string.Empty;
            for (int i = 0; i < fatherid.Length; i++)
            {
                string strTempChidren = getAllChildren(fatherid[i]);
                if (strTempChidren != "")
                {
                    strChidlrens = (strChidlrens == string.Empty) ? strChidlrens : strChidlrens + ","; //如果不是第一个则加上','
                    strChidlrens += strTempChidren;
                }
            }
            return strChidlrens;
        }

        public string getAllChildren(int fatherid)
        {
            DataTable dt = GetList("1=1").Tables[0]; 
            string strChidlrens = string.Empty;

            string strTempChidren = getAllChildren2(dt, fatherid);
            if (strTempChidren != "")
            {
                strChidlrens = (strChidlrens == string.Empty) ? strChidlrens : strChidlrens + ","; //如果不是第一个则加上','
                strChidlrens += strTempChidren;
            }
            return strChidlrens;
        }

        public string getAllChildren2(DataTable dt, int fatherid)
        {
            DataTable dtChildren = getChildNodes(dt, fatherid);

            string strChildren = fatherid.ToString();
            for (int i = 0; i < dtChildren.Rows.Count; i++)
            {
                strChildren += "," + getAllChildren2(dt, Convert.ToInt32(dtChildren.Rows[i]["id"]));
            }
            return strChildren;
        }
        #endregion

        #region 获取某个节点的下一级子节点
        public DataTable getChildNodes(DataTable dt, int fatherid)
        {
            DataTable dtChildren = new DataTable();
            dtChildren.Columns.Add("id", typeof(System.Int32));
            dtChildren.Columns.Add("dbo_typename", typeof(System.String));
            dtChildren.Columns.Add("dbo_linkUrl", typeof(System.String));
            dtChildren.Columns.Add("dbo_fatherid", typeof(System.Int32));
            dtChildren.Columns.Add("dbo_isDisplay", typeof(System.Boolean));
            dtChildren.Columns.Add("dbo_isArticleType", typeof(System.Boolean));


            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (Convert.ToInt32(dt.Rows[i]["dbo_fatherid"]) == fatherid)
                {
                    DataRow dr = dtChildren.NewRow();
                    dr["id"] = dt.Rows[i]["id"];
                    dr["dbo_typename"] = dt.Rows[i]["dbo_typename"];
                    dr["dbo_linkUrl"] = dt.Rows[i]["dbo_linkUrl"];
                    dr["dbo_fatherid"] = dt.Rows[i]["dbo_fatherid"];
                    dr["dbo_isDisplay"] = dt.Rows[i]["dbo_isDisplay"];
                    dr["dbo_isArticleType"] = dt.Rows[i]["dbo_isArticleType"];
                    dtChildren.Rows.Add(dr);
                }
            }

            return dtChildren;
        }

        #endregion

        #region 删除一个节点及其所有字节点，并返回被删除的节点id
        public string DeleteNode(int nodeId)
        {
            string typeids = string.Empty;
            DataTable dt = GetList("dbo_fatherid=" + nodeId.ToString()).Tables[0]; 
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                typeids = DeleteNode(Convert.ToInt32(dt.Rows[i]["id"]));
            }
            Delete(nodeId);
            return (nodeId.ToString() + (typeids == "" ? "" : "," + typeids));

        }
        #endregion

        #region 获取某个专题的所有文章类型
        public int[] getTypeIdsBySpcId(int spcId)
        {
            DataTable dt = GetList("dbo_specialityId=" + spcId).Tables[0]; 
            if (dt.Rows.Count == 0)
            {
                return new int[0];
            }

            int[] typeids = new int[dt.Rows.Count];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                typeids[i] = Convert.ToInt32(dt.Rows[i]["id"]);
            }
            return typeids;

        }
        #endregion

        #region 获取某个节点的父节点
        public int getParentNodeid(int id)
        {
            return Convert.ToInt32(GetModel(id).dbo_Fatherid);
        }
        #endregion

        #region 获取某个节点的所有上级节点
        public int[] getAllParentNodesid(int id)
        {
            if (id == 0) { return new int[] { 0 }; }

            ArrayList al = new ArrayList();
            al.Add(id);
            int parnetid = getParentNodeid(id);
            while (parnetid != 0)
            {
                al.Add(parnetid);
                parnetid = getParentNodeid(parnetid);
            }

            int[] parents = new int[al.Count];
            for (int i = 0; i < al.Count; i++)
            {
                parents[i] = Convert.ToInt32(al[i]);
            }
            return parents;

        }
        #endregion

        #region 重载，获取某个节点的下一级子节点
        public DataTable getChildNodes(int fatherid)
        {
            DataTable dt = GetList("dbo_fatherid=" + fatherid.ToString() + " order by id ").Tables[0];
            return dt;
        }

        #endregion

        /// <summary>
        /// 批量更新SpecialityId
        /// </summary>
        public bool updateSpecialityId(string IDlist,Int32 specialityId)
        {
            return dal.updateSpecialityId(IDlist, specialityId);
        }
        #endregion  ExtensionMethod
    }
}
