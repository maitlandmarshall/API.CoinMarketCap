using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.CoinMarketCap.MicroService.Filters;
using Api.CoinMarketCap.Response.Info;
using Api.CoinMarketCap.Response.Quotes;
using Microsoft.AspNetCore.Mvc;

namespace Api.CoinMarketCap.MicroService.Controllers
{
    [Route("v1/[controller]/[action]")]
    [ApiController]
    public class CryptocurrencyController : ControllerBase
    {
        CoinMarketCapApiClient api;

        public CryptocurrencyController(CoinMarketCapApiClient api)
        {
            this.api = api;
        }

        [HttpGet]
        [CacheFor(100 * 60 * 1000)] // 100 minutes
        public async Task<ActionResult<CryptocurrencyInfoResponse>> Info(string ids = null, string symbols = null)
        {
            if (String.IsNullOrEmpty(ids) && String.IsNullOrEmpty(symbols))
                throw new Exception("Must supply at least one parameter");

            if (!String.IsNullOrEmpty(ids) && !String.IsNullOrEmpty(symbols))
                throw new Exception("Only one parameter can be used at a time");

            if (!String.IsNullOrEmpty(ids))
            {
                int[] idArray = ids.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(y => int.Parse(y.Trim())).ToArray();
                return await this.api.GetCryptocurrencyInfo(idArray);
            } else
            {
                string[] symbolArray = symbols.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(y => y.Trim().ToUpper()).ToArray();
                return await this.api.GetCryptocurrencyInfo(symbolArray);
            }
        }

        [HttpGet("quotes/latest")]
        [CacheFor(60 * 1000)] // 60 seconds
        public async Task<ActionResult<CryptocurrencyQuotesResponse>> QuotesLatest(string ids = null, string symbols = null, FiatCurrency? convert = null)
        {
            if (String.IsNullOrEmpty(ids) && String.IsNullOrEmpty(symbols))
                throw new Exception("Must supply at least one parameter");

            if (!String.IsNullOrEmpty(ids) && !String.IsNullOrEmpty(symbols))
                throw new Exception("Only one parameter can be used at a time");

            if (!String.IsNullOrEmpty(ids))
            {
                int[] idArray = ids.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(y => int.Parse(y.Trim())).ToArray();
                return await this.api.GetCryptocurrencyQuotesLatest(idArray, convert);
            }
            else
            {
                string[] symbolArray = symbols.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(y => y.Trim().ToUpper()).ToArray();
                return await this.api.GetCryptocurrencyQuotesLatest(symbolArray, convert);
            }
        }


    }
}
