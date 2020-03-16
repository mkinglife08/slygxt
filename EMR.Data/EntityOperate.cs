using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using EMR.Data.CustomAttribute;
using System.Data.Common;
using EMR.Core.Caching;
using EMR.Data.CustomeAttribute;
using EMR.Data.Domain;
using System.Configuration;
using EMR.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace EMR.Data
{
    public class EntityOperate<T>
        where T : class
    {
        public static API_DataGet_Config APIConfig { get; set; }

        private static IDataProvider _dataProvider;

        public EntityOperate(Enum DataProviderName, string DBConnectionString)
        {
            if (!string.IsNullOrWhiteSpace(DataProviderName.ToString()))
            {
                Assembly assembly = Assembly.Load("EMR.Data");
                var type = assembly.GetType("EMR.Data." + DataProviderName + "DataProvider");
                dataProvider = (IDataProvider)Activator.CreateInstance(type, new object[] { DBConnectionString });
            }
        }
        /// <summary>
        /// 这里可以用配置文件进行控制
        /// </summary>
        public static IDataProvider dataProvider
        {
            get
            {
                string strDataProviderName = ConfigurationManager.AppSettings["DataProvider"];
                string DBConnectionString = null;
                //APIConfig = new API_DataGet_Config() { DataProvider=DataProviderEnum.oracle,DBConnectionString="",HisCode="",HospitalId="",Sql="" };
                if (APIConfig != null)
                {
                    strDataProviderName = APIConfig.DataProvider.ToString();
                    DBConnectionString = APIConfig.DBConnectionString;
                }
                Assembly assembly = Assembly.Load("EMR.Data");
                var type = assembly.GetType("EMR.Data." + strDataProviderName + "DataProvider");
                return (IDataProvider)Activator.CreateInstance(type, new object[] { DBConnectionString });
            }
            set { _dataProvider = value; }
        }
        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public static int AddEntity(T entity, string strAutoId = "id")
        {
            int ireturn = 0;
            if (entity == null)
            {
                return ireturn;
            }
            PropertyInfo[] properties = entity.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);

            if (properties.Length <= 0)
            {
                return ireturn;
            }
            DbParameter[] iParameters = new DbParameter[properties.Length];
            string strAddField = "", strFieldValue = "";
            int myIndex = 0;
            bool UseSqlParameter = (entity.GetType().GetCustomAttribute<FieldTypeAttribute>() != null && entity.GetType().GetCustomAttribute<FieldTypeAttribute>().fieldType == FieldTypeEnum.DoNotUseSqlParameter) ? false : true;
            string prameterString = "", prameterValue = "";
            foreach (PropertyInfo item in properties)
            {
                string name = item.Name;
                object value = item.GetValue(entity, null);
                if ((item.PropertyType.IsValueType || item.PropertyType.Name.StartsWith("String")) && value != null && name.ToLower() != strAutoId.ToLower())
                {
                    strAddField += name.ToUpper() + ",";

                    //if (value is string && UseSqlParameter)
                    //{
                    //    iParameters[myIndex] = dataProvider.CreateParameter(name, value + "");
                    //    //iParameters[myIndex].ParameterName = "@" + name;
                    //    //iParameters[myIndex].Value = value;
                    //    //iParameters[myIndex].DbType = DbType.String;
                    //    //iParameters[myIndex].Size = 600;
                    //    strFieldValue += "@" + name + ",";
                    //    myIndex++;
                    //}
                    if (value is DateTime)
                    {
                        //如果该字段是CreateTime且为空，在新增的时候自动插入当前时间。
                        if (DateTime.Parse(value + "") < DateTime.Parse("1800-1-1") && name.ToUpper() == "CREATETIME")
                            value = DateTime.Now;
                        if (dataProvider is OracleDataProvider && DateTime.Parse(value + "") > DateTime.Parse("1800-1-1"))
                        {
                            DateTime dateTime = DateTime.Parse(value + "");
                            if (dateTime.Hour == 0 && dateTime.Minute == 0 && dateTime.Second == 0 && dateTime.Millisecond == 0)
                                strFieldValue += "to_date('" + DateTime.Parse(value.ToString()).ToString("yyyy-MM-dd") + "','yyyy-MM-dd'),";
                            else
                                strFieldValue += "to_date('" + DateTime.Parse(value.ToString()).ToString("yyyy-MM-dd HH:mm:ss") + "','yyyy-MM-dd HH24:mi:ss'),";
                        }
                    }
                    else
                    {
                        int MaxLength = item.GetCustomAttribute<StringLengthAttribute>() != null ? item.GetCustomAttribute<StringLengthAttribute>().MaximumLength : 0;
                        if (dataProvider is OracleDataProvider && MaxLength >= 5000)
                        {
                            prameterString += name.ToUpper() + "1 clob;";
                            prameterValue += name.ToUpper() + "1:='" + value + "';";
                            strFieldValue += name.ToUpper() + "1,";
                        }
                        else
                            strFieldValue += "'" + value + "',";
                    }
                }
            }
            string strSQL = string.Format("insert into {0}({1}) values({2})", entity.GetType().Name, strAddField.Trim(','), strFieldValue.Trim(','));
            if (dataProvider is OracleDataProvider && prameterString != "")
            {
                strSQL = string.Format("DECLARE {0} BEGIN {1} {2}; COMMIT;END;", prameterString, prameterValue, strSQL);
            }
            int.TryParse(dataProvider.ExecuteScalar(strSQL, iParameters) + "", out ireturn);
            return ireturn;
        }
        /// <summary>
        /// 更新实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static T UpdateEntity(T entity)
        {
            return UpdateEntity(entity, "id");
        }
        /// <summary>
        /// 根据某个字段更新实体数据
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="strPrimaryKey">主键</param>
        /// <returns></returns>
        public static T UpdateEntity(T entity, string strPrimaryKey)
        {
            //DataSet ireturn = new DataSet();
            //int ireturn = 0;
            if (entity == null)
            {
                return default(T);
            }
            PropertyInfo[] properties = entity.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);

            if (properties.Length <= 0)
            {
                return default(T);
            }
            DbParameter[] iParameters = new DbParameter[properties.Length];
            string strUpdateField = "", strFilter = "";
            int myIndex = 0;
            string prameterString = "", prameterValue = "";
            foreach (PropertyInfo item in properties)
            {
                string name = item.Name;
                object value = item.GetValue(entity, null);
                if ((item.PropertyType.IsValueType || item.PropertyType.Name.StartsWith("String")) && value != null)
                {
                    if (name.ToLower() == strPrimaryKey.ToLower())
                    {
                        iParameters[myIndex] = dataProvider.CreateParameter("@" + name, value + "");
                        strFilter = name + "='" + value + "'";
                        myIndex++;
                    }
                    else if (name.ToLower() != "id")
                    {
                        //if (value is string)
                        //{
                        //    iParameters[myIndex] = dataProvider.CreateParameter("@" + name, value.ToString());
                        //    strUpdateField += name + "=@" + name + ",";
                        //    myIndex++;
                        //}
                        if (value is DateTime)
                        {
                            if (dataProvider is OracleDataProvider && DateTime.Parse(value + "") > DateTime.Parse("1800-1-1"))
                            {
                                DateTime dateTime = DateTime.Parse(value + "");
                                if (dateTime.Hour == 0 && dateTime.Minute == 0 && dateTime.Second == 0 && dateTime.Millisecond == 0)
                                    strUpdateField += name + "=to_date('" + DateTime.Parse(value.ToString()).ToString("yyyy-MM-dd") + "','yyyy-MM-dd'),";
                                else
                                    strUpdateField += name + "=to_date('" + DateTime.Parse(value.ToString()).ToString("yyyy-MM-dd HH:mm:ss") + "','yyyy-MM-dd HH24:mi:ss'),";
                            }
                        }
                        else
                        {
                            int MaxLength = item.GetCustomAttribute<StringLengthAttribute>() != null ? item.GetCustomAttribute<StringLengthAttribute>().MaximumLength : 0;
                            if (dataProvider is OracleDataProvider && MaxLength >= 5000)
                            {
                                prameterString += name.ToUpper() + "1 clob;";
                                prameterValue += name.ToUpper() + "1:='" + value + "';";
                                strUpdateField += name.ToUpper() + "="+ name.ToUpper() + "1,";
                            }
                            else
                                strUpdateField += name + "='" + value + "',";
                        }
                    }
                }
            }
            string strSQL = string.Format("update {0} set {1} where {2}", entity.ToString().Substring(entity.ToString().LastIndexOf(".") + 1), strUpdateField.Trim(','), strFilter);
            if (dataProvider is OracleDataProvider && prameterString != "")
            {
                strSQL = string.Format("DECLARE {0} BEGIN {1} {2}; COMMIT;END;", prameterString, prameterValue, strSQL);
            }
            //int.TryParse(dataProvider.ExecuteScalar(strSQL, iParameters) + "", out ireturn);
            try
            {
                entity = DataSetToEntity(dataProvider.GetDataSet(strSQL, iParameters));
            }
            catch (Exception e)
            {
                return entity;
            }

            return entity;
        }

        /// <summary>
        /// 根据主键或某个字段获取实体
        /// </summary>
        /// <param name="strPrimaryKeyValue"></param>
        /// <param name="strPrimaryKeyName"></param>
        /// <returns></returns>
        public static T GetEntityById(string strPrimaryKeyValue, string strPrimaryKeyName = "id",bool isDefaultCance=false)
        {
            string filter = "";
            T _t = (T)Activator.CreateInstance(typeof(T));
            PropertyInfo[] propertys = _t.GetType().GetProperties();
            if (propertys.Where(f => f.Name.ToUpper().Equals("DEL")).Count() > 0 && !isDefaultCance)
            {
                filter += " and nvl(DEL,0) <> 1";
            }
            if (propertys.Where(f => f.Name.ToUpper().Equals("ISCANCE")).Count() > 0 && !isDefaultCance)
            {
                filter += " and nvl(ISCANCE,0) <> 1";
            }
            return DataSetToEntity(dataProvider.GetDataSet(string.Format("select * from {0} where {1}='{2}'" + filter, typeof(T).Name, strPrimaryKeyName, strPrimaryKeyValue)), 0);
        }


        /// <summary>
        /// 通过SQL语句获取实体
        /// </summary>
        /// <param name="strSQL"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static T GetEntityBySQL(string strSQL, params DbParameter[] parameters)
        {
            return DataSetToEntity(dataProvider.GetDataSet(strSQL, parameters), 0);
        }

        public static T DataSetToEntity(DataSet p_DataSet)
        {
            return DataSetToEntity(p_DataSet, 0);
        }
        /// <summary>
        /// DataSet转换为实体类
        /// </summary>
        /// <typeparam name="T">实体类</typeparam>
        /// <param name="p_DataSet">DataSet</param>
        /// <param name="p_TableIndex">待转换数据表索引</param>
        /// <returns>实体类</returns>
        public static T DataSetToEntity(DataSet p_DataSet, int p_TableIndex)
        {
            if (p_DataSet == null || p_DataSet.Tables.Count < 0)
                return default(T);
            if (p_TableIndex > p_DataSet.Tables.Count - 1)
                return default(T);
            if (p_TableIndex < 0)
                p_TableIndex = 0;
            if (p_DataSet.Tables[p_TableIndex].Rows.Count <= 0)
                return default(T);

            DataRow p_Data = p_DataSet.Tables[p_TableIndex].Rows[0];
            // 返回值初始化
            T _t = (T)Activator.CreateInstance(typeof(T));
            PropertyInfo[] propertys = _t.GetType().GetProperties();
            int curIndex = 0;
            foreach (PropertyInfo pi in propertys)
            {
                try
                {
                    if (p_DataSet.Tables[p_TableIndex].Columns.IndexOf(pi.Name.ToUpper()) != -1 && p_Data[pi.Name.ToUpper()] != DBNull.Value)
                    {
                        if (p_Data[pi.Name.ToUpper()] is System.Boolean)
                            pi.SetValue(_t, Convert.ToBoolean(p_Data[pi.Name.ToUpper()]), null);
                        else if (p_Data[pi.Name.ToUpper()] is System.Byte)
                            pi.SetValue(_t, Convert.ToInt32(p_Data[pi.Name.ToUpper()]), null);
                        else if (pi.PropertyType.AssemblyQualifiedName.Contains("Int"))
                            pi.SetValue(_t, Convert.ToInt32(p_Data[pi.Name.ToUpper()]), null);
                        else if (pi.PropertyType.AssemblyQualifiedName.Contains("Decimal"))
                            pi.SetValue(_t, Convert.ToDecimal(p_Data[pi.Name.ToUpper()]), null);
                        else if (pi.PropertyType.AssemblyQualifiedName.Contains("Double"))
                            pi.SetValue(_t, Convert.ToDouble(p_Data[pi.Name.ToUpper()]), null);
                        else if (pi.PropertyType.AssemblyQualifiedName.Contains("String"))
                            pi.SetValue(_t, p_Data[pi.Name.ToUpper()] + "", null);
                        else
                            pi.SetValue(_t, p_Data[pi.Name.ToUpper()], null);
                    }
                    else if (pi.CanWrite)
                    {
                        pi.SetValue(_t, null, null);
                    }
                }
                catch (Exception err)
                {
                    throw new Exception(curIndex + "." + err.Message + "\r\n" + pi.Name + "\r\n" + _t.GetType().ToString());
                }
                finally
                {
                    curIndex++;
                }
            }
            return _t;
        }

        /// <summary>
        /// 通过SQL语句获取实体集
        /// </summary>
        /// <param name="strSQL"></param>
        /// <param name="aa"></param>
        /// <returns></returns>
        public static List<T> GetEntityListBySQL(string strSQL, params DbParameter[] aa)
        {
            IList<T> ilist = DataSetToEntityList(dataProvider.GetDataSet(strSQL, aa), 0);
            if (ilist != null && ilist.Count() > 0)
                return ilist.ToList();
            else
                return new List<T>();
        }
        /// <summary>
        /// 通过查询条件获取实体集
        /// </summary>
        /// <param name="filter">查询条件</param>
        /// <param name="orderby">排序</param>
        /// <returns></returns>
        public static List<T> GetEntityList(string filter = "", string orderby = "",bool isDefaultCance=false)
        {
            IList<T> ilist = new List<T>();
            T _t = (T)Activator.CreateInstance(typeof(T));
            filter = string.IsNullOrWhiteSpace(filter) ? " where 1=1 " : " where " + filter;

            #region 判断是否有删除标记，过滤删除数据
            PropertyInfo[] propertys = _t.GetType().GetProperties();
            if (propertys.Where(f => f.Name.ToUpper().Equals("DEL")).Count() > 0)
            {
                if (!filter.ToUpper().Contains("DEL") && !isDefaultCance)
                    filter += " and nvl(DEL,0) <> 1 ";
            }
            if (propertys.Where(f => f.Name.ToUpper().Equals("ISCANCE")).Count() > 0)
            {
                if (!filter.ToUpper().Contains("ISCANCE")&&!isDefaultCance)
                    filter += " and nvl(ISCANCE,0) <> 1 ";
            }
            #endregion

            string strSQL = "select * from " + _t.GetType().Name + filter;
            if (orderby != "")
                strSQL += " order by " + orderby;
            //根据每个实体的CacheType属性，进行数据缓存，如果未设置该属性的，则不缓存
            if (_t.GetType().GetCustomAttribute<CacheTypeAttribute>() != null)
            {
                ICacheManager cacheManager = null;
                switch (_t.GetType().GetCustomAttribute<CacheTypeAttribute>().cacheType)
                {
                    case CacheTypeEnum.Redis:
                        cacheManager = RedisCacheManager.CreateInstance();
                        break;
                    case CacheTypeEnum.MemoryCache:
                        cacheManager = new MemoryCacheManager();
                        break;
                }
                if (cacheManager.IsSet(_t.GetType().Name))
                    ilist = cacheManager.Get<List<T>>(_t.GetType().Name);
                else
                {
                    ilist = DataSetToEntityList(dataProvider.GetDataSet(strSQL), 0);
                    cacheManager.Set(_t.GetType().Name, ilist, 60);
                }
            }
            else
            {
                ilist = DataSetToEntityList(dataProvider.GetDataSet(strSQL), 0);
            }
            if (ilist != null && ilist.Count() > 0)
                return ilist.ToList();
            else
                return new List<T>();
        }
        /// <summary>
        /// 通过查询条件删除数据
        /// </summary>
        /// <param name="Filter"></param>
        public static void DeleteByFilter(string Filter)
        {
            if (!string.IsNullOrWhiteSpace(Filter))
            {
                T _t = (T)Activator.CreateInstance(typeof(T));
                dataProvider.ExecuteNonQuery("delete from " + _t.GetType().Name + " where " + Filter);
            }
        }

        /// <summary>
        /// 通过主键或者某个字段删除实体
        /// </summary>
        /// <param name="strPrimaryKeyValue"></param>
        /// <param name="strPrimaryKeyName"></param>
        public static void DeleteById(string strPrimaryKeyValue, string strPrimaryKeyName = "id")
        {
            if (!string.IsNullOrWhiteSpace(strPrimaryKeyValue))
            {
                T _t = (T)Activator.CreateInstance(typeof(T));
                PropertyInfo[] propertys = _t.GetType().GetProperties();
                string DeleteSql = string.Format("delete from {0} where {1} = '{2}'", typeof(T).Name, strPrimaryKeyName, strPrimaryKeyValue);

                if (propertys.Where(f => f.Name.ToUpper().Equals("DEL")).Count() > 0)
                {
                    DeleteSql = string.Format("update {0} set DEL = 1 where {1} = '{2}'", typeof(T).Name, strPrimaryKeyName, strPrimaryKeyValue);
                }
                if (propertys.Where(f => f.Name.ToUpper().Equals("ISCANCE")).Count() > 0)
                {
                    DeleteSql = string.Format("update {0} set ISCANCE = 1 where {1} = '{2}'", typeof(T).Name, strPrimaryKeyName, strPrimaryKeyValue);
                }
                dataProvider.ExecuteNonQuery(DeleteSql);
            }
        }

        /// <summary>
        /// 获取最新排序号
        /// </summary>
        /// <param name="parentid">父类ID</param>
        /// <param name="SortColumnName">排序字段名称</param>
        /// <param name="filter">查询条件</param>
        /// <returns></returns>
        public static int GetLastOrderId(string parentid, string SortColumnName = "DISPLAYSORT", string filter = "")
        {
            int lastOrderId = 0;
            filter = " where " + (string.IsNullOrWhiteSpace(filter) ? " 1=1 " : filter);
            T _t = (T)Activator.CreateInstance(typeof(T));
            PropertyInfo[] propertys = _t.GetType().GetProperties();
            if (propertys.Where(f => f.Name.ToUpper().Equals("PARENTID")).Count() > 0)
            {
                if (!string.IsNullOrWhiteSpace(parentid))
                    filter += " and PARENTID = '" + parentid + "'";
                else
                    filter += " and PARENTID = '0'";
            }
            if (propertys.Where(f => f.Name.ToUpper().Equals(SortColumnName.ToUpper())).Count() > 0)
            {
                int.TryParse(dataProvider.ExecuteScalar(string.Format("select max(" + SortColumnName + ") from {0} {1}", typeof(T).Name, filter)) + "", out lastOrderId);
                return lastOrderId > 0 ? lastOrderId + 1 : 1;
            }
            return 1;
        }

        /// <summary>
        /// 通过分页存储过程获取数据
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        public static DataSet GetDataSetByPagination(PagingEntity page)
        {
            DbParameter[] parameters = new DbParameter[8];
            parameters[0] = dataProvider.CreateParameter("@Tables", typeof(T).Name, DbType.String, 1000);
            parameters[0] = dataProvider.CreateParameter("@PK", page.PrimaryKey, DbType.String, 100);
            parameters[0] = dataProvider.CreateParameter("@Sort", page.Sort, DbType.String, 200);
            parameters[0] = dataProvider.CreateParameter("@PageNumber", page.CurPage, DbType.Int16);
            parameters[0] = dataProvider.CreateParameter("@PageSize", page.PageSize, DbType.Int16);
            parameters[0] = dataProvider.CreateParameter("@Fields", page.Fields, DbType.String, 1000);
            parameters[0] = dataProvider.CreateParameter("@Filter", page.QueryString, DbType.String, 1000);
            parameters[0] = dataProvider.CreateParameter("@Group", DBNull.Value, DbType.String, 1000);

            DataSet ds = new DataSet();//dataProvider.GetDataSetByProcedure("Page2005", parameters);
            return ds;
        }

        /// <summary>
        /// 通过分页存储过程获取实体集
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        public static List<T> GetEntityListByPagination(PagingEntity page)
        {
            DataSet ds = GetDataSetByPagination(page);
            if (ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
            {
                int iDataCount = 0;
                int.TryParse(ds.Tables[1].Rows[0][0] + "", out iDataCount);
                page.DataCount = iDataCount;
            }
            return DataSetToEntityList(ds);
        }

        /// <summary>
        /// 执行SQL语句
        /// </summary>
        /// <param name="sqlString"></param>
        /// <returns></returns>
        public static object ExecSqlString(string sqlString)
        {
            return dataProvider.ExecuteScalar(sqlString);
        }

        /// <summary>
        /// 执行SQL语句
        /// </summary>
        /// <param name="sqlString"></param>
        /// <returns></returns>
        public static DataSet GetDataSetBySql(string sqlString)
        {
            return dataProvider.GetDataSet(sqlString);
        }

        /// <summary>
        /// DataSet转换为实体列表
        /// </summary>
        /// <param name="p_DataSet"></param>
        /// <returns></returns>
        public static List<T> DataSetToEntityList(DataSet p_DataSet)
        {
            IList<T> ilist = DataSetToEntityList(p_DataSet, 0);
            if (ilist != null && ilist.Count() > 0)
                return ilist.ToList();
            else
                return default(List<T>);
        }
        /// <summary>
        /// DataSet转换为实体列表
        /// </summary>
        /// <typeparam name="T">实体类</typeparam>
        /// <param name="p_DataSet">DataSet</param>
        /// <param name="p_TableIndex">待转换数据表索引</param>
        /// <returns>实体类列表</returns>
        public static IList<T> DataSetToEntityList(DataSet p_DataSet, int p_TableIndex)
        {
            if (p_DataSet == null || p_DataSet.Tables.Count < 0)
                return default(IList<T>);
            if (p_TableIndex > p_DataSet.Tables.Count - 1)
                return default(IList<T>);
            if (p_TableIndex < 0)
                p_TableIndex = 0;
            if (p_DataSet.Tables[p_TableIndex].Rows.Count <= 0)
                return default(IList<T>);

            DataTable p_Data = p_DataSet.Tables[p_TableIndex];
            // 返回值初始化
            int curIndex = 0;

            IList<T> result = new List<T>();
            for (int j = 0; j < p_Data.Rows.Count; j++)
            {
                T _t = (T)Activator.CreateInstance(typeof(T));
                PropertyInfo[] propertys = _t.GetType().GetProperties();
                foreach (PropertyInfo pi in propertys)
                {
                    try
                    {
                        if (p_Data.Columns.IndexOf(pi.Name.ToUpper()) != -1 && p_Data.Rows[j][pi.Name.ToUpper()] != DBNull.Value)
                        {
                            if (p_Data.Rows[j][pi.Name.ToUpper()] is System.Boolean)
                                pi.SetValue(_t, Convert.ToBoolean(p_Data.Rows[j][pi.Name.ToUpper()]), null);
                            else if (p_Data.Rows[j][pi.Name.ToUpper()] is System.Byte)
                                pi.SetValue(_t, Convert.ToInt32(p_Data.Rows[j][pi.Name.ToUpper()]), null);
                            else if (pi.PropertyType.AssemblyQualifiedName.Contains("Int"))
                                pi.SetValue(_t, Convert.ToInt32(p_Data.Rows[j][pi.Name.ToUpper()]), null);
                            else if (pi.PropertyType.AssemblyQualifiedName.Contains("String"))
                                pi.SetValue(_t, p_Data.Rows[j][pi.Name.ToUpper()] + "", null);
                            else
                                pi.SetValue(_t, p_Data.Rows[j][pi.Name.ToUpper()], null);
                        }
                        else if (pi.CanWrite)
                        {
                            pi.SetValue(_t, null, null);
                        }
                    }

                    catch (Exception err)
                    {
                        throw new Exception(curIndex + "." + err.Message + "\r\n" + pi.Name + "\r\n" + _t.GetType().ToString());
                    }
                    finally
                    {
                        curIndex++;
                    }
                }
                result.Add(_t);
            }
            return result;
        }

        public static void Dispose()
        {
            APIConfig = null;
            _dataProvider = null;
        }
    }
}
