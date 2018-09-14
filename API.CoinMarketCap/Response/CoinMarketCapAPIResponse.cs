using API.CoinMarketCap.Response.Info;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.CoinMarketCap.Response
{
    public class Status
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonProperty("error_code")]
        public int ErrorCode { get; set; }

        [JsonProperty("error_message")]
        public string ErrorMessage { get; set; }

        [JsonProperty("elapsed")]
        public int Elapsed { get; set; }

        [JsonProperty("credit_count")]
        public int CreditCount { get; set; }
    }

    public class CoinMarketCapAPIResponse
    {
        [JsonProperty("status")]
        public Status Status { get; set; }
    }

    public abstract class CoinMarketCapAPIResponse<Response> : CoinMarketCapAPIResponse
    {
        [JsonProperty("data")]
        public Response Data { get; set; }
    }
}
