﻿// <auto-generated />
using GerenciadorFC.Contabilidade.Servico.Repositorio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace GerenciadorFC.Contabilidade.Servico.Migrations
{
    [DbContext(typeof(Contexto))]
    [Migration("20180428182425_receitadas")]
    partial class receitadas
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GerenciadorFC.Contabilidade.Dominio.DAS.AnexoContribuinte", b =>
                {
                    b.Property<int>("Codigo")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Anexo");

                    b.Property<int>("CodigoDadosDeDAS");

                    b.Property<int?>("DadosDeDASCodigo");

                    b.Property<bool>("Excluido")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(false);

                    b.HasKey("Codigo");

                    b.HasIndex("DadosDeDASCodigo");

                    b.ToTable("AnexoContribuinte");
                });

            modelBuilder.Entity("GerenciadorFC.Contabilidade.Dominio.DAS.DadosDeDAS", b =>
                {
                    b.Property<int>("Codigo")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CNPJ");

                    b.Property<string>("CPF");

                    b.Property<string>("CodigoAntiCaptcha")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("CodigoContribuite")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("CodigoPessoa");

                    b.Property<bool>("Excluido")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(false);

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("ValorTributado")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("anoApuracao")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.Property<string>("mesApuracao")
                        .IsRequired()
                        .HasMaxLength(2);

                    b.HasKey("Codigo");

                    b.ToTable("DadosDeDAS");
                });

            modelBuilder.Entity("GerenciadorFC.Contabilidade.Dominio.DAS.HistoricoDAS", b =>
                {
                    b.Property<int>("Codigo")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CodigoAnexo");

                    b.Property<int>("CodigoPessoa");

                    b.Property<DateTime>("DataGeracao");

                    b.Property<int>("DiaGeracao");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<bool>("Excluido")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(false);

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Codigo");

                    b.ToTable("HistoricoDAS");
                });

            modelBuilder.Entity("GerenciadorFC.Contabilidade.Dominio.Faturamento.Implementacao.CorpoEmissaoNota", b =>
                {
                    b.Property<int>("Codigo")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CodigoEmissaoNota");

                    b.Property<string>("Descricao")
                        .IsRequired();

                    b.Property<string>("Valor")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("Codigo");

                    b.ToTable("CorpoEmissaoNota");
                });

            modelBuilder.Entity("GerenciadorFC.Contabilidade.Dominio.Faturamento.Implementacao.DadosEmissaoNota", b =>
                {
                    b.Property<int>("Codigo")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CodigoPessoa");

                    b.Property<bool>("Excluido")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(false);

                    b.Property<string>("Prefeitura")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("Senha")
                        .IsRequired();

                    b.Property<string>("UrlPrefeitura")
                        .IsRequired()
                        .HasMaxLength(500);

                    b.HasKey("Codigo");

                    b.ToTable("DadosEmissaoNota");
                });

            modelBuilder.Entity("GerenciadorFC.Contabilidade.Dominio.Faturamento.Implementacao.NotaFiscal", b =>
                {
                    b.Property<int>("Codigo")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CodigoPessoa");

                    b.Property<string>("CodigoVerificacao")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<DateTime>("DataEmissao");

                    b.Property<DateTime>("DataEnvio");

                    b.Property<bool>("Excluido")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(false);

                    b.Property<int>("NumeroNFE");

                    b.Property<string>("UrlNfe")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<decimal>("ValorTotal");

                    b.HasKey("Codigo");

                    b.ToTable("NotaFiscal");
                });

            modelBuilder.Entity("GerenciadorFC.Contabilidade.Dominio.Faturamento.Implementacao.PessoaCodigoServico", b =>
                {
                    b.Property<int>("Codigo")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CodigoEmissaoNota");

                    b.Property<string>("CodigoServico")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.Property<int?>("DadosEmissaoNotaCodigo");

                    b.Property<bool>("Excluido")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(false);

                    b.HasKey("Codigo");

                    b.HasIndex("DadosEmissaoNotaCodigo");

                    b.ToTable("PessoaCodigoServico");
                });

            modelBuilder.Entity("GerenciadorFC.Contabilidade.Dominio.Faturamento.Implementacao.TomadorEmissaoNota", b =>
                {
                    b.Property<int>("Codigo")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Bairro")
                        .HasMaxLength(50);

                    b.Property<string>("CEP")
                        .HasMaxLength(10);

                    b.Property<string>("Cidade")
                        .HasMaxLength(50);

                    b.Property<int>("CodigoEmissaoNota");

                    b.Property<string>("Complemento")
                        .HasMaxLength(100);

                    b.Property<string>("Documento")
                        .HasMaxLength(20);

                    b.Property<string>("Email")
                        .HasMaxLength(50);

                    b.Property<bool>("Excluido")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(false);

                    b.Property<string>("Fantasia")
                        .HasMaxLength(100);

                    b.Property<string>("IncrMunicipal")
                        .HasMaxLength(20);

                    b.Property<string>("Logradouro")
                        .HasMaxLength(150);

                    b.Property<string>("NumeroLogradouro")
                        .HasMaxLength(10);

                    b.Property<string>("Razao")
                        .HasMaxLength(100);

                    b.Property<string>("TipoPessoa")
                        .HasMaxLength(2);

                    b.Property<string>("UF")
                        .HasMaxLength(2);

                    b.HasKey("Codigo");

                    b.ToTable("TomadorEmissaoNota");
                });

            modelBuilder.Entity("GerenciadorFC.Contabilidade.Dominio.DAS.AnexoContribuinte", b =>
                {
                    b.HasOne("GerenciadorFC.Contabilidade.Dominio.DAS.DadosDeDAS")
                        .WithMany("Anexo")
                        .HasForeignKey("DadosDeDASCodigo");
                });

            modelBuilder.Entity("GerenciadorFC.Contabilidade.Dominio.Faturamento.Implementacao.PessoaCodigoServico", b =>
                {
                    b.HasOne("GerenciadorFC.Contabilidade.Dominio.Faturamento.Implementacao.DadosEmissaoNota")
                        .WithMany("PessoaCodigoServico")
                        .HasForeignKey("DadosEmissaoNotaCodigo");
                });
#pragma warning restore 612, 618
        }
    }
}
