using Microsoft.EntityFrameworkCore.Migrations;

namespace PruebaTecnica_WebMaster.Migrations
{
    public partial class CustomUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Create",
                schema: "Identity",
                table: "User",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Delete",
                schema: "Identity",
                table: "User",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Edit",
                schema: "Identity",
                table: "User",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Create",
                schema: "Identity",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Delete",
                schema: "Identity",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Edit",
                schema: "Identity",
                table: "User");
        }
    }
}
