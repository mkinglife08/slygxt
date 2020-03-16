/*----------------------------------------------------------------
// Copyright (C) 2018-2019 杭州华卓信息科技有限公司   版权所有。 
// 文件名：InpatientAuthorizedService.cs
// 文件功能描述： 住院病人授权服务层，为（控制器Control、WebService、WebAPI等UI逻辑层）提供住院病人授权相关数据的服务，一般返回与住院病人授权相关的实体或实体集合。
// 创建标识：吕屹凌 2018-12-24 
// 修改标识：
// 修改描述：
----------------------------------------------------------------*/

using EMR.Data;
using EMR.Data.Models;
using EMR.Services.Extension;
using EMR.Services.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace EMR.Services.Server.Doctor
{
    public class InpatientAuthorizedService
    {
        /// <summary>
        /// 授权小时
        /// </summary>
        public int AuthorizedHours = ConfigurationManager.AppSettings["AuthorizedHours"] == null ? 6 : int.Parse(ConfigurationManager.AppSettings["AuthorizedHours"]);

        /// <summary>
        /// 保存住院病人授权
        /// </summary>
        /// <param name="entity"></param>
        public void SaveInfo(CD_InpatientAuthorized entity)
        {
            var cur_entity = EntityOperate<CD_InpatientAuthorized>.GetEntityById(entity.InpatientId, "InpatientId");
            if (cur_entity != null)
            {
                entity.Creator = null;
                entity.CreateTime = null;
                entity.UpdateM("InpatientId");
            }
            else
            {
                entity.SaveModelM();
            }
        }

        /// <summary>
        /// 根据筛选条件查询住院病人授权数据列表
        /// </summary>
        /// <param name="iFilter"></param>
        /// <returns></returns>
        public List<CD_InpatientAuthorized> GetAll(CommonFilter iFilter)
        {
            string filter = "1=1";
            filter += iFilter.GetQueryString();
            List<CD_InpatientAuthorized> list = EntityOperate<CD_InpatientAuthorized>.GetEntityList(filter, "InpatientId");
            
            if (list == null || list.Count <= 0)
            {
                return new List<CD_InpatientAuthorized>();
            }
            return list;
        }
    }
}
