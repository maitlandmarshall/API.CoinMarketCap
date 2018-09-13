using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace API.CoinMarketCap.Tests
{
    public interface IEndpointTest
    {
        Task Historical();
        Task Info();
        Task Latest();
        Task Map();
    }
}
