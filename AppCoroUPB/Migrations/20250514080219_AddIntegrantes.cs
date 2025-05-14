using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppCoroUPB.Migrations
{
    /// <inheritdoc />
    public partial class AddIntegrantes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Integrantes",
                columns: table => new
                {
                    idInt = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreCompleto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    idVinculo = table.Column<int>(type: "int", nullable: false),
                    idCarrera = table.Column<int>(type: "int", nullable: false),
                    FechaIngreso = table.Column<DateOnly>(type: "date", nullable: false),
                    IdVoz = table.Column<int>(type: "int", nullable: false),
                    IdEstado = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Integrantes", x => x.idInt);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Integrantes");
        }
    }
}
