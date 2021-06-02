using Microsoft.EntityFrameworkCore.Migrations;

namespace VSense.API.Migrations
{
    public partial class ExceptionChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeviceID",
                table: "T_Edge_Exception");

            migrationBuilder.AddColumn<int>(
                name: "EdgeID",
                table: "T_Edge_Exception",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EdgeID",
                table: "T_Edge_Exception");

            migrationBuilder.AddColumn<int>(
                name: "DeviceID",
                table: "T_Edge_Exception",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
