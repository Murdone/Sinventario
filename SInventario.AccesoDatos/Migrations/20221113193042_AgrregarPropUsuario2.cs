using Microsoft.EntityFrameworkCore.Migrations;

namespace SInventario.AccesoDatos.Migrations
{
    public partial class AgrregarPropUsuario2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Oais",
                table: "AspNetUsers",
                newName: "Pais");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Pais",
                table: "AspNetUsers",
                newName: "Oais");
        }
    }
}
