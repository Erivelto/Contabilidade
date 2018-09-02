using GerenciadorFC.Contabilidade.Dominio.Faturamento.Implementacao;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace GerenciadorFC.Contabilidade.Servico.Repositorio
{
    public class RepositorioCorpoEmissaoNota
    {
		Contexto ctx = new Contexto();
		public CorpoEmissaoNota Adicionar(CorpoEmissaoNota corpoEmissaoNota)
		{
			ctx.CorpoEmissaoNota.Add(corpoEmissaoNota);
			ctx.SaveChanges();
			return corpoEmissaoNota;
		}
		public CorpoEmissaoNota Atualizar(CorpoEmissaoNota corpoEmissaoNota)
		{
			ctx.Entry(corpoEmissaoNota).State = EntityState.Modified;
			ctx.SaveChanges();
			return corpoEmissaoNota;
		}
		public List<CorpoEmissaoNota> ObterLista()
		{
			return ctx.Set<CorpoEmissaoNota>().ToList();
		}
		public List<CorpoEmissaoNota> ObterLista(int CodigoPessoa)
		{
			return ctx.Set<CorpoEmissaoNota>().Where(x => x.CodigoPessoa == CodigoPessoa && x.Excluido == false).ToList();
		}
		public CorpoEmissaoNota ObterPorCodigo(int codigo)
		{
			return ctx.Set<CorpoEmissaoNota>().Where(x => x.Codigo == codigo).FirstOrDefault();
		}
		public void Excluir(int codigo)
		{
			var remove = ctx.CorpoEmissaoNota.Where(c => c.Codigo == codigo).FirstOrDefault();
			remove.Excluido = true;
			ctx.Entry(remove).State = EntityState.Modified;
			ctx.SaveChanges();
		}
	}
}
