using AgendaFinanceira.Domain.Interfaces;
using AgendaFinanceira.Domain.Model;
using AgendaFinanceira.Infraestrutura.Services;
using Microsoft.AspNetCore.Http.HttpResults;

namespace AgendaFinanceira.Infraestrutura.Repositories
{
    public class DespesasRepository : IDespesasRepository
    {
        private readonly ConnectionContext _connectionContext;

        public DespesasRepository(ConnectionContext connectionContext)
        {
            _connectionContext = connectionContext;
        }

        public void AddNewDespesas(Despesas despesas)
        {
            _connectionContext.Despesas.Add(despesas);
            _connectionContext.SaveChanges();
        }
        public List<Despesas> GetAllDespesas()
        {
            return _connectionContext.Despesas.ToList();
           
        }

        public void DeleteDespesas(int id_despesas)
        {
            var despesas = _connectionContext.Despesas.Find(id_despesas);
            if (despesas != null)
            {
                _connectionContext.Despesas.Remove(despesas);
                _connectionContext.SaveChanges();
            }
            
        }
        public Despesas GetDespesasById(int id_despesas)
        {
            return _connectionContext.Despesas.Find(id_despesas);
        }

        public List<Despesas> GetDespesasRecorrentes(bool recorrente)
        {
           return _connectionContext.Despesas.Where(d => d.recorrente == recorrente).ToList();
        }

        public void UpdateDespesas(int id_despesas, Despesas despesas)
        {
            _connectionContext.Despesas.Update(despesas);
            _connectionContext.SaveChanges();
        }
    }
}
