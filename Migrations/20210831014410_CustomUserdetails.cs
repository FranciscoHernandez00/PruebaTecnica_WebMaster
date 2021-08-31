using Microsoft.EntityFrameworkCore.Migrations;

namespace PruebaTecnica_WebMaster.Migrations
{
    public partial class CustomUserdetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Details",
                schema: "Identity",
                table: "User",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Details",
                schema: "Identity",
                table: "User");
        }
    }
}
