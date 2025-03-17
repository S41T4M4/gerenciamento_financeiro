using System.Text.Json.Serialization;

namespace AgendaFinanceira.ViewModel
{
    public class ReceitaViewModel
    {

        public int IdReceita { get; set; }
        public bool Recorrente { get; set; }
        public decimal Valor { get; set; }
        public string Descricao { get; set; }

        [JsonPropertyName("id_conta")]
        public int IdConta { get; set; }
    }
}
