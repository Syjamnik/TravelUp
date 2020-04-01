using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelUp.Migrations
{
    public partial class removedArticleClass1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Travels_AspNetUsers_AuthorId",
                table: "Travels");

            migrationBuilder.DropIndex(
                name: "IX_Travels_AuthorId",
                table: "Travels");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "Travels");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AuthorId",
                table: "Travels",
                type: "varchar(255) CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Travels_AuthorId",
                table: "Travels",
                column: "AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Travels_AspNetUsers_AuthorId",
                table: "Travels",
                column: "AuthorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
