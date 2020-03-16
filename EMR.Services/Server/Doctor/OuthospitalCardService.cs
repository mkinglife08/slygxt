/*----------------------------------------------------------------
// Copyright (C) 2018-2019 杭州华卓信息科技有限公司   版权所有。 
// 文件名：OuthospitalCardService.cs
// 文件功能描述： 出院证明服务层，为（控制器Control、WebService、WebAPI等UI逻辑层）提供出院证明相关数据的服务，一般返回与出院证明相关的实体或实体集合。
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

namespace EMR.Services.Server.Doctor
{
    public class OuthospitalCardService
    {
        /// <summary>
        /// 保存出院证明
        /// </summary>
        /// <param name="entity"></param>
        public void SaveInfo(CD_OuthospitalCard entity)
        {
            var cur_entity = EntityOperate<CD_OuthospitalCard>.GetEntityById(entity.InpatientId, "InpatientId");
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
        /// 根据筛选条件查询出院证明数据列表
        /// </summary>
        /// <param name="iFilter"></param>
        /// <returns></returns>
        public List<CD_OuthospitalCard> GetAll(CommonFilter iFilter)
        {
            string filter = "1=1";
            filter += iFilter.GetQueryString();
            List<CD_OuthospitalCard> list = EntityOperate<CD_OuthospitalCard>.GetEntityList(filter, "InpatientId");
            
            if (list == null || list.Count <= 0)
            {
                return new List<CD_OuthospitalCard>();
            }
            return list;
        }
    }
}
