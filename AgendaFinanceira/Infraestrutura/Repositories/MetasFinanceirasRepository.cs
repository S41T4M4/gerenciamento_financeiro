using AgendaFinanceira.Domain.Interfaces;
using AgendaFinanceira.Domain.Model;
using AgendaFinanceira.Infraestrutura.Services;

namespace AgendaFinanceira.Infraestrutura.Repositories
{
    public class MetasFinanceirasRepository : IMetasFinanceirasRepository
    {
        private readonly ConnectionContext _connectionContext;

        public MetasFinanceirasRepository(ConnectionContext connectionContext)
        {
            _connectionContext = connectionContext;
        }
        public void NewMetaFinanceira(MetasFinanceiras metasFinanceiras)
        {
            _connectionContext.MetasFinanceiras.Add(metasFinanceiras);
            _connectionContext.SaveChanges();
        }
        public MetasFinanceiras GetMetaFinanceiraById(int id_meta)
        {
            return _connectionContext.MetasFinanceiras.Find(id_meta);
        }
        public void DeleteMetasFinanceira(int id_meta)
        {
            var existMeta = _connectionContext.MetasFinanceiras.Find(id_meta);
            if (existMeta != null)
            {
                _connectionContext.MetasFinanceiras.Remove(existMeta);
                _connectionContext.SaveChanges();
            }
        }

        public List<MetasFinanceiras> GetMetasFinanceiras()
        {
            return _connectionContext.MetasFinanceiras.ToList();
        }

     

        public void UpdateMetaFinanceira(MetasFinanceiras metasFinanceiras)
        {
            _connectionContext.MetasFinanceiras.Update(metasFinanceiras);
            _connectionContext.SaveChanges();
        }
    }
}
