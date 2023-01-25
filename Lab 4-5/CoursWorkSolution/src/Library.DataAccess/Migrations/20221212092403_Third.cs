using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library.DataAccess.Migrations
{
    public partial class Third : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Sexe_FK_User_Sex",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Sexe");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_FK_User_Sex",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FK_User_Sex",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "SexeId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "Sexe",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sexe",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "FK_User_Sex",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SexeId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Sexe",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sexe", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_FK_User_Sex",
                table: "AspNetUsers",
                column: "FK_User_Sex");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Sexe_FK_User_Sex",
                table: "AspNetUsers",
                column: "FK_User_Sex",
                principalTable: "Sexe",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
