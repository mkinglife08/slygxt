using EMR.Data;
using EMR.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EMR.Services.Server.ExternalInterface
{
    public class PatientPaymentService
    {
        API_DataGet_Config config = new API_DataGet_Config() { };
        public API_Payment GetInfoById(string InpatientId)
        {
            //EntityOperate<API_Payment>.APIConfig = config;
            //return EntityOperate<API_Payment>.GetEntityById(InpatientId, "InpatientId");
            List<API_Payment> list = new List<API_Payment>();
            list.Add(new API_Payment() { AdvancePayment="10000",Balance="4236",Cash="0",InpatientId="1",PressMoney="0",PressTime=null,SelfCare= "2541", SelfPay="2541",Total="5764" });
            list.Add(new API_Payment() { AdvancePayment = "0", Balance = "0", Cash = "0", InpatientId = "2", PressMoney = "5396", PressTime = DateTime.Parse("2019-1-12"), SelfCare = "5396", SelfPay = "5396", Total = "5396" });
            API_Payment entity=  list.Find(e => e.InpatientId == InpatientId);
            if (entity == null)
                entity = new API_Payment();
            return entity;
        }
    }
}
