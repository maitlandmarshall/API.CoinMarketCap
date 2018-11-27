using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.CoinMarketCap.MicroService.Filters
{
    public class CacheForAttribute : Attribute, IAsyncActionFilter
    {
        private int CacheTimeMiliseconds { get; set; }
        private Dictionary<string, (DateTime lastExecuted, IActionResult result)> Cache { get; set; }

        public CacheForAttribute(int miliseconds)
        {
            this.CacheTimeMiliseconds = miliseconds;
            this.Cache = new Dictionary<string, (DateTime lastExecuted, IActionResult result)>();
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            string path = $"{context.HttpContext.Request.Path}{context.HttpContext.Request.QueryString}";
            (DateTime lastExecuted, IActionResult result) cacheItem;

            if (this.Cache.TryGetValue(path, out cacheItem))
            {
                // if the cache has expired
                if (DateTime.Now >= cacheItem.lastExecuted.AddMilliseconds(this.CacheTimeMiliseconds))
                {
                    this.Cache.Remove(path);
                } else
                {
                    context.Result = cacheItem.result;
                    return;
                }
            }

            ActionExecutedContext resultContext = await next();

            if (resultContext.Exception == null)
                this.Cache.Add(path, (DateTime.Now, resultContext.Result));
        }
    }


}
