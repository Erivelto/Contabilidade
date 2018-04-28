using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace GerenciadorFC.Contabilidade.Servico.Migrations
{
    public partial class importacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CorpoEmissaoNota",
                columns: table => new
                {
                    Codigo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CodigoEmissaoNota = table.Column<int>(nullable: false),
                    Descricao = table.Column<string>(nullable: false),
                    Valor = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CorpoEmissaoNota", x => x.Codigo);
                });

            migrationBuilder.CreateTable(
                name: "DadosEmissaoNota",
                columns: table => new
                {
                    Codigo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CodigoPessoa = table.Column<int>(nullable: false),
                    Excluido = table.Column<bool>(nullable: false, defaultValue: false),
                    Prefeitura = table.Column<string>(maxLength: 200, nullable: false),
                    Senha = table.Column<string>(nullable: false),
                    UrlPrefeitura = table.Column<string>(maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DadosEmissaoNota", x => x.Codigo);
                });

            migrationBuilder.CreateTable(
                name: "NotaFiscal",
                columns: table => new
                {
                    Codigo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CodigoPessoa = table.Column<int>(nullable: false),
                    CodigoVerificacao = table.Column<string>(maxLength: 20, nullable: false),
                    DataEmissao = table.Column<DateTime>(nullable: false),
                    DataEnvio = table.Column<DateTime>(nullable: false),
                    Excluido = table.Column<bool>(nullable: false, defaultValue: false),
                    NumeroNFE = table.Column<int>(nullable: false),
                    UrlNfe = table.Column<string>(maxLength: 200, nullable: false),
                    ValorTotal = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotaFiscal", x => x.Codigo);
                });

            migrationBuilder.CreateTable(
                name: "TomadorEmissaoNota",
                columns: table => new
                {
                    Codigo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Bairro = table.Column<string>(maxLength: 50, nullable: true),
                    CEP = table.Column<string>(maxLength: 10, nullable: true),
                    Cidade = table.Column<string>(maxLength: 50, nullable: true),
                    CodigoEmissaoNota = table.Column<int>(nullable: false),
                    Complemento = table.Column<string>(maxLength: 100, nullable: true),
                    Documento = table.Column<string>(maxLength: 20, nullable: true),
                    Email = table.Column<string>(maxLength: 50, nullable: true),
                    Excluido = table.Column<bool>(nullable: false, defaultValue: false),
                    Fantasia = table.Column<string>(maxLength: 100, nullable: true),
                    IncrMunicipal = table.Column<string>(maxLength: 20, nullable: true),
                    Logradouro = table.Column<string>(maxLength: 150, nullable: true),
                    NumeroLogradouro = table.Column<string>(maxLength: 10, nullable: true),
                    Razao = table.Column<string>(maxLength: 100, nullable: true),
                    TipoPessoa = table.Column<string>(maxLength: 2, nullable: true),
                    UF = table.Column<string>(maxLength: 2, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TomadorEmissaoNota", x => x.Codigo);
                });

            migrationBuilder.CreateTable(
                name: "PessoaCodigoServico",
                columns: table => new
                {
                    Codigo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CodigoEmissaoNota = table.Column<int>(nullable: false),
                    CodigoServico = table.Column<string>(maxLength: 150, nullable: false),
                    DadosEmissaoNotaCodigo = table.Column<int>(nullable: true),
                    Excluido = table.Column<bool>(nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PessoaCodigoServico", x => x.Codigo);
                    table.ForeignKey(
                        name: "FK_PessoaCodigoServico_DadosEmissaoNota_DadosEmissaoNotaCodigo",
                        column: x => x.DadosEmissaoNotaCodigo,
                        principalTable: "DadosEmissaoNota",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PessoaCodigoServico_DadosEmissaoNotaCodigo",
                table: "PessoaCodigoServico",
                column: "DadosEmissaoNotaCodigo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CorpoEmissaoNota");

            migrationBuilder.DropTable(
                name: "NotaFiscal");

            migrationBuilder.DropTable(
                name: "PessoaCodigoServico");

            migrationBuilder.DropTable(
                name: "TomadorEmissaoNota");

            migrationBuilder.DropTable(
                name: "DadosEmissaoNota");
        }
    }
}
