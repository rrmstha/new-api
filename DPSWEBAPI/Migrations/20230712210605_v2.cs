using Microsoft.EntityFrameworkCore.Migrations;

namespace DPSWEBAPI.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "userModels");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "userModels",
                newName: "fullName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "fullName",
                table: "userModels",
                newName: "LastName");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "userModels",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
