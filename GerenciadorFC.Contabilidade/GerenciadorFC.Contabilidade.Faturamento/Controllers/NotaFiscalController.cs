using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GerenciadorFC.Contabilidade.Dominio.Faturamento.Implementacao;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorFC.Contabilidade.Servico.Controllers
{
    [Produces("application/json")]
    [Route("api/NotaFiscal")]
    public class NotaFiscalController : Controller
    {
		// GET: api/Contabilidade
		Repositorio.RepositorioNotaFiscal _repositorio = new Repositorio.RepositorioNotaFiscal();
		[HttpPost]
		public NotaFiscal Post([FromBody]NotaFiscal notaFiscal)
		{
			_repositorio.Adicionar(notaFiscal);
			return notaFiscal;
		}
		[HttpPut]
		public NotaFiscal Put([FromBody]NotaFiscal notaFiscal)
		{
			_repositorio.Atualizar(notaFiscal);
			return notaFiscal;
		}
		[HttpGet("{codigo}")]
		public NotaFiscal Get(int codigo)
		{
			return _repositorio.ObterPorCodigo(codigo);
		}
		[HttpGet]
		public List<NotaFiscal> Get()
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
