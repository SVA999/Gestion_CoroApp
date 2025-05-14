using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppCoroUPB.Migrations
{
    /// <inheritdoc />
    public partial class AddRelationIntegrantes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "IdEstado",
                table: "Integrantes",
                type: "int",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "tinyint");

            migrationBuilder.CreateTable(
                name: "Carrera_Dependencia",
                columns: table => new
                {
                    idCarrera = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Carrera = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carrera_Dependencia", x => x.idCarrera);
                });

            migrationBuilder.CreateTable(
                name: "ClasificacionVoz",
                columns: table => new
                {
                    idVoz = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Voz = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClasificacionVoz", x => x.idVoz);
                });

            migrationBuilder.CreateTable(
                name: "Estados",
                columns: table => new
                {
                    idEst = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EstadoInt = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estados", x => x.idEst);
                });

            migrationBuilder.CreateTable(
                name: "TipoVinculo",
                columns: table => new
                {
                    idVinculo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Vinculo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoVinculo", x => x.idVinculo);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Carrera_Dependencia");

            migrationBuilder.DropTable(
                name: "ClasificacionVoz");

            migrationBuilder.DropTable(
                name: "Estados");

            migrationBuilder.DropTable(
                name: "TipoVinculo");

            migrationBuilder.AlterColumn<int>(
                name: "IdEstado",
                table: "Integrantes",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
