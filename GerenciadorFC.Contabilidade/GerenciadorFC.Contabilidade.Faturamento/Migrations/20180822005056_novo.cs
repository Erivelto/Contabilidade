using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace GerenciadorFC.Contabilidade.Servico.Migrations
{
    public partial class novo : Migration
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
                    CodigoPessoa = table.Column<int>(nullable: false),
                    CodigoServico = table.Column<string>(nullable: true),
                    CodigoTomador = table.Column<int>(nullable: false),
                    DataPrimeiraEmissao = table.Column<DateTime>(nullable: false),
                    Descricao = table.Column<string>(nullable: false),
                    Valor = table.Column<string>(maxLength: 20, nullable: false),
                    repetir = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CorpoEmissaoNota", x => x.Codigo);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CorpoEmissaoNota");
        }
    }
}
