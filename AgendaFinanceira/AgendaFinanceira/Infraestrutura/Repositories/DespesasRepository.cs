using AgendaFinanceira.Domain.Dtos;
using AgendaFinanceira.Domain.Interfaces;
using AgendaFinanceira.Domain.Model;
using AgendaFinanceira.Infraestrutura.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

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
            return _connectionContext.Despesas.Include(e => e.Categoria).ToList();

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

        public List<Despesas> GetDespesasByCategoria(int id_categoria)
        {
            return _connectionContext.Despesas.Include(e => e.Categoria).Where(e => e.id_categoria == id_categoria).ToList();
        }

        public List<CategoriaFrequenteDTO> GetCategoriasFrequentes()
        {
            return _connectionContext.Despesas.GroupBy(d => d.Categoria).Select(g => new CategoriaFrequenteDTO {
                CategoriaNome = g.Key.nome_categoria,
                Quantidade = g.Count()
            })
            .OrderByDescending(c => c.Quantidade)
            .ToList();


        }

        public List<object> GetDespesasByMes()
        {
            var despesasPorMes = _connectionContext.Despesas
              .GroupBy(d => new { d.data_despesa.Year, d.data_despesa.Month })
              .Select(g => new
              {
                  Mes = new DateTime(g.Key.Year, g.Key.Month, 1).ToString("MMMM yyyy", new CultureInfo("pt-br")),
                  TotalGasto = g.Sum(d => d.valor)
              })
              .OrderBy(d => d.Mes)
              .ToList<object>();

            return despesasPorMes;

        }
    }
}
