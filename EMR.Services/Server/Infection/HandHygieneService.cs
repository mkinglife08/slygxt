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
using EMR.Common;

namespace EMR.Services.Server.Infection
{
    public class HandHygieneService
    {
        /// <summary>
        /// 获取手卫生依从性及正确性现场调查列表
        /// </summary>
        /// <param name="iFilter"></param>
        /// <returns></returns>
        public List<BUS_HANDHYGIENE> GetAllHandHygieneService(CommonFilter iFilter)
        {
            string filter = "1=1";
            filter += iFilter.GetQueryString();
            List<BUS_HANDHYGIENE> list = EntityOperate<BUS_HANDHYGIENE>.GetEntityList(filter, "HANDID desc");

            if (list == null || list.Count <= 0)
            {
                return new List<BUS_HANDHYGIENE>();
            }
            return list;
        }

        /// <summary>
        /// 根据ID获取手卫生依从性及正确性现场调查评分数据表
        /// </summary>
        /// <param name="iFilter"></param>
        /// <returns></returns>
        public Tuple<List<BUS_HANDHYGIENE_SOURCE>, List<AI_DeptInfo>, BUS_HANDHYGIENE> GetHandHygieneSourceList(CommonFilter iFilter, string HANDID)
        {
            string filter = "1=1";
            filter += iFilter.GetQueryString();
            //if (!string.IsNullOrWhiteSpace(RISKID)) { filter += " and RISKID='" + RISKID + "'"; }

            List<BUS_HANDHYGIENE_SOURCE> list = EntityOperate<BUS_HANDHYGIENE_SOURCE>.GetEntityList(filter + (string.IsNullOrWhiteSpace(HANDID) == true ? "" : " and HANDID='" + HANDID + "'"));
            var model = EntityOperate<BUS_HANDHYGIENE>.GetEntityById(HANDID, "HANDID");

            var departList = EntityOperate<AI_DeptInfo>.GetEntityList(filter + (model == null ? "" : " and deptid='" + model.DEPTID + "'"), "ParentID,DeptID");
            var tupe = new Tuple<List<BUS_HANDHYGIENE_SOURCE>, List<AI_DeptInfo>, BUS_HANDHYGIENE>(list, departList, model);
            return tupe;
        }

        /// <summary>
        /// 根据ID获取手卫生依从性调查评分 数据分析表
        /// </summary>
        /// <param name="iFilter"></param>
        /// <param name="HANDID"></param>
        public Tuple<List<HandHygieneGroupAnalysis>, List<HandHygieneDczs>, List<HandHygieneOpModel>> GetHandHygiAnalysisSourceList(CommonFilter iFilter, string HANDID)
        {
            string filter = "1=1";
            filter += iFilter.GetQueryString();


            Func<string, int> funcSort = v =>
            {
                var sort = 0;
                switch (v)
                {
                    case "护士":
                        sort = 1;
                        break;
                    case "医技":
                        sort = 2;
                        break;
                    case "医生":
                        sort = 3;
                        break;
                    case "工人":
                        sort = 4;
                        break;
                }
                return sort;
            };

            List<BUS_HANDHYGIENE_SOURCE> handHygiSource = EntityOperate<BUS_HANDHYGIENE_SOURCE>.GetEntityList(filter + (string.IsNullOrWhiteSpace(HANDID) == true ? "" : " and HANDID='" + HANDID + "'"));

            var handHygieneGroupList = handHygiSource.GroupBy(p => p.ZY).Select(g => new HandHygieneGroupAnalysis
            {

                handhygiene_source = g,
                zy = g.Key,
                sort = funcSort(g.Key),
                currentSum = g.Count()

            }).OrderBy(g => g.sort).ToList();

            //调查总数
            #region
            var dczsSql = string.Format(@" select * from 
                            (select count(jcbrq) jcbrq ,zy  from bus_handhygiene_source  where jcbrq != '正确'  and handid ={0}  group by zy ) 
                            pivot 
                            (
                               sum(jcbrq) for
                               zy in ('医生' ys,'护士' hs,'医技' yj,'工人' gr)
                            )
                            union all 
                            select * from 
                            (select count(JCBRH) JCBRH ,zy  from bus_handhygiene_source  where  JCBRH != '正确' and handid ={0} group by zy ) 
                            pivot 
                            (
                               sum(JCBRH) for
                               zy in ('医生' ys,'护士' hs,'医技' yj,'工人' gr)
                            ) 
                            union all 
                            select * from 
                            (select count(JCWJWPQ) JCWJWPQ ,zy  from bus_handhygiene_source  where  JCWJWPQ != '正确' and handid ={0} group by zy ) 
                            pivot 
                            (
                               sum(JCWJWPQ) for
                               zy in ('医生' ys,'护士' hs,'医技' yj,'工人' gr)
                            ) 
                            union all 
                            select * from 
                            (select count(JCBRHJH) JCBRHJH ,zy  from bus_handhygiene_source  where  JCBRHJH != '正确' and handid = {0} group by zy ) 
                            pivot 
                            (
                               sum(JCBRHJH) for
                               zy in ('医生' ys,'护士' hs,'医技' yj,'工人' gr)
                            )
                            union all 
                            select * from 
                            (select count(JCWWH) JCWWH ,zy  from bus_handhygiene_source  where  JCWWH != '正确' and handid = {0} group by zy ) 
                            pivot 
                            (
                               sum(JCWWH) for
                               zy in ('医生' ys,'护士' hs,'医技' yj,'工人' gr)
                            )
                            union all 
                            select * from 
                            (select count(PCQ) PCQ ,zy  from bus_handhygiene_source  where  PCQ != '正确' and handid = {0} group by zy ) 
                            pivot 
                            (
                               sum(PCQ) for
                               zy in ('医生' ys,'护士' hs,'医技' yj,'工人' gr)
                            )", HANDID);

            #endregion
            var dczsListSource = EntityOperate<HandHygieneDczs>.GetEntityListBySQL(dczsSql);

            var ysOpCount = dczsListSource.Sum(p => p.ys); //医生操作总数
            var hsOpCount = dczsListSource.Sum(p => p.hs); //护士操作总数
            var yjOpCount = dczsListSource.Sum(p => p.yj); //医技操作总数
            var grOpCount = dczsListSource.Sum(p => p.gr); //工人操作总数
            dczsListSource.Add(new HandHygieneDczs { ys = ysOpCount, hs = hsOpCount, yj = yjOpCount, gr = grOpCount });

           // List<HandHygieneDczs> dczsList = new List<HandHygieneDczs>();
           // string[] itemArr = { "接触病人前", "接触病人后", "无菌操作前", "接触病人周围环境后", "接触污物（摘手套）后", "配餐前", "总数" };
            


            var opModelList = new List<HandHygieneOpModel>();
            string[] zyArr = { "医生", "护士", "医技", "工人" };
            foreach (var zyItem in zyArr)
            {
                //获取操作列表sql 
                var getOpList = string.Format(@"select sum(case jcbrq when '消' then 1 else 0  end) x,sum(case jcbrq when '洗' then 1 else 0  end) xx, sum(case jcbrq when '未' then 1 else 0  end) w 
                                              from bus_handhygiene_source  where zy = '{0}' and handid = {1} union all  --医生接触病人前
  
                                            select sum(case JCBRH when '消' then 1 else 0  end) x,sum(case JCBRH when '洗' then 1 else 0  end) xx, sum(case JCBRH when '未' then 1 else 0  end) w 
                                              from bus_handhygiene_source  where zy = '{0}' and handid = {1} union all  --接触病人后
  
                                            select sum(case JCWJWPQ when '消' then 1 else 0  end) x,sum(case JCWJWPQ when '洗' then 1 else 0  end) xx, sum(case JCWJWPQ when '未' then 1 else 0  end) w 
                                              from bus_handhygiene_source  where zy = '{0}' and handid = {1} union all   --接触无菌物品前
  
                                            select sum(case JCBRHJH when '消' then 1 else 0  end) x,sum(case JCBRHJH when '洗' then 1 else 0  end) xx, sum(case JCBRHJH when '未' then 1 else 0  end) w  
                                              from bus_handhygiene_source  where zy = '{0}' and handid = {1} union all --接触病人周围环境后
  
                                            select sum(case JCWWH when '消' then 1 else 0  end) x,sum(case JCWWH when '洗' then 1 else 0  end) xx, sum(case JCWWH when '未' then 1 else 0  end) w  
                                              from bus_handhygiene_source  where zy = '{0}' and handid = {1} union all  --接触污物（摘手套）后
  
                                            select sum(case PCQ when '消' then 1 else 0  end) x,sum(case PCQ when '洗' then 1 else 0  end) xx, sum(case PCQ when '未' then 1 else 0  end) w 
                                              from bus_handhygiene_source  where zy = '{0}'and handid = {1}   --配餐前", zyItem, HANDID);
                HandHygieneOpModel opModel = new HandHygieneOpModel();
                var opList = EntityOperate<OpCategory>.GetEntityListBySQL(getOpList);
                opModel.zyName = zyItem;
                opModel.opList = opList;
                var opCategoryModel = new OpCategory { x = opList.Select(p=>p.x).Sum(), xx = opList.Select(p => p.xx).Sum(), w = opList.Select(p => p.w).Sum() };
                opModel.opList.Add(opCategoryModel);
                opModelList.Add(opModel);
            }
             
            return new Tuple<List<HandHygieneGroupAnalysis>, List<HandHygieneDczs>, List<HandHygieneOpModel>>(handHygieneGroupList, dczsListSource, opModelList);
        }


        /// <summary>
        /// 批量保存手卫生依从性及正确性现场调查评分数据，采用的方式是根据主表ID 删掉数据表中的数据，再批量添加进去
        /// </summary>
        /// <param name="fkdModel"></param>
        /// <param name="fkdSourceModel"></param>
        /// <returns></returns>
        public void Save(BUS_HANDHYGIENE mainModel, string handSource)
        {
            if (!string.IsNullOrWhiteSpace(mainModel.HANDID))
            {
                //根据父ID删掉BUS_RISKINFECTION_SOURCE数据库表中的数据 
                EntityOperate<BUS_HANDHYGIENE_SOURCE>.DeleteByFilter("HANDID='" + mainModel.HANDID + "' and ORGANID = '" + mainModel.ORGANID + "'");
            }

            if (string.IsNullOrWhiteSpace(mainModel.HANDID))
            {
                mainModel.HANDID = CommonService.GetPrimaryId(new GI_SerialInfo() { Name = "BUS_HANDHYGIENE", ColumnName = "HANDID", OrganID = mainModel.ORGANID }) + "";
                mainModel.SaveModelM();
            }
            else
            {
                mainModel.UpdateM("HANDID");
            }

            Func<string, bool> checkVal = s =>
            {
                return string.IsNullOrWhiteSpace(s);
            };
            var handSourceList = JSONHelper.DeserializeObject<List<BUS_HANDHYGIENE_SOURCE>>(handSource,"yyyy-MM-dd HH:ss:mm");
            var handSourceFiltered = handSourceList.Where(p => p.SJDONE != null || p.SJDTWO != null || checkVal(p.XM) != true || checkVal(p.ZY) != true || checkVal(p.JCBRQ) != true || checkVal(p.JCBRH) != true || checkVal(p.JCWJWPQ) != true || checkVal(p.JCBRHJH) != true || checkVal(p.JCWWH) != true || checkVal(p.PCQ) != true || checkVal(p.DCZ) != true);
           // var riskSourceFiltered = riskSourceList.Where(p => string.IsNullOrWhiteSpace(p.FLMC) != true || string.IsNullOrWhiteSpace(p.NR) != true || string.IsNullOrWhiteSpace(p.QZ) != true || string.IsNullOrWhiteSpace(p.KNX) != true || string.IsNullOrWhiteSpace(p.HGSS) != true || string.IsNullOrWhiteSpace(p.DQTX) != true || string.IsNullOrWhiteSpace(p.FZ) != true);

            //过滤后的数据集合大于0
            if (handSourceFiltered.Count() > 0)
            {
                //把过滤后的数据插入数据库
                foreach (var handSourceModel in handSourceFiltered)
                {
                    handSourceModel.HANDSID = CommonService.GetPrimaryId(new GI_SerialInfo() { Name = "BUS_HANDHYGIENE_SOURCE", ColumnName = "HANDSID", OrganID = mainModel.ORGANID }) + "";
                    handSourceModel.ORGANID = mainModel.ORGANID;
                    handSourceModel.HANDID = mainModel.HANDID;
                    handSourceModel.SaveModelM();
                }
            }

        }
    }
}
