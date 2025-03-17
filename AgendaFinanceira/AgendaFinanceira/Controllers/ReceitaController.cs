using AgendaFinanceira.Domain.Interfaces;
using AgendaFinanceira.Domain.Model;
using AgendaFinanceira.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace AgendaFinanceira.Controllers
{
    [ApiController]
    [Route("api/receitas/")]
    public class ReceitaController : ControllerBase
    {
        private readonly IReceitaRepository _receitaRepository;

        public ReceitaController(IReceitaRepository receitaRepository)
        {
            _receitaRepository = receitaRepository;
        }

        [HttpPost("new_receita")]
        public IActionResult AddNewReceita(ReceitaViewModel receitaView)
        {
            Console.WriteLine($"Recebido: id_conta = {receitaView.IdConta}, descricao = {receitaView.Descricao}");
            var receita = new Receitas()
            {
                id_receita = receitaView.IdReceita,
                descricao = receitaView.Descricao,
                recorrente = receitaView.Recorrente,
                valor = receitaView.Valor,
                id_conta = receitaView.IdConta
            };
            _receitaRepository.AddNewReceita(receita);
            return Ok(receita);
        }
        [HttpGet("all_receitas")]
        public IActionResult GetAllReceitas()
        {
            var receitas = _receitaRepository.GetAllReceitas();
            return Ok(receitas);
        }
        [HttpDelete("delete_receita")]
        public IActionResult RemoveReceita(int id_receita)
        {
            var receita = _receitaRepository.GetReceita(id_receita);
            if (receita != null)
            {
                _receitaRepository.DeleteReceita(id_receita);
                return Ok($"Receita removida com sucesso {receita}");
            }
            throw new Exception("Não foi possivel encontrar a receita");
        }
    }
}
