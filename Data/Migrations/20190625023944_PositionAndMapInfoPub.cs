using Microsoft.EntityFrameworkCore.Migrations;

namespace Grasshoppers.Data.Migrations
{
    public partial class PositionAndMapInfoPub : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MapInfo",
                table: "Maps",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Position",
                table: "Characters",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MapInfo",
                table: "Maps");

            migrationBuilder.DropColumn(
                name: "Position",
                table: "Characters");
        }
    }
}
