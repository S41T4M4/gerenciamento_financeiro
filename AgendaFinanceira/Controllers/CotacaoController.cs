
using AgendaFinanceira.Services;
using Microsoft.AspNetCore.Mvc;

namespace AgendaFinanceira.Controllers
{
    [ApiController]
    [Route("api/cotacao")]
    public class CotacaoController : ControllerBase
    {
        private readonly CotacaoService _cotacaoService;

        public CotacaoController(CotacaoService cotacaoService)
        {
            _cotacaoService = cotacaoService;
        }

        [HttpGet("cotacao_dolar")]
        public async Task<IActionResult> ObterCotacaoDolar()
        {
            try
            {
                var cotacao = await _cotacaoService.CotacaoDoDolar();
                return Ok(new { valor = cotacao });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { erro = ex.Message });
            }
        }
        [HttpGet("cotacao_euro")]
        public async Task<IActionResult> ObterCotacaoEuro()
        {

            try
            {
                var cotacaoEuro = await _cotacaoService.CotacaoEuro();
                return Ok(new { valor = cotacaoEuro });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { erro = ex.Message });
            }
        }
    }
}
