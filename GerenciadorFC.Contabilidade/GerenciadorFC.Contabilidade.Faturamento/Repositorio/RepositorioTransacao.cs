using GerenciadorFC.Contabilidade.Dominio.Transacao;

namespace GerenciadorFC.Contabilidade.Servico.Repositorio
{
    public class RepositorioTransacao
    {
		Contexto ctx = new Contexto();
		public void Adicionar(HistoricoTransacao historicoTransacao)
		{
			ctx.HistoricoTransacao.Add(historicoTransacao);
			ctx.SaveChanges();
		}
	}
}
