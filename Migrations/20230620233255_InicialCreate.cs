using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProjetoGR.Migrations
{
    /// <inheritdoc />
    public partial class InicialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cursos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeCurso = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descrição = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataTermino = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TipoUrgencia = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cursos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Estagios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeEmpresa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataTermino = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TipoUrgencia = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estagios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Faculdades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeFaculdade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descrição = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataTermino = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TipoUrgencia = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faculdades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Idade = table.Column<int>(type: "int", nullable: false),
                    TempoEstudo = table.Column<TimeSpan>(type: "time", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordString = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Perfil = table.Column<string>(type: "nvarchar(max)", nullable: true, defaultValue: "colaboradores"),
                    DataAcesso = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CursoUsuario",
                columns: table => new
                {
                    CursosId = table.Column<int>(type: "int", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CursoUsuario", x => new { x.CursosId, x.UsuarioId });
                    table.ForeignKey(
                        name: "FK_CursoUsuario_Cursos_CursosId",
                        column: x => x.CursosId,
                        principalTable: "Cursos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CursoUsuario_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EstagioUsuario",
                columns: table => new
                {
                    EstagiosId = table.Column<int>(type: "int", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstagioUsuario", x => new { x.EstagiosId, x.UsuarioId });
                    table.ForeignKey(
                        name: "FK_EstagioUsuario_Estagios_EstagiosId",
                        column: x => x.EstagiosId,
                        principalTable: "Estagios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EstagioUsuario_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FaculdadeUsuario",
                columns: table => new
                {
                    FaculdadesId = table.Column<int>(type: "int", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FaculdadeUsuario", x => new { x.FaculdadesId, x.UsuarioId });
                    table.ForeignKey(
                        name: "FK_FaculdadeUsuario_Faculdades_FaculdadesId",
                        column: x => x.FaculdadesId,
                        principalTable: "Faculdades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FaculdadeUsuario_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Cursos",
                columns: new[] { "Id", "DataInicio", "DataTermino", "Descrição", "NomeCurso", "TipoUrgencia" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Um curso introdutório de programação em Python.", "Introdução à Programação em Python", 1 },
                    { 2, new DateTime(2023, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Aprenda a criar sites utilizando HTML e CSS.", "Desenvolvimento Web com HTML e CSS", 0 },
                    { 3, new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Aprofunde seus conhecimentos em JavaScript e aprenda técnicas avançadas de programação.", "JavaScript Avançado", 2 },
                    { 4, new DateTime(2023, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Um curso introdutório sobre ciência de dados utilizando a linguagem Python.", "Introdução à Ciência de Dados com Python", 1 },
                    { 5, new DateTime(2023, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Aprenda a criar aplicativos para dispositivos Android utilizando Java e Android Studio.", "Desenvolvimento de Aplicações Android", 2 },
                    { 6, new DateTime(2023, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Aprenda os conceitos de programação orientada a objetos utilizando a linguagem C#.", "Programação Orientada a Objetos em C#", 1 },
                    { 7, new DateTime(2023, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Aprenda a desenvolver aplicações web full stack utilizando Node.js no backend e React no frontend.", "Desenvolvimento Full Stack com Node.js e React", 2 },
                    { 8, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Um curso introdutório sobre os fundamentos e aplicações da inteligência artificial.", "Introdução à Inteligência Artificial", 2 }
                });

            migrationBuilder.InsertData(
                table: "Estagios",
                columns: new[] { "Id", "DataInicio", "DataTermino", "NomeEmpresa", "TipoUrgencia" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Empresa ABC", 0 },
                    { 2, new DateTime(2023, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 2, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Empresa XYZ", 1 },
                    { 3, new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Empresa 123", 2 },
                    { 4, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Empresa ABCD", 1 },
                    { 5, new DateTime(2023, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Empresa XYZW", 0 },
                    { 6, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 7, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Empresa 1234", 2 }
                });

            migrationBuilder.InsertData(
                table: "Faculdades",
                columns: new[] { "Id", "DataInicio", "DataTermino", "Descrição", "NomeFaculdade", "TipoUrgencia" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2027, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Faculdade focada em cursos de ciência da computação e desenvolvimento de software.", "Faculdade de Ciência da Computação", 2 },
                    { 2, new DateTime(2023, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2028, 7, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Faculdade especializada em cursos de engenharia de software e desenvolvimento ágil.", "Faculdade de Engenharia de Software", 2 },
                    { 3, new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2027, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Faculdade com enfoque em cursos de sistemas de informação e gestão de projetos de TI.", "Faculdade de Sistemas de Informação", 0 }
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "DataAcesso", "Email", "Idade", "PasswordSalt", "PasswordString", "Perfil", "TempoEstudo", "Username" },
                values: new object[] { 1, null, "seuEmail@gmail.com", 0, new byte[] { 32, 40, 95, 82, 78, 241, 165, 197, 159, 159, 0, 110, 23, 112, 236, 11, 209, 177, 99, 203, 112, 213, 48, 70, 175, 240, 17, 88, 124, 25, 45, 102, 247, 81, 104, 213, 205, 236, 54, 122, 5, 236, 218, 6, 144, 86, 199, 6, 147, 152, 42, 132, 7, 206, 134, 198, 217, 173, 2, 35, 111, 28, 50, 198, 25, 104, 151, 254, 240, 18, 211, 179, 253, 215, 88, 51, 245, 150, 224, 19, 9, 3, 52, 68, 142, 151, 21, 43, 25, 20, 0, 37, 0, 3, 29, 13, 121, 90, 9, 37, 22, 222, 100, 85, 246, 109, 58, 203, 225, 72, 29, 42, 139, 198, 70, 58, 137, 41, 47, 180, 63, 68, 89, 8, 167, 66, 1, 152 }, "", "chefe", new TimeSpan(0, 0, 0, 0, 0), "PrimeiroUsuario" });

            migrationBuilder.CreateIndex(
                name: "IX_CursoUsuario_UsuarioId",
                table: "CursoUsuario",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_EstagioUsuario_UsuarioId",
                table: "EstagioUsuario",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_FaculdadeUsuario_UsuarioId",
                table: "FaculdadeUsuario",
                column: "UsuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CursoUsuario");

            migrationBuilder.DropTable(
                name: "EstagioUsuario");

            migrationBuilder.DropTable(
                name: "FaculdadeUsuario");

            migrationBuilder.DropTable(
                name: "Cursos");

            migrationBuilder.DropTable(
                name: "Estagios");

            migrationBuilder.DropTable(
                name: "Faculdades");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
