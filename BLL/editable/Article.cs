using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using cycms.Model;
using System.Collections.Specialized;
namespace cycms.BLL
{
    public partial class Article
    {
        ArticleType bllarticletype = new ArticleType();
        Model.Article model = new Model.Article();
        #region  ExtensionMethod
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add_ReturnID(cycms.Model.Article model)
        {
            return dal.Add_ReturnID(model);
        }

        /// <summary>
        /// 删除文章
        /// </summary>
        public bool DeleteArticlesByTypeids(string typeids)
        {
            return dal.DeleteArticlesByTypeids(typeids);
        }

        /// <summary>
        /// 根据ID列表批量更新文章类别
        /// </summary>
        public bool UpdateTypeidByIdList(int typeid,string IdList)
        {
            return dal.UpdateTypeidByIdList(typeid, IdList);
        }

        /// <summary>
        /// 统计某个专题中的文章数目
        /// </summary>
        public int getArticleCountBySpcId(int spcId)
        {
            int[] typeids = bllarticletype.getTypeIdsBySpcId(spcId);
            if (typeids.Length == 0)
            {
                return 0;
            }
            string strTypes = string.Empty;
            int i;
            for (i = 0; i < typeids.Length - 1; i++)
            {
                strTypes += typeids[i].ToString() + ",";
            }
            strTypes += typeids[i].ToString();
            return GetList("dbo_typeid in(" + strTypes + ") ").Tables[0].Rows.Count;
        }

        /// <summary>
        /// 更新点击次数
        /// </summary>
        /// <param name="nv"></param>
        public void updateClicks(NameValueCollection nv)
        {
            for (int i = 0; i < nv.Count; i++)
            {
                model=GetModel(Convert.ToInt32(nv.GetKey(i)));
                model.dbo_Click = Convert.ToInt32(nv[nv.GetKey(i)]);
                Update(model);
            }
        }

        /// <summary>
        /// 分页调用
        /// </summary>
        public DataTable getPagerArticle(int pageIndex, int pageSize, out int rowcount, int[] typeids, string strFiter)
        {
            int pageCount = 0;
            string orderString = " dbo_isTop asc, id desc ";  //排序
            string typeidsString = "";
            typeidsString=bllarticletype.getAllChildren(typeids);
            if (string.IsNullOrEmpty(strFiter)||strFiter.Trim()=="")
                strFiter = "where dbo_typeid in (" + typeidsString + ")";
            else
                strFiter = "where dbo_typeid in (" + typeidsString + ") and " + strFiter;
            return dal.ExecutePager(pageIndex, pageSize, strFiter, orderString, out pageCount,out rowcount);
        }

        #endregion  ExtensionMethod
    }
}
