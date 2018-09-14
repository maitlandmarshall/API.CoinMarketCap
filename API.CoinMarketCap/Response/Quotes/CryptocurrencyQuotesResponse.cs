using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.CoinMarketCap.Response.Quotes
{
    public class CryptocurrencyQuote
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("circulating_supply")]
        public long CirculatingSupply { get; set; }

        [JsonProperty("total_supply")]
        public long TotalSupply { get; set; }

        [JsonProperty("max_supply")]
        public long? MaxSupply { get; set; }

        [JsonProperty("date_added")]
        public DateTime DateAdded { get; set; }

        [JsonProperty("num_market_pairs")]
        public uint NumMarketPairs { get; set; }

        [JsonProperty("cmc_rank")]
        public uint CmcRank { get; set; }

        [JsonProperty("last_updated")]
        public DateTime LastUpdated { get; set; }

        [JsonProperty("quote")]
        public Dictionary<string, CryptocurrencyQuotePrice> Quote { get; set; }
    }

    public class CryptocurrencyQuotePrice
    {
        [JsonProperty("price")]
        public decimal Price { get; set; }

        [JsonProperty("volume_24h")]
        public decimal Volume24h { get; set; }

        [JsonProperty("percent_change_1h")]
        public decimal PercentChange1h { get; set; }

        [JsonProperty("percent_change_24h")]
        public decimal PercentChange24h { get; set; }

        [JsonProperty("percent_change_7d")]
        public decimal PercentChange7d { get; set; }

        [JsonProperty("market_cap")]
        public decimal MarketCap { get; set; }

        [JsonProperty("last_updated")]
        public DateTime LastUpdated { get; set; }
    }

    public class CryptocurrencyQuotesResponse : CoinMarketCapAPIResponse<Dictionary<string, CryptocurrencyQuote>>
    {
    }
}
