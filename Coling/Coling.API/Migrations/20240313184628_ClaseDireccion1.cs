using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Coling.API.Afiliados.Migrations
{
    /// <inheritdoc />
    public partial class ClaseDireccion1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Direccion_Personas_IdPersona",
                table: "Direccion");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Direccion",
                table: "Direccion");

            migrationBuilder.RenameTable(
                name: "Direccion",
                newName: "Direcciones");

            migrationBuilder.RenameIndex(
                name: "IX_Direccion_IdPersona",
                table: "Direcciones",
                newName: "IX_Direcciones_IdPersona");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Direcciones",
                table: "Direcciones",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Direcciones_Personas_IdPersona",
                table: "Direcciones",
                column: "IdPersona",
                principalTable: "Personas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Direcciones_Personas_IdPersona",
                table: "Direcciones");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Direcciones",
                table: "Direcciones");

            migrationBuilder.RenameTable(
                name: "Direcciones",
                newName: "Direccion");

            migrationBuilder.RenameIndex(
                name: "IX_Direcciones_IdPersona",
                table: "Direccion",
                newName: "IX_Direccion_IdPersona");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Direccion",
                table: "Direccion",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Direccion_Personas_IdPersona",
                table: "Direccion",
                column: "IdPersona",
                principalTable: "Personas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
