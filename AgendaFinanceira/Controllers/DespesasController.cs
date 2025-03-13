using AgendaFinanceira.Domain.Interfaces;
using AgendaFinanceira.Domain.Model;
using AgendaFinanceira.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace AgendaFinanceira.Controllers
{
    [ApiController]
    [Route("/despesas/")]
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
               
                recorrente = despesasViewModel.Recorrente,
                valor = despesasViewModel.Valor,
                descricao = despesasViewModel.Descricao


            };
            _despesasRepository.AddNewDespesas(despesas);
            return Ok(despesas);
        }
        [HttpGet("todas_despesas")]
        public IActionResult GetAllDespesas()
        {
            var despesas = _despesasRepository.GetAllDespesas();
            return Ok(despesas);
        }
    }
}
