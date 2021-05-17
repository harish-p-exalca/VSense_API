using System.ComponentModel.DataAnnotations;
using System;
namespace VSense.API.Models
{
    public class m_equipment
    {
        [Key]
        public string EquipmentID { get; set; }
        public string Text { get; set; }
        public string GeoLoc { get; set; }
        public string Plant { get; set; }
        public string Workcenter { get; set; }
         public bool isEnabled { get; set; }
        public DateTime createdOn { get; set; }
        public string createdBy { get; set; }
        public DateTime? modifiedOn { get; set; }
        public string modifiedBy { get; set; }
    }
}