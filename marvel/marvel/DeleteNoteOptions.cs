using CommandLine;
using System;
using System.Collections.Generic;
using System.Text;

namespace marvel
{
	[Verb("deletenote", HelpText = "Deletes a note for a creator.")]
	class DeleteNoteOptions
	{
		[Option('c', "creatorid", Required = true, HelpText = "Creator id to delete note for.")]
		public string CreatorId { get; set; }
	}
}
