using AgendaFinanceira.Domain.Interfaces;
using AgendaFinanceira.Domain.Model;
using AgendaFinanceira.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace AgendaFinanceira.Controllers
{
    [ApiController]
    [Route("api/despesas/")]
    public class DespesasController : ControllerBase
    {
        private readonly IDespesasRepository _despesasRepository;

        public DespesasController(IDespesasRepository despesasRepository)
        {
            _despesasRepository = despesasRepository;
        }
        [HttpPost("nova_despesa")]
        public IActionResult AddNewDespesa(DespesasViewModel despesasViewModel)
        {
            Despesas despesas = new Despesas
            {
                id_conta = despesasViewModel.IdConta,
                recorrente = despesasViewModel.Recorrente,
                valor = despesasViewModel.Valor,
                descricao = despesasViewModel.Descricao,
                data_despesa = despesasViewModel.DataDespesa,
                id_categoria = despesasViewModel.IdCategoria,


            };
            _despesasRepository.AddNewDespesas(despesas);
            return Ok(despesas);
        }
        [HttpGet("todas_despesas")]
        public IActionResult GetAllDespesas()
        {
            var despesas = _despesasRepository.GetAllDespesas().Take(5);
            return Ok(despesas);
        }

        [HttpGet("despesa_recorrente")]

        public IActionResult GetDespesasRecorrentes(bool recorrente)
        {
            var despesasRecorrentes = _despesasRepository.GetDespesasRecorrentes(recorrente);
            return Ok(despesasRecorrentes);
        }
        [HttpGet("despesa_by_categoria/{id_categoria}")]

        public IActionResult GetDespesasByCategoria(int id_categoria)
        {
            var despesaByCategoria = _despesasRepository.GetDespesasByCategoria(id_categoria);
            return Ok(despesaByCategoria);
        }

        [HttpGet("categoria_most_used")]

        public IActionResult GetCategoriaMostUsed()
        {
            var categoriaMaisUsada = _despesasRepository.GetCategoriasFrequentes();
            return Ok(categoriaMaisUsada);
        }

        [HttpGet("despesas_by_month")]
        public IActionResult GetDespesasByMonth()
        {
            var categoriaByMonth = _despesasRepository.GetDespesasByMes();
            return Ok(categoriaByMonth);
        }
    }
}
