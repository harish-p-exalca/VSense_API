using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
namespace VSense.API.Models
{
    public class m_device
    {
        [Key]
        public string DeviceID { get; set; }
        public string Name { get; set; }
        public string Purpose { get; set; }
        public DateTime PuttoUse { get; set; }
        public int Battery { get; set; }
        public int Healthy { get; set; }
        public string SoftwareVersion { get; set; }
        public float Vcc { get; set; }
        public int Lifespan { get; set; }
        public bool isEnabled { get; set; }
        public DateTime createdOn { get; set; }
        public string createdBy { get; set; }
        public DateTime? modifiedOn { get; set; }
        public string modifiedBy { get; set; }
        public virtual ICollection<m_device_param> deviceParams { get; set; }
        
    }
}