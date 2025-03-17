using AgendaFinanceira.Domain.Interfaces;
using AgendaFinanceira.Domain.Model;
using AgendaFinanceira.Infraestrutura.Services;

namespace AgendaFinanceira.Infraestrutura.Repositories
{
    public class ReceitaRepository : IReceitaRepository
    {
        private readonly ConnectionContext _connectionContext;

        public ReceitaRepository(ConnectionContext connectionContext)
        {
            _connectionContext = connectionContext;
        }

        public void AddNewReceita(Receitas receita)
        {
            _connectionContext.Receitas.Add(receita);
            _connectionContext.SaveChanges();
        }

        public void DeleteReceita(int id)
        {
            var receita = _connectionContext.Receitas.Find(id);
            if (receita == null)
            {
                throw new Exception("A receita não existe");
            }
            _connectionContext.Receitas.Remove(receita);
            _connectionContext.SaveChanges();
        }

        public Receitas GetReceita(int id)
        {
            return _connectionContext.Receitas.Find(id);
        }

        public List<Receitas> GetAllReceitas()
        {
            return _connectionContext.Receitas.ToList();
        }

        public void UpdateReceita(Receitas receita)
        {
            throw new NotImplementedException();
        }
    }
}
