using AgendaFinanceira.Domain.Model;

namespace AgendaFinanceira.Domain.Interfaces
{
    public interface ICategoriasRepository
    {
        void AddNewCategoria(Categorias categoria);
        void UpdateCategoria(Categorias newCategoria);
        List<Categorias> GetAllCategorias();
        Categorias GetCategoriasById(int categoriaId);
        void DeleteCategorias(int categoriaId);
    }
}
