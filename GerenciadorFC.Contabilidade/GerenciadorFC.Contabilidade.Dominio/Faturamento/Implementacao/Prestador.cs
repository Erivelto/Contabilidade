using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorFC.Contabilidade.Dominio.Faturamento.Implementacao
{
	public class Prestador
	{
		public string Documento { get; set; }
		public string RazaoSocial { get; set; }
		public string InscricaoMunicipal { get; set; }
		public string Fantasia { get; set; }
		public string Endereco { get; set; }
		public string Numero { get; set; }
		public string Bairro { get; set; }
		public string CEP { get; set; }
		public string Complemento { get; set; }
		public string Cidade { get; set; }
		public string UF { get; set; }
		public string Estado { get; set; }
		public string Email { get; set; }
		public string CodigoServico { get; set; }
		public string Discriminacao { get; set; }
		public string Valor { get; set; }
		public string Usuario { get; set; }
		public string Senha { get; set; }
		public string Captcha { get; set; }
		public string UlrLogin { get; set; }
		public string Tipo { get; set; }
		public string CodigoAntiCaptcha { get; set; }
	}
}
