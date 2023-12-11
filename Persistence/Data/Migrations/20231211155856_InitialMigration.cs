using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // migrationBuilder.AlterDatabase()
            //     .Annotation("MySql:CharSet", "utf8mb4");

            // migrationBuilder.CreateTable(
            //     name: "Pais",
            //     columns: table => new
            //     {
            //         Id = table.Column<int>(type: "int", nullable: false),
            //         NombrePais = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
            //             .Annotation("MySql:CharSet", "utf8mb4")
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PRIMARY", x => x.Id);
            //     })
            //     .Annotation("MySql:CharSet", "utf8mb4");

            // migrationBuilder.CreateTable(
            //     name: "categoriapersona",
            //     columns: table => new
            //     {
            //         Id = table.Column<int>(type: "int", nullable: false),
            //         NombreCategoria = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
            //             .Annotation("MySql:CharSet", "utf8mb4")
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PRIMARY", x => x.Id);
            //     })
            //     .Annotation("MySql:CharSet", "utf8mb4");

            // migrationBuilder.CreateTable(
            //     name: "estado",
            //     columns: table => new
            //     {
            //         Id = table.Column<int>(type: "int", nullable: false),
            //         Descripcion = table.Column<string>(type: "text", nullable: true)
            //             .Annotation("MySql:CharSet", "utf8mb4")
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PRIMARY", x => x.Id);
            //     })
            //     .Annotation("MySql:CharSet", "utf8mb4");

            // migrationBuilder.CreateTable(
            //     name: "tipocontacto",
            //     columns: table => new
            //     {
            //         Id = table.Column<int>(type: "int", nullable: false),
            //         Descripcion = table.Column<string>(type: "text", nullable: true)
            //             .Annotation("MySql:CharSet", "utf8mb4")
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PRIMARY", x => x.Id);
            //     })
            //     .Annotation("MySql:CharSet", "utf8mb4");

            // migrationBuilder.CreateTable(
            //     name: "tipodireccion",
            //     columns: table => new
            //     {
            //         Id = table.Column<int>(type: "int", nullable: false),
            //         Descripcion = table.Column<string>(type: "text", nullable: true)
            //             .Annotation("MySql:CharSet", "utf8mb4")
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PRIMARY", x => x.Id);
            //     })
            //     .Annotation("MySql:CharSet", "utf8mb4");

            // migrationBuilder.CreateTable(
            //     name: "tipopersona",
            //     columns: table => new
            //     {
            //         Id = table.Column<int>(type: "int", nullable: false),
            //         Descripcion = table.Column<string>(type: "text", nullable: true)
            //             .Annotation("MySql:CharSet", "utf8mb4")
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PRIMARY", x => x.Id);
            //     })
            //     .Annotation("MySql:CharSet", "utf8mb4");

            // migrationBuilder.CreateTable(
            //     name: "turno",
            //     columns: table => new
            //     {
            //         Id = table.Column<int>(type: "int", nullable: false),
            //         NombreTurno = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
            //             .Annotation("MySql:CharSet", "utf8mb4"),
            //         HoraTurNOT = table.Column<TimeOnly>(type: "time", nullable: false),
            //         HoraTurnoF = table.Column<TimeOnly>(type: "time", nullable: false)
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PRIMARY", x => x.Id);
            //     })
            //     .Annotation("MySql:CharSet", "utf8mb4");

            // migrationBuilder.CreateTable(
            //     name: "departamento",
            //     columns: table => new
            //     {
            //         Id = table.Column<int>(type: "int", nullable: false),
            //         NombreDepar = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
            //             .Annotation("MySql:CharSet", "utf8mb4"),
            //         IdPaisFk = table.Column<int>(type: "int", nullable: false)
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PRIMARY", x => x.Id);
            //         table.ForeignKey(
            //             name: "FkPais",
            //             column: x => x.IdPaisFk,
            //             principalTable: "Pais",
            //             principalColumn: "Id");
            //     })
            //     .Annotation("MySql:CharSet", "utf8mb4");

            // migrationBuilder.CreateTable(
            //     name: "Ciudad",
            //     columns: table => new
            //     {
            //         Id = table.Column<int>(type: "int", nullable: false),
            //         NombreCiudad = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
            //             .Annotation("MySql:CharSet", "utf8mb4"),
            //         IdDeparFk = table.Column<int>(type: "int", nullable: false)
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PRIMARY", x => x.Id);
            //         table.ForeignKey(
            //             name: "FkDepar",
            //             column: x => x.IdDeparFk,
            //             principalTable: "departamento",
            //             principalColumn: "Id");
            //     })
            //     .Annotation("MySql:CharSet", "utf8mb4");

            // migrationBuilder.CreateTable(
            //     name: "persona",
            //     columns: table => new
            //     {
            //         Id = table.Column<int>(type: "int", nullable: false),
            //         IdPerUq = table.Column<int>(type: "int", nullable: false),
            //         NombrePersona = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
            //             .Annotation("MySql:CharSet", "utf8mb4"),
            //         FechaReg = table.Column<DateOnly>(type: "date", nullable: false),
            //         IdTpPersonaFk = table.Column<int>(type: "int", nullable: false),
            //         IdCategoriaP = table.Column<int>(type: "int", nullable: false),
            //         IdCiudadFk = table.Column<int>(type: "int", nullable: false)
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PRIMARY", x => x.Id);
            //         table.ForeignKey(
            //             name: "FkCatP",
            //             column: x => x.IdCategoriaP,
            //             principalTable: "categoriapersona",
            //             principalColumn: "Id");
            //         table.ForeignKey(
            //             name: "FkCiudad",
            //             column: x => x.IdCiudadFk,
            //             principalTable: "Ciudad",
            //             principalColumn: "Id");
            //         table.ForeignKey(
            //             name: "FkTpPer",
            //             column: x => x.IdTpPersonaFk,
            //             principalTable: "tipopersona",
            //             principalColumn: "Id");
            //     })
            //     .Annotation("MySql:CharSet", "utf8mb4");

            // migrationBuilder.CreateTable(
            //     name: "ContactoPersona",
            //     columns: table => new
            //     {
            //         Id = table.Column<int>(type: "int", nullable: false),
            //         Descripcion = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
            //             .Annotation("MySql:CharSet", "utf8mb4"),
            //         IdTpContactoFk = table.Column<int>(type: "int", nullable: false),
            //         IdPersonaFk = table.Column<int>(type: "int", nullable: false)
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PRIMARY", x => x.Id);
            //         table.ForeignKey(
            //             name: "FkPersonaC",
            //             column: x => x.IdPersonaFk,
            //             principalTable: "persona",
            //             principalColumn: "Id");
            //         table.ForeignKey(
            //             name: "FkTpContacto",
            //             column: x => x.IdTpContactoFk,
            //             principalTable: "tipocontacto",
            //             principalColumn: "Id");
            //     })
            //     .Annotation("MySql:CharSet", "utf8mb4");

            // migrationBuilder.CreateTable(
            //     name: "DireccionPersona",
            //     columns: table => new
            //     {
            //         Id = table.Column<int>(type: "int", nullable: false),
            //         Direccion = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
            //             .Annotation("MySql:CharSet", "utf8mb4"),
            //         IdTpDireccionFk = table.Column<int>(type: "int", nullable: false),
            //         IdPersonaFk = table.Column<int>(type: "int", nullable: false)
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PRIMARY", x => x.Id);
            //         table.ForeignKey(
            //             name: "FkPersona",
            //             column: x => x.IdPersonaFk,
            //             principalTable: "persona",
            //             principalColumn: "Id");
            //         table.ForeignKey(
            //             name: "FkTpDireccion",
            //             column: x => x.IdTpDireccionFk,
            //             principalTable: "tipodireccion",
            //             principalColumn: "Id");
            //     })
            //     .Annotation("MySql:CharSet", "utf8mb4");

            // migrationBuilder.CreateTable(
            //     name: "contrato",
            //     columns: table => new
            //     {
            //         Id = table.Column<int>(type: "int", nullable: false),
            //         FechaContrato = table.Column<DateOnly>(type: "date", nullable: false),
            //         FechaFin = table.Column<DateOnly>(type: "date", nullable: false),
            //         IdClienteFk = table.Column<int>(type: "int", nullable: false),
            //         IdEmpleadoFk = table.Column<int>(type: "int", nullable: false),
            //         IdEstadoFk = table.Column<int>(type: "int", nullable: false)
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PRIMARY", x => x.Id);
            //         table.ForeignKey(
            //             name: "FkCliente",
            //             column: x => x.IdClienteFk,
            //             principalTable: "persona",
            //             principalColumn: "Id");
            //         table.ForeignKey(
            //             name: "FkEmpleado",
            //             column: x => x.IdEmpleadoFk,
            //             principalTable: "persona",
            //             principalColumn: "Id");
            //         table.ForeignKey(
            //             name: "FkEstado",
            //             column: x => x.IdEstadoFk,
            //             principalTable: "estado",
            //             principalColumn: "Id");
            //     })
            //     .Annotation("MySql:CharSet", "utf8mb4");

            // migrationBuilder.CreateTable(
            //     name: "programacion",
            //     columns: table => new
            //     {
            //         Id = table.Column<int>(type: "int", nullable: false),
            //         IdContratoFk = table.Column<int>(type: "int", nullable: false),
            //         IdTurnoFk = table.Column<int>(type: "int", nullable: false),
            //         IdEmpleadoFk = table.Column<int>(type: "int", nullable: false)
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PRIMARY", x => x.Id);
            //         table.ForeignKey(
            //             name: "FkContrato",
            //             column: x => x.IdContratoFk,
            //             principalTable: "contrato",
            //             principalColumn: "Id");
            //         table.ForeignKey(
            //             name: "FkEmpleadouO",
            //             column: x => x.IdEmpleadoFk,
            //             principalTable: "persona",
            //             principalColumn: "Id");
            //         table.ForeignKey(
            //             name: "FkTurno",
            //             column: x => x.IdTurnoFk,
            //             principalTable: "turno",
            //             principalColumn: "Id");
            //     })
            //     .Annotation("MySql:CharSet", "utf8mb4");

            // migrationBuilder.CreateIndex(
            //     name: "FkDepar",
            //     table: "Ciudad",
            //     column: "IdDeparFk");

            // migrationBuilder.CreateIndex(
            //     name: "FkPersonaC",
            //     table: "ContactoPersona",
            //     column: "IdPersonaFk");

            // migrationBuilder.CreateIndex(
            //     name: "FkTpContacto",
            //     table: "ContactoPersona",
            //     column: "IdTpContactoFk");

            // migrationBuilder.CreateIndex(
            //     name: "UqCtPersona",
            //     table: "ContactoPersona",
            //     column: "Descripcion",
            //     unique: true);

            // migrationBuilder.CreateIndex(
            //     name: "FkPersona",
            //     table: "DireccionPersona",
            //     column: "IdPersonaFk");

            // migrationBuilder.CreateIndex(
            //     name: "FkTpDireccion",
            //     table: "DireccionPersona",
            //     column: "IdTpDireccionFk");

            // migrationBuilder.CreateIndex(
            //     name: "FkCliente",
            //     table: "contrato",
            //     column: "IdClienteFk");

            // migrationBuilder.CreateIndex(
            //     name: "FkEmpleado",
            //     table: "contrato",
            //     column: "IdEmpleadoFk");

            // migrationBuilder.CreateIndex(
            //     name: "FkEstado",
            //     table: "contrato",
            //     column: "IdEstadoFk");

            // migrationBuilder.CreateIndex(
            //     name: "FkPais",
            //     table: "departamento",
            //     column: "IdPaisFk");

            // migrationBuilder.CreateIndex(
            //     name: "FkCatP",
            //     table: "persona",
            //     column: "IdCategoriaP");

            // migrationBuilder.CreateIndex(
            //     name: "FkCiudad",
            //     table: "persona",
            //     column: "IdCiudadFk");

            // migrationBuilder.CreateIndex(
            //     name: "FkTpPer",
            //     table: "persona",
            //     column: "IdTpPersonaFk");

            // migrationBuilder.CreateIndex(
            //     name: "UqPer",
            //     table: "persona",
            //     column: "IdPerUq",
            //     unique: true);

            // migrationBuilder.CreateIndex(
            //     name: "FkContrato",
            //     table: "programacion",
            //     column: "IdContratoFk");

            // migrationBuilder.CreateIndex(
            //     name: "FkEmpleadouO",
            //     table: "programacion",
            //     column: "IdEmpleadoFk");

            // migrationBuilder.CreateIndex(
            //     name: "FkTurno",
            //     table: "programacion",
            //     column: "IdTurnoFk");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // migrationBuilder.DropTable(
            //     name: "ContactoPersona");

            // migrationBuilder.DropTable(
            //     name: "DireccionPersona");

            // migrationBuilder.DropTable(
            //     name: "programacion");

            // migrationBuilder.DropTable(
            //     name: "tipocontacto");

            // migrationBuilder.DropTable(
            //     name: "tipodireccion");

            // migrationBuilder.DropTable(
            //     name: "contrato");

            // migrationBuilder.DropTable(
            //     name: "turno");

            // migrationBuilder.DropTable(
            //     name: "persona");

            // migrationBuilder.DropTable(
            //     name: "estado");

            // migrationBuilder.DropTable(
            //     name: "categoriapersona");

            // migrationBuilder.DropTable(
            //     name: "Ciudad");

            // migrationBuilder.DropTable(
            //     name: "tipopersona");

            // migrationBuilder.DropTable(
            //     name: "departamento");

            // migrationBuilder.DropTable(
            //     name: "Pais");
        }
    }
}
