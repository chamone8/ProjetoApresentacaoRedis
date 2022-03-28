using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Projeto.Redis.Infra.Data.Migrations
{
    public partial class IniciandoProjeto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(200)", nullable: true),
                    Email = table.Column<string>(type: "varchar(200)", nullable: true),
                    Telefone = table.Column<string>(type: "varchar(200)", nullable: true),
                    Telefone2 = table.Column<string>(type: "varchar(200)", nullable: true),
                    Rua = table.Column<string>(type: "varchar(200)", nullable: true),
                    Bairro = table.Column<string>(type: "varchar(200)", nullable: true),
                    Cep = table.Column<string>(type: "varchar(200)", nullable: true),
                    Cidade = table.Column<string>(type: "varchar(200)", nullable: true),
                    Estado = table.Column<string>(type: "varchar(200)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cliente");
        }
    }
}
