using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VSense.API.Migrations
{
    public partial class InitialV2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "M_Asset",
                columns: table => new
                {
                    AssetID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    Class = table.Column<string>(nullable: true),
                    SpaceID = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_M_Asset", x => x.AssetID);
                });

            migrationBuilder.CreateTable(
                name: "M_Edge",
                columns: table => new
                {
                    EdgeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    PuttoUse = table.Column<DateTime>(nullable: false),
                    Battery = table.Column<double>(nullable: true),
                    SoftwareVersion = table.Column<string>(nullable: true),
                    Vcc = table.Column<double>(nullable: true),
                    Lifespan = table.Column<double>(nullable: true),
                    EdgeGroup = table.Column<int>(nullable: false),
                    Status = table.Column<string>(nullable: true),
                    ParantEdgeID = table.Column<int>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_M_Edge", x => x.EdgeID);
                });

            migrationBuilder.CreateTable(
                name: "M_Edge_Assign",
                columns: table => new
                {
                    AssignmentID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EdgeID = table.Column<int>(nullable: false),
                    AssetID = table.Column<int>(nullable: false),
                    SpaceID = table.Column<int>(nullable: true),
                    SiteID = table.Column<int>(nullable: true),
                    StartDateTime = table.Column<DateTime>(nullable: false),
                    EndDateTime = table.Column<DateTime>(nullable: false),
                    Frequency = table.Column<double>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_M_Edge_Assign", x => x.AssignmentID);
                });

            migrationBuilder.CreateTable(
                name: "M_Edge_Assign_Param",
                columns: table => new
                {
                    AssignmentID = table.Column<int>(nullable: false),
                    PramID = table.Column<string>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Unit = table.Column<string>(nullable: true),
                    LongText = table.Column<string>(nullable: true),
                    Max = table.Column<double>(nullable: true),
                    Min = table.Column<double>(nullable: true),
                    Icon = table.Column<string>(nullable: true),
                    Soft1ExceptionThreshold = table.Column<double>(nullable: true),
                    Soft2ExceptionThreshold = table.Column<double>(nullable: true),
                    Hard1ExceptionThreshold = table.Column<double>(nullable: true),
                    Hard2ExceptionThreshold = table.Column<double>(nullable: true),
                    ActivityGraphTitle = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_M_Edge_Assign_Param", x => new { x.AssignmentID, x.PramID });
                });

            migrationBuilder.CreateTable(
                name: "M_EdgeGroup_Param",
                columns: table => new
                {
                    EdgeGroup = table.Column<int>(nullable: false),
                    ParamID = table.Column<string>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Unit = table.Column<string>(nullable: true),
                    LongText = table.Column<string>(nullable: true),
                    Min = table.Column<double>(nullable: false),
                    Max = table.Column<double>(nullable: false),
                    Icon = table.Column<string>(nullable: true),
                    IsPercentage = table.Column<string>(nullable: true),
                    Color = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_M_EdgeGroup_Param", x => new { x.EdgeGroup, x.ParamID });
                });

            migrationBuilder.CreateTable(
                name: "M_Group",
                columns: table => new
                {
                    EdgeGroup = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_M_Group", x => x.EdgeGroup);
                });

            migrationBuilder.CreateTable(
                name: "M_Site",
                columns: table => new
                {
                    SiteID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    Geo = table.Column<string>(nullable: true),
                    Plant = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_M_Site", x => x.SiteID);
                });

            migrationBuilder.CreateTable(
                name: "M_Space",
                columns: table => new
                {
                    SpaceID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    WorkCenter = table.Column<string>(nullable: true),
                    ParantSpaceID = table.Column<int>(nullable: true),
                    SiteID = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_M_Space", x => x.SpaceID);
                });

            migrationBuilder.CreateTable(
                name: "Rule",
                columns: table => new
                {
                    RuleID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SiteID = table.Column<int>(nullable: false),
                    SpaceID = table.Column<int>(nullable: true),
                    AssetID = table.Column<int>(nullable: true),
                    Threshold = table.Column<double>(nullable: true),
                    SLA = table.Column<string>(nullable: true),
                    Level1 = table.Column<string>(nullable: true),
                    Level2 = table.Column<string>(nullable: true),
                    Level3 = table.Column<string>(nullable: true),
                    Notif1 = table.Column<string>(nullable: true),
                    Notif2 = table.Column<string>(nullable: true),
                    EmailTemplate = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rule", x => x.RuleID);
                });

            migrationBuilder.CreateTable(
                name: "T_Edge_Exception",
                columns: table => new
                {
                    ExcepID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeviceID = table.Column<int>(nullable: false),
                    PramID = table.Column<string>(nullable: true),
                    Value = table.Column<double>(nullable: false),
                    Threshold = table.Column<double>(nullable: false),
                    AssignedTo = table.Column<string>(nullable: true),
                    SLAStart = table.Column<DateTime>(nullable: false),
                    EscalationLevel = table.Column<string>(nullable: true),
                    Class = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    SovledBy = table.Column<string>(nullable: true),
                    SLAPercentage = table.Column<double>(nullable: true),
                    ResolutionText = table.Column<string>(nullable: true),
                    RCAText = table.Column<string>(nullable: true),
                    RCAAttchment = table.Column<string>(nullable: true),
                    CAPAText = table.Column<string>(nullable: true),
                    CAPAAttachment = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_Edge_Exception", x => x.ExcepID);
                });

            migrationBuilder.CreateTable(
                name: "T_Edge_Log",
                columns: table => new
                {
                    LogID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EdgeID = table.Column<int>(nullable: false),
                    RefID = table.Column<string>(nullable: true),
                    DateTime = table.Column<DateTime>(nullable: false),
                    PramID = table.Column<string>(nullable: true),
                    Value = table.Column<double>(nullable: false),
                    MinValue = table.Column<double>(nullable: false),
                    MaxValue = table.Column<double>(nullable: false),
                    AvgValue = table.Column<double>(nullable: false),
                    Threshold = table.Column<double>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_Edge_Log", x => x.LogID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_T_Edge_Log_EdgeID_PramID",
                table: "T_Edge_Log",
                columns: new[] { "EdgeID", "PramID" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "M_Asset");

            migrationBuilder.DropTable(
                name: "M_Edge");

            migrationBuilder.DropTable(
                name: "M_Edge_Assign");

            migrationBuilder.DropTable(
                name: "M_Edge_Assign_Param");

            migrationBuilder.DropTable(
                name: "M_EdgeGroup_Param");

            migrationBuilder.DropTable(
                name: "M_Group");

            migrationBuilder.DropTable(
                name: "M_Site");

            migrationBuilder.DropTable(
                name: "M_Space");

            migrationBuilder.DropTable(
                name: "Rule");

            migrationBuilder.DropTable(
                name: "T_Edge_Exception");

            migrationBuilder.DropTable(
                name: "T_Edge_Log");
        }
    }
}
