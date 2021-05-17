using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations.Schema;
namespace VSense.API.Models
{
    public class m_device_param
    {
        public string DeviceID { get; set; }
        public string ParamID { get; set; }
        public string Title { get; set; }
        public string Unit { get; set; }
        public string longText { get; set; }
        public int Max { get; set; }
        public int Min { get; set; }
        public string Icon { get; set; }
        public string isPercentage { get; set; }
        public string Color { get; set; }
         public bool isEnabled { get; set; }
        public DateTime createdOn { get; set; }
        public string createdBy { get; set; }
        public DateTime? modifiedOn { get; set; }
        public string modifiedBy { get; set; }
        [ForeignKey("DeviceID")]
        public virtual m_device device { get; set; }
    }
}