/*----------------------------------------------------------------
// Copyright (C) 2018-2019 杭州华卓信息科技有限公司   版权所有。 
// 文件名：CodeDictService.cs
// 文件功能描述： 通用数据服务层，为（控制器Control、WebService、WebAPI等UI逻辑层 以及 其他服务层）提供相关通用数据的服务。
// 创建标识：吕屹凌 2018-12-10 
// 修改标识：
// 修改描述：
----------------------------------------------------------------*/

using EMR.Data;
using EMR.Data.Models;
using System;
using System.Collections.Generic;

namespace EMR.Services
{
    public static class CommonService
    {
        #region 获取自增型主键ID
        /// <summary>
        /// 获取自增型主键ID
        /// </summary>
        /// <param name="_GI_SERIALINFO"></param>
        /// <returns></returns>
        public static int GetPrimaryId(GI_SerialInfo _GI_SERIALINFO)
        {
            int iReturn = 1;
            string CURRENTID = EntityOperate<string>.dataProvider.ExecuteScalar(string.Format("select CURRENTID from GI_SERIALINFO where  NAME = '{1}' and  COLUMNNAME = '{2}'", _GI_SERIALINFO.OrganID, _GI_SERIALINFO.Name, _GI_SERIALINFO.ColumnName)) + "";
            if (!int.TryParse(CURRENTID, out iReturn))
            {
                iReturn = 1;
                EntityOperate<string>.dataProvider.ExecuteNonQuery(string.Format("insert into GI_SERIALINFO(KEYID,ORGINID,NAME,COLUMNNAME,CURRENTID) values(seq_gi_serialinfo.nextval,'{0}','{1}','{2}','{3}')", _GI_SERIALINFO.OrganID, _GI_SERIALINFO.Name, _GI_SERIALINFO.ColumnName, iReturn));
            }
            else
            {
                iReturn++;
                EntityOperate<string>.dataProvider.ExecuteNonQuery(string.Format("update GI_SERIALINFO set CURRENTID = '{3}' where  NAME = '{1}' and  COLUMNNAME = '{2}'", _GI_SERIALINFO.OrganID, _GI_SERIALINFO.Name, _GI_SERIALINFO.ColumnName, iReturn));
            }
            return iReturn;
        }
        #endregion

        /// <summary>
        /// 通过字典编码和父类ID，获取相应的字典名称。
        /// </summary>
        /// <param name="parentID">父类ID</param>
        /// <param name="dictCode">字典编码</param>
        /// <returns></returns>
        public static string GetDictNameByID(string parentID, string dictCode)
        {
            string retValue = "";
            retValue = EntityOperate<string>.ExecSqlString(string.Format("select DictName from GI_CODEDICT where ParentID = '{0}' and DictCode = '{1}'", parentID, dictCode)) + "";
            return retValue;
        }
    }
}
