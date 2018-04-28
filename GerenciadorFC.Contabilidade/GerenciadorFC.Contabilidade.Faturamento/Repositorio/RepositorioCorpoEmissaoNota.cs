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
		public CorpoEmissaoNota ObterPorCodigo(int codigo)
		{
			return ctx.Set<CorpoEmissaoNota>().Where(x => x.Codigo == codigo).FirstOrDefault();
		}
	}
}
