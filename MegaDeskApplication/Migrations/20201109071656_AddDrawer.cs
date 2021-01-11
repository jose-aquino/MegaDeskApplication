using Microsoft.EntityFrameworkCore.Migrations;

namespace MegaDeskApplication.Migrations
{
    public partial class AddDrawer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Drawers",
                table: "Movie",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Drawers",
                table: "Movie");
        }
    }
}
