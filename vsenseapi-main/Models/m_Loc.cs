using System.ComponentModel.DataAnnotations;
using System;
namespace VSense.API.Models
{
    public class m_Loc
    {
        [Key]
        public string LocationID { get; set; }
        public string LcoationText { get; set; }
        public string WorkCenter { get; set; }
        public string Plant { get; set; }
        public string Geo { get; set; }
        public string ParantLocationID { get; set; }
         public bool isEnabled { get; set; }
        public DateTime createdOn { get; set; }
        public string createdBy { get; set; }
        public DateTime? modifiedOn { get; set; }
        public string modifiedBy { get; set; }
    }
}