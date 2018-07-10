using GerenciadorFC.Contabilidade.Dominio.DAS;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciadorFC.Contabilidade.Servico.Repositorio
{
    public class RepositorioDadosDeDAS
    {
		Contexto ctx = new Contexto();
		public DadosDeDAS Adicionar(DadosDeDAS dadosDeDAS)
		{
			ctx.DadosDeDAS.Add(dadosDeDAS);
			ctx.SaveChanges();
			return dadosDeDAS;
		}
		public bool Excluir(int codigo)
		{
			var remove = ctx.DadosDeDAS.Where(c => c.Codigo == codigo).FirstOrDefault();
			remove.Excluido = true;
			ctx.Entry(remove).State = EntityState.Modified;
			ctx.SaveChanges();
			return true;
		}
		public DadosDeDAS Atualizar(DadosDeDAS dadosDeDAS)
		{
			ctx.Entry(dadosDeDAS).State = EntityState.Modified;
			ctx.SaveChanges();
			return dadosDeDAS;
		}
		public List<DadosDeDAS> ObterLista()
		{
			return ctx.Set<DadosDeDAS>().Where(c => c.Excluido == false).ToList();
		}
		public List<DadosDeDAS> ObterListaDas()
		{
			var historico = ctx.Set<HistoricoDAS>().Where(c => c.Excluido == false).Select(c => c.CodigoPessoa).ToList();

			return ctx.Set<DadosDeDAS>().Where(c => c.Excluido == false && !c.CodigoPessoa.Equals(historico)).ToList();
		}
		public DadosDeDAS ObterPorCodigo(int codigo)
		{
			return ctx.Set<DadosDeDAS>().Where(x => x.CodigoPessoa == codigo && x.Excluido == false).FirstOrDefault();
		}
		 
	}
}
