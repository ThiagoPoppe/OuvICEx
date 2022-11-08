using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OuvICEx.API.Repository.Data.Migrations
{
    public partial class AddUserAndTargetDepartamentToPublication : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TargetDepartamentId",
                table: "Publications",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Publications",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Publications_TargetDepartamentId",
                table: "Publications",
                column: "TargetDepartamentId");

            migrationBuilder.CreateIndex(
                name: "IX_Publications_UserId",
                table: "Publications",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Publications_Departaments_TargetDepartamentId",
                table: "Publications",
                column: "TargetDepartamentId",
                principalTable: "Departaments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Publications_Users_UserId",
                table: "Publications",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Publications_Departaments_TargetDepartamentId",
                table: "Publications");

            migrationBuilder.DropForeignKey(
                name: "FK_Publications_Users_UserId",
                table: "Publications");

            migrationBuilder.DropIndex(
                name: "IX_Publications_TargetDepartamentId",
                table: "Publications");

            migrationBuilder.DropIndex(
                name: "IX_Publications_UserId",
                table: "Publications");

            migrationBuilder.DropColumn(
                name: "TargetDepartamentId",
                table: "Publications");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Publications");
        }
    }
}
