using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VSense.API.Models
{
    public class CommonClass
    {
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
    }
    #region Masters
    [Table("M_Site")]
    public class MSite : CommonClass
    {
        [Key]
        public int SiteID { get; set; }
        public string Title { get; set; }
        public string Geo { get; set; }
        public string Plant { get; set; }
    }
    [Table("M_Space")]
    public class MSpace : CommonClass
    {
        [Key]
        public int SpaceID { get; set; }
        public string Title { get; set; }
        public string WorkCenter { get; set; }
        public int? ParantSpaceID { get; set; }
        public int SiteID { get; set; }
    }
    [Table("M_Asset")]
    public class MAsset : CommonClass
    {
        [Key]
        public int AssetID { get; set; }
        public string Title { get; set; }
        public string Class { get; set; }
        public int SpaceID { get; set; }
        public string Status { get; set; }
    }
    [Table("M_Group")]
    public class MEdgeGroup : CommonClass
    {
        [Key]
        public int EdgeGroup { get; set; }
        public string Title { get; set; }
    }
    [Table("M_EdgeGroup_Param")]
    public class MEdgeGroupParam : CommonClass
    {
        public int EdgeGroup { get; set; }
        public string ParamID { get; set; }
        public string Title { get; set; }
        public string Unit { get; set; }
        public string LongText { get; set; }
        public double Min { get; set; }
        public double Max { get; set; }
        public string Icon { get; set; }
        public string IsPercentage { get; set; }
        public string Color { get; set; }
    }
    [Table("M_Edge")]
    public class MEdge : CommonClass
    {
        [Key]
        public int EdgeID { get; set; }
        public string Title { get; set; }
        public DateTime PuttoUse { get; set; }
        public double? Battery { get; set; }
        public string SoftwareVersion { get; set; }
        public double? Vcc { get; set; }
        public double? Lifespan { get; set; }
        public int EdgeGroup { get; set; }
        public string Status { get; set; }
        public int? ParantEdgeID { get; set; }
    }
    [Table("M_Edge_Assign")]
    public class MEdgeAssign : CommonClass
    {
        [Key]
        public int AssignmentID { get; set; }
        public int EdgeID { get; set; }
        public int AssetID { get; set; }
        public int? SpaceID { get; set; }
        public int? SiteID { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public double Frequency { get; set; }
    }
    [Table("M_Edge_Assign_Param")]
    public class MEdgeAssignParam : CommonClass
    {
        public int AssignmentID { get; set; }
        public string PramID { get; set; }
        public string Title { get; set; }
        public string Unit { get; set; }
        public string LongText { get; set; }
        public double? Max { get; set; }
        public double? Min { get; set; }
        public string Icon { get; set; }
        public double? Soft1ExceptionThreshold { get; set; }
        public double? Soft2ExceptionThreshold { get; set; }
        public double? Hard1ExceptionThreshold { get; set; }
        public double? Hard2ExceptionThreshold { get; set; }
        public string ActivityGraphTitle { get; set; }
    }
    public class MEdgeGroupView:MEdgeGroup {
        public List<MEdgeGroupParam> EdgeParams { get; set; }
    }
    public class AssetView : MAsset
    {
        public List<Assignment> Assignments { get; set; }
    }
    public class Assignment:MEdgeAssign
    {
        public List<MEdgeAssignParam> AssignParams { get; set; }
    }
    #endregion
    #region Rule
    [Table("Rule")]
    public class Rule : CommonClass
    {
        [Key]
        public int RuleID { get; set; }
        public string Title { get; set; }
        public int SiteID { get; set; }
        public int? SpaceID { get; set; }
        public int? AssetID { get; set; }
        public double? Threshold { get; set; }
        public string SLA { get; set; }
        public string Level1 { get; set; }
        public string Level2 { get; set; }
        public string Level3 { get; set; }
        public string Notif1 { get; set; }
        public string Notif2 { get; set; }
        public string EmailTemplate { get; set; }
    }
    #endregion
    #region Log
    [Table("T_Edge_Log")]
    public class EdgeLog
    {
        [Key]
        public int LogID { get; set; }
        public int EdgeID { get; set; }
        public string RefID { get; set; }
        public DateTime DateTime { get; set; }
        public string PramID { get; set; }
        public double Value { get; set; }
        public double MinValue { get; set; }
        public double MaxValue { get; set; }
        public double AvgValue { get; set; }
        public double Threshold { get; set; }
    }
    [Table("T_Edge_Exception")]
    public class EdgeException : CommonClass
    {
        [Key]
        public int ExcepID { get; set; }
        public int EdgeID { get; set; }
        public string PramID { get; set; }
        public double Value { get; set; }
        public double Threshold { get; set; }
        public string AssignedTo { get; set; }
        public DateTime SLAStart { get; set; }
        public string EscalationLevel { get; set; }
        public string Class { get; set; }
        public string Status { get; set; }
        public string SovledBy { get; set; }
        public double? SLAPercentage { get; set; }
        public string ResolutionText { get; set; }
        public string RCAText { get; set; }
        public string RCAAttchment { get; set; }
        public string CAPAText { get; set; }
        public string CAPAAttachment { get; set; }
    }
    public class AssignParamLogView
    {
        public string PramID { get; set; }
        public string Title { get; set; }
        public string ActivityGraphTitle { get; set; }
        public double? Min { get; set; }
        public double? Max { get; set; }
        public string Unit { get; set; }
        public double Value { get; set; }
        public double MinValue { get; set; }
        public double MaxValue { get; set; }
        public double AvgValue { get; set; }
        public DateTime DateTime { get; set; }
        public bool IsLogExist { get; set; }
    }
    public class LiveFeedView
    {
        public string Site { get; set; }
        public string Space { get; set; }
        public string Asset { get; set; }
        public string PramTitle { get; set; }
        public int LogID { get; set; }
        public int EdgeID { get; set; }
        public string RefID { get; set; }
        public DateTime DateTime { get; set; }
        public string PramID { get; set; }
        public double Value { get; set; }
        public double MinValue { get; set; }
        public double MaxValue { get; set; }
        public double AvgValue { get; set; }
        public double Threshold { get; set; }
    }
    public class ExceptionView
    {
        public int ExcepID { get; set; }
        public string Site { get; set; }
        public string Space { get; set; }
        public string Asset { get; set; }
        public string Class { get; set; }
        public string PramID { get; set; }
        public double Value { get; set; }
        public DateTime DateTime { get; set; }
        public double Threshold { get; set; }
        public string AssignedTo { get; set; }
        public DateTime SLAStart { get; set; }
        public string Status { get; set; }
    }
    #endregion
    #region Monitor
    public class MonitorTableView
    {
        public string Site { get; set; }
        public string Space { get; set; }
        public string Asset { get; set; }
        public string Edge { get; set; }
        public int EdgeID { get; set; }
        public bool Status { get; set; }
        public DateTime? LastFeed { get; set; }
    }
    public class EdgeStatusChartData
    {
        public DateTime x { get; set; }
        public int y { get; set; }
    }
    public class ControlCenterFeed
    {
        public string Site { get; set; }
        public string Space { get; set; }
        public string Asset { get; set; }
        public string Title { get; set; }
        public double? Value { get; set; }
        public bool Status { get; set; }
        public DateTime? LastFeed { get; set; }
    }
    #endregion
}
