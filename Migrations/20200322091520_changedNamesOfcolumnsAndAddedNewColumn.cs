using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelUp.Migrations
{
    public partial class changedNamesOfcolumnsAndAddedNewColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_travelUserMTMs_Travels_TravelId",
                table: "travelUserMTMs");

            migrationBuilder.DropForeignKey(
                name: "FK_travelUserMTMs_AspNetUsers_UserId",
                table: "travelUserMTMs");

            migrationBuilder.DropForeignKey(
                name: "FK_TravelUserVisitedList_Travels_TravelId",
                table: "TravelUserVisitedList");

            migrationBuilder.DropForeignKey(
                name: "FK_TravelUserVisitedList_AspNetUsers_UserId",
                table: "TravelUserVisitedList");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TravelUserVisitedList",
                table: "TravelUserVisitedList");

            migrationBuilder.DropPrimaryKey(
                name: "PK_travelUserMTMs",
                table: "travelUserMTMs");

            migrationBuilder.RenameTable(
                name: "TravelUserVisitedList",
                newName: "TravelUserVisMTMs");

            migrationBuilder.RenameTable(
                name: "travelUserMTMs",
                newName: "TravelUserFaMTMs");

            migrationBuilder.RenameIndex(
                name: "IX_TravelUserVisitedList_UserId",
                table: "TravelUserVisMTMs",
                newName: "IX_TravelUserVisMTMs_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_travelUserMTMs_UserId",
                table: "TravelUserFaMTMs",
                newName: "IX_TravelUserFaMTMs_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TravelUserVisMTMs",
                table: "TravelUserVisMTMs",
                columns: new[] { "TravelId", "UserId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_TravelUserFaMTMs",
                table: "TravelUserFaMTMs",
                columns: new[] { "TravelId", "UserId" });

            migrationBuilder.AddForeignKey(
                name: "FK_TravelUserFaMTMs_Travels_TravelId",
                table: "TravelUserFaMTMs",
                column: "TravelId",
                principalTable: "Travels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TravelUserFaMTMs_AspNetUsers_UserId",
                table: "TravelUserFaMTMs",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TravelUserVisMTMs_Travels_TravelId",
                table: "TravelUserVisMTMs",
                column: "TravelId",
                principalTable: "Travels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TravelUserVisMTMs_AspNetUsers_UserId",
                table: "TravelUserVisMTMs",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TravelUserFaMTMs_Travels_TravelId",
                table: "TravelUserFaMTMs");

            migrationBuilder.DropForeignKey(
                name: "FK_TravelUserFaMTMs_AspNetUsers_UserId",
                table: "TravelUserFaMTMs");

            migrationBuilder.DropForeignKey(
                name: "FK_TravelUserVisMTMs_Travels_TravelId",
                table: "TravelUserVisMTMs");

            migrationBuilder.DropForeignKey(
                name: "FK_TravelUserVisMTMs_AspNetUsers_UserId",
                table: "TravelUserVisMTMs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TravelUserVisMTMs",
                table: "TravelUserVisMTMs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TravelUserFaMTMs",
                table: "TravelUserFaMTMs");

            migrationBuilder.RenameTable(
                name: "TravelUserVisMTMs",
                newName: "TravelUserVisitedList");

            migrationBuilder.RenameTable(
                name: "TravelUserFaMTMs",
                newName: "travelUserMTMs");

            migrationBuilder.RenameIndex(
                name: "IX_TravelUserVisMTMs_UserId",
                table: "TravelUserVisitedList",
                newName: "IX_TravelUserVisitedList_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_TravelUserFaMTMs_UserId",
                table: "travelUserMTMs",
                newName: "IX_travelUserMTMs_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TravelUserVisitedList",
                table: "TravelUserVisitedList",
                columns: new[] { "TravelId", "UserId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_travelUserMTMs",
                table: "travelUserMTMs",
                columns: new[] { "TravelId", "UserId" });

            migrationBuilder.AddForeignKey(
                name: "FK_travelUserMTMs_Travels_TravelId",
                table: "travelUserMTMs",
                column: "TravelId",
                principalTable: "Travels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_travelUserMTMs_AspNetUsers_UserId",
                table: "travelUserMTMs",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TravelUserVisitedList_Travels_TravelId",
                table: "TravelUserVisitedList",
                column: "TravelId",
                principalTable: "Travels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TravelUserVisitedList_AspNetUsers_UserId",
                table: "TravelUserVisitedList",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
