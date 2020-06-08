using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace webApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly TelemetryClient _telemetryClient;

        public IndexModel(ILogger<IndexModel> logger, TelemetryClient telemetryClient)
        {
            _logger = logger;
            _telemetryClient = telemetryClient;
        }

        public void OnGet()
        {
            var pageView = new PageViewTelemetry("Index");
            _telemetryClient.TrackPageView(pageView);
        }
    }
}
