using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciadorFC.Contabilidade.Servico.Model
{
	public class Contato
	{
		public int Codigo { get; set; }
		public int CodigoPessoa { get; set; }
		public int CodigoRepLegal { get; set; }
		public string email { get; set; }
		public string Site { get; set; }
		public string DDD { get; set; }
		public string Telefone { get; set; }
		public string DDDC { get; set; }
		public string Celular { get; set; }
		public bool Excluido { get; set; }
	}
}
