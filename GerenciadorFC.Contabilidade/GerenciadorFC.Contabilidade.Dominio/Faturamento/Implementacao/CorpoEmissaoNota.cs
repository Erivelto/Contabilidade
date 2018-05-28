﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorFC.Contabilidade.Dominio.Faturamento.Implementacao
{
	public class CorpoEmissaoNota
	{
		public int Codigo { get; set; }
		public int CodigoEmissaoNota { get; set; }
		public string Descricao { get; set; }
		public string Valor { get; set; } 
		public int DiaEmissao { get; set; }
	}
}
