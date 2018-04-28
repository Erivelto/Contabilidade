using Microsoft.EntityFrameworkCore;
using GerenciadorFC.Contabilidade.Dominio.Faturamento.Implementacao;

namespace GerenciadorFC.Contabilidade.Servico.Repositorio
{
	public class Contexto : DbContext
	{
		public DbSet<DadosEmissaoNota> DadosEmissaoNota { get; set; }
		public DbSet<CorpoEmissaoNota> CorpoEmissaoNota { get; set; }
		public DbSet<NotaFiscal> NotaFiscal { get; set; }
		public DbSet<TomadorEmissaoNota> TomadorEmissaoNota { get; set; }
		public DbSet<PessoaCodigoServico> PessoaCodigoServico { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(@"Server=tcp:gerenciadorbilhetagem.database.windows.net,1433;Initial Catalog=dbContabilidade; Uid=fabioesimoes; Pwd=q1w2e3r4@;");
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			//DadosEmissaoNota 
			modelBuilder.Entity<DadosEmissaoNota>().HasKey(p => p.Codigo);
			modelBuilder.Entity<DadosEmissaoNota>().Property(p => p.CodigoPessoa).IsRequired();
			modelBuilder.Entity<DadosEmissaoNota>().Property(p => p.Senha).IsRequired();
			modelBuilder.Entity<DadosEmissaoNota>().Property(p => p.Prefeitura).HasMaxLength(200).IsRequired();
			modelBuilder.Entity<DadosEmissaoNota>().Property(p => p.UrlPrefeitura).HasMaxLength(500).IsRequired();			
			modelBuilder.Entity<DadosEmissaoNota>().Property(p => p.Excluido).HasDefaultValue(false);

			//TomadorEmissaoNota
			modelBuilder.Entity<TomadorEmissaoNota>().HasKey(t => t.Codigo);
			modelBuilder.Entity<TomadorEmissaoNota>().Property(p => p.CodigoEmissaoNota).IsRequired();
			modelBuilder.Entity<TomadorEmissaoNota>().Property(p => p.Email).HasMaxLength(50);
			modelBuilder.Entity<TomadorEmissaoNota>().Property(p => p.Documento).HasMaxLength(20);
			modelBuilder.Entity<TomadorEmissaoNota>().Property(p => p.Razao).HasMaxLength(100);
			modelBuilder.Entity<TomadorEmissaoNota>().Property(p => p.Fantasia).HasMaxLength(100);
			modelBuilder.Entity<TomadorEmissaoNota>().Property(p => p.Logradouro).HasMaxLength(150);
			modelBuilder.Entity<TomadorEmissaoNota>().Property(p => p.NumeroLogradouro).HasMaxLength(10);
			modelBuilder.Entity<TomadorEmissaoNota>().Property(p => p.Complemento).HasMaxLength(100);
			modelBuilder.Entity<TomadorEmissaoNota>().Property(p => p.Bairro).HasMaxLength(50);
			modelBuilder.Entity<TomadorEmissaoNota>().Property(p => p.Cidade).HasMaxLength(50);
			modelBuilder.Entity<TomadorEmissaoNota>().Property(p => p.UF).HasMaxLength(2);
			modelBuilder.Entity<TomadorEmissaoNota>().Property(p => p.CEP).HasMaxLength(10);
			modelBuilder.Entity<TomadorEmissaoNota>().Property(p => p.IncrMunicipal).HasMaxLength(20);
			modelBuilder.Entity<TomadorEmissaoNota>().Property(p => p.TipoPessoa).HasMaxLength(2);
			modelBuilder.Entity<TomadorEmissaoNota>().Property(p => p.Excluido).HasDefaultValue(false);

			//PessoaCodigoServico
			modelBuilder.Entity<PessoaCodigoServico>().HasKey(t => t.Codigo);
			modelBuilder.Entity<PessoaCodigoServico>().Property(p => p.CodigoEmissaoNota).IsRequired();
			modelBuilder.Entity<PessoaCodigoServico>().Property(p => p.CodigoServico).IsRequired().HasMaxLength(150); 
			modelBuilder.Entity<PessoaCodigoServico>().Property(p => p.Excluido).HasDefaultValue(false);

			//CorpoEmissaoNota
			modelBuilder.Entity<CorpoEmissaoNota>().HasKey(t => t.Codigo);
			modelBuilder.Entity<CorpoEmissaoNota>().Property(p => p.CodigoEmissaoNota).IsRequired();
			modelBuilder.Entity<CorpoEmissaoNota>().Property(p => p.Descricao).IsRequired();
			modelBuilder.Entity<CorpoEmissaoNota>().Property(p => p.Valor).IsRequired().HasMaxLength(20);

			//NotaFiscal
			modelBuilder.Entity<NotaFiscal>().HasKey(t => t.Codigo);
			modelBuilder.Entity<NotaFiscal>().Property(p => p.CodigoPessoa).IsRequired();
			modelBuilder.Entity<NotaFiscal>().Property(p => p.CodigoVerificacao).IsRequired().HasMaxLength(20); 
			modelBuilder.Entity<NotaFiscal>().Property(p => p.UrlNfe).IsRequired().HasMaxLength(200); 
			modelBuilder.Entity<NotaFiscal>().Property(p => p.Excluido).HasDefaultValue(false);

	
		}
	}
}
