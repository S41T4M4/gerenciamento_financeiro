using AgendaFinanceira.Domain.Interfaces;
using AgendaFinanceira.Domain.Model;
using AgendaFinanceira.Infraestrutura.Services;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace AgendaFinanceira.Infraestrutura.Repositories
{
    public class TransacoesRepository : ITransacoesRepository
    { 
        private readonly ConnectionContext _connectionContext;

        public TransacoesRepository(ConnectionContext connectionContext)
        {
            _connectionContext = connectionContext;
        }

        public void AddNewTransacoes(Transacoes transacoes)
        {
            _connectionContext.Transacoes.Add(transacoes);
            _connectionContext.SaveChanges();
        }

        public void DeleteTransacao(int id_transacao)
        {
            var transacaoExisting = _connectionContext.Transacoes.Find(id_transacao);
            if (transacaoExisting != null)
            {
                _connectionContext.Transacoes.Remove(transacaoExisting);
                _connectionContext.SaveChanges();
            }
        }

        public List<Transacoes> GetAllTransacoes()
        {
            return _connectionContext.Transacoes.ToList();  
        }

        public Transacoes GetTransacaoById(int id)
        {
            return _connectionContext.Transacoes.Include(t => t.Categorias).Include(t => t.Contas).SingleOrDefault(t => t.id_transacao == id);
        }

        public List<Transacoes> GetTransacaoRecorrente()
        {
            string nome_categoria = "recorrente";
            return _connectionContext.Transacoes.Include(t => t.Categorias).Include(t => t.Contas).Where(t => t.Categorias.nome_categoria.StartsWith("recorrente") == nome_categoria.StartsWith("recorrente")).ToList();
        }

        public List<Transacoes> GetTransacoesByConta(int id_conta)
        {
            return _connectionContext.Transacoes.Include(t => t.Contas).Where(t => t.id_conta == id_conta).ToList();
        }

        public void UpdateTransacoes(Transacoes transacoes)
        {
            _connectionContext.Transacoes.Update(transacoes);
            _connectionContext.SaveChanges();
        }
        
    }
}
