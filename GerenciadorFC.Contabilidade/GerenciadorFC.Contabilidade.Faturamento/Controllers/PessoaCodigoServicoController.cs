using GerenciadorFC.Contabilidade.Dominio.Faturamento.Implementacao;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace GerenciadorFC.Contabilidade.Servico.Controllers
{
	[Produces("application/json")]
    [Route("api/PessoaCodigoServico")]
    public class PessoaCodigoServicoController : Controller
    {
		// GET: api/Contabilidade
		Repositorio.RepositorioPessoaCodigoServico _repositorio = new Repositorio.RepositorioPessoaCodigoServico();
		[HttpPost]
		public PessoaCodigoServico Post([FromBody]PessoaCodigoServico pessoaCodigoServico)
		{
			_repositorio.Adicionar(pessoaCodigoServico);
			return pessoaCodigoServico;
		}
		[HttpPut]
		public PessoaCodigoServico Put([FromBody]PessoaCodigoServico pessoaCodigoServico)
		{
			_repositorio.Atualizar(pessoaCodigoServico);
			return pessoaCodigoServico;
		}
		[HttpGet("{codigo}")]
		public List<PessoaCodigoServico> Get(int codigo)
		{
			return _repositorio.ObterPorCodigo(codigo);
		}
		[HttpGet]
		public List<PessoaCodigoServico> Get()
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
