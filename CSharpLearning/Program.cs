using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CSharpLearning
{
	class Program
	{
		private static string baseUrl = "";
		private static HashSet<string> checkedLinks = new HashSet<string>();

		public static void CountWordsOnPageRecursive(string url, int depth = 3)
		{
			string content;

			using (var wc = new System.Net.WebClient())
			{
				try
				{
					content = wc.DownloadString(url);
				}
				catch (Exception exception)
				{
					Console.WriteLine(url + ": " + exception.Message);
					return;
				}
			}

			Console.WriteLine("{0}: {1}", url, Regex.Matches(content, "Game", RegexOptions.IgnoreCase).Count);
			checkedLinks.Add(url);

			if (depth >= 0)
			{
				foreach (Match match in Regex.Matches(content, "href=\"/([^\"#\\?:.]*)[\"#\\?]"))
				{
					var link = baseUrl + match.Groups[1].Value;

					if (!checkedLinks.Contains(link)) CountWordsOnPageRecursive(link, depth - 1);
				}
			}
		}

		static void Main(string[] args)
		{
			DateTime begin = DateTime.UtcNow;
			baseUrl = "http://www.games-academy.de/";
			CountWordsOnPageRecursive(baseUrl);

			DateTime end = DateTime.UtcNow;

			Console.WriteLine("Finished: {0}ms", (end - begin).TotalMilliseconds);
			
			Console.ReadKey();
		}
	}
}
