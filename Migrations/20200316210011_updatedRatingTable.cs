using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelUp.Migrations
{
    public partial class updatedRatingTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Value",
                table: "Ratings");

            migrationBuilder.AddColumn<int>(
                name: "NumberOfVotes",
                table: "Ratings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<long>(
                name: "Votes",
                table: "Ratings",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberOfVotes",
                table: "Ratings");

            migrationBuilder.DropColumn(
                name: "Votes",
                table: "Ratings");

            migrationBuilder.AddColumn<double>(
                name: "Value",
                table: "Ratings",
                type: "double",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
