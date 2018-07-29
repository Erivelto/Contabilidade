using GerenciadorFC.Contabilidade.Dominio.Faturamento.Implementacao;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace GerenciadorFC.Contabilidade.Servico.Repositorio
{
    public class RepositorioTomadorEmissaoNota
    {
		Contexto ctx = new Contexto();
		public TomadorEmissaoNota Adicionar(TomadorEmissaoNota tomadorEmissaoNota)
		{
			ctx.TomadorEmissaoNota.Add(tomadorEmissaoNota);
			ctx.SaveChanges();
			return tomadorEmissaoNota;
		}
		public bool Excluir(int codigo)
		{
			var remove = ctx.TomadorEmissaoNota.Where(c => c.Codigo == codigo).FirstOrDefault();
			remove.Excluido = true;
			ctx.Entry(remove).State = EntityState.Modified;
			ctx.SaveChanges();
			return true;
		}
		public TomadorEmissaoNota Atualizar(TomadorEmissaoNota tomadorEmissaoNota)
		{
			ctx.Entry(tomadorEmissaoNota).State = EntityState.Modified;
			ctx.SaveChanges();
			return tomadorEmissaoNota;
		}
		public List<TomadorEmissaoNota> ObterLista()
		{
			return ctx.Set<TomadorEmissaoNota>().Where(c => c.Excluido == false).ToList();
		}
		public List<TomadorEmissaoNota> ObterPorCodigo(int codigo)
		{
			return ctx.Set<TomadorEmissaoNota>().Where(x => x.CodigoEmissaoNota == codigo && x.Excluido == false).ToList();
		}
	}
}
