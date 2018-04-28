using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace GerenciadorFC.Contabilidade.Servico.Migrations
{
    public partial class receitadas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DadosDeDAS",
                columns: table => new
                {
                    Codigo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CNPJ = table.Column<string>(nullable: true),
                    CPF = table.Column<string>(nullable: true),
                    CodigoAntiCaptcha = table.Column<string>(maxLength: 50, nullable: false),
                    CodigoContribuite = table.Column<string>(maxLength: 50, nullable: false),
                    CodigoPessoa = table.Column<int>(nullable: false),
                    Excluido = table.Column<bool>(nullable: false, defaultValue: false),
                    Url = table.Column<string>(maxLength: 100, nullable: false),
                    ValorTributado = table.Column<string>(maxLength: 30, nullable: false),
                    anoApuracao = table.Column<string>(maxLength: 10, nullable: false),
                    mesApuracao = table.Column<string>(maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DadosDeDAS", x => x.Codigo);
                });

            migrationBuilder.CreateTable(
                name: "HistoricoDAS",
                columns: table => new
                {
                    Codigo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CodigoAnexo = table.Column<int>(nullable: false),
                    CodigoPessoa = table.Column<int>(nullable: false),
                    DataGeracao = table.Column<DateTime>(nullable: false),
                    DiaGeracao = table.Column<int>(nullable: false),
                    Email = table.Column<string>(maxLength: 50, nullable: false),
                    Excluido = table.Column<bool>(nullable: false, defaultValue: false),
                    Status = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoricoDAS", x => x.Codigo);
                });

            migrationBuilder.CreateTable(
                name: "AnexoContribuinte",
                columns: table => new
                {
                    Codigo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Anexo = table.Column<string>(nullable: true),
                    CodigoDadosDeDAS = table.Column<int>(nullable: false),
                    DadosDeDASCodigo = table.Column<int>(nullable: true),
                    Excluido = table.Column<bool>(nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnexoContribuinte", x => x.Codigo);
                    table.ForeignKey(
                        name: "FK_AnexoContribuinte_DadosDeDAS_DadosDeDASCodigo",
                        column: x => x.DadosDeDASCodigo,
                        principalTable: "DadosDeDAS",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnexoContribuinte_DadosDeDASCodigo",
                table: "AnexoContribuinte",
                column: "DadosDeDASCodigo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnexoContribuinte");

            migrationBuilder.DropTable(
                name: "HistoricoDAS");

            migrationBuilder.DropTable(
                name: "DadosDeDAS");
        }
    }
}
