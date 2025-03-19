using Newtonsoft.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace AgendaFinanceira.ViewModel
{
    public class DespesasViewModel
    {
        public int IdDespesas { get; set; }
        public bool Recorrente { get; set; }
        public decimal Valor { get; set; }
        public string Descricao { get; set; }
        [JsonPropertyName("data_despesa")]
        public DateTime DataDespesa { get; set; }

        [JsonPropertyName("id_conta")]
        public int IdConta { get; set; }

        [JsonPropertyName("id_categoria")]
        public int IdCategoria { get; set; }
    }
}
