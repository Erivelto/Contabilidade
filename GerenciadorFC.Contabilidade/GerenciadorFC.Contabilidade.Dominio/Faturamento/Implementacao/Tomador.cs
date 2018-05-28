using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorFC.Contabilidade.Dominio.Faturamento.Implementacao
{
	public class Tomador
	{
		public string Documento { get; set; }
		public string RazaoSocial { get; set; }
		public string InscricaoMunicipal { get; set; }
		public string Fantasia { get; set; }
		public string Endereco { get; set; }
		public string Cidade { get; set; }
		public string UF { get; set; }
		public string Email { get; set; }
		public string TipoPessoa { get; set; }
		public string Numero { get; set; }
		public string Bairro { get; set; }
		public string CEP { get; set; }
		public string Complemento { get; set; }
	}
}
