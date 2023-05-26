using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestDb.Migrations
{
    /// <inheritdoc />
    public partial class dos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Libro_Persona_AutorId",
                table: "Libro");

            migrationBuilder.DropForeignKey(
                name: "FK_Prestamo_Persona_UsuarioId",
                table: "Prestamo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Persona",
                table: "Persona");

            migrationBuilder.DropColumn(
                name: "Apellido",
                table: "Persona");

            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "Persona");

            migrationBuilder.DropColumn(
                name: "Persona_type",
                table: "Persona");

            migrationBuilder.RenameTable(
                name: "Persona",
                newName: "Usuario");

            migrationBuilder.RenameColumn(
                name: "IdPersona",
                table: "Usuario",
                newName: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usuario",
                table: "Usuario",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Autor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreAutor = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autor", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Libro_Autor_AutorId",
                table: "Libro",
                column: "AutorId",
                principalTable: "Autor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Prestamo_Usuario_UsuarioId",
                table: "Prestamo",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Libro_Autor_AutorId",
                table: "Libro");

            migrationBuilder.DropForeignKey(
                name: "FK_Prestamo_Usuario_UsuarioId",
                table: "Prestamo");

            migrationBuilder.DropTable(
                name: "Autor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Usuario",
                table: "Usuario");

            migrationBuilder.RenameTable(
                name: "Usuario",
                newName: "Persona");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Persona",
                newName: "IdPersona");

            migrationBuilder.AddColumn<string>(
                name: "Apellido",
                table: "Persona",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "Persona",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Persona_type",
                table: "Persona",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Persona",
                table: "Persona",
                column: "IdPersona");

            migrationBuilder.AddForeignKey(
                name: "FK_Libro_Persona_AutorId",
                table: "Libro",
                column: "AutorId",
                principalTable: "Persona",
                principalColumn: "IdPersona",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Prestamo_Persona_UsuarioId",
                table: "Prestamo",
                column: "UsuarioId",
                principalTable: "Persona",
                principalColumn: "IdPersona");
        }
    }
}
