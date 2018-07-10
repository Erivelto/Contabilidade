using GerenciadorFC.Contabilidade.Dominio.DAS;
using GerenciadorFC.Contabilidade.Servico.Model;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using GerenciadorFC.Contabilidade.Crawler.Receita;
using GerenciadorFC.Contabilidade.Dominio.Transacao;
using System;
using System.Threading.Tasks;

namespace GerenciadorFC.Contabilidade.Servico.Servicos
{
	public class GeraListaDAS
	{
		Repositorio.RepositorioDadosDeDAS repositorio = new Repositorio.RepositorioDadosDeDAS();
		Repositorio.RepositorioTransacao transacao = new Repositorio.RepositorioTransacao();
		Repositorio.RepositorioHistoricoDAS rephistoricoDAS = new Repositorio.RepositorioHistoricoDAS();
		ReceitaDAS receita = new ReceitaDAS();
		public void GeraPessoasDAS()
		{
			var dadosDeDAS = new List<DadosDeDAS>();
			dadosDeDAS = repositorio.ObterListaDas();
		
			if (dadosDeDAS != null)
			{
				foreach (var item in dadosDeDAS)
				{
					if (item.CodigoPessoa > 0)
					{
						var email =  GetEmail(item.CodigoPessoa);

						if (email != null)
						{
							try
							{
								receita.EmissorImpostos(item, email.ToString());
								var historricoDAS = new HistoricoDAS();
								historricoDAS.CodigoAnexo = item.Anexo[0].Codigo;
								historricoDAS.CodigoPessoa = item.CodigoPessoa;
								historricoDAS.DataGeracao = DateTime.Now;
								historricoDAS.DiaGeracao = DateTime.Now.Day;
								historricoDAS.Email = email.ToString();
								historricoDAS.Excluido = false;
								historricoDAS.Status = "Gerado";
								rephistoricoDAS.Adicionar(historricoDAS);
								var historicoTransaca = new HistoricoTransacao();
								historicoTransaca.Data = DateTime.Now;
								historicoTransaca.CodigoHistorico = 1;
								historicoTransaca.Sucesso = true;
								historicoTransaca.Mensagem = "Imposto gerado com sucesso";
								transacao.Adicionar(historicoTransaca);
							}
							catch (System.Exception ex)
							{
								var historicoTransaca = new HistoricoTransacao();
								historicoTransaca.Data = DateTime.Now;
								historicoTransaca.CodigoHistorico = 1;
								historicoTransaca.Sucesso = false;
								historicoTransaca.Mensagem = "";
								historicoTransaca.Erro = ex.Message.ToString();
								transacao.Adicionar(historicoTransaca);
							}
						}
					}
				}
			}
		}
		private async Task<string> GetEmail(int CodigoPessoa)
		{
			string email = "";
			using (var client = new HttpClient())
			{
				client.BaseAddress = new System.Uri("http://gerenciadorfccadastroservicos20180317071207.azurewebsites.net/");
				var resposta = await client.GetAsync("api/RepLegalPessoa/" + CodigoPessoa.ToString());
				string dados = await resposta.Content.ReadAsStringAsync();
				var _rep = JsonConvert.DeserializeObject<RepresentanteLegal>(dados);

				using (var clientRep = new HttpClient())
				{
					clientRep.BaseAddress = new System.Uri("http://gerenciadorfccadastroservicos20180317071207.azurewebsites.net/");
					var respostaRep = await clientRep.GetAsync("api/Contato/" + _rep.Codigo.ToString());
					string dadosRep = await respostaRep.Content.ReadAsStringAsync();
					var rep = JsonConvert.DeserializeObject<Contato>(dadosRep);

					email = rep.email;
				}

			}
			return email;
		}
	}
}
