using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelUp.Migrations
{
    public partial class addedImagesAddr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImagesAddr",
                table: "AllTravels",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagesAddr",
                table: "AllTravels");
        }
    }
}
