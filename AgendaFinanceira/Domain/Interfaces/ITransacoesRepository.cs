using AgendaFinanceira.Domain.Model;

namespace AgendaFinanceira.Domain.Interfaces
{
    public interface ITransacoesRepository
    {
        void AddNewTransacoes(Transacoes transacoes);
        void UpdateTransacoes(Transacoes transacoes);
        List<Transacoes> GetAllTransacoes();
        Transacoes GetTransacaoById(int id);
        void DeleteTransacao(int id);
        List<Transacoes> GetTransacoesByConta(int id_conta);
        List<Transacoes> GetTransacaoRecorrente();
    }
}
