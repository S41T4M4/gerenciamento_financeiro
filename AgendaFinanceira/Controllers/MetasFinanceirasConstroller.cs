using AgendaFinanceira.Domain.Interfaces;
using AgendaFinanceira.Domain.Model;
using AgendaFinanceira.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace AgendaFinanceira.Controllers
{
    [ApiController]
    [Route("api/metas_financeiras/")]
    public class MetasFinanceirasConstroller : ControllerBase
    {
        private readonly IMetasFinanceirasRepository _metasFinanceirasRepository;

        private readonly IContasRepository _contasRepository;

       
        public MetasFinanceirasConstroller(IMetasFinanceirasRepository metasFinanceirasRepository)
        {
            _metasFinanceirasRepository = metasFinanceirasRepository;
        }

        [HttpPost("new_meta_financeira")]
        public IActionResult NewMetaFinanceira(MetasFinanceirasViewModel metasViewModel)
        {

            var metaFinanceira = new MetasFinanceiras
            {
                id_meta = metasViewModel.IdMeta,
                descricao = metasViewModel.Descricao,
                valor_meta = metasViewModel.ValorMeta,
                valor_atual = metasViewModel.ValorAtual,
                prazo = metasViewModel.Prazo.ToUniversalTime()
,
            };
           
            if (metaFinanceira.valor_meta <= 0)
            {
                throw new Exception("O valor tem que ser maior do que 0");
            }
            _metasFinanceirasRepository.NewMetaFinanceira(metaFinanceira);
            return Ok(metaFinanceira);
        }
        [HttpGet("get_all_metas")]
        public IActionResult GetAllMetasFinanceiras()
        {
            var metasFinanceiras = _metasFinanceirasRepository.GetMetasFinanceiras();
            return Ok(metasFinanceiras);
        }
        [HttpGet("get_metas_by_id/{id_meta}")]
        public IActionResult GetMetaFinanceiraById(int id_meta)
        {
            var metaFinanceira = _metasFinanceirasRepository.GetMetaFinanceiraById(id_meta);
            return Ok(metaFinanceira);
        }
        [HttpPut("update_meta_financeira")]
        public IActionResult UpdateMetaFinanceira(int id_meta, MetasFinanceirasViewModel metasFinanceirasViewModel)
        {
            var metaExists = _metasFinanceirasRepository.GetMetaFinanceiraById(id_meta);
            if (metaExists == null)
            {
                throw new ArgumentException("A meta financeira ainda não existe");
            }
            metaExists.descricao = metasFinanceirasViewModel.Descricao;
            metaExists.valor_meta = metasFinanceirasViewModel.ValorMeta;
            metaExists.valor_atual = metasFinanceirasViewModel.ValorAtual;
            metaExists.prazo = metasFinanceirasViewModel.Prazo;

            _metasFinanceirasRepository.UpdateMetaFinanceira(metaExists);
            return Ok(metaExists);
        }
        [HttpDelete("remove_meta_financeira/{id_meta}")]
        public IActionResult RemoveMetaFinanceira(int id_meta)
        {
            var metaExists = _metasFinanceirasRepository.GetMetaFinanceiraById(id_meta);
            
            if (metaExists == null)
            {
                throw new Exception("Não existe a meta");
            }
            
            _metasFinanceirasRepository.DeleteMetasFinanceira(id_meta);
            return Ok();
        }
    }
}
