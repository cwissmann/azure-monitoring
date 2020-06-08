using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Tracking;

namespace functionNet01
{
    public static class HttpGet02
    {
        [FunctionName("HttpGet02")]
        public static IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            var trackingService = new TrackingService();
            trackingService.TrackCustomEvent("CampusEvent", "Lorem ipsum from HttpGet02");
            
            var sleepingTime = new Random().Next(4,8) * 1000;
            trackingService.TrackCustomMetric("HttpGet02 Duration", sleepingTime);
            Thread.Sleep(sleepingTime);

            log.LogInformation("HttpGet02 log information");

            string responseMessage = $"Hello Campus; SleepingTime: {sleepingTime/1000}s";
            return new OkObjectResult(responseMessage);
        }
    }
}
