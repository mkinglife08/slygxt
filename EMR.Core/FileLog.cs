/*----------------------------------------------------------------
// Copyright (C) 2018-2019 杭州华卓信息科技有限公司   版权所有。 
// 文件名：FileLog.cs
// 文件功能描述： 文件日志操作类。
// 创建标识：吕屹凌 2018-12-10 
// 修改标识：
// 修改描述：
----------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMR.Core
{
    /// <summary>
    /// 文件日志操作类
    /// </summary>
    public class FileLog
    {
        /// <summary>
        /// 添加用户日志
        /// </summary>
        /// <param name="LogContent">日志内容</param>
        public static void AddUserLog(string LogContent)
        {
            AddLog(LogContent, DateTime.Now, "User");
        }

        /// <summary>
        /// 添加错误日志
        /// </summary>
        /// <param name="LogContent">日志内容</param>
        public static void AddErrorLog(string LogContent)
        {
            AddLog(LogContent, DateTime.Now, "Error");
        }

        /// <summary>
        /// 添加调试日志
        /// </summary>
        /// <param name="LogContent">日志内容</param>
        public static void AddDebugLog(string LogContent)
        {
            AddLog(LogContent, DateTime.Now, "Error");
        }

        /// <summary>
        /// 添加消息发送日志
        /// </summary>
        /// <param name="LogContent">日志内容</param>
        public static void AddSMSLog(string LogContent)
        {
            AddLog(LogContent, DateTime.Now, "SMS");
        }

        /// <summary>
        /// 添加日志主体
        /// </summary>
        /// <param name="LogContent">日志内容</param>
        /// <param name="dtCur">当前时间</param>
        /// <param name="strLogName">日志名称</param>
        public static void AddLog(string LogContent, DateTime dtCur, string strLogName)
        {
            string LOG_DIR = AppDomain.CurrentDomain.BaseDirectory + "Log";
            if (!string.IsNullOrEmpty(strLogName))
                LOG_DIR += "\\" + strLogName;
            if (!Directory.Exists(LOG_DIR))
            {
                Directory.CreateDirectory(LOG_DIR);
            }
            string path = string.Concat(new object[]
            {
                LOG_DIR,"\\log_",dtCur.Year,"_",dtCur.Month,"_",dtCur.Day,".log"
            });
            if (!File.Exists(path))
            {
                using (File.Create(path))
                {
                }
            }
            LogContent = string.Concat(new string[]
            {
                "====",
                " 开始 ",
                DateTime.Now.ToString(),
                "(RawUrl:",
                strLogName,
                ") =====",
                LogContent,
                "\r\n"
            });
            StreamWriter streamWriter = null;
            try
            {
                streamWriter = new StreamWriter(path, true, Encoding.Default);
                streamWriter.WriteLine(LogContent);
                streamWriter.Flush();
            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }
            finally
            {
                if (streamWriter != null)
                {
                    streamWriter.Close();
                    streamWriter.Dispose();
                }
            }
        }
    }
}
