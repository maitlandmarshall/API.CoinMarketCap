using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Api.CoinMarketCap.MicroService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Start(args).Wait();
        }

        public static Task Start(string[] args, CancellationToken token = default(CancellationToken)) => CreateWebHostBuilder(args).Build().RunAsync(token);

        internal static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args) 
                .UseStartup<Startup>();
    }
}
