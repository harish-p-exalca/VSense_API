using System;
using System.Collections.Generic;

namespace VSense.API.Context
{
    public partial class CurrentConsumption
    {
        public string DeviceId { get; set; }
        public string Current { get; set; }
        public string Watt { get; set; }
        public DateTime DateTime { get; set; }
    }
}
