using AgendaFinanceira.Domain.Interfaces;
using AgendaFinanceira.Domain.Model;
using AgendaFinanceira.Infraestrutura.Services;

namespace AgendaFinanceira.Infraestrutura.Repositories
{
    public class CategoriaRepository:ICategoriasRepository
    {
        private readonly ConnectionContext _connectionContext;

        public CategoriaRepository(ConnectionContext connectionContext)
        {
            _connectionContext = connectionContext;
        }

        public void AddNewCategoria(Categorias categoria)
        {
            _connectionContext.Categorias.Add(categoria);
            _connectionContext.SaveChanges();

        }

        public void DeleteCategorias(int categoriaId)
        {
            var categoria = _connectionContext.Categorias.Find(categoriaId);
            if (categoria == null)
            {
                throw new Exception("Não existe essa categoria");
            }
            _connectionContext.Categorias.Remove(categoria);
            _connectionContext.SaveChanges();
        }

        public List<Categorias> GetAllCategorias()
        {
            return _connectionContext.Categorias.ToList();
        }

        public Categorias GetCategoriasById(int categoriaId)
        {
            return _connectionContext.Categorias.Find(categoriaId);
        }

        public void UpdateCategoria(Categorias newCategoria)
        {
            _connectionContext.Categorias.Update(newCategoria);
            _connectionContext.SaveChanges();
        }
    }
}
