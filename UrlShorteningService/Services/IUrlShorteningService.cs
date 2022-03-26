using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UrlShorteningApi.Models;

namespace UrlShortening.Services
{
    public interface IUrlShorteningService
    {
        public string GetLongUrl(string shortUrl);
        public CreateViewModel CreateShortUrl(string longUrl, string customShortUrl);

    }
}
