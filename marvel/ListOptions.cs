using CommandLine;
using CommandLine.Text;
using System;
using System.Collections.Generic;
using System.Text;

namespace marvel
{
	/// <summary>
	/// Command line options for list command.
	/// </summary>
	[Verb("list", HelpText = "Shows the lists of creators with sorting and paging.")]
	class ListOptions : CommonOptions
	{
		[Option('f', "fullname", Required = false, HelpText = "Find creators by full name substring.")]
		public string FullName { get; set; }

		[Option('m', "modifiedsince", Required = false, HelpText = "Find creators modified since the given date.")]
		public string ModifiedSince { get; set; }

		[Option('s', "sortby", Required = false, HelpText = "Fields to sort by.")]
		public IEnumerable<string> Sorting { get; set; }

		[Option('p', "page", Required = false, Default = 0, HelpText = "Page number.")]
		public int Page { get; set; }

		[Option('z', "size", Required = false, Default = 10, HelpText = "Page size.")]
		public int Size { get; set; }

		[Option('n', "shownotes", Required = false, HelpText = "Specifies whether or not to show the note text.")]
		public bool ShowNotes { get; set; }

		[Usage(ApplicationAlias = "marvel")]
		public static IEnumerable<Example> Examples
		{
			get
			{
				yield return new Example("Normal scenario", new ListOptions { });
				yield return new Example("Paging", new ListOptions { Page = 3, Size = 20 });
				yield return new Example("Use modified since filter", new ListOptions { ModifiedSince = new DateTime(2015, 1, 1).ToString(), Page = 2, Size = 20 });
				yield return new Example("Search by full name", new ListOptions { FullName = "rick" });
				yield return new Example("Sorting with paging", new ListOptions { Sorting = new List<String>() { "comicsTotal,desc", "fullName" }, Page = 2, Size = 20 });
				yield return new Example("Provide server url", new FindOptions { Url = "http://192.168.1.8:8080/" });
			}
		}
	}
}
