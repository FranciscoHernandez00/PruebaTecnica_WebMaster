using Microsoft.EntityFrameworkCore.Migrations;

namespace PruebaTecnica_WebMaster.Migrations
{
    public partial class Address : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Adress",
                schema: "Identity",
                table: "Store");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                schema: "Identity",
                table: "Store",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                schema: "Identity",
                table: "Store");

            migrationBuilder.AddColumn<string>(
                name: "Adress",
                schema: "Identity",
                table: "Store",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
