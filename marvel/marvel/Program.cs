using CommandLine;
using System;

namespace marvel
{
	class Program
	{
		static void Main(string[] args)
		{
			Parser.Default.ParseArguments<FindOptions, ListOptions, AddNoteOptions, DeleteNoteOptions>(args)
				.MapResult(
					(FindOptions options) => FindCreator(options),
					(ListOptions options) => ListCreators(options),
					(AddNoteOptions options) => AddNote(options),
					(DeleteNoteOptions options) => DeleteNote(options),
					errs => 1);
		}

		static int FindCreator(FindOptions options)
		{
			return FindCommandHandler.Execute(options);
		}

		static int ListCreators(ListOptions options)
		{
			return ListCommandHandler.Execute(options);
		}

		static int AddNote(AddNoteOptions options)
		{
			return AddNoteCommandHandler.Execute(options);
		}

		static int DeleteNote(DeleteNoteOptions options)
		{
			Console.WriteLine("delete note");

			return 0;
		}
	}
}
