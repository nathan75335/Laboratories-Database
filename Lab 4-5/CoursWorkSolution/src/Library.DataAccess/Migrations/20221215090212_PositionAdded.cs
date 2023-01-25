using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library.DataAccess.Migrations
{
    public partial class PositionAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BorrowBooks_Worker_WorkerId",
                table: "BorrowBooks");

            migrationBuilder.DropForeignKey(
                name: "FK_Worker_Position_PositionId",
                table: "Worker");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Worker",
                table: "Worker");

            migrationBuilder.RenameTable(
                name: "Worker",
                newName: "Workers");

            migrationBuilder.RenameIndex(
                name: "IX_Worker_PositionId",
                table: "Workers",
                newName: "IX_Workers_PositionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Workers",
                table: "Workers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BorrowBooks_Workers_WorkerId",
                table: "BorrowBooks",
                column: "WorkerId",
                principalTable: "Workers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Workers_Position_PositionId",
                table: "Workers",
                column: "PositionId",
                principalTable: "Position",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BorrowBooks_Workers_WorkerId",
                table: "BorrowBooks");

            migrationBuilder.DropForeignKey(
                name: "FK_Workers_Position_PositionId",
                table: "Workers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Workers",
                table: "Workers");

            migrationBuilder.RenameTable(
                name: "Workers",
                newName: "Worker");

            migrationBuilder.RenameIndex(
                name: "IX_Workers_PositionId",
                table: "Worker",
                newName: "IX_Worker_PositionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Worker",
                table: "Worker",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BorrowBooks_Worker_WorkerId",
                table: "BorrowBooks",
                column: "WorkerId",
                principalTable: "Worker",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Worker_Position_PositionId",
                table: "Worker",
                column: "PositionId",
                principalTable: "Position",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
