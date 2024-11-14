using DctTestAssignment.Models;
using Newtonsoft.Json;
using System.Net.Http;


namespace DctTestAssignment.Services
{
    //a31fd0a1-c143-414f-8ece-0d89c066f48f
    public class CoinMarketCapApiService
    {
        private readonly HttpClient _httpClient;

        public CoinMarketCapApiService()
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Add("X-CMC_PRO_API_KEY", "a31fd0a1-c143-414f-8ece-0d89c066f48f");
        }

        public async Task<List<CryptoCurrency>> GetTopCurrenciesAsync()
        {
            var response = await _httpClient.GetStringAsync("https://pro-api.coinmarketcap.com/v1/cryptocurrency/listings/latest?limit=10");
            var result = JsonConvert.DeserializeObject<ApiResponse>(response);
            return result.Data;
        }
    }

    public class ApiResponse
    {
        public List<CryptoCurrency> Data { get; set; }
    }
}
