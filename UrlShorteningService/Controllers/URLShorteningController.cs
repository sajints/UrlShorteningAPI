using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UrlShortening.Services;
using UrlShorteningApi.Helpers;
using UrlShorteningApi.Models;

namespace UrlShortening.Controllers
{
    [ApiController]
    //[Route("[controller]")]
    public class URLShorteningController : ControllerBase
    {

        private readonly IUrlShorteningService _service;
        private readonly IAnalyticsService _analticsService;

        public URLShorteningController(IUrlShorteningService service, IAnalyticsService analticsService)
        {
            _service = service;
            _analticsService = analticsService;
        }

        [HttpGet]
        //[ValidateAntiForgeryToken]
        [Route("api/RedirectToLongUrl")]
        public RedirectResult RedirectToLongUrl(string shortUrl)
        {
            if (! (Uri.IsWellFormedUriString(shortUrl, UriKind.Absolute)))
                return null;

            string longUrl = _service.GetLongUrl(shortUrl);

            return Redirect(longUrl);
        }

        [HttpGet]
        //[ValidateAntiForgeryToken]
        [Route("api/GetStatistics")]
        public IActionResult GetStatistics ()
        {
            PreviousDayAnalyticsViewModel previousDayAnalyticsViewModel = _analticsService.Get();

            return Ok(previousDayAnalyticsViewModel);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        [Route("api/Create")]
        public IActionResult Create(string longUrl, string  customShortUrl)
        {
            if (!(Uri.IsWellFormedUriString(longUrl, UriKind.Absolute)))
                return Ok(Messages.wrongInputMessage);
            if (customShortUrl != null && !(Uri.IsWellFormedUriString(customShortUrl, UriKind.Absolute)))
                return Ok(Messages.wrongInputMessage);
            CreateViewModel createViewModel = _service.CreateShortUrl(longUrl, customShortUrl);
            
            return Ok(createViewModel);

        }
    }
}
