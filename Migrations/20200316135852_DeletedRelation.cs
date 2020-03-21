using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelUp.Migrations
{
    public partial class DeletedRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Travels_TravelId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Travels_TravelId1",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_TravelId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_TravelId1",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "TravelId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "TravelId1",
                table: "Users");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TravelId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TravelId1",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_TravelId",
                table: "Users",
                column: "TravelId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_TravelId1",
                table: "Users",
                column: "TravelId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Travels_TravelId",
                table: "Users",
                column: "TravelId",
                principalTable: "Travels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Travels_TravelId1",
                table: "Users",
                column: "TravelId1",
                principalTable: "Travels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
