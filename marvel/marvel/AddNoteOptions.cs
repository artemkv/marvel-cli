using CommandLine;
using CommandLine.Text;
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

		[Usage(ApplicationAlias = "marvel")]
		public static IEnumerable<Example> Examples
		{
			get
			{
				yield return new Example("Normal scenario", new AddNoteOptions { CreatorId = 12976, NoteText = "Hello note" });
				yield return new Example("Provide server url", new AddNoteOptions { Url = "http://192.168.1.8:8080/api/", CreatorId = 12976, NoteText = "Hello note" });
			}
		}
	}
}
