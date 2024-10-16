using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LamaApp.Server.Migrations
{
    /// <inheritdoc />
    public partial class firstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Capitulos",
                columns: table => new
                {
                    ID_Capitulo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pais = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ciudad = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Capitulos", x => x.ID_Capitulo);
                });

            migrationBuilder.CreateTable(
                name: "Contactos",
                columns: table => new
                {
                    ID_Contacto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Celular = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contactos", x => x.ID_Contacto);
                });

            migrationBuilder.CreateTable(
                name: "Motocicletas",
                columns: table => new
                {
                    ID_Motocicleta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Marca = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Modelo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cilindrada = table.Column<int>(type: "int", nullable: false),
                    Placa = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Motocicletas", x => x.ID_Motocicleta);
                });

            migrationBuilder.CreateTable(
                name: "Parejas",
                columns: table => new
                {
                    ID_Pareja = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cedula = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parejas", x => x.ID_Pareja);
                });

            migrationBuilder.CreateTable(
                name: "Eventos",
                columns: table => new
                {
                    ID_Evento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha_Inicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Fecha_Fin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Ubicacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Creador = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ID_Capitulo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eventos", x => x.ID_Evento);
                    table.ForeignKey(
                        name: "FK_Eventos_Capitulos_ID_Capitulo",
                        column: x => x.ID_Capitulo,
                        principalTable: "Capitulos",
                        principalColumn: "ID_Capitulo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    ID_Usuario = table.Column<int>(type: "int", nullable: false),
                    Nombre_Usuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contraseña = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cedula = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fecha_Nacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Fecha_Registro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ID_Contacto = table.Column<int>(type: "int", nullable: false),
                    ID_Pareja = table.Column<int>(type: "int", nullable: false),
                    ID_Capitulo = table.Column<int>(type: "int", nullable: false),
                    ID_Motocicleta = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.ID_Usuario);
                    table.ForeignKey(
                        name: "FK_Usuarios_Capitulos_ID_Capitulo",
                        column: x => x.ID_Capitulo,
                        principalTable: "Capitulos",
                        principalColumn: "ID_Capitulo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Usuarios_Contactos_ID_Contacto",
                        column: x => x.ID_Contacto,
                        principalTable: "Contactos",
                        principalColumn: "ID_Contacto",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Usuarios_Motocicletas_ID_Motocicleta",
                        column: x => x.ID_Motocicleta,
                        principalTable: "Motocicletas",
                        principalColumn: "ID_Motocicleta",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Usuarios_Parejas_ID_Pareja",
                        column: x => x.ID_Pareja,
                        principalTable: "Parejas",
                        principalColumn: "ID_Pareja",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Inscripciones",
                columns: table => new
                {
                    ID_Inscripcion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha_Compra = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ID_Evento = table.Column<int>(type: "int", nullable: false),
                    ID_Usuario = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inscripciones", x => x.ID_Inscripcion);
                    table.ForeignKey(
                        name: "FK_Inscripciones_Eventos_ID_Evento",
                        column: x => x.ID_Evento,
                        principalTable: "Eventos",
                        principalColumn: "ID_Evento");
                    table.ForeignKey(
                        name: "FK_Inscripciones_Usuarios_ID_Usuario",
                        column: x => x.ID_Usuario,
                        principalTable: "Usuarios",
                        principalColumn: "ID_Usuario");
                });

            migrationBuilder.CreateTable(
                name: "Publicaciones",
                columns: table => new
                {
                    ID_Publicacion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ID_Usuario = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publicaciones", x => x.ID_Publicacion);
                    table.ForeignKey(
                        name: "FK_Publicaciones_Usuarios_ID_Usuario",
                        column: x => x.ID_Usuario,
                        principalTable: "Usuarios",
                        principalColumn: "ID_Usuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Eventos_ID_Capitulo",
                table: "Eventos",
                column: "ID_Capitulo");

            migrationBuilder.CreateIndex(
                name: "IX_Inscripciones_ID_Evento",
                table: "Inscripciones",
                column: "ID_Evento");

            migrationBuilder.CreateIndex(
                name: "IX_Inscripciones_ID_Usuario",
                table: "Inscripciones",
                column: "ID_Usuario");

            migrationBuilder.CreateIndex(
                name: "IX_Publicaciones_ID_Usuario",
                table: "Publicaciones",
                column: "ID_Usuario");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_ID_Capitulo",
                table: "Usuarios",
                column: "ID_Capitulo");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_ID_Contacto",
                table: "Usuarios",
                column: "ID_Contacto",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_ID_Motocicleta",
                table: "Usuarios",
                column: "ID_Motocicleta",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_ID_Pareja",
                table: "Usuarios",
                column: "ID_Pareja",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inscripciones");

            migrationBuilder.DropTable(
                name: "Publicaciones");

            migrationBuilder.DropTable(
                name: "Eventos");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Capitulos");

            migrationBuilder.DropTable(
                name: "Contactos");

            migrationBuilder.DropTable(
                name: "Motocicletas");

            migrationBuilder.DropTable(
                name: "Parejas");
        }
    }
}
