using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SInventario.AccesoDatos.Migrations
{
    public partial class Invnari : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.CreateTable(
                name: "BodegaProductos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BodegaId = table.Column<int>(type: "int", nullable: false),
                    ProductoId = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BodegaProductos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BodegaProductos_Bodegas_BodegaId",
                        column: x => x.BodegaId,
                        principalTable: "Bodegas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BodegaProductos_productos_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "productos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Invetario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioAplicacionId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaFinal = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BodegaId = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invetario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Invetario_AspNetUsers_UsuarioAplicacionId",
                        column: x => x.UsuarioAplicacionId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Invetario_Bodegas_BodegaId",
                        column: x => x.BodegaId,
                        principalTable: "Bodegas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InventarioDetalle",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InventarioId = table.Column<int>(type: "int", nullable: false),
                    ProductoId = table.Column<int>(type: "int", nullable: false),
                    StockAnterior = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventarioDetalle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InventarioDetalle_Invetario_InventarioId",
                        column: x => x.InventarioId,
                        principalTable: "Invetario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InventarioDetalle_productos_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "productos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BodegaProductos_BodegaId",
                table: "BodegaProductos",
                column: "BodegaId");

            migrationBuilder.CreateIndex(
                name: "IX_BodegaProductos_ProductoId",
                table: "BodegaProductos",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_InventarioDetalle_InventarioId",
                table: "InventarioDetalle",
                column: "InventarioId");

            migrationBuilder.CreateIndex(
                name: "IX_InventarioDetalle_ProductoId",
                table: "InventarioDetalle",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_Invetario_BodegaId",
                table: "Invetario",
                column: "BodegaId");

            migrationBuilder.CreateIndex(
                name: "IX_Invetario_UsuarioAplicacionId",
                table: "Invetario",
                column: "UsuarioAplicacionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BodegaProductos");

            migrationBuilder.DropTable(
                name: "InventarioDetalle");

            migrationBuilder.DropTable(
                name: "Invetario");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
