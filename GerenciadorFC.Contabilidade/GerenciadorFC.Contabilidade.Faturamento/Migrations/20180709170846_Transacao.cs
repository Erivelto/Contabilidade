using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace GerenciadorFC.Contabilidade.Servico.Migrations
{
    public partial class Transacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HistoricoTransacao",
                columns: table => new
                {
                    Codigo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CodigoHistorico = table.Column<int>(nullable: false),
                    Data = table.Column<DateTime>(nullable: false),
                    Erro = table.Column<string>(nullable: true),
                    Mensagem = table.Column<string>(nullable: true),
                    Sucesso = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoricoTransacao", x => x.Codigo);
                });

            migrationBuilder.CreateTable(
                name: "Transacao",
                columns: table => new
                {
                    CodigoTransacao = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transacao", x => x.CodigoTransacao);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HistoricoTransacao");

            migrationBuilder.DropTable(
                name: "Transacao");
        }
    }
}
