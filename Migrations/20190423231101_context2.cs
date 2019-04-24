using Microsoft.EntityFrameworkCore.Migrations;

namespace CRUD.Migrations
{
    public partial class Context2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Midias",
                table: "Midias");

            migrationBuilder.RenameTable(
                name: "Midias",
                newName: "Midia");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Midia",
                table: "Midia",
                column: "MidiaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Midia",
                table: "Midia");

            migrationBuilder.RenameTable(
                name: "Midia",
                newName: "Midias");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Midias",
                table: "Midias",
                column: "MidiaId");
        }
    }
}
