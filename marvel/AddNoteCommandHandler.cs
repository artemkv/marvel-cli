using marvel.sdk;
using System;
using System.Collections.Generic;
using System.Text;

namespace marvel
{
	/// <summary>
	/// Handles the "addnote" command.
	/// Adds note to a creator with given id.
	/// </summary>
	static class AddNoteCommandHandler
	{
		public static int Execute(AddNoteOptions options)
		{
			try
			{
				MarvelApi.AddNoteAsync(options.Url, options.CreatorId, options.NoteText).Wait();
				return 0;
			}
			catch (Exception e)
			{
				Console.WriteLine("Error adding note:");
				Console.WriteLine(e.Message);
				return -1;
			}
		}
	}
}
