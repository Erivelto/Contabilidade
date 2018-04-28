using System.Collections.Generic;

namespace GerenciadorFC.Contabilidade.Dominio.DAS
{
	public class DadosDeDAS
	{
		public DadosDeDAS()
		{
			Url = "https://www8.receita.fazenda.gov.br/SimplesNacional/controleAcesso/Autentica.aspx?id=60";
			CodigoAntiCaptcha = "00104610857095f5ae8953b5ee208d11";
		}
		public int Codigo { get; set; }
		public int CodigoPessoa { get; set; }
		public string CNPJ { get; set; }
		public string CPF { get; set; }
		public string CodigoContribuite { get; set; }
		public string Url { get; set; }
		public string CodigoAntiCaptcha { get; set; }
		public string mesApuracao { get; set; }
		public string anoApuracao { get; set; }
		public string ValorTributado { get; set; }
		public List<AnexoContribuinte> Anexo { get; set; }
		public bool Excluido { get; set; }
	}
}
