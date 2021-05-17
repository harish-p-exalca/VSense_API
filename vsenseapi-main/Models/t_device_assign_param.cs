using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
namespace VSense.API.Models
{
    public class t_device_assign_param
    {
        public int assignmentID { get; set; }
        public string PramID { get; set; }
        public string Title { get; set; }
        public string Unit { get; set; }
        public string longText { get; set; }
        public float? Max { get; set; }
        public float? Min { get; set; }
        public string Icon { get; set; }
        public float? Soft_1_Exception_Threshold { get; set; }
        public float? Soft_2_Exception_Threshold { get; set; }
        public float? Hard_1_Exception_Threshold { get; set; }
        public float? Hard_2_Exception_Threshold { get; set; }
        public string ActivityGraphTitle { get; set; }
        [ForeignKey("assignmentID")]
        public virtual t_device_assign device_assign { get; set; }
        public bool isEnabled { get; set; }
        public DateTime createdOn { get; set; }
        public string createdBy { get; set; }
        public DateTime? modifiedOn { get; set; }
        public string modifiedBy { get; set; }
    }
}