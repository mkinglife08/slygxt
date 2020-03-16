/*----------------------------------------------------------------
// Copyright (C) 2018-2019 杭州华卓信息科技有限公司   版权所有。 
// 文件名：SqlDataProvider.cs
// 文件功能描述： SqlServer 数据库操作类，提供操作 SqlServer 数据库的相关方法。
// 创建标识：吕屹凌 2018-12-10 
// 修改标识：
// 修改描述：
----------------------------------------------------------------*/

using System;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace EMR.Data
{
    public class SqlDataProvider : IDataProvider,IDisposable
    {
        public string ConnectionString = ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["DefaultConn"]].ConnectionString;
        public SqlDataProvider()
        {

        }
        public SqlDataProvider(string _connectionStringName)
        {
            if (!string.IsNullOrWhiteSpace(_connectionStringName))
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
            SqlCommand command = new SqlCommand();
            SqlConnection connection = new SqlConnection(ConnectionString);
            int result = 0;
            try
            {
                PrepareCommand(command, connection, null, CommandType.Text, cmdText, commandParameters);
                result = command.ExecuteNonQuery();
                command.Parameters.Clear();
            }
            catch
            {
                throw;
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
            SqlCommand command = new SqlCommand();
            SqlTransaction o_transaction = transaction as SqlTransaction;
            SqlConnection connection = o_transaction.Connection;
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
            SqlCommand cmd = new SqlCommand();
            SqlConnection conn = new SqlConnection(ConnectionString);

            // 在这里使用try/catch处理是因为如果方法出现异常，则SqlDataReader就不存在，
            //CommandBehavior.CloseConnection的语句就不会执行，触发的异常由catch捕获。
            //关闭数据库连接，并通过throw再次引发捕捉到的异常。
            try
            {
                PrepareCommand(cmd, conn, null, CommandType.Text, cmdText, commandParameters);
                SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                return rdr;
            }
            catch (Exception err) { throw new Exception(err.Message); }
            finally
            {
                cmd.Dispose();
                conn.Close();
                conn.Dispose();
            }
        }

        public object ExecuteScalar(string cmdText, params DbParameter[] commandParameters)
        {
            SqlCommand command = new SqlCommand();
            SqlConnection connection = new SqlConnection(ConnectionString);
            object result = 0;
            try
            {
                PrepareCommand(command, connection, null, CommandType.Text, cmdText, commandParameters);
                result = command.ExecuteScalar();
                command.Parameters.Clear();
            }
            catch
            {
                throw;
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
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                PrepareCommand(cmd, connection, null, CommandType.Text, cmdText, commandParameters);
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    try
                    {
                        da.Fill(ds, "ds");
                        cmd.Parameters.Clear();
                        return ds;
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    finally
                    {
                        connection.Close();
                        connection.Dispose();
                    }
                }
            }
        }

        public DataSet GetDataSetByProcedure(string ProcedureName, params DbParameter[] commandParameters)
        {
            CommandType ctype = CommandType.StoredProcedure;
            return null;
        }

        /// <summary>  
        /// 执行数据库命令前的准备工作  
        /// </summary>  
        /// <param name="command">Command对象</param>  
        /// <param name="connection">数据库连接对象</param>  
        /// <param name="trans">事务对象</param>  
        /// <param name="cmdType">Command类型</param>  
        /// <param name="cmdText">Sql存储过程名称或PL/SQL命令</param>  
        /// <param name="commandParameters">命令参数集合</param>  
        private void PrepareCommand(SqlCommand command, SqlConnection connection, SqlTransaction trans, CommandType cmdType, string cmdText, DbParameter[] commandParameters)
        {
            if (connection.State != ConnectionState.Open) connection.Open();

            command.Connection = connection;
            command.CommandText = cmdText;
            command.CommandType = cmdType;

            if (trans != null) command.Transaction = trans;

            if (commandParameters != null)
            {
                foreach (SqlParameter parm in commandParameters)
                    command.Parameters.Add(parm);
            }
        }

        public DbParameter CreateParameter(string name, object value)
        {
            return new SqlParameter("@" + name, value);
        }

        public DbParameter CreateParameter(string name, object value, DbType dbType, int size = 0)
        {
            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = "@" + name;
            parameter.DbType = dbType;
            parameter.Value = value;
            if(size>0)
                parameter.Size = size;
            return parameter;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
