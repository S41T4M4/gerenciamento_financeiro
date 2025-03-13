using AgendaFinanceira.Domain.Interfaces;
using AgendaFinanceira.Domain.Model;
using AgendaFinanceira.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace AgendaFinanceira.Controllers
{
    [ApiController]
    [Route("api/contas")]
    public class ContasController : ControllerBase
    {
        private readonly IContasRepository _contasRepository;

        public ContasController(IContasRepository contasRepository)
        {
            _contasRepository = contasRepository;
        }

        [HttpPost("nova_conta")]
        public IActionResult AddNewConta(ContaViewModel contaView)
        {
            var conta = new Contas
            {
                id_conta = contaView.IdConta,
                nome_conta = contaView.NomeConta,
                saldo = contaView.Saldo,
            };
            _contasRepository.AddNewConta(conta);
            return Ok(conta);
        }
        [HttpGet("todas_contas")]
        public IActionResult GetAllContas()
        {
            var contas = _contasRepository.GetAllContas();
            return Ok(contas);
        }
        [HttpGet("get_conta_by_id/{id_conta}")]
        public IActionResult GetContaById(int id_conta)
        {
            var contaExisting = _contasRepository.GetContaById(id_conta);
            return Ok(contaExisting);
        }
        [HttpDelete("delete_conta")]
        public IActionResult DeleteConta(int id_conta)
        {
            _contasRepository.DeleteConta(id_conta);
            return Ok("Deletado com sucesso o id: " + id_conta);

        }
        [HttpPut("update_conta")]
        public IActionResult UpdateConta(int id_conta, ContaViewModel contaView)
        {
            var existingConta = _contasRepository.GetContaById(id_conta);
            if (existingConta == null)
            {
                throw new Exception("Não existe essa conta ");
            }
            
            existingConta.nome_conta = contaView.NomeConta;
            existingConta.saldo = contaView.Saldo;

            _contasRepository.UpdateConta(existingConta);
            return Ok("Conta nova criado com sucesso " + existingConta.nome_conta);



        }
        [HttpPut("update_saldo/{id_conta}")]
        public IActionResult UpdateStatusConta(int id_conta, ContaViewModel contasView)
        {
            var existingConta = _contasRepository.GetContaById(id_conta);
            if (existingConta != null)
            {
                existingConta.saldo = contasView.Saldo;
                _contasRepository.UpdateConta(existingConta);
                return Ok();
            }
            return BadRequest();

        }
    }
}
