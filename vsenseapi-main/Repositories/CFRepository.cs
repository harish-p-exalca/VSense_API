using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VSense.API.Context;

namespace VSense.API.Repositories
{
    public class CFRepository:ICFRepository
    {
        private readonly CarbonFootPrintContext _context;

        public CFRepository(CarbonFootPrintContext context)
        {
            _context = context;
        }
        public List<WaterConsumption> GetAllWaterDevices()
        {
            try
            {
                var result = _context.WaterConsumption.ToList().GroupBy(t => t.DeviceId).Select(x => x.LastOrDefault()).ToList();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<CurrentConsumption> GetAllCurrentDevices()
        {
            try
            {
                var result = _context.CurrentConsumption.ToList().GroupBy(t => t.DeviceId).Select(x=>x.LastOrDefault()).ToList();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public WaterConsumption GetWaterConsumption(string DeviceID)
        {
            try
            {
                var result = _context.WaterConsumption.OrderByDescending(t => t.DateTime).FirstOrDefault(x => x.DeviceId == DeviceID);
                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public CurrentConsumption GetCurrentConsumption(string DeviceID)
        {
            try
            {
                var result = _context.CurrentConsumption.OrderByDescending(t => t.DateTime).FirstOrDefault(x => x.DeviceId == DeviceID);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public double GetEnergy(string DeviceID)
        {
            try
            {
                var All_Logs = _context.CurrentConsumption.Where(t => t.DeviceId == DeviceID).OrderByDescending(x=>x.DateTime).ToList();
                var Power = All_Logs.Select(t=> Convert.ToDouble(t.Watt)).FirstOrDefault();
                var Times = All_Logs.Select(t => t.DateTime).Take(2).ToList();
                var TimeDiff = Times[0].Subtract(Times[1]).TotalSeconds;
                var TotalPower = Power * TimeDiff;
                //var All_DateTimes = All_Logs.Select(t => t.DateTime).ToList();
                //double TotalTime = 0;
                //for (int i = 1; i < All_DateTimes.Count; i++)
                //{
                //    TotalTime += All_DateTimes[i].Subtract(All_DateTimes[i - 1]).TotalSeconds;
                //}
                var TotalHours = TimeDiff / 3600;
                var Energy = (TotalPower * TotalHours)/1000;
                return Energy;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
