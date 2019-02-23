using CommandLine;
using System;
using System.Collections.Generic;
using System.Text;

namespace marvel
{
	[Verb("addnote", HelpText = "Adds a note to a creator. If note already exists, overwrites it.")]
	class AddNoteOptions
	{
		[Option('c', "creatorid", Required = true, HelpText = "Creator id to add note to.")]
		public string CreatorId { get; set; }

		[Option('t', "text", Required = true, HelpText = "Note text.")]
		public string NoteText { get; set; }
	}
}
