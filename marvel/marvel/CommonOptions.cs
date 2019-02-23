using CommandLine;
using System;
using System.Collections.Generic;
using System.Text;

namespace marvel
{
	/// <summary>
	/// Command line options common for all commands.
	/// </summary>
	class CommonOptions
	{
		[Option("url", Required = false,
			Default = "http://localhost:8080/api/",
			HelpText = "Url to use for connection.")]
		public string Url { get; set; }
	}
}
