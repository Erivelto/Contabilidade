using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorFC.Contabilidade.Dominio.Transacao
{
	public class HistoricoTransacao
	{
		public int Codigo { get; set; }
		public int CodigoHistorico { get; set; }
		public DateTime Data { get; set; }
		public bool Sucesso { get; set; }
		public string Erro { get; set; }
		public string Mensagem { get; set; }
	}
}
