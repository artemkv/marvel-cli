using marvel.sdk;
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
				DateTime? modifiedSince = null;
				if (!String.IsNullOrEmpty(options.ModifiedSince))
				{
					// Parses using the same rules as when printing date to screen.
					// This should allow you to copy-paste date from the output directly to the command line,
					// whatever locale you are in.
					modifiedSince = DateTime.Parse(options.ModifiedSince);
				}
				GetCreatorsResponse response = MarvelApi.GetCreatorsAsync(
					options.Url,
					options.FullName,
					modifiedSince,
					options.Page,
					options.Size,
					options.Sorting).Result;
				Console.WriteLine($"Page number: {response.PageNumber}");
				Console.WriteLine($"Page size: {response.PageSize}");
				Console.WriteLine($"Showing {response.Count} of total {response.Total} results.");
				Console.WriteLine();
				Console.WriteLine(
					"    Id FullName                                           Modified Comics Series");
				Console.WriteLine(
					"--------------------------------------------------------------------------------");
				foreach (var creator in response.Creators)
				{
					Console.WriteLine(
						$"{creator.Id,6} {creator.FullName,-30}{creator.Modified,30}{creator.ComicsTotal,6}{creator.SeriesTotal,6}");
					if (options.ShowNotes && creator.Note != null)
					{
						Console.WriteLine($"Note: [{creator.Note.Text}]");
					}
				}

				return 0;
			}
			catch (Exception e)
			{
				Console.WriteLine("Error retrieving creators:");
				Console.WriteLine(e.Message);
				return -1;
			}
		}
	}
}
