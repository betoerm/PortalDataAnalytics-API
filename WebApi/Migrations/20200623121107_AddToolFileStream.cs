using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Migrations
{
    public partial class AddToolFileStream : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Url",
                table: "Tools");

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Tools",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Provedor",
                table: "Tools",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Tools",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Location",
                table: "Tools");

            migrationBuilder.DropColumn(
                name: "Provedor",
                table: "Tools");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Tools");

            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "Tools",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
