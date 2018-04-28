using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GerenciadorFC.Contabilidade.Dominio.DAS;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorFC.Contabilidade.Servico.Repositorio
{
    [Produces("application/json")]
    [Route("api/HistoricoDAS")]
    public class HistoricoDASController : Controller
    {
		// GET: api/Contabilidade
		Repositorio.RepositorioHistoricoDAS _repositorio = new Repositorio.RepositorioHistoricoDAS();
		[HttpPost]
		public HistoricoDAS Post([FromBody]HistoricoDAS historicoDAS)
		{
			_repositorio.Adicionar(historicoDAS);
			return historicoDAS;
		}
		[HttpPut]
		public HistoricoDAS Put([FromBody]HistoricoDAS historicoDAS)
		{
			_repositorio.Atualizar(historicoDAS);
			return historicoDAS;
		}
		[HttpGet("{codigo}")]
		public HistoricoDAS Get(int codigo)
		{
			return _repositorio.ObterPorCodigo(codigo);
		}
		[HttpGet]
		public List<HistoricoDAS> Get()
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
