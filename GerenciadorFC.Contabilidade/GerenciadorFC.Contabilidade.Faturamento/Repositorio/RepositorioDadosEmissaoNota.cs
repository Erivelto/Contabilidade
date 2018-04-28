using GerenciadorFC.Contabilidade.Dominio.Faturamento.Implementacao;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace GerenciadorFC.Contabilidade.Servico.Repositorio
{
	public class RepositorioDadosEmissaoNota
    {
		Contexto ctx = new Contexto();
		public DadosEmissaoNota Adicionar(DadosEmissaoNota dadosEmissaoNota)
		{
			ctx.DadosEmissaoNota.Add(dadosEmissaoNota);
			ctx.SaveChanges();
			return dadosEmissaoNota;
		}
		public bool Excluir(int codigo)
		{
			var remove = ctx.DadosEmissaoNota.Where(c => c.Codigo == codigo).FirstOrDefault();
			remove.Excluido = true;
			ctx.Entry(remove).State = EntityState.Modified;
			ctx.SaveChanges();
			return true;
		}
		public DadosEmissaoNota Atualizar(DadosEmissaoNota dadosEmissaoNota)
		{
			ctx.Entry(dadosEmissaoNota).State = EntityState.Modified;
			ctx.SaveChanges();
			return dadosEmissaoNota;
		}
		public List<DadosEmissaoNota> ObterLista()
		{
			return ctx.Set<DadosEmissaoNota>().Where(c => c.Excluido == false).ToList();
		}
		public DadosEmissaoNota ObterPorCodigo(int codigo)
		{
			return ctx.Set<DadosEmissaoNota>().Where(x => x.Codigo == codigo && x.Excluido == false).FirstOrDefault();
		}
	}
}
