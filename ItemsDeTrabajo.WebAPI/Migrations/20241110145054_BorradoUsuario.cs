using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ItemsDeTrabajo.WebAPI.Migrations
{
    public partial class BorradoUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemTrabajos_Usuarios_UsuarioId",
                table: "ItemTrabajos");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_ItemTrabajos_UsuarioId",
                table: "ItemTrabajos");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "ItemTrabajos");

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "ItemTrabajos",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserName",
                table: "ItemTrabajos");

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "ItemTrabajos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Visible = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.UsuarioId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemTrabajos_UsuarioId",
                table: "ItemTrabajos",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemTrabajos_Usuarios_UsuarioId",
                table: "ItemTrabajos",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "UsuarioId");
        }
    }
}
