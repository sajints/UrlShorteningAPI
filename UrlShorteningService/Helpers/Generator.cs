using System.Text;
using System.Linq;
using System;
using System.Text.RegularExpressions;

namespace UrlShorteningApi.Helpers
{
    public static class Validation
    {
        public static bool ValidateURL(string url)
        {
            string pattern = @"^(http|http(s)?://)?([\w-]+\.)+[\w-]+[.com|.in|.org]+(\[\?%&=]*)?";
            MatchCollection mc = Regex.Matches(url, pattern);
            foreach (Match m in mc)
            {
                Console.WriteLine(m);
            }
            return true;
        }

    }
    
}
