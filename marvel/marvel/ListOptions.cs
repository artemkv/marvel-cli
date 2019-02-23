using CommandLine;
using CommandLine.Text;
using System;
using System.Collections.Generic;
using System.Text;

namespace marvel
{
	[Verb("list", HelpText = "Shows the lists of creators.")]
	class ListOptions
	{
		[Option('f', "fullname", Required = false, HelpText = "Find creator by exact full name match.")]
		public string FullName { get; set; }

		[Option('m', "modifiedsince", Required = false, HelpText = "Find creators modified since the given date.")]
		public string ModifiedSince { get; set; }

		[Option('s', "sortby", Required = false, HelpText = "Fields to sort by.")]
		public IEnumerable<string> Sorting { get; set; }
	}
}
