using CommandLine;
using CommandLine.Text;
using System;
using System.Collections.Generic;
using System.Text;

namespace marvel
{
	/// <summary>
	/// Command line options for delete note command.
	/// </summary>
	[Verb("deletenote", HelpText = "Deletes a note for a creator.")]
	class DeleteNoteOptions : CommonOptions
	{
		[Option('c', "creatorid", Required = true, HelpText = "Creator id to delete note for.")]
		public int CreatorId { get; set; }

		[Usage(ApplicationAlias = "marvel")]
		public static IEnumerable<Example> Examples
		{
			get
			{
				yield return new Example("Normal scenario", new DeleteNoteOptions { CreatorId = 12976 });
				yield return new Example("Provide server url", new DeleteNoteOptions { Url = "http://192.168.1.8:8080/", CreatorId = 12976 });
			}
		}
	}
}
