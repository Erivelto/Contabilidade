using GerenciadorFC.Contabilidade.Dominio.Faturamento.Implementacao;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace GerenciadorFC.Contabilidade.Servico.Controllers
{
	[Produces("application/json")]
    [Route("api/TomadorEmissaoNota")]
    public class TomadorEmissaoNotaController : Controller
    {
		// GET: api/Contabilidade
		Repositorio.RepositorioTomadorEmissaoNota _repositorio = new Repositorio.RepositorioTomadorEmissaoNota();
		[HttpPost]
		public TomadorEmissaoNota Post([FromBody]TomadorEmissaoNota tomadorEmissaoNota)
		{
			_repositorio.Adicionar(tomadorEmissaoNota);
			return tomadorEmissaoNota;
		}
		[HttpPut]
		public TomadorEmissaoNota Put([FromBody]TomadorEmissaoNota tomadorEmissaoNota)
		{
			_repositorio.Atualizar(tomadorEmissaoNota);
			return tomadorEmissaoNota;
		}
		[HttpGet("{codigo}")]
		public TomadorEmissaoNota Get(int codigo)
		{
			return _repositorio.ObterPorCodigo(codigo);
		}
		[HttpGet]
		public List<TomadorEmissaoNota> Get()
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
