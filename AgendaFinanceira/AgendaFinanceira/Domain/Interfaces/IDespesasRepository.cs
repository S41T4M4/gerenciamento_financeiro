using AgendaFinanceira.Domain.Model;

namespace AgendaFinanceira.Domain.Interfaces
{
    public interface IDespesasRepository
    {
        void AddNewDespesas(Despesas despesas);
        List<Despesas> GetAllDespesas();
        Despesas GetDespesasById(int id_despesas);
        void DeleteDespesas(int id_despesas);
        void UpdateDespesas(int id_despesas, Despesas despesas);
        List<Despesas> GetDespesasRecorrentes(bool recorrente);
    }
}
