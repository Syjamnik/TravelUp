using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelUp.Migrations
{
    public partial class removedArticleClass3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AuthorId",
                table: "AllTravels",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RatingId",
                table: "AllTravels",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AllTravels_AuthorId",
                table: "AllTravels",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_AllTravels_RatingId",
                table: "AllTravels",
                column: "RatingId");

            migrationBuilder.AddForeignKey(
                name: "FK_AllTravels_AspNetUsers_AuthorId",
                table: "AllTravels",
                column: "AuthorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AllTravels_Ratings_RatingId",
                table: "AllTravels",
                column: "RatingId",
                principalTable: "Ratings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AllTravels_AspNetUsers_AuthorId",
                table: "AllTravels");

            migrationBuilder.DropForeignKey(
                name: "FK_AllTravels_Ratings_RatingId",
                table: "AllTravels");

            migrationBuilder.DropIndex(
                name: "IX_AllTravels_AuthorId",
                table: "AllTravels");

            migrationBuilder.DropIndex(
                name: "IX_AllTravels_RatingId",
                table: "AllTravels");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "AllTravels");

            migrationBuilder.DropColumn(
                name: "RatingId",
                table: "AllTravels");
        }
    }
}
