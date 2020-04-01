using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelUp.Migrations
{
    public partial class removedArticleClass2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Travels_Ratings_RatingId",
                table: "Travels");

            migrationBuilder.DropForeignKey(
                name: "FK_TravelUserFaMTMs_Travels_TravelId",
                table: "TravelUserFaMTMs");

            migrationBuilder.DropForeignKey(
                name: "FK_TravelUserVisMTMs_Travels_TravelId",
                table: "TravelUserVisMTMs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Travels",
                table: "Travels");

            migrationBuilder.DropIndex(
                name: "IX_Travels_RatingId",
                table: "Travels");

            migrationBuilder.DropColumn(
                name: "RatingId",
                table: "Travels");

            migrationBuilder.RenameTable(
                name: "Travels",
                newName: "AllTravels");

            migrationBuilder.AlterColumn<string>(
                name: "Header",
                table: "AllTravels",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50) CHARACTER SET utf8mb4",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AllTravels",
                table: "AllTravels",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TravelUserFaMTMs_AllTravels_TravelId",
                table: "TravelUserFaMTMs",
                column: "TravelId",
                principalTable: "AllTravels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TravelUserVisMTMs_AllTravels_TravelId",
                table: "TravelUserVisMTMs",
                column: "TravelId",
                principalTable: "AllTravels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TravelUserFaMTMs_AllTravels_TravelId",
                table: "TravelUserFaMTMs");

            migrationBuilder.DropForeignKey(
                name: "FK_TravelUserVisMTMs_AllTravels_TravelId",
                table: "TravelUserVisMTMs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AllTravels",
                table: "AllTravels");

            migrationBuilder.RenameTable(
                name: "AllTravels",
                newName: "Travels");

            migrationBuilder.AlterColumn<string>(
                name: "Header",
                table: "Travels",
                type: "varchar(50) CHARACTER SET utf8mb4",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RatingId",
                table: "Travels",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Travels",
                table: "Travels",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Travels_RatingId",
                table: "Travels",
                column: "RatingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Travels_Ratings_RatingId",
                table: "Travels",
                column: "RatingId",
                principalTable: "Ratings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TravelUserFaMTMs_Travels_TravelId",
                table: "TravelUserFaMTMs",
                column: "TravelId",
                principalTable: "Travels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TravelUserVisMTMs_Travels_TravelId",
                table: "TravelUserVisMTMs",
                column: "TravelId",
                principalTable: "Travels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
