using System;

namespace GerenciadorFC.Contabilidade.Dominio.DAS
{
	public class HistoricoDAS
	{
		public int Codigo { get; set; }
		public int CodigoPessoa { get; set; }
		public int CodigoAnexo { get; set; }
		public int DiaGeracao { get; set; }
		public DateTime DataGeracao { get; set; }
		public string Status { get; set; }
		public string Email { get; set; }
		public bool Excluido { get; set; }
	}
}
