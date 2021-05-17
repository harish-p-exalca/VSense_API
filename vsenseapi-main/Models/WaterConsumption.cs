using System;
using System.Collections.Generic;

namespace VSense.API.Context
{
    public partial class WaterConsumption
    {
        public string DeviceId { get; set; }
        public string Flow { get; set; }
        public string Qty { get; set; }
        public DateTime DateTime { get; set; }
    }
}
