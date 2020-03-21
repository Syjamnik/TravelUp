using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelUp.Migrations
{
    public partial class addedMTMRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Travels_Users_UserId",
                table: "Travels");

            migrationBuilder.DropForeignKey(
                name: "FK_Travels_Users_UserId1",
                table: "Travels");

            migrationBuilder.DropIndex(
                name: "IX_Travels_UserId",
                table: "Travels");

            migrationBuilder.DropIndex(
                name: "IX_Travels_UserId1",
                table: "Travels");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Travels");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Travels");

            migrationBuilder.CreateTable(
                name: "travelUserMTMs",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    TravelId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_travelUserMTMs", x => new { x.TravelId, x.UserId });
                    table.ForeignKey(
                        name: "FK_travelUserMTMs_Travels_TravelId",
                        column: x => x.TravelId,
                        principalTable: "Travels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_travelUserMTMs_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TravelUserVisitedList",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    TravelId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TravelUserVisitedList", x => new { x.TravelId, x.UserId });
                    table.ForeignKey(
                        name: "FK_TravelUserVisitedList_Travels_TravelId",
                        column: x => x.TravelId,
                        principalTable: "Travels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TravelUserVisitedList_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_travelUserMTMs_UserId",
                table: "travelUserMTMs",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TravelUserVisitedList_UserId",
                table: "TravelUserVisitedList",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "travelUserMTMs");

            migrationBuilder.DropTable(
                name: "TravelUserVisitedList");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Travels",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId1",
                table: "Travels",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Travels_UserId",
                table: "Travels",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Travels_UserId1",
                table: "Travels",
                column: "UserId1");

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
    }
}
