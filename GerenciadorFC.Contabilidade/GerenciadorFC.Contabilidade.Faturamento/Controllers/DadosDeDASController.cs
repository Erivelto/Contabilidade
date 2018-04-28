using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GerenciadorFC.Contabilidade.Dominio.DAS;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorFC.Contabilidade.Servico.Controllers
{
    [Produces("application/json")]
    [Route("api/DadosDeDAS")]
    public class DadosDeDASController : Controller
    {
		// GET: api/Contabilidade
		Repositorio.RepositorioDadosDeDAS _repositorio = new Repositorio.RepositorioDadosDeDAS();
		[HttpPost]
		public DadosDeDAS Post([FromBody] DadosDeDAS dadosDeDAS)
		{
			_repositorio.Adicionar(dadosDeDAS);
			return dadosDeDAS;
		}
		[HttpPut]
		public DadosDeDAS Put([FromBody] DadosDeDAS dadosDeDAS)
		{
			_repositorio.Atualizar(dadosDeDAS);
			return dadosDeDAS;
		}
		[HttpGet("{codigo}")]
		public DadosDeDAS Get(int codigo)
		{
			return _repositorio.ObterPorCodigo(codigo);
		}
		[HttpGet]
		public List<DadosDeDAS> Get()
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
