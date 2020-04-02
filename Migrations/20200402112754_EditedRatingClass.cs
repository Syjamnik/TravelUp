using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelUp.Migrations
{
    public partial class EditedRatingClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Votes",
                table: "Ratings");

            migrationBuilder.AddColumn<long>(
                name: "Score",
                table: "Ratings",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Score",
                table: "Ratings");

            migrationBuilder.AddColumn<long>(
                name: "Votes",
                table: "Ratings",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
