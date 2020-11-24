using System;
using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.DataContracts;
using Microsoft.ApplicationInsights.Extensibility;

namespace consoleapp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Schau mir in die Augen!");

            var config = TelemetryConfiguration.CreateDefault();
            config.InstrumentationKey = "INSTRUMENTATIONKEY";
            var tc = new TelemetryClient(config);

            // Track traces
            tc.TrackTrace("Campus Console Trace", SeverityLevel.Information);

            tc.Flush();
        }
    }
}
