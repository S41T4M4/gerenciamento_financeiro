using AgendaFinanceira.Domain.Interfaces;
using AgendaFinanceira.Domain.Model;
using AgendaFinanceira.Infraestrutura.Services;
using System.Runtime.CompilerServices;

namespace AgendaFinanceira.Infraestrutura.Repositories
{
    public class ContasRepository : IContasRepository
    {
        private readonly ConnectionContext _connectionContext;

        public ContasRepository(ConnectionContext connectionContext)
        {
            _connectionContext = connectionContext;
        }

        public void AddNewConta(Contas contas)
        {
            _connectionContext.Contas.Add(contas);
            _connectionContext.SaveChanges();
        }
        public void UpdateConta(Contas contas)
        {

            _connectionContext.Contas.Update(contas);
            _connectionContext.SaveChanges();
        }

        public void UpdateSaldoConta(Contas conta)
        {
            var contaExisting = _connectionContext.Contas.Find(conta.id_conta);
            if (contaExisting != null)
            {
                contaExisting.saldo = conta.saldo;
                _connectionContext.Contas.Update(contaExisting);
                _connectionContext.SaveChanges();
            }

        }



        public List<Contas> GetAllContas()
        {
            return _connectionContext.Contas.ToList();
        }

        public Contas GetContaById(int id)
        {
            return _connectionContext.Contas.Find(id);

        }


        public void DeleteConta(int id)
        {
            var contaExisting = _connectionContext.Contas.Find(id);
            if (contaExisting != null)
            {
                _connectionContext.Contas.Remove(contaExisting);
                _connectionContext.SaveChanges();
            }
        }

    }
}
