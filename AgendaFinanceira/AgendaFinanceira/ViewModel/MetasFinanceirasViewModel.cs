using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace AgendaFinanceira.ViewModel
{
    public class MetasFinanceirasViewModel
    {
        [JsonPropertyName("id_meta")]
        public int IdMeta { get; set; }
        public string Descricao { get; set; }
        [JsonPropertyName("valor_meta")]
        public decimal ValorMeta { get; set; }
        [JsonPropertyName("valor_atual")]
        public decimal ValorAtual { get; set; }
        public DateTime Prazo { get; set; }
    }
}
