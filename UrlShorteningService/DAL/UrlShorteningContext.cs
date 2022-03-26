using UrlShorteningApi.Models;

namespace UrlShorteningApi.DAL
{
    public interface IUrlShorteningContext
    {
        ShortUrlMap GetById(int id);
        string GetByShortUrl(string shortUrl);
        int Save(ShortUrlMap shortUrlMap);
        bool GetByToken(string token);
        string GetByLongUrl(string longUrl);


    }

    public class UrlShorteningContext : IUrlShorteningContext
    {
        private readonly SQLDBContext _context;

        public UrlShorteningContext(SQLDBContext context)
        {
            _context = context;
        }
        public ShortUrlMap GetById(int id)
        {
            return _context._shortUrlMaps.Find(id);
        }

        public string GetByShortUrl(string shortUrl)
        {
            foreach (var shortUrlMap in _context._shortUrlMaps)
            {
                if (shortUrlMap.shortUrl == shortUrl)
                {
                    return shortUrlMap.longUrl;
                }
            }
            return null;
        }

        public string GetByLongUrl(string longUrl)
        {
            foreach (var shortUrlMap in _context._shortUrlMaps)
            {
                if (shortUrlMap.longUrl == longUrl)
                {
                    return shortUrlMap.shortUrl;
                }
            }
            return "";
        }

        public bool GetByToken(string token)
        {
            foreach (var shortUrlMap in _context._shortUrlMaps)
            {
                if (shortUrlMap.token == token)
                {
                    return true;
                }
            }
            return false;
        }
        public int Save(ShortUrlMap shortUrlMap)
        {
            _context._shortUrlMaps.Add(shortUrlMap);
            _context.SaveChanges();

            return shortUrlMap.Id;
        }
    }
}
