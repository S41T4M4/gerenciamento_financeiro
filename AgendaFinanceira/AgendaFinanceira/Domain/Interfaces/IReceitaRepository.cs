using AgendaFinanceira.Domain.Model;

namespace AgendaFinanceira.Domain.Interfaces
{
    public interface IReceitaRepository
    {
        void AddNewReceita(Receitas receita);
        List<Receitas> GetAllReceitas();
        Receitas GetReceita(int id);
        void UpdateReceita (Receitas receita);
        void DeleteReceita(int id);

    }
}
