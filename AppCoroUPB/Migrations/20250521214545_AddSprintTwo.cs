using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppCoroUPB.Migrations
{
    /// <inheritdoc />
    public partial class AddSprintTwo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EstadoInt",
                table: "Estados",
                newName: "Estado");

            migrationBuilder.CreateTable(
                name: "Canciones",
                columns: table => new
                {
                    idCanc = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    idComp = table.Column<int>(type: "int", nullable: false),
                    idIdioma = table.Column<int>(type: "int", nullable: false),
                    Duracion = table.Column<int>(type: "int", nullable: false),
                    idClasif = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Canciones", x => x.idCanc);
                });

            migrationBuilder.CreateTable(
                name: "ClasificacionCancion",
                columns: table => new
                {
                    idClasif = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Clasificacion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClasificacionCancion", x => x.idClasif);
                });

            migrationBuilder.CreateTable(
                name: "CompositorCanciones",
                columns: table => new
                {
                    idComp = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Compositor = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompositorCanciones", x => x.idComp);
                });

            migrationBuilder.CreateTable(
                name: "Directores",
                columns: table => new
                {
                    idDic = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreCompleto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaInicio = table.Column<DateOnly>(type: "date", nullable: false),
                    idEstado = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Directores", x => x.idDic);
                });

            migrationBuilder.CreateTable(
                name: "Idiomas",
                columns: table => new
                {
                    idIdioma = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idioma = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Idiomas", x => x.idIdioma);
                });

            migrationBuilder.CreateTable(
                name: "LugaresPresentaciones",
                columns: table => new
                {
                    idLugPresent = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Lugar = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LugaresPresentaciones", x => x.idLugPresent);
                });

            migrationBuilder.CreateTable(
                name: "Presentaciones",
                columns: table => new
                {
                    idPresent = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateOnly>(type: "date", nullable: false),
                    idLugPresent = table.Column<int>(type: "int", nullable: false),
                    idEvent = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Presentaciones", x => x.idPresent);
                });

            migrationBuilder.CreateTable(
                name: "TipoEvento",
                columns: table => new
                {
                    idEvent = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Evento = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoEvento", x => x.idEvent);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Canciones");

            migrationBuilder.DropTable(
                name: "ClasificacionCancion");

            migrationBuilder.DropTable(
                name: "CompositorCanciones");

            migrationBuilder.DropTable(
                name: "Directores");

            migrationBuilder.DropTable(
                name: "Idiomas");

            migrationBuilder.DropTable(
                name: "LugaresPresentaciones");

            migrationBuilder.DropTable(
                name: "Presentaciones");

            migrationBuilder.DropTable(
                name: "TipoEvento");

            migrationBuilder.RenameColumn(
                name: "Estado",
                table: "Estados",
                newName: "EstadoInt");
        }
    }
}
