using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OuvICEx.API.Repository.Data.Migrations
{
    public partial class CorrectUserDepartamentColumnNameTypo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "Users");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                table: "Users",
                type: "INTEGER",
                nullable: true);
        }
    }
}
