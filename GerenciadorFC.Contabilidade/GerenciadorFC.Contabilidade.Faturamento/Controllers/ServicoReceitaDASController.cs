using Hangfire;
using Microsoft.AspNetCore.Mvc;
using System;

namespace GerenciadorFC.Contabilidade.Servico.Controllers
{
    [Produces("application/json")]
    [Route("api/ServicoReceitaDAS")]
    public class ServicoReceitaDASController : Controller
    {
		[HttpGet]
		public string Get()
		{
			var servico = new Servicos.GeraListaDAS();
			servico.GeraPessoasDAS();
			//var jobDelayed = BackgroundJob.Schedule(() =>  servico.GeraPessoasDAS(), TimeSpan.FromMinutes(1));

			return "Jobs criados com sucesso!";
		}
	}
}