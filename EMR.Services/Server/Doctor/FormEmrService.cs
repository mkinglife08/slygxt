/*----------------------------------------------------------------
// Copyright (C) 2018-2019 杭州华卓信息科技有限公司   版权所有。 
// 文件名：FormEmrService.cs
// 文件功能描述： 病程记录服务层，为（控制器Control、WebService、WebAPI等UI逻辑层）提供病程记录相关数据的服务，一般返回与病程记录相关的实体或实体集合。
// 创建标识：吕屹凌 2019-1-21
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
    public class FormEmrService
    {
        /// <summary>
        /// 保存病程记录
        /// </summary>
        /// <param name="entity"></param>
        public void SaveInfo(CD_FormEmr entity)
        {
            if (!string.IsNullOrWhiteSpace(entity.FormEmrId) && entity.FormEmrId != "null")
            {
                entity.Creator = null;
                entity.CreateTime = null;
                entity.UpdateM("FormEmrId");
            }
            else
            {
                entity.FormEmrId = CommonService.GetPrimaryId(new GI_SerialInfo() { Name = "CD_FormEmr", ColumnName = "FormEmrId", OrganID = entity.OrganID }) + "";
                entity.SaveModelM();
            }
        }

        /// <summary>
        /// 根据筛选条件查询病程记录数据列表
        /// </summary>
        /// <param name="iFilter"></param>
        /// <returns></returns>
        public List<CD_FormEmr> GetAll(CommonFilter iFilter)
        {
            string filter = "1=1";
            filter += iFilter.GetQueryString();
            List<CD_FormEmr> list = EntityOperate<CD_FormEmr>.GetEntityList(filter, "CreateTime");
            if (list == null || list.Count <= 0)
            {
                return new List<CD_FormEmr>();
            }
            return list;
        }

        #region 树结构
        /// <summary>
        /// 获取树数据
        /// </summary>
        /// <param name="ParentID">父类ID</param>
        /// <returns></returns>
        public List<TreeEntityForLayui> GetSingleTreeNode(string ParentID,string InpatientId,int TemplateType)
        {
            List<TreeEntityForLayui> retValue = new List<TreeEntityForLayui>();
            List<V_FormEmr> list = EntityOperate<V_FormEmr>.GetEntityList("InpatientId = '"+ InpatientId + "' and TemplateType = "+ TemplateType).ToList();
            if (list != null && list.Count > 0)
            {
                list.ForEach((f) =>
                {
                    TreeEntityForLayui tree = new TreeEntityForLayui() { name = f.TemplateName, id = f.FormEmrId, pid = ParentID };
                    //if (f.ISLAST != 1)//如果不是末级，则加子级
                    //    tree.children = new List<TreeEntityForLayui>();
                    retValue.Add(tree);
                });
            }
            return retValue;
        }
        #endregion
    }
}
