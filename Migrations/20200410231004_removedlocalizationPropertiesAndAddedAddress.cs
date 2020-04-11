using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelUp.Migrations
{
    public partial class removedlocalizationPropertiesAndAddedAddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "googleMapsLatitude",
                table: "AllTravels");

            migrationBuilder.DropColumn(
                name: "googleMapsLongitude",
                table: "AllTravels");

            migrationBuilder.AddColumn<string>(
                name: "AddressOfThePlace",
                table: "AllTravels",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddressOfThePlace",
                table: "AllTravels");

            migrationBuilder.AddColumn<double>(
                name: "googleMapsLatitude",
                table: "AllTravels",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "googleMapsLongitude",
                table: "AllTravels",
                type: "double",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
