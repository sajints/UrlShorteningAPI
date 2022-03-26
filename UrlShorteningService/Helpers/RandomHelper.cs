using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UrlShortening.Services
{
    public static class RandomHelper
    {
        public static string GenerateRandomAlphanumericString()
        {
            int length = 6;
            const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

            var random = new Random();
            var randomString = new string(Enumerable.Repeat(chars, length)
                                                    .Select(s => s[random.Next(s.Length)]).ToArray());
            return randomString;
        }
    }
}
