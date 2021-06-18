using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VSense.API.Migrations
{
    public partial class LogChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "T_Edge_Log");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "T_Edge_Log");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "T_Edge_Log");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "T_Edge_Log");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "T_Edge_Log");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "T_Edge_Log",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "T_Edge_Log",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "T_Edge_Log",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "T_Edge_Log",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "T_Edge_Log",
                type: "datetime2",
                nullable: true);
        }
    }
}
