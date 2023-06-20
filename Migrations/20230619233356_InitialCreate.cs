using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProjetoGR.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
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
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Idade = table.Column<int>(type: "int", nullable: false),
                    TempoEstudo = table.Column<TimeSpan>(type: "time", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordString = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Perfil = table.Column<string>(type: "nvarchar(max)", nullable: true, defaultValue: "colaboradores"),
                    DataAcesso = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
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
                    TipoUrgencia = table.Column<int>(type: "int", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estagios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Estagios_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id");
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
                    TipoUrgencia = table.Column<int>(type: "int", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faculdades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Faculdades_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id");
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
                columns: new[] { "Id", "DataInicio", "DataTermino", "NomeEmpresa", "TipoUrgencia", "UsuarioId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Empresa ABC", 0, null },
                    { 2, new DateTime(2023, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 2, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Empresa XYZ", 1, null },
                    { 3, new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Empresa 123", 2, null },
                    { 4, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Empresa ABCD", 1, null },
                    { 5, new DateTime(2023, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Empresa XYZW", 0, null },
                    { 6, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 7, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Empresa 1234", 2, null }
                });

            migrationBuilder.InsertData(
                table: "Faculdades",
                columns: new[] { "Id", "DataInicio", "DataTermino", "Descrição", "NomeFaculdade", "TipoUrgencia", "UsuarioId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2027, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Faculdade focada em cursos de ciência da computação e desenvolvimento de software.", "Faculdade de Ciência da Computação", 2, null },
                    { 2, new DateTime(2023, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2028, 7, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Faculdade especializada em cursos de engenharia de software e desenvolvimento ágil.", "Faculdade de Engenharia de Software", 2, null },
                    { 3, new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2027, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Faculdade com enfoque em cursos de sistemas de informação e gestão de projetos de TI.", "Faculdade de Sistemas de Informação", 0, null }
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "DataAcesso", "Email", "Idade", "PasswordHash", "PasswordSalt", "PasswordString", "Perfil", "TempoEstudo", "Username" },
                values: new object[] { 1, null, "seuEmail@gmail.com", 0, new byte[] { 49, 62, 80, 54, 202, 244, 30, 234, 164, 158, 36, 158, 13, 166, 168, 152, 165, 157, 109, 53, 244, 192, 79, 25, 50, 16, 152, 168, 201, 109, 104, 196, 179, 121, 25, 132, 222, 214, 248, 242, 188, 185, 182, 138, 35, 142, 133, 30, 163, 207, 104, 206, 241, 162, 163, 186, 218, 111, 104, 56, 66, 103, 36, 220 }, new byte[] { 60, 2, 61, 161, 80, 28, 110, 240, 130, 117, 209, 117, 109, 229, 95, 62, 212, 207, 57, 236, 35, 66, 0, 79, 119, 97, 148, 33, 61, 90, 26, 137, 192, 179, 204, 41, 181, 167, 234, 10, 175, 191, 232, 176, 78, 188, 127, 134, 154, 24, 32, 77, 85, 88, 129, 42, 108, 56, 243, 157, 159, 58, 108, 159, 254, 1, 107, 210, 246, 127, 137, 124, 29, 136, 206, 247, 102, 175, 199, 121, 53, 143, 92, 171, 226, 91, 179, 165, 61, 54, 137, 200, 105, 39, 229, 199, 199, 244, 25, 161, 93, 151, 122, 37, 82, 73, 88, 53, 0, 226, 233, 222, 193, 137, 194, 174, 141, 169, 35, 96, 215, 84, 25, 205, 9, 89, 110, 64 }, "", "chefe", new TimeSpan(0, 0, 0, 0, 0), "PrimeiroUsuario" });

            migrationBuilder.CreateIndex(
                name: "IX_Estagios_UsuarioId",
                table: "Estagios",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Faculdades_UsuarioId",
                table: "Faculdades",
                column: "UsuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
