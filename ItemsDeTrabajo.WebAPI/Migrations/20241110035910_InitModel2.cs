using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ItemsDeTrabajo.WebAPI.Migrations
{
    public partial class InitModel2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Relevancia",
                table: "ItemTrabajos",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Relevancia",
                table: "ItemTrabajos",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
