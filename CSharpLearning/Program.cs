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

		public static async Task CountWordsOnPageRecursive(string url, int depth = 3)
		{
			string content;

			using (var hc = new System.Net.Http.HttpClient())
			{
				try
				{
					content = await hc.GetStringAsync(url);
				}
				catch (Exception exception)
				{
					Console.WriteLine(url + ": " + exception.Message);
					return;
				}
			}

			Console.WriteLine("{2} -> {0}: {1}", url, Regex.Matches(content, "Game", RegexOptions.IgnoreCase).Count, depth);

			if (depth >= 0)
			{
				List<Task> tasks = new List<Task>();

				foreach (Match match in Regex.Matches(content, "href=\"/([^\"#\\?:.]*)[\"#\\?]"))
				{
					var link = baseUrl + match.Groups[1].Value;

					lock (checkedLinks)
					{
						if (checkedLinks.Contains(link) || link.Contains("node")) continue;
						checkedLinks.Add(link);
					}

					tasks.Add(Task.Run(() => CountWordsOnPageRecursive(link, depth - 1)));
				}

				await Task.WhenAll(tasks.ToArray());
			}
		}

		static void Main(string[] args)
		{
			DateTime begin = DateTime.UtcNow;
			baseUrl = "https://www.games-academy.de/";
			checkedLinks.Add(baseUrl);

			CountWordsOnPageRecursive(baseUrl).Wait();

			DateTime end = DateTime.UtcNow;
			Console.WriteLine("Finished: {0}ms", (end - begin).TotalMilliseconds);

			Console.ReadKey();
		}
	}
}
