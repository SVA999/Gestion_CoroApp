using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppCoroUPB.Migrations
{
    /// <inheritdoc />
    public partial class AddTablaLugaresEnsayo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Duracion",
                table: "Ensayos");

            migrationBuilder.DropColumn(
                name: "IdDirector",
                table: "Ensayos");

            migrationBuilder.RenameColumn(
                name: "IdLugarEns",
                table: "Ensayos",
                newName: "IdLugEns");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Ensayos",
                newName: "idEns");

            migrationBuilder.CreateTable(
                name: "LugaresEnsayo",
                columns: table => new
                {
                    idLugEns = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Lugar = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LugaresEnsayo", x => x.idLugEns);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LugaresEnsayo");

            migrationBuilder.RenameColumn(
                name: "IdLugEns",
                table: "Ensayos",
                newName: "IdLugarEns");

            migrationBuilder.RenameColumn(
                name: "idEns",
                table: "Ensayos",
                newName: "Id");

            migrationBuilder.AddColumn<int>(
                name: "Duracion",
                table: "Ensayos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdDirector",
                table: "Ensayos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
