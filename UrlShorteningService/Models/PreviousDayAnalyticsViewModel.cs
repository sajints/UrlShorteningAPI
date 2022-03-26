using System;
using System.Collections.Generic;

namespace UrlShorteningApi.Models
{
    public class PreviousDayAnalyticsViewModel
    {
        public int totalCount { get; set; }
        public IList<Details> details = new List<Details>();
    }

    public class Details
    {
        public DateOnly dateOnly { get; set; }
        public DateTime date { get; set; }
        public string longUrl { get; set; }
    }
}
