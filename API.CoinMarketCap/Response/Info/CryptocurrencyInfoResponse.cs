using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace API.CoinMarketCap.Response.Info
{
    public class CryptocurrencyInfo
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("category")]
        public string Category { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("logo")]
        public string Logo { get; set; }

        [JsonProperty("tags")]
        public List<string> Tags { get; set; }

        [JsonProperty("urls")]
        public UrlsSegment Urls { get; set; }
    }

    public class CryptocurrencyInfoResponse : CoinMarketCapAPIResponse<List<CryptocurrencyInfo>>
    {
        public override List<CryptocurrencyInfo> Data
        {
            get
            {
                if (this.data != null)
                    return this.data;

                return this.data = this.WeakData.Children().Select(y => y.First.ToObject<CryptocurrencyInfo>()).ToList();
            }
        }
    }
}
