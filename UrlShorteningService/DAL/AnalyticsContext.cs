using System;
using UrlShorteningApi.Models;

namespace UrlShorteningApi.DAL
{
    public interface IAnalyticsContext
    {
        public ShortUrlMap GetById(int id);
        public PreviousDayAnalyticsViewModel Get();

        public bool Save(PreviousDayAnalyticsModel analyticsModel);


    }
    public class AnalyticsContext : IAnalyticsContext
    {
        private readonly SQLDBContext _context;

        public AnalyticsContext(SQLDBContext context)
        {
            _context = context;
        }
        public ShortUrlMap GetById(int id)
        {
            return _context._shortUrlMaps.Find(id);
        }

        public PreviousDayAnalyticsViewModel Get()
        {
            PreviousDayAnalyticsViewModel analyticsViewModel = new PreviousDayAnalyticsViewModel();
            
            DateOnly yesterday = DateOnly.FromDateTime( DateTime.Today.AddDays(-1).Date);
            int totalCount = 0;
            foreach (var previousDayAnalyticsModel in _context._analyticsModel)
            {
                if (previousDayAnalyticsModel.dateOnly == yesterday)
                {
                    Details _details = new Details();
                    _details.dateOnly = previousDayAnalyticsModel.dateOnly;
                    _details.date = previousDayAnalyticsModel.date;
                    _details.longUrl = previousDayAnalyticsModel.longUrl;
                    analyticsViewModel.details.Add(_details);

                    totalCount++;
                }
            }
            analyticsViewModel.totalCount = totalCount;
            return analyticsViewModel;
        }
        

        public bool Save(PreviousDayAnalyticsModel analyticsModel)
        {
            _context._analyticsModel.Add(analyticsModel);
            _context.SaveChanges();

            return true;
        }
    }
}
