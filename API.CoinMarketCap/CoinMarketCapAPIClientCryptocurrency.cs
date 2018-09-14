using API.CoinMarketCap.Response.Info;
using API.CoinMarketCap.Response.Latest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace API.CoinMarketCap
{
    public partial class CoinMarketCapAPIClient
    {
        #region INFO
        public Task<CryptocurrencyInfoResponse> GetCryptocurrencyInfo(params int[] ids) =>
            this.GetCryptocurrencyInfo(ids, null);

        public Task<CryptocurrencyInfoResponse> GetCryptocurrencyInfo(params string[] symbols) =>
            this.GetCryptocurrencyInfo(null, symbols);

        private Task<CryptocurrencyInfoResponse> GetCryptocurrencyInfo(int[] ids, string[] symbols)
        {
            const string endpoint = "cryptocurrency/info";

            string[] urlParams = new string[1];
            if (ids != null)
            {
                urlParams[0] = $"id={String.Join(",", ids)}";
            } else
            {
                urlParams[0] = $"symbol={String.Join(",", symbols)}";
            }

            return this.ExecuteRequest<CryptocurrencyInfoResponse>(this.CreateWebRequest(endpoint, urlParams));
        }
        #endregion

        #region QUOTES / LATEST

        public Task<CryptocurrencyQuotesResponse> GetCryptocurrencyQuotesLatest(int[] ids, FiatCurrency? convert = null) =>
            this.GetCryptocurrencyQuotesLatest(ids, null, convert);

        public Task<CryptocurrencyQuotesResponse> GetCryptocurrencyQuotesLatest(string[] symbols, FiatCurrency? convert = null) =>
            this.GetCryptocurrencyQuotesLatest(null, symbols, convert);

        private Task<CryptocurrencyQuotesResponse> GetCryptocurrencyQuotesLatest(int[] ids, string[] symbols, FiatCurrency? convert)
        {
            const string endpoint = "cryptocurrency/quotes/latest";

            string[] urlParams = new string[2];
            if (ids != null)
            {
                urlParams[0] = $"id={String.Join(",", ids)}";
            }
            else
            {
                urlParams[0] = $"symbol={String.Join(",", symbols)}";
            }

            if (convert.HasValue)
            {
                urlParams[1] = $"convert={convert.Value.ToString()}";
            }

            return this.ExecuteRequest<CryptocurrencyQuotesResponse>(this.CreateWebRequest(endpoint, urlParams));
        }

        #endregion
    }
}
