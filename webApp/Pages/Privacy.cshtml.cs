using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace webApp.Pages
{
    public class PrivacyModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;
        private readonly TelemetryClient _telemetryClient;

        public PrivacyModel(ILogger<PrivacyModel> logger, TelemetryClient telemetryClient)
        {
            _logger = logger;
            _telemetryClient = telemetryClient;
        }

        public void OnGet()
        {
            var pageView = new PageViewTelemetry("Privacy");
            _telemetryClient.TrackPageView(pageView);
        }
    }
}
