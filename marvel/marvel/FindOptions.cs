using CommandLine;
using System;
using System.Collections.Generic;
using System.Text;

namespace marvel
{
	/// <summary>
	/// Command line options for find command.
	/// </summary>
	[Verb("find", HelpText = "Finds the creator by id.")]
	class FindOptions : CommonOptions
	{
		[Option("id", Required = true, HelpText = "Creator id.")]
		public int Id { get; set; }

		[Option('n', "shownotes", Required = false, HelpText = "Specifies whether or not to show the note text.")]
		public bool ShowNotes { get; set; }
	}
}
