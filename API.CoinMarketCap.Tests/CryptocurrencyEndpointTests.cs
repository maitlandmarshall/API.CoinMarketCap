using Api.CoinMarketCap.Response.Info;
using Api.CoinMarketCap.Response.Quotes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Api.CoinMarketCap.Tests
{
    [TestClass]
    public class CryptocurrencyEndpointTests
    {
        CoinMarketCapApiClient client;

        public CryptocurrencyEndpointTests()
        {
            this.client = new CoinMarketCapApiClient("61663324-40cb-43c7-9c0f-9528051771eb");
        }

        public Task Historical()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public async Task Info()
        {
            CryptocurrencyInfoResponse singleResult = await this.client.GetCryptocurrencyInfo("BTC");
            Assert.IsTrue(singleResult.Data.Count == 1);
            Assert.IsTrue(singleResult.Data["BTC"].Symbol.ToLower() == "btc");

            CryptocurrencyInfoResponse multiResult = await this.client.GetCryptocurrencyInfo("BTC", "ETH");
            Assert.IsTrue(multiResult.Data.Count == 2);
            Assert.IsTrue(multiResult.Data["ETH"].Symbol.ToLower() == "eth");
        }

        [TestMethod]
        public async Task QuotesLatest()
        {
            CryptocurrencyQuotesResponse singleResult = await this.client.GetCryptocurrencyQuotesLatest(new string[] { "BTC" });
            Assert.IsTrue(singleResult.Data.Count == 1);
            Assert.IsTrue(singleResult.Data["BTC"].Symbol.ToLower() == "btc");
            Assert.IsNotNull(singleResult.Data["BTC"].Quote[FiatCurrency.USD.ToString()]);

            CryptocurrencyQuotesResponse multiResult = await this.client.GetCryptocurrencyQuotesLatest(new string[] { "BTC", "ETH" }, FiatCurrency.AUD);
            Assert.IsTrue(multiResult.Data.Count == 2);
            Assert.IsTrue(multiResult.Data["ETH"].Symbol.ToLower() == "eth");
        }

        [TestMethod]
        public async Task QuotesLatestConvertCurrency()
        {
            CryptocurrencyQuotesResponse singleResult = await this.client.GetCryptocurrencyQuotesLatest(new string[] {"ETH" }, FiatCurrency.AUD);
            Assert.IsTrue(singleResult.Data.Count == 1);
            Assert.IsTrue(singleResult.Data["ETH"].Symbol.ToLower() == "eth");
            Assert.IsNotNull(singleResult.Data["ETH"].Quote[FiatCurrency.AUD.ToString()]);

            CryptocurrencyQuotesResponse multiResult = await this.client.GetCryptocurrencyQuotesLatest(new string[] { "XRP", "ETH" });
            Assert.IsTrue(multiResult.Data.Count == 2);
            Assert.IsTrue(multiResult.Data["ETH"].Symbol.ToLower() == "eth");
            Assert.IsNotNull(multiResult.Data["ETH"].Quote[FiatCurrency.USD.ToString()]);
        }

        public Task Map()
        {
            throw new NotImplementedException();
        }
    }
}
