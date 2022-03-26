using System;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int repeat = 0;
            while(repeat==0)
            {
                Uri uri = new Uri("https://de.search.yahoo.com/search?fr=mcafee&type=E211DE1451G0&p=dotnet+ef+database+update");
                var host = uri.Host;
                Console.WriteLine(host + "/" + GenerateRandomAlphanumericString());
                //Console.WriteLine( GenerateRandomAlphanumericString());
                repeat = Convert.ToInt32( Console.ReadLine());
            }
        }

        public static string GenerateRandomAlphanumericString()
        {
            int length = 5;
            const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

            var random = new Random();
            var randomString = new string(Enumerable.Repeat(chars, length)
                                                    .Select(s => s[random.Next(s.Length)]).ToArray());
            return randomString;
        }
    }
}
