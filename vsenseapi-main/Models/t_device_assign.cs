using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace VSense.API.Models
{
    public class t_device_assign
    {
        [Key]
        public int assignmentID { get; set; }
        public string DeviceID { get; set; }
        public string EquipmentID { get; set; }
        public DateTime StDateTime { get; set; }
        public DateTime enDateTime { get; set; }
        public int Frequency { get; set; }
        public string LocID { get; set; }
        [ForeignKey("DeviceID")]
        public virtual m_device device { get; set; }
        [ForeignKey("EquipmentID")]
        public virtual m_equipment equipment { get; set; }
        [ForeignKey("LocID")]
        public virtual m_Loc location { get; set; }
         public bool isEnabled { get; set; }
        public DateTime createdOn { get; set; }
        public string createdBy { get; set; }
        public DateTime? modifiedOn { get; set; }
        public string modifiedBy { get; set; }
        
    }
}