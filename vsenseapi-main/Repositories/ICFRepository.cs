using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VSense.API.Context;

namespace VSense.API.Repositories
{
    public interface ICFRepository
    {
        List<WaterConsumption> GetAllWaterDevices();
        List<CurrentConsumption> GetAllCurrentDevices();
        WaterConsumption GetWaterConsumption(string DeviceID);
        CurrentConsumption GetCurrentConsumption(string DeviceID);
        double GetEnergy(string DeviceID);
    }
}
