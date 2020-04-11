using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelUp.Migrations
{
    public partial class addedFieldsInTravelClassForGoogleMaps : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "googleMapsLatitude",
                table: "AllTravels",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "googleMapsLongitude",
                table: "AllTravels",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "googleMapsLatitude",
                table: "AllTravels");

            migrationBuilder.DropColumn(
                name: "googleMapsLongitude",
                table: "AllTravels");
        }
    }
}
