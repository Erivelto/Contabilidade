using GerenciadorFC.Contabilidade.Dominio.DAS;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace GerenciadorFC.Contabilidade.Servico.Repositorio
{
	public class RepositorioHistoricoDAS
    {
		Contexto ctx = new Contexto();
		public HistoricoDAS Adicionar(HistoricoDAS historicoDAS)
		{
			ctx.HistoricoDAS.Add(historicoDAS);
			ctx.SaveChanges();
			return historicoDAS;
		}
		public bool Excluir(int codigo)
		{
			var remove = ctx.HistoricoDAS.Where(c => c.Codigo == codigo).FirstOrDefault();
			remove.Excluido = true;
			ctx.Entry(remove).State = EntityState.Modified;
			ctx.SaveChanges();
			return true;
		}
		public HistoricoDAS Atualizar(HistoricoDAS historicoDAS)
		{
			ctx.Entry(historicoDAS).State = EntityState.Modified;
			ctx.SaveChanges();
			return historicoDAS;
		}
		public List<HistoricoDAS> ObterLista()
		{
			return ctx.Set<HistoricoDAS>().Where(c => c.Excluido == false).ToList();
		}
		public HistoricoDAS ObterPorCodigo(int codigo)
		{
			return ctx.Set<HistoricoDAS>().Where(x => x.Codigo == codigo && x.Excluido == false).FirstOrDefault();
		}
	}
}
