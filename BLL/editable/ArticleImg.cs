using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using cycms.Model;

namespace cycms.BLL
{
    public partial class ArticleImg
    {
        #region  ExtensionMethod
        /// <summary>
        /// 根据文章ID删除一条数据
        /// </summary>
        public bool DeleteByArticleId(int ArticleId)
        {

            return dal.DeleteByArticleId(ArticleId);
        }

        /// <summary>
        /// 根据文章列表ID删除一条数据
        /// </summary>
        public bool DeleteByArticleIdList(string ArticleIdList)
        {

            return dal.DeleteByArticleIdList(ArticleIdList);
        }
        #endregion  ExtensionMethod
    }
}
