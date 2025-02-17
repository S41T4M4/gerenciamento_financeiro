using AgendaFinanceira.Domain.Model;

namespace AgendaFinanceira.Domain.Interfaces
{
    public interface IMetasFinanceirasRepository
    {
        void NewMetaFinanceira(MetasFinanceiras metasFinanceiras);
        void UpdateMetaFinanceira(MetasFinanceiras metasFinanceiras);
        List<MetasFinanceiras> GetMetasFinanceiras();
        MetasFinanceiras GetMetaFinanceiraById(int id_meta);
        void DeleteMetasFinanceira(int id_meta);
    }
}
