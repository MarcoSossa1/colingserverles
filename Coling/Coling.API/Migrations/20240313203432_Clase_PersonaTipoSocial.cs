using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Coling.API.Afiliados.Migrations
{
    /// <inheritdoc />
    public partial class Clase_PersonaTipoSocial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PersonaTipoSocial_Personas_IdPersona",
                table: "PersonaTipoSocial");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonaTipoSocial_TiposSociales_IdTipoSocial",
                table: "PersonaTipoSocial");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PersonaTipoSocial",
                table: "PersonaTipoSocial");

            migrationBuilder.RenameTable(
                name: "PersonaTipoSocial",
                newName: "PersonasTiposSociales");

            migrationBuilder.RenameIndex(
                name: "IX_PersonaTipoSocial_IdTipoSocial",
                table: "PersonasTiposSociales",
                newName: "IX_PersonasTiposSociales_IdTipoSocial");

            migrationBuilder.RenameIndex(
                name: "IX_PersonaTipoSocial_IdPersona",
                table: "PersonasTiposSociales",
                newName: "IX_PersonasTiposSociales_IdPersona");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PersonasTiposSociales",
                table: "PersonasTiposSociales",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PersonasTiposSociales_Personas_IdPersona",
                table: "PersonasTiposSociales",
                column: "IdPersona",
                principalTable: "Personas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonasTiposSociales_TiposSociales_IdTipoSocial",
                table: "PersonasTiposSociales",
                column: "IdTipoSocial",
                principalTable: "TiposSociales",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PersonasTiposSociales_Personas_IdPersona",
                table: "PersonasTiposSociales");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonasTiposSociales_TiposSociales_IdTipoSocial",
                table: "PersonasTiposSociales");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PersonasTiposSociales",
                table: "PersonasTiposSociales");

            migrationBuilder.RenameTable(
                name: "PersonasTiposSociales",
                newName: "PersonaTipoSocial");

            migrationBuilder.RenameIndex(
                name: "IX_PersonasTiposSociales_IdTipoSocial",
                table: "PersonaTipoSocial",
                newName: "IX_PersonaTipoSocial_IdTipoSocial");

            migrationBuilder.RenameIndex(
                name: "IX_PersonasTiposSociales_IdPersona",
                table: "PersonaTipoSocial",
                newName: "IX_PersonaTipoSocial_IdPersona");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PersonaTipoSocial",
                table: "PersonaTipoSocial",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PersonaTipoSocial_Personas_IdPersona",
                table: "PersonaTipoSocial",
                column: "IdPersona",
                principalTable: "Personas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonaTipoSocial_TiposSociales_IdTipoSocial",
                table: "PersonaTipoSocial",
                column: "IdTipoSocial",
                principalTable: "TiposSociales",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
