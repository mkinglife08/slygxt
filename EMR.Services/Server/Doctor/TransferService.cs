/*----------------------------------------------------------------
// Copyright (C) 2018-2019 杭州华卓信息科技有限公司   版权所有。 
// 文件名：BasicInpatientInfoService.cs
// 文件功能描述：转科信息服务层，为（控制器Control、WebService、WebAPI等UI逻辑层）提供病人基本信息相关数据的服务，一般返回与病人基本信息相关的实体或实体集合。
// 创建标识：朱天伟 2019-5-23 
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
    public class TransferService
    {
        /// <summary>
        /// 根据病人ID获得转科信息
        /// </summary>
        /// <returns></returns>
        public List<CD_Transfer> GetListByInpatientId(string InpatientId) {
            List<CD_Transfer> list = EntityOperate<CD_Transfer>.GetEntityList("InpatientId='" + InpatientId + "' ", " CREATETIME desc");
            return list;
        }

        /// <summary>
        /// 获得转科信息
        /// </summary>
        /// <param name="where">条件</param>
        /// <returns></returns>
        public List<CD_Transfer> GetList(string where="") {
            string sql = string.Format(@"
                    select t.*,i.name InpatientName,i.HealthCard,olddept.deptname OldDeptName ,oldward.deptname OldWardName,currentdept.deptname CurrentDeptName,currentward.deptname CurrentWardName
                    from CD_TRANSFER t 
                    left join CD_INPATIENT i on i.inpatientid=t.inpatientid
                    left join AI_DEPTINFO olddept on olddept.Deptid=t.olddeptid
                    left join AI_DEPTINFO oldward on oldward.Deptid=t.oldwardid
                    left join AI_DEPTINFO currentdept on currentdept.Deptid=t.currentdeptid
                    left join AI_DEPTINFO currentward on currentward.Deptid=t.currentwardid
                    where 1=1 {0} order by ConversionTime desc
            ", where);

            List<CD_Transfer> list = EntityOperate<CD_Transfer>.GetEntityListBySQL(sql);

            return list;
        }
    }
}
