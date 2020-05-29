using System;
using System.Collections.Generic;
using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.DataContracts;

namespace Tracking
{
    public class TrackingService
    {
        private readonly TelemetryClient _telemetryClient = new TelemetryClient();

        public void TrackCustomEvent()
        {
            var dictionary = new Dictionary<string, string>();
            dictionary.Add("name", "Campus Event");
            dictionary.Add("prop1", "Lorem ipsum");
            dictionary.Add("prop2", "Lorem ipsum");
            _telemetryClient.TrackEvent("", dictionary);
        }

        public void TrackCustomMetric()
        {
            var metric = new MetricTelemetry();
            metric.Name = "Campus Metric";
            metric.Sum = new Random().NextDouble()*10;
            _telemetryClient.TrackMetric(metric);
        }
    }
}