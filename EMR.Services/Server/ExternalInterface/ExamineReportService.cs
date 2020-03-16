using EMR.Data;
using EMR.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EMR.Services.Server.ExternalInterface
{
    public class ExamineReportService
    {
        API_DataGet_Config config = new API_DataGet_Config() { };
        public API_ExamineReport GetInfoById(string InpatientId)
        {
            //EntityOperate<API_Payment>.APIConfig = config;
            //return EntityOperate<API_Payment>.GetEntityById(InpatientId, "InpatientId");
            List<API_ExamineReport> list = new List<API_ExamineReport>();
            API_ExamineReport entity =  list.Find(e => e.InpatientId == InpatientId);
            if (entity == null)
                entity = new API_ExamineReport();
            return entity;
        }
    }
}
