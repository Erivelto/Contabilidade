using GerenciadorFC.Contabilidade.Dominio.Faturamento.Implementacao;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace GerenciadorFC.Contabilidade.Servico.Controllers
{
	[Produces("application/json")]
    [Route("api/DadosEmissaoNota")]
    public class DadosEmissaoNotaController : Controller
    {
		// GET: api/Contabilidade
		Repositorio.RepositorioDadosEmissaoNota _repositorio = new Repositorio.RepositorioDadosEmissaoNota();
		[HttpPost]
		public DadosEmissaoNota Post([FromBody]DadosEmissaoNota dadosEmissaoNota)
		{
			_repositorio.Adicionar(dadosEmissaoNota);
			return dadosEmissaoNota;
		}
		[HttpPut]
		public DadosEmissaoNota Put([FromBody]DadosEmissaoNota dadosEmissaoNota)
		{
			_repositorio.Atualizar(dadosEmissaoNota);
			return dadosEmissaoNota;
		}
		[HttpGet("{codigo}")]
		public DadosEmissaoNota Get(int codigo)
		{
			return _repositorio.ObterPorCodigo(codigo);
		}
		[HttpGet]
		public List<DadosEmissaoNota> Get()
		{
			return _repositorio.ObterLista();
		}
		[HttpDelete]
		public bool Delete(int codigo)
		{
			return _repositorio.Excluir(codigo);
		}
	}
}
