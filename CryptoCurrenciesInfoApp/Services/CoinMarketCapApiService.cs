﻿using CryptoCurrenciesInfoApp.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http;


namespace CryptoCurrenciesInfoApp.Services
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
            var result = JsonConvert.DeserializeObject<ApiResponse<List<CryptoCurrency>>>(response);
            return result.Data;
        }

        public async Task<decimal> ConvertCurrencyAsync(decimal amount, string fromSymbol, string toSymbol)
        {
            var response = await _httpClient.GetStringAsync($"https://pro-api.coinmarketcap.com/v1/tools/price-conversion?amount={amount}&symbol={fromSymbol}&convert={toSymbol}");

            var json = JsonConvert.DeserializeObject<JObject>(response);
            var price = json["data"]?["quote"]?[toSymbol]?["price"]?.Value<decimal>();

            return price.Value;
        }
    }

    public class ApiResponse<T>
    {
        public T Data { get; set; }
    }
}
