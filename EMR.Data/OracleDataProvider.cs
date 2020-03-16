/*----------------------------------------------------------------
// Copyright (C) 2018-2019 杭州华卓信息科技有限公司   版权所有。 
// 文件名：OracleDataProvider.cs
// 文件功能描述： Oracle 数据库操作类，提供操作 Oracle 数据库的相关方法。
// 创建标识：吕屹凌 2018-12-10 
// 修改标识：
// 修改描述：
----------------------------------------------------------------*/

using System;
using System.Configuration;
using System.Data;
using System.Data.Common;
using Oracle.ManagedDataAccess.Client;

namespace EMR.Data
{
    public class OracleDataProvider : IDataProvider
    {
        public string ConnectionString = ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["DefaultConn"]].ConnectionString ;
        public OracleDataProvider()
        {
        }
        public OracleDataProvider(string _connectionStringName)
        {
            if(!string.IsNullOrWhiteSpace(_connectionStringName))
                ConnectionString = ConfigurationManager.ConnectionStrings[_connectionStringName].ConnectionString;
        }

        /// <summary>
        /// 执行SQL语句并返回受影响的行数
        /// </summary>
        /// <param name="cmdText">SQL语句</param>
        /// <param name="commandParameters">参数数组</param>
        /// <returns>受影响的行数</returns>
        public int ExecuteNonQuery(string cmdText, params DbParameter[] commandParameters)
        {
            OracleCommand command = new OracleCommand();
            OracleConnection connection = new OracleConnection(ConnectionString);
            int result = 0;
            try
            {
                PrepareCommand(command, connection, null, CommandType.Text, cmdText, commandParameters);
                result = command.ExecuteNonQuery();
                command.Parameters.Clear();
            }
            catch(Exception err)
            {
                throw new Exception(err.Message);
            }
            finally
            {
                command.Dispose();
                connection.Close();
                connection.Dispose();
            }
            return result;
        }

        /// <summary>
        /// 执行SQL语句并返回受影响的行数
        /// </summary>
        /// <param name="transaction">事务</param>
        /// <param name="cmdType">SQL语句类型</param>
        /// <param name="cmdText">SQL语句</param>
        /// <param name="commandParameters">参数数组</param>
        /// <returns>受影响的行数</returns>
        public int ExecuteNonQuery(DbTransaction transaction, CommandType cmdType, string cmdText, params DbParameter[] commandParameters)
        {
            OracleCommand command = new OracleCommand();
            OracleTransaction o_transaction = transaction as OracleTransaction;
            OracleConnection connection = o_transaction.Connection;
            int result = 0;

            try
            {
                PrepareCommand(command, connection, o_transaction, cmdType, cmdText, commandParameters);
                result = command.ExecuteNonQuery();
                command.Parameters.Clear();
            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }
            finally
            {
                transaction.Dispose();
                command.Dispose();
                connection.Close();
                connection.Dispose();
            }

            return result;
        }

        /// <summary>
        /// 执行SQL语句并返回一个DataReader
        /// </summary>
        /// <param name="cmdText">SQL语句</param>
        /// <param name="commandParameters">参数数组</param>
        /// <returns>DbDataReader</returns>
        public DbDataReader ExecuteReader(string cmdText, params DbParameter[] commandParameters)
        {
            OracleCommand command = new OracleCommand();
            OracleConnection connection = new OracleConnection(ConnectionString);
            OracleDataReader reader = null;
            try
            {
                PrepareCommand(command, connection, null, CommandType.Text, cmdText, commandParameters);
                reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                command.Parameters.Clear();
                return reader;
            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }
            finally
            {
                command.Dispose();
                connection.Close();
                connection.Dispose();
            }
        }

        public object ExecuteScalar(string cmdText, params DbParameter[] commandParameters)
        {
            OracleCommand command = new OracleCommand();
            OracleConnection connection = new OracleConnection(ConnectionString);
            object result = null;

            try
            {
                cmdText = cmdText.Replace("@", "&");
                PrepareCommand(command, connection, null, CommandType.Text, cmdText, commandParameters);
                result = command.ExecuteScalar();
                command.Parameters.Clear();
            }
            catch(Exception err)
            {
                throw new Exception(err.Message);
            }
            finally
            {
                command.Dispose();
                connection.Close();
                connection.Dispose();
            }

            return result;
        }

        public DataSet GetDataSet(string cmdText, params DbParameter[] commandParameters)
        {
            OracleCommand command = new OracleCommand();
            OracleConnection connection = new OracleConnection(ConnectionString);
            DataSet dataset = null;

            try
            {
                PrepareCommand(command, connection, null, CommandType.Text, cmdText, commandParameters);
                OracleDataAdapter adapter = new OracleDataAdapter();
                adapter.SelectCommand = command;
                dataset = new DataSet();
                adapter.Fill(dataset);
                command.Parameters.Clear();
            }
            catch(Exception err)
            {
                throw new Exception(err.Message);
            }
            finally
            {
                command.Dispose();
                connection.Close();
                connection.Dispose();
            }

            return dataset;
        }

        /// <summary>  
        /// 执行数据库命令前的准备工作  
        /// </summary>  
        /// <param name="command">Command对象</param>  
        /// <param name="connection">数据库连接对象</param>  
        /// <param name="trans">事务对象</param>  
        /// <param name="cmdType">Command类型</param>  
        /// <param name="cmdText">Oracle存储过程名称或PL/SQL命令</param>  
        /// <param name="commandParameters">命令参数集合</param>  
        private static void PrepareCommand(OracleCommand command, OracleConnection connection, OracleTransaction trans, CommandType cmdType, string cmdText, DbParameter[] commandParameters)
        {
            if (connection.State != ConnectionState.Open) connection.Open();

            command.Connection = connection;
            command.CommandText = cmdText;
            command.CommandType = cmdType;

            if (trans != null) command.Transaction = trans;

            if (commandParameters != null)
            {
                foreach (OracleParameter parm in commandParameters)
                    if(parm != null)
                        command.Parameters.Add(parm);
            }
        }

        /// <summary>  
        /// 将.NET日期时间类型转化为Oracle兼容的日期时间格式字符串  
        /// </summary>  
        /// <param name="date">.NET日期时间类型对象</param>  
        /// <returns>Oracle兼容的日期时间格式字符串（如该字符串：TO_DATE('2007-12-1','YYYY-MM-DD')）</returns>  
        internal static string GetOracleDateFormat(DateTime date)
        {
            return "TO_DATE('" + date.ToString("yyyy-M-dd") + "','YYYY-MM-DD')";
        }

        /// <summary>  
        /// 将.NET日期时间类型转化为Oracle兼容的日期格式字符串  
        /// </summary>  
        /// <param name="date">.NET日期时间类型对象</param>  
        /// <param name="format">Oracle日期时间类型格式化限定符</param>  
        /// <returns>Oracle兼容的日期时间格式字符串（如该字符串：TO_DATE('2007-12-1','YYYY-MM-DD')）</returns>  
        internal static string GetOracleDateFormat(DateTime date, string format)
        {
            if (format == null || format.Trim() == "") format = "YYYY-MM-DD";
            return "TO_DATE('" + date.ToString("yyyy-M-dd") + "','" + format + "')";
        }

        /// <summary>  
        /// 将指定的关键字处理为模糊查询时的合法参数值  
        /// </summary>  
        /// <param name="source">待处理的查询关键字</param>  
        /// <returns>过滤后的查询关键字</returns>  
        internal static string HandleLikeKey(string source)
        {
            if (source == null || source.Trim() == "") return null;

            source = source.Replace("[", "[]]");
            source = source.Replace("_", "[_]");
            source = source.Replace("%", "[%]");

            return ("%" + source + "%");
        }
        public DbParameter CreateParameter(string name, object value)
        {
            return new OracleParameter("&" + name, value);
        }

        public DbParameter CreateParameter(string name, object value, DbType dbType, int size = 0)
        {
            OracleParameter parameter = new OracleParameter();
            parameter.ParameterName = "&" + name;
            parameter.DbType = dbType;
            parameter.Value = value;
            if (size > 0)
                parameter.Size = size;
            return parameter;
        }
    }
}
