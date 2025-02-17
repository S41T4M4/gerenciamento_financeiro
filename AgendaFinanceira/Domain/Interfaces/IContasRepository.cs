using AgendaFinanceira.Domain.Model;

namespace AgendaFinanceira.Domain.Interfaces
{
    public interface IContasRepository
    {
        void AddNewConta(Contas contas);
        void UpdateConta(Contas contas);
        List<Contas> GetAllContas();
        Contas GetContaById(int id);
        void DeleteConta(int id);
    }
}
