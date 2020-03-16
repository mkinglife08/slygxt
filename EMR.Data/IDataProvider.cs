/*----------------------------------------------------------------
// Copyright (C) 2018-2019 杭州华卓信息科技有限公司   版权所有。 
// 文件名：IDataProvider.cs
// 文件功能描述： 数据操作类接口。
// 创建标识：吕屹凌 2018-12-10 
// 修改标识：
// 修改描述：
----------------------------------------------------------------*/

using System.Data;
using System.Data.Common;

namespace EMR.Data
{
    /// <summary>
    /// 数据操作类接口
    /// </summary>
    public interface IDataProvider
    {
        /// <summary>
        /// 执行SQL语句并返回受影响的行数
        /// </summary>
        /// <param name="cmdText">SQL语句</param>
        /// <param name="commandParameters">参数数组</param>
        /// <returns>受影响的行数</returns>
        int ExecuteNonQuery(string cmdText, params DbParameter[] commandParameters);

        /// <summary>
        /// 执行SQL语句并返回受影响的行数
        /// </summary>
        /// <param name="transaction">事务</param>
        /// <param name="cmdType">SQL语句类型</param>
        /// <param name="cmdText">SQL语句</param>
        /// <param name="commandParameters">参数数组</param>
        /// <returns>受影响的行数</returns>
        int ExecuteNonQuery(DbTransaction transaction, CommandType cmdType, string cmdText, params DbParameter[] commandParameters);

        /// <summary>
        /// 执行SQL语句并返回一个DataReader
        /// </summary>
        /// <param name="cmdText">SQL语句</param>
        /// <param name="commandParameters">参数数组</param>
        /// <returns>DbDataReader</returns>
        DbDataReader ExecuteReader(string cmdText, params DbParameter[] commandParameters);

        /// <summary>
        /// 执行SQL语句并返回第一行第一列
        /// </summary>
        /// <param name="cmdText">SQL语句</param>
        /// <param name="commandParameters">参数数组</param>
        /// <returns>第一行第一列</returns>
        object ExecuteScalar(string cmdText, params DbParameter[] commandParameters);

        /// <summary>
        /// 执行SQL语句并返回一个DataSet数据集
        /// </summary>
        /// <param name="cmdText">SQL语句</param>
        /// <param name="commandParameters">参数数组</param>
        /// <returns>DataSet数据集</returns>
        DataSet GetDataSet(string cmdText, params DbParameter[] commandParameters);

        /// <summary>
        /// 参数创建（由于）
        /// </summary>
        /// <param name="name"></param>
        /// <param name="vallue"></param>
        /// <returns></returns>
        DbParameter CreateParameter(string name, object vallue);
        DbParameter CreateParameter(string name,object vallue,DbType dbType,int size=0);
    }
}
