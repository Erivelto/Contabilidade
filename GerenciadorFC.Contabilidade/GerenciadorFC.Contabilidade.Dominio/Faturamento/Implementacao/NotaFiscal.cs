using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorFC.Contabilidade.Dominio.Faturamento.Implementacao
{
	public class NotaFiscal
	{
		public int Codigo { get; set; }
		public int CodigoPessoa { get; set; }
		public DateTime DataEnvio { get; set; }
		public DateTime DataEmissao{ get; set; }
		public decimal ValorTotal { get; set; }
		public int NumeroNFE { get; set; }
		public string CodigoVerificacao { get; set; }
		public string UrlNfe { get; set; }		
		public bool Excluido { get; set; }
	}
}
