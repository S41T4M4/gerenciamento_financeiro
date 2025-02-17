using Microsoft.AspNetCore.Mvc;
using AgendaFinanceira.Infraestrutura.Services;
using System;
using System.Threading.Tasks;

namespace AgendaFinanceira.Controllers
{
    [ApiController]
    [Route("api/nubank")]
    public class NubankController : ControllerBase
    {
        private readonly NubankService _nubankService;

        public NubankController(NubankService nubankService)
        {
            _nubankService = nubankService;
        }

        [HttpGet("get-transactions")]
        public async Task<IActionResult> GetTransactions()
        {
            try
            {
                var token = await _nubankService.AuthenticateAsync("15129054610", "Staff4912.");
                var transactions = await _nubankService.GetTransactionHistoryAsync(token);
                return Ok(transactions);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
