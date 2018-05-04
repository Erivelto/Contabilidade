using GerenciadorFC.Contabilidade.Dominio.Faturamento.Implementacao;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace GerenciadorFC.Contabilidade.Servico.Repositorio
{
    public class RepositorioPessoaCodigoServico
    {
		Contexto ctx = new Contexto();
		public PessoaCodigoServico Adicionar(PessoaCodigoServico pessoaCodigoServico)
		{
			ctx.PessoaCodigoServico.Add(pessoaCodigoServico);
			ctx.SaveChanges();
			return pessoaCodigoServico;
		}
		public bool Excluir(int codigo)
		{
			var remove = ctx.PessoaCodigoServico.Where(c => c.Codigo == codigo).FirstOrDefault();
			remove.Excluido = true;
			ctx.Entry(remove).State = EntityState.Modified;
			ctx.SaveChanges();
			return true;
		}
		public PessoaCodigoServico Atualizar(PessoaCodigoServico pessoaCodigoServico)
		{
			ctx.Entry(pessoaCodigoServico).State = EntityState.Modified;
			ctx.SaveChanges();
			return pessoaCodigoServico;
		}
		public List<PessoaCodigoServico> ObterLista()
		{
			return ctx.Set<PessoaCodigoServico>().Where(c => c.Excluido == false).ToList();
		}
		public List<PessoaCodigoServico> ObterPorCodigo(int codigo)
		{
			return ctx.Set<PessoaCodigoServico>().Where(x => x.CodigoEmissaoNota == codigo && x.Excluido == false).ToList();
		}
	}
}
