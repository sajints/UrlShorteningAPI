using UrlShorteningApi.Models;

namespace UrlShortening.Services
{
    public interface IAnalyticsService
    {
        PreviousDayAnalyticsViewModel Get();
        bool Save(string longUrl);
    }
}
