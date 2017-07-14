using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using cycms.Model;
namespace cycms.BLL
{
    public partial class Speciality
    {
        BLL.ArticleType bllarticletype = new ArticleType();
        BLL.Article bllarticle = new Article();
        #region  ExtensionMethod
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool RealDelete(int ID)
        {
            DataTable dt = bllarticletype.GetList("dbo_fatherid=0 and dbo_specialityId=" + ID).Tables[0];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string typeids = bllarticletype.DeleteNode(Convert.ToInt32(dt.Rows[i]["id"]));
                bllarticle.DeleteArticlesByTypeids(typeids);
            }
            return dal.Delete(ID);
        }
        #endregion  ExtensionMethod
    }
}
