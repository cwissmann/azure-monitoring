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
    public static class HttpGet01
    {
        [FunctionName("HttpGet01")]
        public static IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            var trackingService = new TrackingService();
            trackingService.TrackCustomEvent("CampusEvent", "Lorem ipsum from HttpGet01");
            trackingService.TrackCustomMetric("Campus", new Random().NextDouble()*10);

            Thread.Sleep(new Random().Next(1,4) * 1000);

            log.LogInformation("HttpGet01 log information");

            string responseMessage = "Hello Campus";
            return new OkObjectResult(responseMessage);
        }
    }
}
