using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace AgendaFinanceira.Services
{
    public class CotacaoService
    {
        private readonly HttpClient _httpClient;

        public CotacaoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public string url = "https://economia.awesomeapi.com.br/last/";


        public async Task<Decimal> CotacaoDoDolar()
        {
            try
            {

                HttpResponseMessage response = await _httpClient.GetAsync(url + "USD-BRL");

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("Não foi encontrado nenhum registro");
                }
                string json = await response.Content.ReadAsStringAsync();
                using var doc = JsonDocument.Parse(json);
                var root = doc.RootElement.GetProperty("USDBRL");
                decimal valorDolar = decimal.Parse(root.GetProperty("bid").GetString(), System.Globalization.CultureInfo.InvariantCulture);

                return valorDolar;

            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao obter cotação do dólar.", ex);
            }


        }
        public async Task<Decimal> CotacaoEuro()
        {
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(url + "EUR-BRL");
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("Não foi encotrado nenhum registro");
                }
                string json = await response.Content.ReadAsStringAsync();
                using var doc = JsonDocument.Parse(json);
                var root = doc.RootElement.GetProperty("EURBRL");
                decimal valorEuro = decimal.Parse(root.GetProperty("bid").ToString(), System.Globalization.CultureInfo.InvariantCulture);

                return valorEuro;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao obter cotação do euro.", ex);
            }
        }

    }
}
