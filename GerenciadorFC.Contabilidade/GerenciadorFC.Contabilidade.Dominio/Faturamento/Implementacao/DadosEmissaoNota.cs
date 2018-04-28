using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorFC.Contabilidade.Dominio.Faturamento.Implementacao
{
	public class DadosEmissaoNota
	{
		public int Codigo { get; set; }
		public int CodigoPessoa { get; set; }
		public string Senha { get; set; }
		public string Prefeitura { get; set; }
		public string UrlPrefeitura { get; set; }
		public List<PessoaCodigoServico> PessoaCodigoServico { get; set; }
		public bool Excluido { get; set; }
	}
}
