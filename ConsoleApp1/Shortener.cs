using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
	public class NixURL
	{
		public Guid ID { get; set; }
		public string URL { get; set; }
		public string ShortenedURL { get; set; }
		public string Token { get; set; }
		public int Clicked { get; set; } = 0;
		public DateTime Created { get; set; } = DateTime.Now;
	}

	public class Shortener
	{
		//public string Token { get; set; }
		//private NixURL biturl;
		// The method with which we generate the token
		private string GenerateToken()
		{
			string urlsafe = string.Empty;
			Enumerable.Range(48, 75)
			  .Where(i => i < 58 || i > 64 && i < 91 || i > 96)
			  .OrderBy(o => new Random().Next())
			  .ToList()
			  .ForEach(i => urlsafe += Convert.ToChar(i)); // Store each char into urlsafe
			string Token = urlsafe.Substring(new Random().Next(0, urlsafe.Length), new Random().Next(2, 6));
			return urlsafe;
		}

		public Shortener(string url)
		{

		}
	}
}
