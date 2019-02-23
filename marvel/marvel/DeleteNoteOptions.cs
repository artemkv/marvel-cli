using CommandLine;
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
		public string CreatorId { get; set; }
	}
}
