using CommandLine;
using System;
using System.Collections.Generic;
using System.Text;

namespace marvel
{
	/// <summary>
	/// Command line options for add note command.
	/// </summary>
	[Verb("addnote", HelpText = "Adds a note to a creator. If note already exists, overwrites it.")]
	class AddNoteOptions : CommonOptions
	{
		[Option('c', "creatorid", Required = true, HelpText = "Creator id to add note to.")]
		public int CreatorId { get; set; }

		[Option('t', "text", Required = true, HelpText = "Note text.")]
		public string NoteText { get; set; }
	}
}
