using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace marvel
{
	/// <summary>
	/// Handles the "list" command.
	/// Retrieves the list of creators and prints them on the console.
	/// </summary>
	static class ListCommandHandler
	{
		public static int Execute(ListOptions options)
		{
			try
			{
				// TODO: use options to construct the url
				GetCreatorsResponse response = GetResponseAsync(options.Url).Result;
				Console.WriteLine($"Page number: {response.PageNumber}");
				Console.WriteLine($"Page size: {response.PageSize}");
				Console.WriteLine($"Showing {response.Count} of total {response.Total} results.");
				Console.WriteLine();
				Console.WriteLine(
					"    Id FullName                                            Modified Comics Series");
				Console.WriteLine(
					"---------------------------------------------------------------------------------");
				foreach (var creator in response.Creators)
				{
					Console.WriteLine(
						$"{creator.Id,6} {creator.FullName,-30}{creator.Modified,30}{creator.ComicsTotal,6}{creator.SeriesTotal,6}");
				}

				return 0;
			}
			catch (HttpRequestException e)
			{
				Console.WriteLine("Error retrieving creators:");
				Console.WriteLine(e.Message);
				return -1;
			}
		}

		private static async Task<GetCreatorsResponse> GetResponseAsync(String url)
		{
			var response = await HttpClientProvider.HttpClient.GetAsync(url);

			if (response.IsSuccessStatusCode)
			{
				var results = JsonConvert.DeserializeObject<GetCreatorsResponse>(await response.Content.ReadAsStringAsync());
				return results;
			}

			throw new HttpRequestException(((int)response.StatusCode).ToString() + " " + response.ReasonPhrase);
		}
	}
}
