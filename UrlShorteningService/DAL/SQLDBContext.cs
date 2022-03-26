using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UrlShortening;
using UrlShorteningApi.Models;

namespace UrlShorteningApi.DAL
{
    public class SQLDBContext: DbContext
    {
    public SQLDBContext(DbContextOptions options) : base(options)
    {

    }

    public DbSet<ShortUrlMap> _shortUrlMaps { get; set; }
    public DbSet<PreviousDayAnalyticsModel> _analyticsModel { get; set; }

    }
}
