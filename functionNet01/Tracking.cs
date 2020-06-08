using System;
using System.Collections.Generic;
using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.DataContracts;

namespace Tracking
{
    public class TrackingService
    {
        private readonly TelemetryClient _telemetryClient = new TelemetryClient();

        public void TrackCustomEvent(string name, string message)
        {
            var dictionary = new Dictionary<string, string>();
            dictionary.Add("message", message);
            dictionary.Add("prop1", "campus prop event");
            _telemetryClient.TrackEvent(name, dictionary);
        }

        public void TrackCustomMetric(string name, double sum)
        {
            var metric = new MetricTelemetry();
            metric.Name = $"{name} Metric";
            metric.Sum = sum;
            _telemetryClient.TrackMetric(metric);
        }
    }
}