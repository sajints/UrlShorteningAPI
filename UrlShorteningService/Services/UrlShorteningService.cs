using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UrlShorteningApi.DAL;
using UrlShortening;
using System.Web.Http.ModelBinding;
using UrlShorteningApi.Models;
using UrlShorteningApi.Helpers;

namespace UrlShortening.Services
{
    public class UrlShorteningService : IUrlShorteningService
    {
        private readonly IUrlShorteningContext _context;
        private readonly IAnalyticsService _analyticsService;


        public UrlShorteningService(IUrlShorteningContext context, IAnalyticsService analyticsService) //
        {
            _context = context;
            _analyticsService = analyticsService;
        }
        public string GetLongUrl(string shortUrl)
        {
            string longUrl = _context.GetByShortUrl(shortUrl);
            _analyticsService.Save(longUrl);
            return longUrl;
        }
        public CreateViewModel CreateShortUrl(string longUrl, string customShortUrl)
        {
            string _token = string.Empty;
            string _shortUrl = string.Empty;
            CreateViewModel vm = IsLongUrlExisting(longUrl);
            if (vm != null)
            {
                return vm;
            }

            if (customShortUrl == null)
            {
                bool isExisting = true;
                while(!isExisting)
                { 
                    _token = RandomHelper.GenerateRandomAlphanumericString();
                    isExisting = _context.GetByToken(_token);
                }
                Uri uri = new Uri(longUrl);
                var host = uri.Host;
                int protocollength = longUrl.IndexOf("://", 0);
                var protocol = longUrl.Substring (0, protocollength +3) ;

                _shortUrl = protocol + host + "/" + _token;
            }
            else
            {
                Uri uri = new Uri(customShortUrl);
                var host = uri.Host;
                int hostlength = customShortUrl.IndexOf(host, 0);
                string hostSubString = customShortUrl.Substring(hostlength);
                int withoutProtocol = hostSubString.IndexOf("/",0);
                string token = hostSubString.Substring(withoutProtocol + 1);
                if(token.Length != 5)
                { 
                    return new CreateViewModel
                    {
                        message = Messages.wrongInputMessage,
                        status = false,
                        shortUrl = customShortUrl
                    };
                }
                _shortUrl = customShortUrl;
            }

            string _message = "Added successfully!";
            bool _status = true;
            var shortUrlMap = new ShortUrlMap
            {
                longUrl = longUrl,
                shortUrl = _shortUrl,
                token = _token

            };

            try
            {
                _context.Save(shortUrlMap);
            }
            catch(Exception ex)
            {
                _message = ex.Message;
                _status = false;
            }
            var createViewModel = new CreateViewModel
            {
                message = _message,
                status = _status,
                shortUrl = _shortUrl
            };
            
            return createViewModel;
        }

        private CreateViewModel IsLongUrlExisting(string longUrl)
        {
            string shortUrl = _context.GetByLongUrl(longUrl);
            if ( shortUrl != "")
            { 
                var createViewModel = new CreateViewModel
                {
                    message = Messages.longUrlExistingMessage,
                    status = false,
                    shortUrl = shortUrl
                };
                return createViewModel;
            }
            return null;
        }
    }
}
