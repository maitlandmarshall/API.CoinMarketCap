using API.CoinMarketCap.Response;
using API.CoinMarketCap.Response.Info;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace API.CoinMarketCap
{
    public enum FiatCurrency
    {
        USD,
        AUD,
        BRL,
        CAD,
        CHF,
        CLP,
        CNY,
        CZK,
        DKK,
        EUR,
        GBP,
        HKD,
        HUF,
        IDR,
        ILS,
        INR,
        JPY,
        KRW,
        MXN,
        MYR,
        NOK,
        NZD,
        PHP,
        PKR,
        PLN,
        RUB,
        SEK,
        SGD,
        THB,
        TRY,
        TWD,
        ZAR
    }

    public partial class CoinMarketCapAPIClient
    {
        const string APIEndpoint = "https://pro-api.coinmarketcap.com";
        const string APIVersion = "v1";
        const string APIKeyRequestHeader = "X-CMC_PRO_API_KEY";

        public string APIKey { get; private set; }

        public CoinMarketCapAPIClient(string apiKey)
        {
            if (String.IsNullOrEmpty(apiKey))
                throw new ArgumentException("You must provide a valid API Key.");

            this.APIKey = apiKey;
        }

        private HttpWebRequest CreateWebRequest(string apiEndpoint, params string[] urlParams)
        {
            // Ensure the apiEndpoint starts with v1/, or whatever the current version is
            if (!apiEndpoint.StartsWith($"{APIVersion}/"))
                apiEndpoint = $"{APIVersion}/{apiEndpoint}";

            // Joins the UrlParams into the apiEndpoint string
            if (urlParams.Length > 0)
                apiEndpoint = apiEndpoint + $"?{String.Join("&", urlParams.Where(y => y != null))}";
                
            Uri baseUri = new Uri(APIEndpoint),
                fullUri = new Uri(baseUri, apiEndpoint);

            HttpWebRequest request = WebRequest.CreateHttp(fullUri) as HttpWebRequest;
            request.Headers[APIKeyRequestHeader] = this.APIKey;
            request.Headers[HttpRequestHeader.AcceptEncoding] = "deflate, gzip";
            request.Accept = "application/json";

            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            return request;
        }

        private async Task<T> ExecuteRequest<T>(HttpWebRequest request) where T: CoinMarketCapAPIResponse
        {
            HttpWebResponse response;

            try
            {
                response = await request.GetResponseAsync() as HttpWebResponse;
            } catch(WebException ex)
            {
                response = ex.Response as HttpWebResponse;

                switch (response.StatusCode)
                {
                    case (HttpStatusCode)400:
                        throw new WebException("The server could not process the request, likely due to an invalid argument.", ex);
                    case (HttpStatusCode)401:
                        throw new WebException("Your request lacks valid authentication credentials, likely an issue with your API Key.", ex);
                    case (HttpStatusCode)402:
                        throw new WebException("Your API request was rejected due to it being a paid subscription plan with an overdue balance. Pay the balance in the Developer Portal billing tab (https://pro.coinmarketcap.com/account/plan) and it will be enabled.", ex);
                    case (HttpStatusCode)403:
                        throw new WebException("Your request was rejected due to a permission issue, likely a restriction on the API Key's associated service plan. Here is a convenient map (https://pro.coinmarketcap.com/features) of service plans to endpoints.", ex);
                    case (HttpStatusCode)429:
                        throw new WebException("The API Key's rate limit was exceeded; consider slowing down your API Request frequency if this is an HTTP request throttling error. Consider upgrading your service plan if you have reached your monthly API call credit limit for the day/month", ex);
                    case (HttpStatusCode)500:
                        throw new WebException("An unexpected server issue was encountered.", ex);
                    default: throw;
                }
            }

            string responseBody;
            using (StreamReader sr = new StreamReader(response.GetResponseStream()))
            {
                responseBody = await sr.ReadToEndAsync();
            }

            return JsonConvert.DeserializeObject<T>(responseBody);
        }

    }
}
