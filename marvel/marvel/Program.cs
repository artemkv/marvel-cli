using CommandLine;
using System;

namespace marvel
{
	class Program
	{
		static void Main(string[] args)
		{
			Parser.Default.ParseArguments<ListOptions, AddNoteOptions, DeleteNoteOptions>(args)
				.MapResult(
					(ListOptions options) => ListCreators(options),
					(AddNoteOptions options) => AddNote(options),
					(DeleteNoteOptions options) => DeleteNote(options),
					errs => 1);
		}

		static int ListCreators(ListOptions options)
		{
			return ListCommandHandler.Execute(options);
		}

		static int AddNote(AddNoteOptions options)
		{
			Console.WriteLine("add note");

			return 0;
		}

		static int DeleteNote(DeleteNoteOptions options)
		{
			Console.WriteLine("delete note");

			return 0;
		}
	}
}
