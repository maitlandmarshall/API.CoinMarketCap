using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Api.CoinMarketCap.MicroService.Client.Tests
{
    [TestClass]
    public class CryptocurrencyControllerTests
    {
        const string microServiceUrl = "https://localhost:5001";
        CoinMarketCapMicroServiceClient client;

        Process microService;

        [TestInitialize]
        public void Initialize()
        {
            this.client = new CoinMarketCapMicroServiceClient(microServiceUrl, new HttpClient());

            string currentDir =  Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "..\\..\\..\\..\\Api.CoinMarketCap.MicroService\\"));
            ProcessStartInfo process = new ProcessStartInfo("dotnet", "run")
            {
                WorkingDirectory = currentDir,
                CreateNoWindow = true,
                UseShellExecute = false,
                RedirectStandardError = true,
                RedirectStandardOutput = true
            };

            this.microService = new Process();
            this.microService.StartInfo = process;
            this.microService.Start();
        }

        [TestCleanup]
        public void Cleanup()
        {
            this.microService.Kill();            
        }

        [TestMethod]
        public async Task InfoTest()
        {
            CryptocurrencyInfoResponse response = await this.client.InfoAsync(null, "eth");
            Assert.IsNotNull(response);

            CryptocurrencyInfo ethInfo;
            if (!response.Data.TryGetValue("ETH", out ethInfo))
                throw new Exception("ETH not found in response");

            Assert.IsTrue(ethInfo.Name.ToLower() == "ethereum");
        }

        [TestMethod]
        public async Task QuotesLatestTest()
        {
            CryptocurrencyQuotesResponse response = await this.client.QuotesLatestAsync(null, "eth", FiatCurrency.AUD);

            CryptocurrencyQuote ethInfo;
            if (!response.Data.TryGetValue("ETH", out ethInfo))
                throw new Exception("ETH not found in response");

            Assert.IsTrue(ethInfo.Quote["AUD"].Price != 0);
        }
    }
}
