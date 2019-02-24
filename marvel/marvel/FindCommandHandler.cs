using marvel.sdk;
using System;
using System.Collections.Generic;
using System.Text;

namespace marvel
{
	/// <summary>
	/// Handles the "find" command.
	/// Retrieves creator by id and prints it's data on the console.
	/// </summary>
	static class FindCommandHandler
	{
		public static int Execute(FindOptions options)
		{
			try
			{
				Creator creator = MarvelApi.GetCreatorAsync(options.Url, options.Id).Result;

				Console.WriteLine(
					"    Id FullName                                           Modified Comics Series");
				Console.WriteLine(
					"--------------------------------------------------------------------------------");
				Console.WriteLine(
					$"{creator.Id,6} {creator.FullName,-30}{creator.Modified,30}{creator.ComicsTotal,6}{creator.SeriesTotal,6}");
				if (options.ShowNotes && creator.Note != null)
				{
					Console.WriteLine($"Note: [{creator.Note.Text}]");
				}

				return 0;
			}
			catch (Exception e)
			{
				Console.WriteLine("Error retrieving creator:");
				Console.WriteLine(e.Message);
				return -1;
			}
		}
	}
}
