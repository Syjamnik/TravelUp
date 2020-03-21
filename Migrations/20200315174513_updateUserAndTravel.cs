using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelUp.Migrations
{
    public partial class updateUserAndTravel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Header",
                table: "Travels",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AuthorId",
                table: "Travels",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Travels",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId1",
                table: "Travels",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    EmailAddress = table.Column<string>(nullable: true),
                    TravelId = table.Column<int>(nullable: true),
                    TravelId1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Travels_TravelId",
                        column: x => x.TravelId,
                        principalTable: "Travels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Users_Travels_TravelId1",
                        column: x => x.TravelId1,
                        principalTable: "Travels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Travels_AuthorId",
                table: "Travels",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Travels_UserId",
                table: "Travels",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Travels_UserId1",
                table: "Travels",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Users_TravelId",
                table: "Users",
                column: "TravelId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_TravelId1",
                table: "Users",
                column: "TravelId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Travels_Users_AuthorId",
                table: "Travels",
                column: "AuthorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Travels_Users_UserId",
                table: "Travels",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Travels_Users_UserId1",
                table: "Travels",
                column: "UserId1",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Travels_Users_AuthorId",
                table: "Travels");

            migrationBuilder.DropForeignKey(
                name: "FK_Travels_Users_UserId",
                table: "Travels");

            migrationBuilder.DropForeignKey(
                name: "FK_Travels_Users_UserId1",
                table: "Travels");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Travels_AuthorId",
                table: "Travels");

            migrationBuilder.DropIndex(
                name: "IX_Travels_UserId",
                table: "Travels");

            migrationBuilder.DropIndex(
                name: "IX_Travels_UserId1",
                table: "Travels");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "Travels");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Travels");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Travels");

            migrationBuilder.AlterColumn<string>(
                name: "Header",
                table: "Travels",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);
        }
    }
}
