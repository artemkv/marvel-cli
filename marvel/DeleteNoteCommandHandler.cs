using marvel.sdk;
using System;
using System.Collections.Generic;
using System.Text;

namespace marvel
{
	/// <summary>
	/// Handles the "deletenote" command.
	/// Deletes note for a creator with given id.
	/// </summary>
	static class DeleteNoteCommandHandler
	{
		public static int Execute(DeleteNoteOptions options)
		{
			try
			{
				MarvelApi.DeleteNoteAsync(options.Url, options.CreatorId).Wait();
				return 0;
			}
			catch (Exception e)
			{
				Console.WriteLine("Error deleting note:");
				Console.WriteLine(e.Message);
				return -1;
			}
		}
	}
}
