using GerenciadorFC.Contabilidade.Dominio.Faturamento.Implementacao;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GerenciadorFC.Contabilidade.Servico.Repositorio
{
	public class RepositorioPrestador
    {
		Contexto ctx = new Contexto();
		public List<EmissaoNotafiscal> ObterLista()
		{
			var emissaoNotafiscal = new List<EmissaoNotafiscal>();

			var listaEmissao = ctx.DadosEmissaoNota
				.Join(ctx.CorpoEmissaoNota, d => d.Codigo, c => c.CodigoEmissaoNota, (d, c) => new { c, d })
				.Select(x => new
				{
					x.c.CodigoEmissaoNota,
					x.c.Descricao,
					x.c.DiaEmissao,
					x.c.Valor,
					x.d.CodigoPessoa,
					x.d.PessoaCodigoServico,
					x.d.Prefeitura,
					x.d.Senha,
					x.d.UrlPrefeitura,
					x.d.Excluido
				}).ToList();




			return emissaoNotafiscal;
		}

	}
}
