using AgendaFinanceira.Domain.Interfaces;
using AgendaFinanceira.Domain.Model;
using AgendaFinanceira.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace AgendaFinanceira.Controllers
{
    [ApiController]
    [Route("api/transacoes/")]
    public class TransacoesController : ControllerBase
    {
        private readonly ITransacoesRepository _transacoesRepository;

        public TransacoesController(ITransacoesRepository transacoesRepository)
        {
            this._transacoesRepository = transacoesRepository;
        }

        [HttpPost("new_transacao")]
        public IActionResult NewTransacao(TransacoesViewModel transacoesViewModel)
        {
            var transacoes = new Transacoes
            {
                id_transacao = transacoesViewModel.IdTransacao,
                valor = transacoesViewModel.Valor,
                tipo = transacoesViewModel.Tipo,
                data_transacao = transacoesViewModel.DataTransacao,
                id_conta = transacoesViewModel.IdConta,
                id_categoria = transacoesViewModel.IdCategoria,
            };
            _transacoesRepository.AddNewTransacoes(transacoes);
            return Ok(new { message = "A transação foi gerada com sucesso ! ", transacoes });
        }
        [HttpGet("get_all_transacoes")]
        public IActionResult GetAllTransacoes()
        {
            var transacoes = _transacoesRepository.GetAllTransacoes();
            return Ok(transacoes);
        }
        [HttpGet("get_transacoes_recorrentes")]

        public IActionResult GetTransacaoByRecorrencia()
        {

            var transacoes = _transacoesRepository.GetTransacaoRecorrente();
            return Ok(transacoes);
        }



        [HttpGet("get_transacao_by_id/{id_transacao}")]
        public IActionResult GetTransacaoById(int id_transacao)
        {
            var transacao = _transacoesRepository.GetTransacaoById(id_transacao);
            return Ok(transacao);
        }
        [HttpGet("get_transacao_by_conta/{id_conta}")]
        public IActionResult GetTransacoesByConta(int id_conta)
        {
            var transacoes = _transacoesRepository.GetTransacoesByConta(id_conta);
            return Ok(transacoes);
        }

        [HttpPut("update_transacao")]
        public IActionResult UpdateTransacaoes(int id_transacao, TransacoesViewModel transacoesViewModel)
        {
            var transacaoExisting = _transacoesRepository.GetTransacaoById(id_transacao);
            if (transacaoExisting == null)
            {
                throw new ArgumentException("Não foi encontrado a transação");
            }
            transacaoExisting.tipo = transacoesViewModel.Tipo;
            transacaoExisting.valor = transacoesViewModel.Valor;
            transacaoExisting.data_transacao = transacoesViewModel.DataTransacao;
            transacaoExisting.id_conta = transacoesViewModel.IdConta;
            transacaoExisting.id_categoria = transacoesViewModel.IdCategoria;

            _transacoesRepository.UpdateTransacoes(transacaoExisting);
            return Ok();

        }
        [HttpDelete("remove_transacao")]
        public IActionResult RemoveTransacao(int id_transacao)
        {
            var transacaoExists = _transacoesRepository.GetTransacaoById(id_transacao);
            if (transacaoExists == null)
            {
                throw new ArgumentException("A transação não existe");
            }
            _transacoesRepository.DeleteTransacao(id_transacao);
            return Ok();
        }



    }
}
