using GerenciadorFC.Contabilidade.Dominio.Faturamento.Implementacao;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace GerenciadorFC.Contabilidade.Servico.Controllers
{
	[Produces("application/json")]
    [Route("api/CorpoEmissaoNota")]
    public class CorpoEmissaoNotaController : Controller
    {
		// GET: api/Contabilidade
		Repositorio.RepositorioCorpoEmissaoNota _repositorio = new Repositorio.RepositorioCorpoEmissaoNota();
		[HttpPost]
		public CorpoEmissaoNota Post([FromBody]CorpoEmissaoNota corpoEmissaoNota)
		{
			_repositorio.Adicionar(corpoEmissaoNota);
			return corpoEmissaoNota;
		}
		[HttpPut]
		public CorpoEmissaoNota Put([FromBody]CorpoEmissaoNota corpoEmissaoNota)
		{
			_repositorio.Atualizar(corpoEmissaoNota);
			return corpoEmissaoNota;
		}
		[HttpGet("{codigo}")]
		public CorpoEmissaoNota Get(int codigo)
		{
			return _repositorio.ObterPorCodigo(codigo);
		}
		[HttpDelete("{codigo}")]
		public ActionResult Delete(int codigo)
		{
			_repositorio.Excluir(codigo);
			return Ok();
		}
		[HttpGet("Agendamento/{codigoPessoa}")]
		public List<CorpoEmissaoNota> GetList(int codigoPessoa)
		{
			return _repositorio.ObterLista(codigoPessoa);
		}
		[HttpGet]
		public List<CorpoEmissaoNota> Get()
		{
			return _repositorio.ObterLista();
		}

	}
}
