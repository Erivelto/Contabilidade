﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorFC.Contabilidade.Dominio.Faturamento.Implementacao
{
	public class TomadorEmissaoNota
	{
		public int Codigo { get; set; }
		public int CodigoEmissaoNota { get; set; }
		public string Email { get; set; }
		public string Documento { get; set; } 
		public string Razao { get; set; }
		public string Fantasia { get; set; }
		public string Logradouro { get; set; }
		public string NumeroLogradouro { get; set; }
		public string Complemento { get; set; }
		public string Bairro { get; set; }
		public string Cidade { get; set; }
		public string UF { get; set; }
		public string CEP { get; set; }
		public string IncrMunicipal { get; set; }
		public string TipoPessoa { get; set; }
		public bool Excluido { get; set; }
	}
}
