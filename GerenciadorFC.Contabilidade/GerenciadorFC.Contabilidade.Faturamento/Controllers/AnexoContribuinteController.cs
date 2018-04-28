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
    [Route("api/AnexoContribuinte")]
    public class AnexoContribuinteController : Controller
    {
		// GET: api/Contabilidade
		Repositorio.RepositorioAnexoContribuinte _repositorio = new Repositorio.RepositorioAnexoContribuinte();
		[HttpPost]
		public AnexoContribuinte Post([FromBody]AnexoContribuinte anexoContribuinte)
		{
			_repositorio.Adicionar(anexoContribuinte);
			return anexoContribuinte;
		}
		[HttpPut]
		public AnexoContribuinte Put([FromBody]AnexoContribuinte anexoContribuinte)
		{
			_repositorio.Atualizar(anexoContribuinte);
			return anexoContribuinte;
		}
		[HttpGet("{codigo}")]
		public AnexoContribuinte Get(int codigo)
		{
			return _repositorio.ObterPorCodigo(codigo);
		}
		[HttpGet]
		public List<AnexoContribuinte> Get()
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
