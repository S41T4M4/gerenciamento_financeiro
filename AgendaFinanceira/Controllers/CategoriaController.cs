using AgendaFinanceira.Domain.Interfaces;
using AgendaFinanceira.Domain.Model;
using AgendaFinanceira.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Net.WebSockets;

namespace AgendaFinanceira.Controllers
{
    [ApiController]
    [Route("api/categoria/")]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriasRepository _categoriasRepository;

        public CategoriaController(ICategoriasRepository categoriasRepository)
        {
            _categoriasRepository = categoriasRepository;
        }

        [HttpPost("new_categoria")]
        public IActionResult NewCategoria(CategoriaViewModel categoriaView)
        {
            var categoria = new Categorias
            {
                id_categoria = categoriaView.IdCategoria,
                nome_categoria = categoriaView.NomeCategoria,
            };

            if (string.IsNullOrEmpty(categoria.nome_categoria))
            {
                throw new ArgumentException("O nome não pode ser vazio");
            }

            _categoriasRepository.AddNewCategoria(categoria);


            return Ok(new
            {
                message = "Operação realizada com sucesso",
                nome_categoria = categoria.nome_categoria
            });
        }
        [HttpGet("get_all_categorias")]
        public IActionResult GetAllCategorias()
        {
            var categorias = _categoriasRepository.GetAllCategorias();
            return Ok(categorias);
        }
        [HttpGet("get_categorias_by_id")]
        public IActionResult GetCategoriaById(int id_categoria)
        {
            var categoria = _categoriasRepository.GetCategoriasById(id_categoria);
            if (categoria == null)
            {
                return NotFound(new { message = "Categoria não encontrada" });
            }
            return Ok(categoria);
        }
        [HttpDelete("delete_categoria")]
        public IActionResult DeleteCategoria(int id_categoria)
        {
            var categoria = _categoriasRepository.GetCategoriasById(id_categoria);
            if (categoria == null)
            {
                return NotFound(new { message = "Categoria não encontrada" });
            }
            _categoriasRepository.DeleteCategorias(id_categoria);
            return Ok(new { message = "Categoria apagada com sucesso !" });
        }
        [HttpPost("update_categoria")]
        public IActionResult UpdateCategoria(int id_categoria, CategoriaViewModel categoriaView)
        {
            var categoriaExisting = _categoriasRepository.GetCategoriasById(id_categoria);
            if (categoriaExisting == null)
            {
                return NotFound(new { message = "Categoria não encontrada" });
            }
            categoriaExisting.nome_categoria = categoriaView.NomeCategoria;

            _categoriasRepository.UpdateCategoria(categoriaExisting);

            return Ok(new
            {
                message = "A categoria foi atualizada com sucesso !",
                nome_categoria = categoriaExisting.nome_categoria
            });

        }


    }
}
