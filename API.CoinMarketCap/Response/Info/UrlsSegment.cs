using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Api.CoinMarketCap.Response.Info
{
    public class UrlsSegment
    {
        [JsonProperty("website")]
        public List<string> Website { get; set; }

        [JsonProperty("explorer")]
        public List<string> Explorer { get; set; }

        [JsonProperty("source_code")]
        public List<string> SourceCode { get; set; }

        [JsonProperty("message_board")]
        public List<string> MessageBoard { get; set; }

        [JsonProperty("chat")]
        public List<string> Chat { get; set; }

        [JsonProperty("announcement")]
        public List<string> Announcement { get; set; }

        [JsonProperty("reddit")]
        public List<string> Reddit { get; set; }

        [JsonProperty("twitter")]
        public List<string> Twitter { get; set; }
    }
}
