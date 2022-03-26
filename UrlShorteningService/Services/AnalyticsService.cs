using UrlShorteningApi.DAL;
using UrlShorteningApi.Models;
using System;
namespace UrlShortening.Services
{
    public class AnalyticsService : IAnalyticsService
    {
        private readonly IAnalyticsContext _context;

        public AnalyticsService(IAnalyticsContext context)
        {
            _context = context;
        }
        public PreviousDayAnalyticsViewModel Get()
        {
            return _context.Get();
        }

        public bool Save(string longUrl)
        {
            PreviousDayAnalyticsModel model = new PreviousDayAnalyticsModel();
            model.dateOnly = DateOnly.FromDateTime(DateTime.Today);
            model.date = DateTime.Now;
            model.longUrl = longUrl;
            _context.Save(model);
            return true;
        }
    }
}
