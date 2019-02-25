using CommandLine;
using CommandLine.Text;
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

		[Usage(ApplicationAlias = "marvel")]
		public static IEnumerable<Example> Examples
		{
			get
			{
				yield return new Example("Normal scenario", new FindOptions { Id = 12976 });
				yield return new Example("Show notes", new FindOptions { Id = 12976, ShowNotes = true });
				yield return new Example("Provide server url", new FindOptions { Url = "http://192.168.1.8:8080/", Id = 12976 });
			}
		}
	}
}
