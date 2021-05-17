using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;
namespace VSense.API.Models
{
    public class Device_log
    {
        [Key]
        public int LogID { get; set; }
        public string DeviceID { get; set; }
        public string RefID { get; set; }
        public DateTime dateTime { get; set; }
        public string PramID { get; set; }
        public float value { get; set; }
        public float minValue { get; set; }
        public float maxValue { get; set; }
        public float avgValue { get; set; }
        public float Threshold { get; set; }
        
    }
    public class Log{
        public Device_log device_log { get; set; }
        public t_device_assign device_assign { get; set; }
    }
    public class logWithStatus{
        public int LogID { get; set; }
        public string DeviceID { get; set; }
        public string RefID { get; set; }
        public DateTime dateTime { get; set; }
        public string PramID { get; set; }
        public float value { get; set; }
        public float minValue { get; set; }
        public float maxValue { get; set; }
        public float avgValue { get; set; }
        public float Threshold { get; set; }
        public int Battery { get; set; }
        public int Healthy { get; set; }
        public string SoftwareVersion { get; set; }
        public float Vcc { get; set; }
    }
}