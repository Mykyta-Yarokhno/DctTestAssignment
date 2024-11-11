using DctTestAssignment.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http;


namespace DctTestAssignment
{
    public class CoinCapApiService
    {
        private readonly HttpClient _httpClient;

        public CoinCapApiService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<List<CurrencyMarketInfo>?> GetCurrencyMarkets(string currencyId)
        {
            var response = await _httpClient.GetStringAsync($"https://api.coincap.io/v2/assets/{currencyId}/markets");
            var result = JsonConvert.DeserializeObject<CoinCapApiResponse>(response);
            return result?.Data;
        }
    }

    public class CoinCapApiResponse
    {
        public List<CurrencyMarketInfo> Data { get; set; }
    }
}

