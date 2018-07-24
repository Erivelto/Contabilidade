using GerenciadorFC.Contabilidade.Dominio.DAS;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciadorFC.Contabilidade.Servico.Repositorio
{
    public class RepositorioAnexoContribuinte
    {
		Contexto ctx = new Contexto();
		public AnexoContribuinte Adicionar(AnexoContribuinte anexoContribuinte)
		{
			ctx.AnexoContribuinte.Add(anexoContribuinte);
			ctx.SaveChanges();
			return anexoContribuinte;
		}
		public bool Excluir(int codigo)
		{
			var remove = ctx.AnexoContribuinte.Where(c => c.Codigo == codigo).FirstOrDefault();
			remove.Excluido = true;
			ctx.Entry(remove).State = EntityState.Modified;
			ctx.SaveChanges();
			return true;
		}
		public AnexoContribuinte Atualizar(AnexoContribuinte anexoContribuinte)
		{
			ctx.Entry(anexoContribuinte).State = EntityState.Modified;
			ctx.SaveChanges();
			return anexoContribuinte;
		}
		public List<AnexoContribuinte> ObterLista()
		{
			return ctx.Set<AnexoContribuinte>().Where(c => c.Excluido == false).ToList();
		}
		public List<AnexoContribuinte> ObterListaAnexo(int codigo)
		{
			return ctx.Set<AnexoContribuinte>().Where(c => c.Excluido == false && c.CodigoDadosDeDAS == codigo).ToList();
		}
		public AnexoContribuinte ObterPorCodigo(int codigo)
		{
			return ctx.Set<AnexoContribuinte>().Where(x => x.Codigo == codigo && x.Excluido == false).FirstOrDefault();
		}
	}
}
