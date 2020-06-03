using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.DataContracts;
using Tracking;

namespace functionNet01
{
    public static class Time01
    {
        [FunctionName("Time01")]
        public static void Run([TimerTrigger("0 */5 * * * *")]TimerInfo myTimer, ILogger log)
        {
            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");

            var random = new Random().Next(0, 10);

            var tracking = new TrackingService();
            tracking.TrackCustomMetric("Random", random);

            if (random > 6)
            {
                tracking.TrackCustomEvent("ExceptionEvent", $"Random {random} > 6");
                throw new Exception($"Exception thrown in TimeTrigger function; random = {random}");
            }

            tracking.TrackCustomEvent("Time01Event", $"Random {random} <= 6");
        }
    }
}
