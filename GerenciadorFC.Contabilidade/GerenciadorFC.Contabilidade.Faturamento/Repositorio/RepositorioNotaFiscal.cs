using GerenciadorFC.Contabilidade.Dominio.Faturamento.Implementacao;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace GerenciadorFC.Contabilidade.Servico.Repositorio
{
    public class RepositorioNotaFiscal
    {
		Contexto ctx = new Contexto();
		public NotaFiscal Adicionar(NotaFiscal notaFiscal)
		{
			ctx.NotaFiscal.Add(notaFiscal);
			ctx.SaveChanges();
			return notaFiscal;
		}
		public bool Excluir(int codigo)
		{
			var remove = ctx.NotaFiscal.Where(c => c.Codigo == codigo).FirstOrDefault();
			remove.Excluido = true;
			ctx.Entry(remove).State = EntityState.Modified;
			ctx.SaveChanges();
			return true;
		}
		public NotaFiscal Atualizar(NotaFiscal notaFiscal)
		{
			ctx.Entry(notaFiscal).State = EntityState.Modified;
			ctx.SaveChanges();
			return notaFiscal;
		}
		public List<NotaFiscal> ObterLista()
		{
			return ctx.Set<NotaFiscal>().Where(c => c.Excluido == false).ToList();
		}
		public NotaFiscal ObterPorCodigo(int codigo)
		{
			return ctx.Set<NotaFiscal>().Where(x => x.Codigo == codigo && x.Excluido == false).FirstOrDefault();
		}
	}
}
