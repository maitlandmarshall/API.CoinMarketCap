using API.CoinMarketCap.Response.Info;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace API.CoinMarketCap
{
    public partial class CoinMarketCapAPIClient
    {
        public Task<CryptocurrencyInfoResponse> GetCryptocurrencyInfo(params int[] ids) =>
            this.GetCryptocurrencyInfo(ids, null);

        public Task<CryptocurrencyInfoResponse> GetCryptocurrencyInfo(params string[] symbols) =>
            this.GetCryptocurrencyInfo(null, symbols);

        private Task<CryptocurrencyInfoResponse> GetCryptocurrencyInfo(int[] ids, string[] symbol)
        {
            const string endpoint = "cryptocurrency/info";

            string[] urlParams = new string[1];
            if (ids != null)
            {
                urlParams[0] = $"id={String.Join(",", ids)}";
            } else
            {
                urlParams[0] = $"symbol={String.Join(",", symbol)}";
            }

            return this.ExecuteRequest<CryptocurrencyInfoResponse>(this.CreateWebRequest(endpoint, urlParams));
        }

    }
}
