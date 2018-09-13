using API.CoinMarketCap.Response.Info;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace API.CoinMarketCap.Tests
{
    [TestClass]
    public class CryptocurrencyEndpointTests : IEndpointTest
    {
        CoinMarketCapAPIClient client;

        public CryptocurrencyEndpointTests()
        {
            this.client = new CoinMarketCapAPIClient("61663324-40cb-43c7-9c0f-9528051771eb");
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
            Assert.IsTrue(singleResult.Data[0].Symbol.ToLower() == "btc");

            CryptocurrencyInfoResponse multiResult = await this.client.GetCryptocurrencyInfo("BTC", "ETH");
            Assert.IsTrue(multiResult.Data.Count == 2);
            Assert.IsTrue(multiResult.Data[1].Symbol.ToLower() == "eth");
        }

        public Task Latest()
        {
            throw new NotImplementedException();
        }

        public Task Map()
        {
            throw new NotImplementedException();
        }
    }
}
